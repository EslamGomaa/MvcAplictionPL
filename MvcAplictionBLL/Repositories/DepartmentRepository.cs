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
    public class DepartmentRepository : GenericRepository<Department>,  IDepartmentRepository 
    {
        public DepartmentRepository(ApplicationDbContext dbContext) :base(dbContext)
        {
            
        }

    }
}
