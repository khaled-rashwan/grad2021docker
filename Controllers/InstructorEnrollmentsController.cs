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
    public class InstructorEnrollmentsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public InstructorEnrollmentsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: InstructorEnrollments
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.InstructorEnrollments.Include(i => i.AcademicYear).Include(i => i.CourseEnrollment).Include(i => i.Instructor);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: InstructorEnrollments/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var instructorEnrollment = await _context.InstructorEnrollments
                .Include(i => i.AcademicYear)
                .Include(i => i.CourseEnrollment)
                .Include(i => i.Instructor)
                .FirstOrDefaultAsync(m => m.InstructorEnrollmentID == id);
            if (instructorEnrollment == null)
            {
                return NotFound();
            }

            return View(instructorEnrollment);
        }

        // GET: InstructorEnrollments/Create
        public IActionResult Create()
        {
            ViewData["AcademicYearID"] = new SelectList(_context.AcademicYears, "AcademicYearID", "AcademicYearID");
            ViewData["CourseName"] = new SelectList(_context.CourseEnrollments, "CourseName", "CourseName");
            ViewData["InstructorNatId"] = new SelectList(_context.Instructors, "InstructorNatId", "InstructorNatId");
            return View();
        }

        // POST: InstructorEnrollments/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("InstructorEnrollmentID,InstructorNatId,AcademicYearID,CourseName,BranchName")] InstructorEnrollment instructorEnrollment)
        {
            if (ModelState.IsValid)
            {
                _context.Add(instructorEnrollment);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AcademicYearID"] = new SelectList(_context.AcademicYears, "AcademicYearID", "AcademicYearID", instructorEnrollment.AcademicYearID);
            ViewData["CourseName"] = new SelectList(_context.CourseEnrollments, "CourseName", "CourseName", instructorEnrollment.CourseName);
            ViewData["InstructorNatId"] = new SelectList(_context.Instructors, "InstructorNatId", "InstructorNatId", instructorEnrollment.InstructorNatId);
            return View(instructorEnrollment);
        }

        // GET: InstructorEnrollments/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var instructorEnrollment = await _context.InstructorEnrollments.FindAsync(id);
            if (instructorEnrollment == null)
            {
                return NotFound();
            }
            ViewData["AcademicYearID"] = new SelectList(_context.AcademicYears, "AcademicYearID", "AcademicYearID", instructorEnrollment.AcademicYearID);
            ViewData["CourseName"] = new SelectList(_context.CourseEnrollments, "CourseName", "CourseName", instructorEnrollment.CourseName);
            ViewData["InstructorNatId"] = new SelectList(_context.Instructors, "InstructorNatId", "InstructorNatId", instructorEnrollment.InstructorNatId);
            return View(instructorEnrollment);
        }

        // POST: InstructorEnrollments/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("InstructorEnrollmentID,InstructorNatId,AcademicYearID,CourseName,BranchName")] InstructorEnrollment instructorEnrollment)
        {
            if (id != instructorEnrollment.InstructorEnrollmentID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(instructorEnrollment);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!InstructorEnrollmentExists(instructorEnrollment.InstructorEnrollmentID))
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
            ViewData["AcademicYearID"] = new SelectList(_context.AcademicYears, "AcademicYearID", "AcademicYearID", instructorEnrollment.AcademicYearID);
            ViewData["CourseName"] = new SelectList(_context.CourseEnrollments, "CourseName", "CourseName", instructorEnrollment.CourseName);
            ViewData["InstructorNatId"] = new SelectList(_context.Instructors, "InstructorNatId", "InstructorNatId", instructorEnrollment.InstructorNatId);
            return View(instructorEnrollment);
        }

        // GET: InstructorEnrollments/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var instructorEnrollment = await _context.InstructorEnrollments
                .Include(i => i.AcademicYear)
                .Include(i => i.CourseEnrollment)
                .Include(i => i.Instructor)
                .FirstOrDefaultAsync(m => m.InstructorEnrollmentID == id);
            if (instructorEnrollment == null)
            {
                return NotFound();
            }

            return View(instructorEnrollment);
        }

        // POST: InstructorEnrollments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var instructorEnrollment = await _context.InstructorEnrollments.FindAsync(id);
            _context.InstructorEnrollments.Remove(instructorEnrollment);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool InstructorEnrollmentExists(int id)
        {
            return _context.InstructorEnrollments.Any(e => e.InstructorEnrollmentID == id);
        }
    }
}
