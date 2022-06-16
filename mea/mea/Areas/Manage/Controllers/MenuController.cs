using mea.DAL;
using mea.Models;
using mea.ViewModel;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace mea.Areas.Manage.Controllers
{
    [Area("Manage")]
    public class MenuController : Controller
    {
        public AppDbContext _contex { get; }

        private readonly IWebHostEnvironment _hostEnvironment;

        public MenuController(AppDbContext context, IWebHostEnvironment hostEnvironment)
        {
            _contex = context;
            _hostEnvironment = hostEnvironment;
        }
        public async Task <IActionResult> Index()
        {
            HomeVM homeVM = new HomeVM 
            { 
                Categories = await _contex.Categories.ToListAsync(),
                Menus = await _contex.Menus.ToListAsync(),
            };
            return View(homeVM);
        }
        public async Task<IActionResult> Create()
        {
            ViewBag.Categories = new SelectList(_contex.Categories,nameof(Category.Id),nameof(Category.Name));
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Menu menu)
        {
            string uniqueFileName = null;
            if (menu.Photo != null)
            {
                string uploadsFolder = Path.Combine(_hostEnvironment.WebRootPath, "assets","image");
                uniqueFileName = Guid.NewGuid().ToString() + "_" + menu.Photo.FileName;
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    menu.Photo.CopyTo(fileStream);
                }
            }
            Menu menus = new Menu
            {
                Name = menu.Name,
                Image= uniqueFileName,
                Category= menu.Category,
                CategoryId= menu.CategoryId,
                Description= menu.Description,
                Price= menu.Price

            };
            await _contex.AddAsync(menus);
            await _contex.SaveChangesAsync();
            ViewBag.Categories = new SelectList(_contex.Categories, nameof(Category.Id), nameof(Category.Name));
            return View();
        }
    }
}
