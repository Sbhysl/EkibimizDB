using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EkibimizDB.ViewModels
{
    public class EmployeeGroupBySalaryViewModel
    {
        [Key]
        [DataType(DataType.Currency)]
        [Display(Name ="Maaş TL")]
        public double Salary { get; set; }

        [Display(Name ="")]
        public int EmployeeCount { get; set; }
    }
}
