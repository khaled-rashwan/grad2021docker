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
    public class StudentCoursesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public StudentCoursesController(ApplicationDbContext context)
        {
            _context = context;
        }
        
        // GET: StudentCourses
        public async Task<IActionResult> Index(string sortOrder, string searchString)
        {
            ViewData["StudentNatId"] = String.IsNullOrEmpty(sortOrder) ? "NatIdAsc" : "";
            ViewData["CurrentFilter"] = searchString;

            var applicationDbContext = from s in _context.StudentCourses
                .Include(s => s.CourseEnrollment)
                .Include(s => s.StudentEnrollment)
                                       select s;

            if (!String.IsNullOrEmpty(searchString))
            {
                applicationDbContext = applicationDbContext.Where(s => s.CourseName.Contains(searchString));
            }

            switch (sortOrder)
            {
                case "NatIdAsc":
                    applicationDbContext = applicationDbContext
                        .OrderBy(s => s.StudentNatId)
                        .ThenBy(s=>s.CourseEnrollment.LevelName)
                        .ThenBy(s=>s.CourseName);
                    break;
                default:
                    applicationDbContext = applicationDbContext.OrderBy(s => s.FinalExamMark);
                    break;
            }
            //return View(await applicationDbContext.ToListAsync());
            return View(await applicationDbContext.AsNoTracking().ToListAsync());
        }

        // GET: StudentCourses/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var studentCourse = await _context.StudentCourses
                .Include(s => s.CourseEnrollment)
                .Include(s => s.StudentEnrollment)
                .FirstOrDefaultAsync(m => m.StudentCourseID == id);
            if (studentCourse == null)
            {
                return NotFound();
            }

            ViewData["CourseName"] = new SelectList(_context.CourseEnrollments, "CourseName", "CourseName");
            ViewData["BranchName"] = new SelectList(_context.CourseEnrollments, "BranchName", "BranchName");
            ViewData["StudentNatId"] = new SelectList(_context.StudentEnrollments, "StudentNatId", "StudentNatId");
            ViewData["AcademicYearID"] = new SelectList(_context.StudentEnrollments, "AcademicYearID", "AcademicYearID");

            return View(studentCourse);
        }

        // GET: StudentCourses/Create
        public IActionResult Create()
        {
            ViewData["CourseName"] = new SelectList(_context.CourseEnrollments, "CourseName", "CourseName");
            ViewData["BranchName"] = new SelectList(_context.CourseEnrollments, "BranchName", "BranchName");
            ViewData["StudentNatId"] = new SelectList(_context.StudentEnrollments, "StudentNatId", "StudentNatId");
            ViewData["AcademicYearID"] = new SelectList(_context.StudentEnrollments, "AcademicYearID", "AcademicYearID");
            return View();
        }

        // POST: StudentCourses/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("StudentCourseID,CourseName,AcademicYearID,BranchName,StudentNatId,MidTermMark,CourseWorkMark,OralExamMark,FinalExamMark,MerciMark")] StudentCourse studentCourse)
        {
            if (ModelState.IsValid)
            {
                _context.Add(studentCourse);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CourseName"] = new SelectList(_context.CourseEnrollments, "CourseName", "CourseName");
            ViewData["BranchName"] = new SelectList(_context.CourseEnrollments, "BranchName", "BranchName");
            ViewData["StudentNatId"] = new SelectList(_context.StudentEnrollments, "StudentNatId", "StudentNatId");
            ViewData["AcademicYearID"] = new SelectList(_context.StudentEnrollments, "AcademicYearID", "AcademicYearID");
            return View(studentCourse);
        }

        // GET: StudentCourses/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var studentCourse = await _context.StudentCourses.FindAsync(id);
            if (studentCourse == null)
            {
                return NotFound();
            }
            ViewData["CourseName"] = new SelectList(_context.CourseEnrollments, "CourseName", "CourseName");
            ViewData["BranchName"] = new SelectList(_context.CourseEnrollments, "BranchName", "BranchName");
            ViewData["StudentNatId"] = new SelectList(_context.StudentEnrollments, "StudentNatId", "StudentNatId");
            ViewData["AcademicYearID"] = new SelectList(_context.StudentEnrollments, "AcademicYearID", "AcademicYearID");
            return View(studentCourse);
        }

        // POST: StudentCourses/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("StudentCourseID,CourseName,AcademicYearID,BranchName,StudentNatId,MidTermMark,CourseWorkMark,OralExamMark,FinalExamMark,MerciMark")] StudentCourse studentCourse)
        {
            if (id != studentCourse.StudentCourseID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(studentCourse);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StudentCourseExists(studentCourse.StudentCourseID))
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
            ViewData["CourseName"] = new SelectList(_context.CourseEnrollments, "CourseName", "CourseName");
            ViewData["BranchName"] = new SelectList(_context.CourseEnrollments, "BranchName", "BranchName");
            ViewData["StudentNatId"] = new SelectList(_context.StudentEnrollments, "StudentNatId", "StudentNatId");
            ViewData["AcademicYearID"] = new SelectList(_context.StudentEnrollments, "AcademicYearID", "AcademicYearID");
            return View(studentCourse);
        }

        // GET: StudentCourses/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var studentCourse = await _context.StudentCourses
                .Include(s => s.CourseEnrollment)
                .Include(s => s.StudentEnrollment)
                .FirstOrDefaultAsync(m => m.StudentCourseID == id);
            if (studentCourse == null)
            {
                return NotFound();
            }

            return View(studentCourse);
        }

        // POST: StudentCourses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var studentCourse = await _context.StudentCourses.FindAsync(id);
            _context.StudentCourses.Remove(studentCourse);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StudentCourseExists(int id)
        {
            return _context.StudentCourses.Any(e => e.StudentCourseID == id);
        }
    }
}
