using Microsoft.Extensions.Options;
using System.ComponentModel.DataAnnotations;

namespace UnitConverterWeb.Models;

public class TempConversionModel : IValidatableObject
{
	private static readonly Dictionary<string, string> UnitAbbreviation = new()
		{
			{ "celsius", "°C" },
			{ "fahrenheit", "°F" },
		};
	private static readonly Dictionary<string, string> UnitsAllowed = new()
		{
			{ "celsius", "Celsius" },
			{ "fahrenheit", "Fahrenheit" },
		};
	[Required]
	public float Temperature { get; set; }
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
