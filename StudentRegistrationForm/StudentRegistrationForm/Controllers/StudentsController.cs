using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using StudentRegistrationForm.Data;
using StudentRegistrationForm.Models;

namespace StudentRegistrationForm.Controllers
{
    public class StudentsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public StudentsController(ApplicationDbContext context)
        {
            _context = context;
        }

    
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.students.Include(s => s.City).Include(s => s.Country).Include(s => s.CurrentAddress).Include(s => s.PermanentAddress).Include(s => s.State);
            return View(await applicationDbContext.ToListAsync());
        }

      
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.students == null)
            {
                return NotFound();
            }

            var student = await _context.students
                .Include(s => s.City)
                .Include(s => s.Country)
                .Include(s => s.CurrentAddress)
                .Include(s => s.PermanentAddress)
                .Include(s => s.State)
                .FirstOrDefaultAsync(m => m.StudentID == id);
            if (student == null)
            {
                return NotFound();
            }

            return View(student);
        }

      
        public IActionResult Create()
        {
            ViewData["CityID"] = new SelectList(_context.city, "CityID", "CityID");
            ViewData["CountryID"] = new SelectList(_context.country, "CountryID", "CountryID");
            ViewData["CurrentAddressID"] = new SelectList(_context.addresses, "AddressID", "AddressID");
            ViewData["PermanentAddressID"] = new SelectList(_context.addresses, "AddressID", "AddressID");
            ViewData["StateID"] = new SelectList(_context.states, "StateID", "StateID");
            return View();
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("StudentID,StudentName,FatherName,MotherName,MobileNumber,Gender,MaritalStatus,DateOfBirth,Nationality,Religion,Caste,Reservation,GroupToStudy,QualifyingExamination,Board,HallTicketNo,MonthYearOfPassing,TotalMarks,AverageMarks,PreferredCollegeName,FirstLanguage,SecondLanguage,CurrentAddressID,PermanentAddressID,CountryID,StateID,CityID")] Student student)
        {
            if (ModelState.IsValid)
            {
                _context.Add(student);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CityID"] = new SelectList(_context.city, "CityID", "CityID", student.CityID);
            ViewData["CountryID"] = new SelectList(_context.country, "CountryID", "CountryID", student.CountryID);
            ViewData["CurrentAddressID"] = new SelectList(_context.addresses, "AddressID", "AddressID", student.CurrentAddressID);
            ViewData["PermanentAddressID"] = new SelectList(_context.addresses, "AddressID", "AddressID", student.PermanentAddressID);
            ViewData["StateID"] = new SelectList(_context.states, "StateID", "StateID", student.StateID);
            return View(student);
        }

      
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.students == null)
            {
                return NotFound();
            }

            var student = await _context.students.FindAsync(id);
            if (student == null)
            {
                return NotFound();
            }
            ViewData["CityID"] = new SelectList(_context.city, "CityID", "CityID", student.CityID);
            ViewData["CountryID"] = new SelectList(_context.country, "CountryID", "CountryID", student.CountryID);
            ViewData["CurrentAddressID"] = new SelectList(_context.addresses, "AddressID", "AddressID", student.CurrentAddressID);
            ViewData["PermanentAddressID"] = new SelectList(_context.addresses, "AddressID", "AddressID", student.PermanentAddressID);
            ViewData["StateID"] = new SelectList(_context.states, "StateID", "StateID", student.StateID);
            return View(student);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("StudentID,StudentName,FatherName,MotherName,MobileNumber,Gender,MaritalStatus,DateOfBirth,Nationality,Religion,Caste,Reservation,GroupToStudy,QualifyingExamination,Board,HallTicketNo,MonthYearOfPassing,TotalMarks,AverageMarks,PreferredCollegeName,FirstLanguage,SecondLanguage,CurrentAddressID,PermanentAddressID,CountryID,StateID,CityID")] Student student)
        {
            if (id != student.StudentID)
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
                    if (!StudentExists(student.StudentID))
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
            ViewData["CityID"] = new SelectList(_context.city, "CityID", "CityID", student.CityID);
            ViewData["CountryID"] = new SelectList(_context.country, "CountryID", "CountryID", student.CountryID);
            ViewData["CurrentAddressID"] = new SelectList(_context.addresses, "AddressID", "AddressID", student.CurrentAddressID);
            ViewData["PermanentAddressID"] = new SelectList(_context.addresses, "AddressID", "AddressID", student.PermanentAddressID);
            ViewData["StateID"] = new SelectList(_context.states, "StateID", "StateID", student.StateID);
            return View(student);
        }

       
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.students == null)
            {
                return NotFound();
            }

            var student = await _context.students
                .Include(s => s.City)
                .Include(s => s.Country)
                .Include(s => s.CurrentAddress)
                .Include(s => s.PermanentAddress)
                .Include(s => s.State)
                .FirstOrDefaultAsync(m => m.StudentID == id);
            if (student == null)
            {
                return NotFound();
            }

            return View(student);
        }

   
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.students == null)
            {
                return Problem("Entity set 'ApplicationDbContext.students'  is null.");
            }
            var student = await _context.students.FindAsync(id);
            if (student != null)
            {
                _context.students.Remove(student);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StudentExists(int id)
        {
          return (_context.students?.Any(e => e.StudentID == id)).GetValueOrDefault();
        }
    }
}
