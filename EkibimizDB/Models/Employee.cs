using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace EkibimizDB.Models
{
    public enum PositionTypes
    {
        [Display(Name ="Yazılım Geliştirici")] Developer,
        [Display(Name ="Veritabanı Yöneticisi")]DatabaseAdministrator,
        [Display(Name = "Sistem Yöneticisi")] Administrator,
        [Display(Name = "Arayüz Tasarımcısı")] FrontEndDeveloper,
        [Display(Name = "Test Uzmanı")] Tester
    }
    public class Employee
    {
        [Key]
        [Display(Name ="ID")]
        public int EmployeeID { get; set; }

        [Required]
        [Display(Name ="Adı")]
        [StringLength(50)]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Soyadı")]
        [StringLength(50)]
        public string LastName { get; set; }

        [Display(Name ="Görevi")]
        [Required]
        public PositionTypes Position { get; set; }

        [Display(Name ="Maaşı")]
        [Required]
        public double Salary { get; set; }

        [DataType(DataType.EmailAddress)]
        [Required]
        [Display(Name ="E-posta Adresi")]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [Display(Name ="İşe Giriş Tarihi")]
        public DateTime DateJoined { get; set; }

        [DataType(DataType.MultilineText)]
        [StringLength(250)]
        [Display(Name ="Notlarım")]
        public string Notes { get; set; }
    }
}
