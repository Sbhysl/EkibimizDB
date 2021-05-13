using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EkibimizDB.Models;
using PagedList.Core;

namespace EkibimizDB.Controllers
{
    public class EmployeesController : Controller
    {
        private readonly EkibimizDbContext _context;

        public EmployeesController(EkibimizDbContext context)
        {
            _context = context;
        }
        [Route("/ekibimiz/list/{id:double}")]
        public IActionResult List(double id)
        {
            var employees = from e in _context.Employees
                            where e.Salary == id
                            select e;

            return View(employees);
        }

        // GET: Employees
        [Route("/ekibimiz")]
        public IActionResult Index(string searchString, string sortOrder, string currentFilter,int? page)
        {

            var employees = from e in _context.Employees
                            select e;
            //select new { e.EmployeeID, e.FirstName, e.LastName, e.Position, e.Email, e.DateJoined };
            if (!String.IsNullOrEmpty(searchString))
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }
            ViewBag.CurrentFilter = searchString;
            if (!String.IsNullOrEmpty(searchString))
            {
                employees = employees.Where(a => a.FirstName.Contains(searchString) || a.LastName.Contains(searchString)|| a.Email.Contains(searchString));
            }
          
            ViewBag.FirstNameSortOrder = "FirstNameAsc";
            ViewBag.LastNameSortOrder = "LastNameAsc";
            ViewBag.PositionSortOrder = "PositionAsc";
            ViewBag.EmailSortOrder = "EmailAsc";

            if (String.IsNullOrEmpty(sortOrder))
            {
                sortOrder = "";//default parametre ekledik
            }

            switch (sortOrder)
            {
                case "FirstNameAsc":
                    ViewBag.FirstNameSortOrder = "FirstNameDesc";
                    employees = employees.OrderBy(e => e.FirstName);
                    break;
                case "FirstNameDesc":
                    ViewBag.FirstNameSortOrder = "FirstNameAsc";
                    employees = employees.OrderByDescending(e => e.FirstName);
                    break;
                case "LastNameAsc":
                    ViewBag.LastNameSortOrder = "LastNameDesc";
                    employees = employees.OrderBy(e => e.LastName);
                    break;
                case "LastNameDesc":
                    ViewBag.LastNameSortOrder = "LastNameAsc";
                    employees = employees.OrderByDescending(e => e.LastName);
                    break;
                case "PositionAsc":
                    ViewBag.PositionSortOrder = "PositionDesc";
                    employees = employees.OrderBy(e => e.Position);
                    break;
                case "PositionDesc":
                    ViewBag.PositionSortOrder = "PositionAsc";
                    employees = employees.OrderByDescending(e => e.Position);
                    break;
                case "EmailAsc":
                    ViewBag.EmailSortOrder = "EmailDesc";
                    employees = employees.OrderBy(e => e.Email);
                    break;
                case "EmailDesc":
                    ViewBag.EmailSortOrder = "EmailAsc";
                    employees = employees.OrderByDescending(e => e.Email);
                    break;

                default:
                    employees = employees.OrderBy(e => e.EmployeeID);
                    break;
            }
            int pageSize = 3;//sayfada kaç eleman olacak
            int pageNumber = (page ?? 1);
            return View( employees.ToPagedList(pageNumber,pageSize));
        }

        // GET: Employees/Details/5
        [Route("ekibimiz/detay/{id:int}/{slug}")]
        public async Task<IActionResult> Details(int? id, string slug)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employee = await _context.Employees
                .FirstOrDefaultAsync(m => m.EmployeeID == id);
            if (employee == null)
            {
                return NotFound();
            }

            return View(employee);
        }

        // GET: Employees/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Employees/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("EmployeeID,FirstName,LastName,Position,Salary,Email,DateJoined,Notes")] Employee employee)
        {
            if (ModelState.IsValid)
            {
                _context.Add(employee);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(employee);
        }

        // GET: Employees/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employee = await _context.Employees.FindAsync(id);
            if (employee == null)
            {
                return NotFound();
            }
            return View(employee);
        }

        // POST: Employees/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("EmployeeID,FirstName,LastName,Position,Salary,Email,DateJoined,Notes")] Employee employee)
        {
            if (id != employee.EmployeeID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(employee);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EmployeeExists(employee.EmployeeID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(employee);
        }

        // GET: Employees/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employee = await _context.Employees
                .FirstOrDefaultAsync(m => m.EmployeeID == id);
            if (employee == null)
            {
                return NotFound();
            }

            return View(employee);
        }

        // POST: Employees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var employee = await _context.Employees.FindAsync(id);
            _context.Employees.Remove(employee);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EmployeeExists(int id)
        {
            return _context.Employees.Any(e => e.EmployeeID == id);
        }

        public IActionResult JsonList()
        {
            return Json(_context.Employees.ToList());
        }

        [Route("/ekibimiz/DateList/{*dateJoined}")]
        public IActionResult DateList(string dateJoined)
        {
            var employees = from e in _context.Employees
                            where e.DateJoined == DateTime.Parse(dateJoined)
                            select e;

            return View(employees);
        }
    }
}
