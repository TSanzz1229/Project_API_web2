using Microsoft.AspNetCore.Mvc;
using PhoneShopASPnet.Data;

namespace PhoneShopASPnet.Controllers.Components
{
	[ViewComponent(Name = "_BrandSide")]
	public class _BrandSideViewComponent : ViewComponent
	{
		private readonly PhoneShopASPnetContext _context;
		public _BrandSideViewComponent(PhoneShopASPnetContext context)
		{
			_context = context;
		}
		public IViewComponentResult Invoke()
		{
			var _brand = _context.Brand.ToList();
			return View("_BrandSide",_brand);
		}
	}
}
