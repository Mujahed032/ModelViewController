using Employees_Mujahed.Data;
using Employees_Mujahed.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Employees_Mujahed.Controllers
{
    public class EmployeeMujahed : Controller
    {
        private readonly DataContext _context;

        public EmployeeMujahed(DataContext context)
        {
            _context = context;
        }

        public IActionResult Empty()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(EmployeesMujahed Login)
        {
            var employee = new EmployeesMujahed()
            {
                Id = Guid.NewGuid(),
                Name = Login.Name,
                Email = Login.Email,
                
            };
            await _context.employeeMujaheds.AddAsync(employee);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var employee = await _context.employeeMujaheds.ToListAsync();
            return View(employee);
        }

        [HttpGet]
        public IActionResult Add()
        {
         
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddMujahed AddNewEmployee)
        {
            var employee = new EmployeesMujahed()
            {
                Id = Guid.NewGuid(),
                Name = AddNewEmployee.Name,
                Email = AddNewEmployee.Email,
                Salary = AddNewEmployee.Salary,
                DateOfBirth = AddNewEmployee.DateOfBirth,
                Designation = AddNewEmployee.Designation
            };
            await _context.employeeMujaheds.AddAsync(employee);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Edit(Guid Id)
        {
            var employee = await _context.employeeMujaheds.FirstOrDefaultAsync(x => x.Id == Id);
            if (employee != null)
            {
                var viewmodel = new EditMujahed()
                {
                    Id = Guid.NewGuid(),
                    Name = employee.Name,
                    Email = employee.Email,
                    Salary = employee.Salary,
                    DateOfBirth = employee.DateOfBirth,
                    Designation = employee.Designation
                };
                return View(viewmodel);
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> Edit(EditMujahed model)
        {
            var employee = await _context.employeeMujaheds.FindAsync(model.Id);

            if (employee != null)
            {
                employee.Name = model.Name;
                employee.Email = model.Email;
                employee.Salary = model.Salary;
                employee.DateOfBirth = model.DateOfBirth;
                employee.Designation = model.Designation;

                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return RedirectToAction("Index");
        }
        [HttpGet]
        public async Task<IActionResult> Delete(Guid Id)
        {
            var employee = await _context.employeeMujaheds.FirstOrDefaultAsync(x => x.Id == Id);
            if (employee != null)
            {
                var viewmodel = new DeleteMujahed()
                {
                    Id = Guid.NewGuid(),
                    Name = employee.Name,
                    Email = employee.Email,
                    Salary = employee.Salary,
                    DateOfBirth = employee.DateOfBirth,
                    Designation = employee.Designation
                };
                return View(viewmodel);
            }
            return RedirectToAction("Index");
        }
        [HttpPost]
        public async Task<IActionResult> Delete(DeleteMujahed model)
        {
            var employee =await _context.employeeMujaheds.FindAsync(model.Id);

            if(employee != null)
            {
               _context.employeeMujaheds.Remove(employee);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }
    }
}
