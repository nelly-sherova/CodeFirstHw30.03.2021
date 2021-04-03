using codeFirstHW.Db;
using codeFirstHW.Models;
using codeFirstHW.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace codeFirstHW.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly DataContext _dataContext;

        public CategoryController(ILogger<HomeController> logger, DataContext dataContext)
        {
            _logger = logger;
            _dataContext = dataContext;
        }

        public async Task<IActionResult> Index()
        {
            var list = await _dataContext.Categories.ToListAsync();
            return View(list);
        }


        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Category model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            _dataContext.Categories.Add(new Models.Category() { Name = model.Name });

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

            var rez = await _dataContext.Categories.FindAsync(id);

            if (rez == null)
            {
                return RedirectToAction("Index");
            }
            return View(new CategoryViewModul()
            {
                Id = rez.Id,
                Name = rez.Name,
            });
        }

        [HttpPost]
        public async Task<IActionResult> Edit(CategoryViewModul model)
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
            var rez = _dataContext.Categories.Find(id);
            if (rez == null)
            {
                return RedirectToAction("Index");
            }
            _dataContext.Categories.Remove(rez);
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
