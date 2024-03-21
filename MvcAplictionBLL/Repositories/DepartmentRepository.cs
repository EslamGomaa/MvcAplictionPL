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
    public class DepartmentRepository : IDepartmentRepository
    {
        private readonly ApplicationDbContext _dbContext;
        public DepartmentRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public int Add(Department entity)
        {
            _dbContext.Department.Add(entity);
            return _dbContext.SaveChanges();
        }

        public int Delete(Department entity)
        {
             _dbContext.Department.Remove(entity);
            return _dbContext.SaveChanges();

        }

        public Department Get(int id)
        {
            //var department = _dbContext.Department.Where(D=>D.Id == id).FirstOrDefault();
            return _dbContext.Department.Find(id);
        }

        public IEnumerable<Department> GetAll()
        {
            return _dbContext.Department.AsNoTracking().ToList();
        }

        public int Update(Department entity)
        {
            _dbContext.Department.Update(entity);
            return _dbContext.SaveChanges();


        }
    }
}
