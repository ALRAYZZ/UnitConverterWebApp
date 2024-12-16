using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using UnitConverterWeb.Models;
using UnitConverterWeb.Services;

namespace UnitConverterWeb.Pages
{
    public class IndexModel : PageModel
    {
        
        private readonly UnitConverterService _conversionService;
		private readonly ILogger<IndexModel> _logger;

		[BindProperty]
		public LengthConversionModel LengthConversionModel { get; set; }
		public double? convertedValue { get; set; } = null;
		public double? originalValue { get; set; } = null;
		public string OriginalUnitMesure { get; set; }
		public string ResultUnitMesure { get; set; }

		public IndexModel(ILogger<IndexModel> logger, UnitConverterService conversionService)
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
				OriginalUnitMesure = LengthConversionModel.OriginalUnitAbbreviation;
				ResultUnitMesure = LengthConversionModel.ResultUnitAbbreviation;
				originalValue = LengthConversionModel.Length;
				convertedValue = _conversionService.ConvertLength(LengthConversionModel.Length, LengthConversionModel.OriginalUnit, LengthConversionModel.ResultUnit);
			}
			return Page();
		}
    }
}
