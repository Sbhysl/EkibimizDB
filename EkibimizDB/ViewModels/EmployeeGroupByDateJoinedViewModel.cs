using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EkibimizDB.ViewModels
{
    public class EmployeeGroupByDateJoinedViewModel
    {
        [Key]
        [DataType(DataType.Date)]
        [Display(Name ="İşe Giriş Tarihi")]
        public DateTime DateJoined { get; set; }

        [Display(Name ="Çalışan Sayısı")]
        public int EmployeeCount { get; set; }

    }
}
