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
    public class CourseEnrollmentsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CourseEnrollmentsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: CourseEnrollments
        public async Task<IActionResult> Index(string sortOrder)
        {
            var applicationDbContext = from s in _context.CourseEnrollments
                                       .Include(c => c.Branch)
                                       .Include(c => c.Course)
                                       select s;
            switch (sortOrder)
            {
                case "LevelNameAsc":
                    applicationDbContext = applicationDbContext
                        .OrderBy(s => s.LevelName)
                        .ThenBy(s=>s.BranchName)
                        .ThenBy(s => s.Term)
                        .ThenBy(s => s.CourseName);
                    break;
                case "branchNameAsc":
                    applicationDbContext = applicationDbContext
                        .OrderBy(s => s.BranchName)
                        .ThenBy(s => s.LevelName)
                        .ThenBy(s => s.Term)
                        .ThenBy(s => s.CourseName);
                    break;
            }
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: CourseEnrollments/Details/5
        public async Task<IActionResult> Details(string CourseName, string BranchName)
        {
            if (CourseName == null || BranchName == null)
            {
                return NotFound();
            }

            var courseEnrollment = await _context.CourseEnrollments
                .Include(c => c.Branch)
                .Include(c => c.Course)
                .FirstOrDefaultAsync(m => m.CourseName == CourseName && m.BranchName == BranchName);
            if (courseEnrollment == null)
            {
                return NotFound();
            }
            ViewData["CourseName"] = CourseName;
            ViewData["BranchName"] = BranchName;
            return View(courseEnrollment);
        }

        // GET: CourseEnrollments/Create
        public IActionResult Create()
        {
            ViewData["BranchName"] = new SelectList(_context.Branches, "BranchName", "BranchName");
            ViewData["CourseName"] = new SelectList(_context.Courses, "CourseName", "CourseName");
            return View();
        }

        // POST: CourseEnrollments/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CourseName,LevelName,BranchName,Term")] CourseEnrollment courseEnrollment)
        {
            if (ModelState.IsValid)
            {
                _context.Add(courseEnrollment);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["BranchName"] = new SelectList(_context.Branches, "BranchName", "BranchName", courseEnrollment.BranchName);
            ViewData["CourseName"] = new SelectList(_context.Courses, "CourseName", "CourseName", courseEnrollment.CourseName);
            return View(courseEnrollment);
        }

        // GET: CourseEnrollments/Edit/5
        public async Task<IActionResult> Edit(string CourseName, string BranchName)
        {
            if (CourseName == null || BranchName == null)
            {
                return NotFound();
            }

            var courseEnrollment = await _context.CourseEnrollments.FindAsync(CourseName, BranchName);
            if (courseEnrollment == null)
            {
                return NotFound();
            }
            ViewData["BranchName"] = new SelectList(_context.Branches, "BranchName", "BranchName", courseEnrollment.BranchName);
            ViewData["CourseName"] = new SelectList(_context.Courses, "CourseName", "CourseName", courseEnrollment.CourseName);
            return View(courseEnrollment);
        }

        // POST: CourseEnrollments/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("CourseName,LevelName,BranchName,Term")] CourseEnrollment courseEnrollment)
        {
            if (id != courseEnrollment.CourseName)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(courseEnrollment);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CourseEnrollmentExists(courseEnrollment.CourseName,courseEnrollment.BranchName))
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
            ViewData["BranchName"] = new SelectList(_context.Branches, "BranchName", "BranchName", courseEnrollment.BranchName);
            ViewData["CourseName"] = new SelectList(_context.Courses, "CourseName", "CourseName", courseEnrollment.CourseName);
            return View(courseEnrollment);
        }

        // GET: CourseEnrollments/Delete/5
        public async Task<IActionResult> Delete(string CourseName, string BranchName)
        {
            if (CourseName == null || BranchName == null)
            {
                return NotFound();
            }

            var courseEnrollment = await _context.CourseEnrollments
                .Include(c => c.Branch)
                .Include(c => c.Course)
                .FirstOrDefaultAsync(m => m.CourseName == CourseName && m.BranchName == BranchName);
            if (courseEnrollment == null)
            {
                return NotFound();
            }

            return View(courseEnrollment);
        }

        // POST: CourseEnrollments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed( string CourseName, string BranchName)
        {
            var courseEnrollment = await _context.CourseEnrollments.FindAsync( CourseName,  BranchName);
            _context.CourseEnrollments.Remove(courseEnrollment);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CourseEnrollmentExists(string CourseName, string BranchName)
        {
            return _context.CourseEnrollments.Any(m => m.CourseName == CourseName && m.BranchName == BranchName);
        }
    }
}
