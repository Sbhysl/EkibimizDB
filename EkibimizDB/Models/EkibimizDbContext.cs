using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EkibimizDB.ViewModels;

namespace EkibimizDB.Models
{
    public class EkibimizDbContext: DbContext
    {
        public EkibimizDbContext(DbContextOptions<EkibimizDbContext> options):base(options)
        {

        }

        public DbSet<Employee> Employees { get; set; }

        public DbSet<EkibimizDB.ViewModels.EmployeeGroupBySalaryViewModel> EmployeeGroupBySalaryViewModel { get; set; }

        public DbSet<EkibimizDB.ViewModels.EmployeeGroupByDateJoinedViewModel> EmployeeGroupByDateJoinedViewModel { get; set; }

    }
}
