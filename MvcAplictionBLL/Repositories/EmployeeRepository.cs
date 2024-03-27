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
    public class EmployeeRepository : GenericRepository<Employee>, IEmployeeRepository
    {
        

        public EmployeeRepository(ApplicationDbContext dbContext) :base(dbContext)
        {
            
            
        }
        public IQueryable<Employee> GetEmployyByAddrss(string addrss)
        {

            return _dbContext .Employees.Where(E=>E.Address.ToLower() == addrss.ToLower());
        }
    }
}
