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
    public class StudentEnrollmentsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public StudentEnrollmentsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: StudentEnrollments
        public async Task<IActionResult> Index(int? pageNumber, string searchString)
        {

            if (searchString != null)
            {
                pageNumber = 1;
            }
            int pageSize = 20;
            var applicationDbContext = from s in _context.StudentEnrollments
                                       .Include(s => s.AcademicYear)
                                       .Include(s => s.Branch)
                                       .Include(s => s.Student)
                                       select s;

            return View(await PaginatedList<StudentEnrollment>.CreateAsync(applicationDbContext.AsNoTracking(), pageNumber ?? 1, pageSize)); 
            //return View(await applicationDbContext.ToListAsync());
        }

        // GET: StudentEnrollments/Details/5
        public async Task<IActionResult> Details(ulong? StudentNatId, int AcademicYearID)
        {
            if (StudentNatId == null || AcademicYearID == null)
            {
                return NotFound();
            }

            var studentEnrollment = await _context.StudentEnrollments
                .Include(s => s.AcademicYear)
                .Include(s => s.Branch)
                .Include(s => s.Student)
                .FirstOrDefaultAsync(s => s.AcademicYearID == AcademicYearID && s.StudentNatId== StudentNatId);
            if (studentEnrollment == null)
            {
                return NotFound();
            }

            ViewData["AcademicYearID"] = AcademicYearID;
            ViewData["StudentNatId"] = StudentNatId;

            return View(studentEnrollment);
        }

        // GET: StudentEnrollments/Create
        public IActionResult Create()
        {
            ViewData["AcademicYearID"] = new SelectList(_context.AcademicYears, "AcademicYearID", "AcademicYearID");
            ViewData["BranchName"] = new SelectList(_context.Branches, "BranchName", "BranchName");
            ViewData["StudentNatId"] = new SelectList(_context.Students, "StudentNatId", "StudentNatId");
            return View();
        }

        // POST: StudentEnrollments/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("StudentNatId,AcademicYearID,LevelName,BranchName")] StudentEnrollment studentEnrollment)
        {
            if (ModelState.IsValid)
            {
                _context.Add(studentEnrollment);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AcademicYearID"] = new SelectList(_context.AcademicYears, "AcademicYearID", "AcademicYearID", studentEnrollment.AcademicYearID);
            ViewData["BranchName"] = new SelectList(_context.Branches, "BranchName", "BranchName", studentEnrollment.BranchName);
            ViewData["StudentNatId"] = new SelectList(_context.Students, "StudentNatId", "StudentNatId", studentEnrollment.StudentNatId);
            return View(studentEnrollment);
        }

        // GET: StudentEnrollments/Edit/5
        public async Task<IActionResult> Edit(ulong? StudentNatId, int AcademicYearID)
        {
            if ( StudentNatId==null || AcademicYearID==null)
            {
                return NotFound();
            }

            var studentEnrollment = await _context.StudentEnrollments.FindAsync(StudentNatId, AcademicYearID);
            if (studentEnrollment == null)
            {
                return NotFound();
            }
            ViewData["AcademicYearID"] = new SelectList(_context.AcademicYears, "AcademicYearID", "AcademicYearID", studentEnrollment.AcademicYearID);
            ViewData["BranchName"] = new SelectList(_context.Branches, "BranchName", "BranchName", studentEnrollment.BranchName);
            ViewData["StudentNatId"] = new SelectList(_context.Students, "StudentNatId", "StudentNatId", studentEnrollment.StudentNatId);
            return View(studentEnrollment);
        }

        // POST: StudentEnrollments/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(ulong id, [Bind("StudentNatId,AcademicYearID,LevelName,BranchName")] StudentEnrollment studentEnrollment)
        {
            if (id != studentEnrollment.StudentNatId )
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(studentEnrollment);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StudentEnrollmentExists(studentEnrollment.StudentNatId,studentEnrollment.AcademicYearID))
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
            ViewData["AcademicYearID"] = new SelectList(_context.AcademicYears, "AcademicYearID", "AcademicYearID", studentEnrollment.AcademicYearID);
            ViewData["BranchName"] = new SelectList(_context.Branches, "BranchName", "BranchName", studentEnrollment.BranchName);
            ViewData["StudentNatId"] = new SelectList(_context.Students, "StudentNatId", "StudentNatId", studentEnrollment.StudentNatId);
            return View(studentEnrollment);
        }

        // GET: StudentEnrollments/Delete/5
        public async Task<IActionResult> Delete(ulong? StudentNatId, int AcademicYearID)
        {
            if ( StudentNatId==null || AcademicYearID==null)
            {
                return NotFound();
            }

            var studentEnrollment = await _context.StudentEnrollments
                .Include(s => s.AcademicYear)
                .Include(s => s.Branch)
                .Include(s => s.Student)
                .FirstOrDefaultAsync(s => s.AcademicYearID == AcademicYearID && s.StudentNatId == StudentNatId);
            if (studentEnrollment == null)
            {
                return NotFound();
            }

            return View(studentEnrollment);
        }

        // POST: StudentEnrollments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(ulong StudentNatId, int AcademicYearID)
        {
            var studentEnrollment = await _context.StudentEnrollments.FindAsync( StudentNatId, AcademicYearID);
            _context.StudentEnrollments.Remove(studentEnrollment);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StudentEnrollmentExists(ulong StudentNatId, int AcademicYearID)
        {
            return _context.StudentEnrollments.Any(s => s.AcademicYearID == AcademicYearID && s.StudentNatId == StudentNatId);
        }
    }
}
