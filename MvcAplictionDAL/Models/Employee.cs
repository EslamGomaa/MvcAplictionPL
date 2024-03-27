using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace MvcAplictionDAL.Models
{
    public enum Gender
    {
        Male = 1,
        Female = 2,

    }  public enum EmpType
    {
        FullTime = 1,
        PartTime = 2,

    }

    public class Employee :ModelBase
    {
        
        [Required]
        [MaxLength(50)]
        [MinLength(5)]

        public string Name { get; set; }
        [Range(22, 30)]
        public int? Age { get; set; }
        public string Address { get; set; }
        [Display(Name = "Is Active ")]
        public decimal? Salary { get; set; }
        public bool IsActive { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }

        public DateTime HiringDate { get; set; }
        public Gender Gender { get; set; }
        public EmpType EmpType { get; set; }

        public DateTime CreationDate { get; set; }
        public bool IsDeleted { get; set; }

    }
}
