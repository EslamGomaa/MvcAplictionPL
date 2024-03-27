using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using MvcAplictionBLL.Interfaces;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.Hosting;
using MvcAplictionDAL.Models;
using MvcAplictionBLL.Repositories;
using System;

namespace MvcAplictionPL.Controllers
{
    public class EmployeeController : Controller
    {

        private IEmployeeRepository _employeesRepo;
        private readonly IWebHostEnvironment _env;

        public EmployeeController(IEmployeeRepository employeesRepo, IWebHostEnvironment env)  // Ask clr for creating an object from class implamenting 
        {
            _employeesRepo = employeesRepo;
            _env = env;
        }
        public IActionResult Index()
        {
            var employees = _employeesRepo.GetAll();
            return View(employees);
        }
        [HttpGet]
        public IActionResult Create()
        {

            return View();
        }
        [HttpPost]
        public IActionResult Create(Employee employees)
        {
            if (ModelState.IsValid)
            {
                var count = _employeesRepo.Add(employees);
                if (count > 0)
                {
                    return RedirectToAction(nameof(Index));
                }
            }


            return View(employees);
        }
        public IActionResult Details(int? id, string viewName = "Details")
        {
            if (!id.HasValue)
            {
                return BadRequest();

            }
            var employees = _employeesRepo.Get(id.Value);
            if (employees == null)
            {
                return NotFound();
            }
            return View(viewName, employees);


        }
        [HttpGet]
        public IActionResult Edit(int? id)
        {
            return Details(id, "Edit");
            //if (!id.HasValue)
            //{
            //    return BadRequest();

            //}
            //var employees = _employeesRepo.Get(id.Value);
            //if (employees == null)
            //{
            //    return NotFound();
            //}
            //return View(employees);


        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit([FromRoute] int id, Employee employees)
        {
            if (id != employees.Id)
                return BadRequest();
            if (!ModelState.IsValid)
            {
                return View(employees);

            }
            try
            {
                _employeesRepo.Update(employees);
                return RedirectToAction(nameof(Index));

            }
            catch (Exception ex)
            {
                if (_env.IsDevelopment())

                    ModelState.AddModelError(string.Empty, ex.Message);


                else
                    ModelState.AddModelError(string.Empty, "Error During the Update Department ");
            }
            return View(employees);

        }
        [HttpGet]
        public IActionResult Delete(int? id)
        {
            return Details(id, "Delete");

        }
        [HttpPost]
        public IActionResult Delete(Employee employees)
        {
            try
            {
                _employeesRepo.Delete(employees);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                if (_env.IsDevelopment())

                    ModelState.AddModelError(string.Empty, ex.Message);


                else
                    ModelState.AddModelError(string.Empty, "Error During the Update Department ");
            }
            return View(employees);
        }

    }
}
