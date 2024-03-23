using Microsoft.AspNetCore.Mvc;
using MvcAplictionBLL.Interfaces;
using MvcAplictionBLL.Repositories;

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
    }
}
