using ActivityTracker.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace ActivityTracker.Controllers
{
	public class HomeController : Controller
	{
		private readonly ILogger<HomeController> _logger;
		private readonly ApplicationDbContext _context;

		public HomeController(ILogger<HomeController> logger, ApplicationDbContext context)
		{
			_logger = logger;
			_context = context;
		}

		public IActionResult Index()
		{
			var actvities = _context.Activities.ToList();
			return View(actvities);
		}

		public IActionResult Privacy()
		{
			return View();
		}

		public IActionResult Create(ActivityTracker.Models.Activity activity)
		{
			if (ModelState.IsValid)
			{
				_context.Activities.Add(activity);
				_context.SaveChanges();
				return RedirectToAction(nameof(Index));
			}
			return View(activity);
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = System.Diagnostics.Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}
