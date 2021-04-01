using codeFirstHW.Db;
using codeFirstHW.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace codeFirstHW.Controllers
{
    public class ProductController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly DataContext _dataContext;

        public ProductController(ILogger<HomeController> logger, DataContext dataContext)
        {
            _dataContext = dataContext;
            _logger = logger;

        }
        [HttpGet]
        public async Task<IActionResult> Index(string category)
        {
            List<Product> lst = new List<Product>();
            if (category == null)
            {
                lst = await _dataContext.Products.ToListAsync();
            }
            else
            {
                lst = await _dataContext.Products.Where(p => p.Category.Name.Equals(category)).ToListAsync();
            }
            return View(lst);
        }



        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var rez = await _dataContext.Categories.ToListAsync();

            return View(new Product()
            {
                Categories = rez.Select(p => new SelectListItem { Text = p.Name, Value = p.Id.ToString() }).ToList()
            });
        }

        [HttpPost]
        public async Task<IActionResult> Create(Product model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            _dataContext.Products.Add(new Product()
            {
                Name = model.Name,
                Price = model.Price,
                CategoryId = model.CategoryId
            });

            await _dataContext.SaveChangesAsync();

            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            if (id <= 0)
            {
                return RedirectToAction("Index");
            }

            var rez = await _dataContext.Products.FindAsync(id);

            if (rez == null)
            {
                return RedirectToAction("Index");
            }
            return View(new Product()
            {
                Id = rez.Id,
                Name = rez.Name,
                Price = rez.Price,
                Categories = await _dataContext.Categories.Select(p => new SelectListItem { Text = p.Name, Value = p.Id.ToString() }).ToListAsync()
            });
        }
        [HttpPost]
        public async Task<IActionResult> Edit(Category model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var rez = _dataContext.Categories.Find(model.Id);
            if (rez == null)
            {
                return RedirectToAction("Index");
            }

            rez.Name = model.Name;
            await _dataContext.SaveChangesAsync();

            return RedirectToAction("Index");
        }


        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            if (id <= 0)
            {
                return RedirectToAction("Index");
            }
            var rez = _dataContext.Products.Find(id);
            if (rez == null)
            {
                return RedirectToAction("Index");
            }
            _dataContext.Products.Remove(rez);
            await _dataContext.SaveChangesAsync();
            return RedirectToAction("Index");
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

    }
}
