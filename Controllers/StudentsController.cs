using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using grad2021.Data;
using grad2021.Models;

namespace grad2021.Controllers
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
            return View(await _context.Students.ToListAsync());
        }

        // GET: Students/Details/5
        public async Task<IActionResult> Details(ulong? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var student = await _context.Students
                .FirstOrDefaultAsync(m => m.StudentNatId == id);
            if (student == null)
            {
                return NotFound();
            }

            return View(student);
        }

        // GET: Students/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Students/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("StudentName,StudentNatId,BirthDate,BirthPlace,Gender,Phone,EnrollmentDate,SeatNo, LevelName, BranchName")] StudentTransfer studentTransfer)
        {
            Student student = new();
            student.StudentName = studentTransfer.StudentName;
            student.StudentNatId = studentTransfer.StudentNatId;
            student.BirthDate = studentTransfer.BirthDate;
            student.BirthPlace = studentTransfer.BirthPlace;
            student.Gender = studentTransfer.Gender;
            student.Phone = studentTransfer.Phone;
            student.EnrollmentDate = studentTransfer.EnrollmentDate;
            student.SeatNo = studentTransfer.SeatNo;

            if (ModelState.IsValid)
            {
                _context.Add(student);
                await _context.SaveChangesAsync();
                //add new student enrollment for prep year

                int academicYearId = await _context.AcademicYears
                .MaxAsync(x=>x.AcademicYearID);

                var courseEnrollments = await _context.CourseEnrollments
                    .Where(m => m.LevelName == studentTransfer.LevelName && m.BranchName == studentTransfer.BranchName)
                    .ToListAsync();
                StudentEnrollment studentEnrollment = new();
                studentEnrollment.AcademicYearID = academicYearId;
                studentEnrollment.BranchName = studentTransfer.BranchName;
                studentEnrollment.LevelName = studentTransfer.LevelName;
                studentEnrollment.StudentNatId = student.StudentNatId;
                _context.Add(studentEnrollment);
                await _context.SaveChangesAsync();

                List<StudentCourse> studentCourses = new();
                foreach(CourseEnrollment courseEnrollment in courseEnrollments)
                {
                    StudentCourse studentCourse = new();
                    studentCourse.AcademicYearID = studentEnrollment.AcademicYearID;
                    studentCourse.BranchName = studentEnrollment.BranchName;
                    studentCourse.CourseName = courseEnrollment.CourseName;
                    studentCourse.StudentNatId = studentEnrollment.StudentNatId;
                    studentCourses.Add(studentCourse);
                }
                _context.AddRange(studentCourses);
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }
            return View(student);
        }

        // GET: Students/Edit/5
        public async Task<IActionResult> Edit(ulong? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var student = await _context.Students.FindAsync(id);
            if (student == null)
            {
                return NotFound();
            }
            return View(student);
        }

        // POST: Students/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(ulong id, [Bind("StudentName,StudentNatId,BirthDate,BirthPlace,Gender,Phone,EnrollmentDate,SeatNo")] Student student)
        {
            if (id != student.StudentNatId)
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
                    if (!StudentExists(student.StudentNatId))
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

        // GET: Students/Delete/5
        public async Task<IActionResult> Delete(ulong? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var student = await _context.Students
                .FirstOrDefaultAsync(m => m.StudentNatId == id);
            if (student == null)
            {
                return NotFound();
            }

            return View(student);
        }

        // POST: Students/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(ulong id)
        {
            var student = await _context.Students.FindAsync(id);
            _context.Students.Remove(student);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StudentExists(ulong id)
        {
            return _context.Students.Any(e => e.StudentNatId == id);
        }
    }
}
