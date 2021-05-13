using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EkibimizDB.Models;
using EkibimizDB.ViewModels;

namespace EkibimizDB.Controllers
{
    public class EmployeeGroupBySalaryViewModelsController : Controller
    {
        private readonly EkibimizDbContext _context;

        public EmployeeGroupBySalaryViewModelsController(EkibimizDbContext context)
        {
            _context = context;
        }

        // GET: EmployeeGroupBySalaryViewModels
        [Route("/maas-dagilimi",Name ="Maaş Dağılımı")]
        public IActionResult Index()
        {
            List<EmployeeGroupBySalaryViewModel> list = _context.Employees.GroupBy(e => e.Salary).Select(e => new EmployeeGroupBySalaryViewModel { Salary = e.Key, EmployeeCount = e.Count() }).ToList();
            return View( list);
        }

      
        // GET: EmployeeGroupBySalaryViewModels/Details/5
        public IActionResult Details(double? salary)
        {
           
            return RedirectToAction("List","ekibimiz", new {@id=salary});
        }

       

        private bool EmployeeGroupBySalaryViewModelExists(double id)
        {
            return _context.EmployeeGroupBySalaryViewModel.Any(e => e.Salary == id);
        }
    }
}
