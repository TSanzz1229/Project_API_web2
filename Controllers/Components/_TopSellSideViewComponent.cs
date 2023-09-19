using Microsoft.AspNetCore.Mvc;
using PhoneShopASPnet.Data;

namespace PhoneShopASPnet.Controllers.Components
{
	[ViewComponent(Name = "_TopSellSide")]
	public class _TopSellSideViewComponent : ViewComponent
	{
		private readonly PhoneShopASPnetContext _context;

		public _TopSellSideViewComponent(PhoneShopASPnetContext context)
		{
			_context = context;
		}
		public IViewComponentResult Invoke()
		{
			var _product = _context.Product.ToList();
			return View("_TopSellSide", _product);
		}
	}
}
