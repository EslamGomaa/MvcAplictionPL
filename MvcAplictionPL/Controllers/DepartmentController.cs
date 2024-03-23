using Microsoft.AspNetCore.Mvc;
using MvcAplictionBLL.Interfaces;
using MvcAplictionBLL.Repositories;
using MvcAplictionDAL.Models;

namespace MvcAplictionPL.Controllers
{
    public class DepartmentController : Controller
    {
        private IDepartmentRepository _departmentsRepo;
        public DepartmentController(IDepartmentRepository departmentsRepo)  // Ask clr for creating an object from class implamenting 
        {
            _departmentsRepo = departmentsRepo;

        }
        public IActionResult Index()
        {
            var departments = _departmentsRepo.GetAll();
            return View(departments);
        }
        [HttpGet]
        public IActionResult Create()
        {
            
            return View();
        }
        [HttpPost]
        public IActionResult Create(Department department)
        {
            if(ModelState.IsValid)
            { 
                var count =_departmentsRepo.Add(department);
                if(count > 0)
                {
                    return RedirectToAction(nameof(Index ));
                }
            }


            return View(department);
        }
    }
}
