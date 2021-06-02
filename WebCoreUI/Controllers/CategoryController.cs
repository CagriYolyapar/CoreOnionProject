using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Project.BLL.ManagerServices.Abstracts;
using Project.ENTITIES.Models;
using WebCoreUI.VMClasses;

namespace WebCoreUI.Controllers
{
    public class CategoryController : Controller
    {
        ICategoryManager _icm;

        public CategoryController(ICategoryManager icm)
        {
            _icm = icm;
        }


        public IActionResult CategoryList()
        {

            CategoryVM cvm = new CategoryVM
            {
                Categories = _icm.GetAll()
            };
            
            return View(cvm);
        }

        public IActionResult AddCategory()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddCategory(Category category)
        {
            TempData["message"] = _icm.Add(category);
            return RedirectToAction("AddCategory");
        }
    }
}
