using Microsoft.AspNetCore.Mvc;
using PhoneShopASPnet.Data;

namespace PhoneShopASPnet.Controllers.Components
{
    [ViewComponent(Name = "_CategorySide")]
    public class _CategorySideViewComponent : ViewComponent
    {

        private readonly PhoneShopASPnetContext _context;
        public _CategorySideViewComponent(PhoneShopASPnetContext context)
        {
            _context = context;
        }
        public IViewComponentResult Invoke()
        {
            var _category = _context.Category.ToList();
            return View("_CategorySide", _category);
        }
    }
}
