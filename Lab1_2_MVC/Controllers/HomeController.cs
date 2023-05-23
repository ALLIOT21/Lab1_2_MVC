using Lab1_2_MVC.Data;
using Lab1_2_MVC.Data.Entities;
using Lab1_2_MVC.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel;
using System.Diagnostics;
using System.Reflection;

namespace Lab1_2_MVC.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger,
            ApplicationDbContext dbContext)
        {
            _logger = logger;
            _dbContext = dbContext;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var model = new IndexModel
            {
                Persons = _dbContext.Persons.ToList(),
            };
            ViewData["Genders"] = GetGendersSelectList();
            return View(model);
        }

        [HttpPost]
        public IActionResult Create(IndexModel model)
        {
            _dbContext.Add(model.Person);
            _dbContext.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        private List<SelectListItem> GetGendersSelectList()
        {
            var genders = new List<SelectListItem>();
            foreach (var item in Enum.GetValues(typeof(Gender)))
            {
                FieldInfo fi = item.GetType().GetField(item.ToString());
                DescriptionAttribute[] attributes = fi.GetCustomAttributes(typeof(DescriptionAttribute), false) as DescriptionAttribute[];
                genders.Add(new SelectListItem
                {
                    Value = item.ToString(),
                    Text = attributes.First().Description,
                });
            }
            return genders;
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}