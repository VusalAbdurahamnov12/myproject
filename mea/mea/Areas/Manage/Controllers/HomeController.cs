using mea.DAL;
using mea.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace mea.Areas.Manage.Controllers
{
    [Area("Manage")]
    public class HomeController : Controller
    {
        public AppDbContext _contex { get; }
        public HomeController(AppDbContext context)
        {
            _contex = context;
        }


        public async Task <IActionResult> Index()
        {
            return View(await _contex.Categories.ToListAsync());
        }
        public async Task<IActionResult> Create( )
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Category category)
        {
            if (category != null)
            {
                await _contex.Categories.AddAsync(category);
                await _contex.SaveChangesAsync();
            return RedirectToAction("Index");
            }
            return View(category);
        }
        public async Task<IActionResult> Delete(int id)
        {
            if (id!=null)
            {
                var wildeleted = await  _contex.Categories.FindAsync(id);
                _contex.Categories.Remove(wildeleted);
                await _contex.SaveChangesAsync();
            }
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> Update(int id)
        {
            Category category = await _contex.Categories.FindAsync(id);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Update(Category category)
        {
            Category mydb = await _contex.Categories.FirstOrDefaultAsync(x => x.Id == category.Id);
            if (mydb == null) return NotFound();
            mydb.Name=category.Name;
            return View();
        }
    }
}
