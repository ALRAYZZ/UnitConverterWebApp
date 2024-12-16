using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using UnitConverterWeb.Models;
using UnitConverterWeb.Services;

namespace UnitConverterWeb.Pages;

public class WeightModel : PageModel
{
	private readonly UnitConverterService _conversionService;
	private readonly ILogger<WeightModel> _logger;

	[BindProperty]
	public WeightConversionModel WeightConversionModel { get; set; }
	public double? convertedValue { get; set; } = null;
	public double? originalValue { get; set; } = null;
	public string OriginalUnitMesure { get; set; }
	public string ResultUnitMesure { get; set; }

	public WeightModel(ILogger<WeightModel> logger, UnitConverterService conversionService)
	{
		_logger = logger;
		_conversionService = conversionService;
	}

	public void OnGet()
    {
    }
	public IActionResult OnPost()
	{
		if (ModelState.IsValid)
		{
			OriginalUnitMesure = WeightConversionModel.OriginalUnitAbbreviation;
			ResultUnitMesure = WeightConversionModel.ResultUnitAbbreviation;
			originalValue = WeightConversionModel.Weight;
			convertedValue = _conversionService.ConvertWeight(WeightConversionModel.Weight, WeightConversionModel.OriginalUnit, WeightConversionModel.ResultUnit);
		}
		return Page();
	}
}
