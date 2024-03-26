﻿using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.Hosting;
using MvcAplictionBLL.Interfaces;
using MvcAplictionBLL.Repositories;
using MvcAplictionDAL.Models;
using System;

namespace MvcAplictionPL.Controllers
{
    public class DepartmentController : Controller
    {
        private IDepartmentRepository _departmentsRepo;
        private readonly IWebHostEnvironment _env;

        public DepartmentController(IDepartmentRepository departmentsRepo ,IWebHostEnvironment env )  // Ask clr for creating an object from class implamenting 
        {
            _departmentsRepo = departmentsRepo;
            _env = env;
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
        public IActionResult Details(int? id ,string viewName= "Details")
        {
            if (!id.HasValue)
            {
                return BadRequest();

            }
            var department = _departmentsRepo.Get(id.Value);    
            if(department == null) { 
                return NotFound ();
            }
            return View(viewName, department);


        }
        [HttpGet]
        public IActionResult Edit(int? id)
        {
            return Details(id ,"Edit");
            //if (!id.HasValue)
            //{
            //    return BadRequest();

            //}
            //var department = _departmentsRepo.Get(id.Value);
            //if (department == null)
            //{
            //    return NotFound();
            //}
            //return View(department);


        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit([FromRoute]int id,Department department)
        {
            if(id!= department.Id) 
                return BadRequest ();
           if (!ModelState.IsValid)
            {
                return View(department);

            }
            try
            {
                _departmentsRepo.Update(department);
                return RedirectToAction(nameof(Index));

            }
            catch (Exception ex)
            {
                if(_env.IsDevelopment())

                    ModelState.AddModelError(string.Empty, ex.Message);


                else 
                    ModelState.AddModelError(string.Empty, "Error During the Update Department "); 
            }
            return View(department);

        }
        [HttpGet]
        public IActionResult Delete(int? id)
        {
            return Details(id, "Delete");

        }
        [HttpPost]
        public IActionResult Delete (Department department)
        {
            try
            {
                _departmentsRepo.Delete(department);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                if (_env.IsDevelopment())

                    ModelState.AddModelError(string.Empty, ex.Message);


                else
                    ModelState.AddModelError(string.Empty, "Error During the Update Department ");
            }
            return View(department);
        }




    }
}
