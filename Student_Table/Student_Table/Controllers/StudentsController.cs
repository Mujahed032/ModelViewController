using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Student_Table.Data;
using Student_Table.Models;

namespace Student_Table.Controllers
{
    public class StudentsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public StudentsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Students
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Students.Include(s => s.CurrentAddress).Include(s => s.Nationality).Include(s => s.PermanentAddress);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Students/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Students == null)
            {
                return NotFound();
            }

            var student = await _context.Students
                .Include(s => s.CurrentAddress)
                .Include(s => s.Nationality)
                .Include(s => s.PermanentAddress)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (student == null)
            {
                return NotFound();
            }

            return View(student);
        }

        // GET: Students/Create
        public IActionResult Create()
        {
            ViewData["CurrentAddressId"] = new SelectList(_context.Addresses, "Id", "PostalCode");
            ViewData["NationalityId"] = new SelectList(_context.Countries, "Id", "Name");
            ViewData["PermanentAddressId"] = new SelectList(_context.Addresses, "Id", "PostalCode");
            return View();
        }

        // POST: Students/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,StudentName,FatherName,MotherName,MobileNumber,Gender,MaritalStatus,CurrentAddressId,PermanentAddressId,CountryId,StateId,CityId,DateOfBirth,NationalityId,Religion,Caste,ReservationCategory,GroupToStudy,QualifyingExamination,Board,HallTicketNumber,MonthYearOfPassing,TotalMarks,AverageMarks,PreferredCollege,SecondLanguage")] Student student)
        {
            if (ModelState.IsValid)
            {
                _context.Add(student);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CurrentAddressId"] = new SelectList(_context.Addresses, "Id", "PostalCode", student.CurrentAddressId);
            ViewData["NationalityId"] = new SelectList(_context.Countries, "Id", "Name", student.NationalityId);
            ViewData["PermanentAddressId"] = new SelectList(_context.Addresses, "Id", "PostalCode", student.PermanentAddressId);
            return View(student);
        }

        // GET: Students/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Students == null)
            {
                return NotFound();
            }

            var student = await _context.Students.FindAsync(id);
            if (student == null)
            {
                return NotFound();
            }
            ViewData["CurrentAddressId"] = new SelectList(_context.Addresses, "Id", "PostalCode", student.CurrentAddressId);
            ViewData["NationalityId"] = new SelectList(_context.Countries, "Id", "Name", student.NationalityId);
            ViewData["PermanentAddressId"] = new SelectList(_context.Addresses, "Id", "PostalCode", student.PermanentAddressId);
            return View(student);
        }

        // POST: Students/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,StudentName,FatherName,MotherName,MobileNumber,Gender,MaritalStatus,CurrentAddressId,PermanentAddressId,CountryId,StateId,CityId,DateOfBirth,NationalityId,Religion,Caste,ReservationCategory,GroupToStudy,QualifyingExamination,Board,HallTicketNumber,MonthYearOfPassing,TotalMarks,AverageMarks,PreferredCollege,SecondLanguage")] Student student)
        {
            if (id != student.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(student);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StudentExists(student.Id))
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
            ViewData["CurrentAddressId"] = new SelectList(_context.Addresses, "Id", "PostalCode", student.CurrentAddressId);
            ViewData["NationalityId"] = new SelectList(_context.Countries, "Id", "Name", student.NationalityId);
            ViewData["PermanentAddressId"] = new SelectList(_context.Addresses, "Id", "PostalCode", student.PermanentAddressId);
            return View(student);
        }

        // GET: Students/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Students == null)
            {
                return NotFound();
            }

            var student = await _context.Students
                .Include(s => s.CurrentAddress)
                .Include(s => s.Nationality)
                .Include(s => s.PermanentAddress)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (student == null)
            {
                return NotFound();
            }

            return View(student);
        }

        // POST: Students/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Students == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Students'  is null.");
            }
            var student = await _context.Students.FindAsync(id);
            if (student != null)
            {
                _context.Students.Remove(student);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StudentExists(int id)
        {
          return (_context.Students?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
