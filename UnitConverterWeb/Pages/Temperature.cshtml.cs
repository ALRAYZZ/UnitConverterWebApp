using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using UnitConverterWeb.Models;
using UnitConverterWeb.Services;

namespace UnitConverterWeb.Pages
{
    public class TemperatureModel : PageModel
    {
		private readonly UnitConverterService _conversionService;
		private readonly ILogger<TemperatureModel> _logger;

		[BindProperty]
		public TempConversionModel TempConversionModel { get; set; }
		public double? convertedValue { get; set; } = null;
		public double? originalValue { get; set; } = null;
		public string OriginalUnitMesure { get; set; }
		public string ResultUnitMesure { get; set; }

		public TemperatureModel(ILogger<TemperatureModel> logger, UnitConverterService conversionService)
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
				OriginalUnitMesure = TempConversionModel.OriginalUnitAbbreviation;
				ResultUnitMesure = TempConversionModel.ResultUnitAbbreviation;
				originalValue = TempConversionModel.Temperature;
				convertedValue = _conversionService.ConvertTemperature(TempConversionModel.Temperature, TempConversionModel.OriginalUnit, TempConversionModel.ResultUnit);
			}
			return Page();
		}
	}
}
