using Microsoft.AspNetCore.Mvc;
using PhoneShopASPnet.Data;

namespace PhoneShopASPnet.Controllers.Components
{
    [ViewComponent(Name = "_SearchSide")]
    public class _SearchSideViewComponent : ViewComponent
    {
        private readonly PhoneShopASPnetContext _context;
        public _SearchSideViewComponent(PhoneShopASPnetContext context)
        {
            _context = context;
        }
        public IViewComponentResult Invoke()
        {
            return View(_context.Category.ToList());
        }
    }
}
