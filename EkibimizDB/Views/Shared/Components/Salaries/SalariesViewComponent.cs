using EkibimizDB.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EkibimizDB.ViewModels;

namespace EkibimizDB.Views.Shared.Components.Salaries
{
    public class SalariesViewComponent:ViewComponent
    {
        private readonly EkibimizDbContext _contex;

        public SalariesViewComponent(EkibimizDbContext context)
        {
            _contex = context;
        }

        public IViewComponentResult Invoke()
        {
            List<EmployeeGroupBySalaryViewModel> list = _contex.Employees.GroupBy(e => e.Salary).Select(e => new EmployeeGroupBySalaryViewModel { Salary = e.Key, EmployeeCount = e.Count() }).ToList();

            return View(list);
        }

    }
}
