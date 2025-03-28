using Microsoft.AspNetCore.Mvc;

using RestuarantList.Models;

using Microsoft.EntityFrameworkCore;
using RestuarantList.Data;

namespace RestuarantList.Controllers
{
    public class RestuarantList : Controller
    {

        private readonly RestuarantListContext _context;

        public RestuarantList(RestuarantListContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index(string searchString)
        {
            var restuarants = from r in _context.Restuarants
                              select r;
            if (!string.IsNullOrEmpty(searchString))
            {
                restuarants = restuarants.Where(r => r.Name.Contains(searchString));
            }
            return View(await _context.Restuarants.ToListAsync());
        }

        public async Task<IActionResult> Details(int? id)
        {
            var restuarant = await _context.Restuarants
                .Include(rd => rd.RestuarantDishes)
                .ThenInclude(d => d.Dish)
                .FirstOrDefaultAsync(x => x.Id == id);

            if (restuarant == null)
            {
                return NotFound();
            }

            return View(restuarant);
        }


        public IActionResult Random()
        {
            return Content("Hello Asp.Net");
        }
        //public IActionResult Index()
        //{
        //    return View();
        //}
    }
}
