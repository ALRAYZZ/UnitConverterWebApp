using System.ComponentModel.DataAnnotations;

namespace UnitConverterWeb.Models
{
	public class WeightConversionModel : IValidatableObject
	{
		private static readonly Dictionary<string, string> UnitAbbreviation = new()
		{
			{ "kilograms", "kg" },
			{ "pounds", "lb" },
		};
		private static readonly Dictionary<string, string> UnitsAllowed = new()
		{
			{ "kilograms", "Kilograms" },
			{ "pounds", "Pounds" },
		};
		[Required]
		public double Weight { get; set; }
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
