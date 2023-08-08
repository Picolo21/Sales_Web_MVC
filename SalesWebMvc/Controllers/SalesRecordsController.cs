using Microsoft.AspNetCore.Mvc;
using SalesWebMvc.Services;

namespace SalesWebMvc.Controllers
{
	public class SalesRecordsController : Controller
	{
		private readonly SalesRecordService _salesRecordService;

        public SalesRecordsController(SalesRecordService salesRecordService)
        {
			_salesRecordService = salesRecordService;
        }
        public IActionResult Index()
		{
			return View();
		}

		public async Task<IActionResult> SimpleSearch(DateTime? initialDate, DateTime? finalDate)
		{
			if (!initialDate.HasValue)
				initialDate = new DateTime(DateTime.Now.Year, 1, 1);

			if (!finalDate.HasValue)
				finalDate = DateTime.Now;

			ViewData["initialDate"] = initialDate.Value.ToString("yyyy/MM/dd");
			ViewData["finalDate"] = finalDate.Value.ToString("yyyy/MM/dd");

			var result = await _salesRecordService.FindByDateAsync(initialDate, finalDate);
			return View(result);
		}

		public IActionResult GroupingSearch()
		{
			return View();
		}
	}
}
