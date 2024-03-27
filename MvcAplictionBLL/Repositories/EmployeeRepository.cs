using Microsoft.EntityFrameworkCore;
using MvcAplictionBLL.Interfaces;
using MvcAplictionDAL.Data;
using MvcAplictionDAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvcAplictionBLL.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly ApplicationDbContext _dbContext;
        public EmployeeRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public int Add(Employee entity)
        {
            _dbContext.Employees.Add(entity);
            return _dbContext.SaveChanges();
        }

     

        public int Delete(Employee entity)
        {
            _dbContext.Employees.Remove(entity);
            return _dbContext.SaveChanges();

        }


        public Employee Get(int id)
        {
            //var Employee = _dbContext.Employee.Where(D=>D.Id == id).FirstOrDefault();
            return _dbContext.Employees.Find(id);
        }

        public IEnumerable<Employee> GetAll()
        {
            return _dbContext.Employees.AsNoTracking().ToList();
        }

        public int Update(Employee entity)
        {
            _dbContext.Employees.Update(entity);
            return _dbContext.SaveChanges();


        }

      

      
    }
}
