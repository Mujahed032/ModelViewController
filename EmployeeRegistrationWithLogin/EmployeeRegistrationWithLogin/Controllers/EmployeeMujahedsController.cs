using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EmployeeRegistrationWithLogin.Data;
using EmployeeRegistrationWithLogin.Models;

namespace EmployeeRegistrationWithLogin.Controllers
{
    public class EmployeeMujahedsController : Controller
    {
        private readonly DataContext _context;

        public EmployeeMujahedsController(DataContext context)
        {
            _context = context;
        }

      
        public async Task<IActionResult> Index()
        {
              return _context.employeeMujaheds != null ? 
                          View(await _context.employeeMujaheds.ToListAsync()) :
                          Problem("Entity set 'DataContext.employeeMujaheds'  is null.");
        }

       
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null || _context.employeeMujaheds == null)
            {
                return NotFound();
            }

            var employeeMujahed = await _context.employeeMujaheds
                .FirstOrDefaultAsync(m => m.Id == id);
            if (employeeMujahed == null)
            {
                return NotFound();
            }

            return View(employeeMujahed);
        }

       
        public IActionResult Create()
        {
            return View();
        }

       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Password,Email,Salary,DateOfBirth,Designation")] EmployeeMujahed employeeMujahed)
        {
            if (ModelState.IsValid)
            {
                employeeMujahed.Id = Guid.NewGuid();
                _context.Add(employeeMujahed);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(employeeMujahed);
        }

        
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null || _context.employeeMujaheds == null)
            {
                return NotFound();
            }

            var employeeMujahed = await _context.employeeMujaheds.FindAsync(id);
            if (employeeMujahed == null)
            {
                return NotFound();
            }
            return View(employeeMujahed);
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,Name,Password,Email,Salary,DateOfBirth,Designation")] EmployeeMujahed employeeMujahed)
        {
            if (id != employeeMujahed.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(employeeMujahed);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EmployeeMujahedExists(employeeMujahed.Id))
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
            return View(employeeMujahed);
        }

        
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null || _context.employeeMujaheds == null)
            {
                return NotFound();
            }

            var employeeMujahed = await _context.employeeMujaheds
                .FirstOrDefaultAsync(m => m.Id == id);
            if (employeeMujahed == null)
            {
                return NotFound();
            }

            return View(employeeMujahed);
        }

        
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            if (_context.employeeMujaheds == null)
            {
                return Problem("Entity set 'DataContext.employeeMujaheds'  is null.");
            }
            var employeeMujahed = await _context.employeeMujaheds.FindAsync(id);
            if (employeeMujahed != null)
            {
                _context.employeeMujaheds.Remove(employeeMujahed);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EmployeeMujahedExists(Guid id)
        {
          return (_context.employeeMujaheds?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
