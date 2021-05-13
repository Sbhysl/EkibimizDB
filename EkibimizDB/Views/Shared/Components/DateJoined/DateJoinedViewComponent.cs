using EkibimizDB.Models;
using EkibimizDB.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EkibimizDB.Views.Shared.Components.DateJoined
{
    public class DateJoinedViewComponent:ViewComponent
    {
        private readonly EkibimizDbContext _contex;

        public DateJoinedViewComponent(EkibimizDbContext context)
        {
            _contex = context;
        }

        public IViewComponentResult Invoke()
        {
            List<EmployeeGroupByDateJoinedViewModel> list = _contex.Employees.GroupBy(e => e.DateJoined).Select(e => new EmployeeGroupByDateJoinedViewModel 
            { DateJoined = e.Key,
             EmployeeCount = e.Count() }).ToList();

            return View(list);
        }
    }
}
