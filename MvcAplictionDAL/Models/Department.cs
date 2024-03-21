using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvcAplictionDAL.Models
{
    internal class Department
    {
        public int Id { get; set; }
        // null the option type in c#  5.0
        [Required(ErrorMessage ="Code is Required ya Eslam !!!")]
        public string  Code  { get; set; }

        public string Name { get; set; }
        public DateTime DateOfCreation { get; set; } 
            
    }
}
