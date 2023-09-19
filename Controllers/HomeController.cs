using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PhoneShopASPnet.Data;
using PhoneShopASPnet.Models;
using System.Diagnostics;

namespace PhoneShopASPnet.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
		private readonly PhoneShopASPnetContext _context;

		public HomeController(ILogger<HomeController> logger , PhoneShopASPnetContext context)
        {
            _logger = logger;
			_context = context;
		}

        public IActionResult Index()
        {
			var _product  = _context.Product.Include(p => p.Brand).Include(p => p.Category);
			return View(_product.ToList());
        }
  
	}
}