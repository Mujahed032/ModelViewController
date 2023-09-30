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

        // GET: Student
        public IActionResult Index()
        {
            var students = _context.students.Include(s => s.PermanentAddress).Include(s => s.CurrentAddress).ToList();
            return View(students);
        }

        // GET: Student/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var student = _context.students
                .Include(s => s.PermanentAddress)
                .Include(s => s.CurrentAddress)
                .FirstOrDefault(s => s.Id == id);

            if (student == null)
            {
                return NotFound();
            }

            return View(student);
        }

        // GET: Student/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Student/Create
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

        // GET: Student/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var student = _context.students
                .Include(s => s.PermanentAddress)
                .Include(s => s.CurrentAddress)
                .FirstOrDefault(s => s.Id == id);

            if (student == null)
            {
                return NotFound();
            }
            return View(student);
        }

        // POST: Student/Edit/5
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

        // GET: Student/Delete/5
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var student = _context.students
                .Include(s => s.PermanentAddress)
                .Include(s => s.CurrentAddress)
                .FirstOrDefault(s => s.Id == id);

            if (student == null)
            {
                return NotFound();
            }

            return View(student);
        }

        // POST: Student/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var student = _context.students.Find(id);
            _context.students.Remove(student);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        private bool StudentExists(int id)
        {
            return _context.students.Any(e => e.Id == id);
        }
    }

}

