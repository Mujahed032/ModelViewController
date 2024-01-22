using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Student_Form.Data;
using Student_Form.Models;

namespace Student_Form.Controllers
{
      public class StudentController : Controller
     {
  
        private readonly ApplicationDbContext _context;

        public StudentController(ApplicationDbContext context)
        {
            _context = context;
        }

    
        public IActionResult Index()
        {
            var students = _context.Students.Include(s => s.PermanentAddress).Include(s => s.CurrentAddress).ToList();
            return View(students);
        }

     
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var student = _context.Students
                .Include(s => s.PermanentAddress)
                .Include(s => s.CurrentAddress)
                .FirstOrDefault(s => s.Id == id);

            if (student == null)
            {
                return NotFound();
            }

            return View(student);
        }

        
        public IActionResult Create()
        {
            return View();
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Id,StudentName,Gender,DateOfBirth,Email,Password,ConfirmPassword,PhoneNumber,PermanentAddress,CurrentAddress,Hobbies,Course")] Student student)
        {
            if (ModelState.IsValid)
            {
                _context.Add(student);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(student);
        }

        
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var student = _context.Students
                .Include(s => s.PermanentAddress)
                .Include(s => s.CurrentAddress)
                .FirstOrDefault(s => s.Id == id);

            if (student == null)
            {
                return NotFound();
            }
            return View(student);
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("Id,StudentName,Gender,DateOfBirth,Email,Password,ConfirmPassword,PhoneNumber,PermanentAddress,CurrentAddress,Hobbies,Course")] Student student)
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
                    _context.SaveChanges();
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
            return View(student);
        }

       
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var student = _context.Students
                .Include(s => s.PermanentAddress)
                .Include(s => s.CurrentAddress)
                .FirstOrDefault(s => s.Id == id);

            if (student == null)
            {
                return NotFound();
            }

            return View(student);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var student = _context.Students.Find(id);
            _context.Students.Remove(student);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        private bool StudentExists(int id)
        {
            return _context.Students.Any(e => e.Id == id);
        }
    }

}

