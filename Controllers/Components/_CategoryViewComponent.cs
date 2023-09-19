using Microsoft.AspNetCore.Mvc;
using PhoneShopASPnet.Data;

namespace PhoneShopASPnet.Controllers.Components
{
    [ViewComponent(Name = "_Category")]
    public class _CategoryViewComponent : ViewComponent
    {
        private readonly PhoneShopASPnetContext _context;

        public _CategoryViewComponent(PhoneShopASPnetContext context)
        {
            _context = context;
        }
        public IViewComponentResult Invoke()
        {
            var _category = _context.Category.ToList();
            return View("_Category", _category);
        }
    }
}
