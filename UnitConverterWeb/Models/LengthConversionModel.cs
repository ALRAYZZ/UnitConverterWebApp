using System.ComponentModel.DataAnnotations;

namespace UnitConverterWeb.Models
{
	public class LengthConversionModel : IValidatableObject
	{
		private static readonly Dictionary<string, string> UnitAbbreviation = new()
		{
			{ "meters", "m" },
			{ "feets", "ft" },
		};
		private static readonly Dictionary<string, string> UnitsAllowed = new()
		{
			{ "meters", "Meters" },
			{ "feets", "Feets" },
		};
		[Required]
		public double Length { get; set; }
		[Required]
		public string OriginalUnit { get; set; }
		[Required]
		public string ResultUnit { get; set; }
		public string OriginalUnitAbbreviation => GetUnitAbbreviation(OriginalUnit);
		public string ResultUnitAbbreviation => GetUnitAbbreviation(ResultUnit);



		private string GetUnitAbbreviation(string unit)
		{
			return UnitAbbreviation.TryGetValue(unit.ToLower(), out var abbreviation) ? abbreviation : unit;
		}
		public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
		{
			if (!UnitsAllowed.ContainsKey(OriginalUnit.ToLower()))
			{
				yield return new ValidationResult("Invalid unit name", new[] { nameof(OriginalUnit) });
			}
			if (!UnitsAllowed.ContainsKey(ResultUnit.ToLower()))
			{
				yield return new ValidationResult("Invalid unit name", new[] { nameof(ResultUnit) });
			}
		}
	}
}
