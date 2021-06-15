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
    public class SelectionsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SelectionsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Selections
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Selection.Include(s => s.CurrentBranch).Include(s => s.SelectionBranch).Include(s => s.StudentEnrollment);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Selections/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var selection = await _context.Selection
                .Include(s => s.CurrentBranch)
                .Include(s => s.SelectionBranch)
                .Include(s => s.StudentEnrollment)
                .FirstOrDefaultAsync(m => m.SelectionID == id);
            if (selection == null)
            {
                return NotFound();
            }

            return View(selection);
        }

        // GET: Selections/Create
        public IActionResult Create()
        {
            ViewData["CurrentBranchName"] = new SelectList(_context.Branches, "BranchName", "BranchName");
            ViewData["SelectionBranchName"] = new SelectList(_context.Branches, "BranchName", "BranchName");
            ViewData["StudentNatId"] = new SelectList(_context.StudentEnrollments, "StudentNatId", "StudentNatId");
            ViewData["AcademicYearID"] = new SelectList(_context.AcademicYears, "AcademicYearID", "AcademicYearID");
            return View();
        }

        // POST: Selections/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SelectionID,StudentNatId,AcademicYearID,SelectionNo,CurrentBranchName,SelectionBranchName")] Selection selection)
        {
            if (ModelState.IsValid)
            {
                _context.Add(selection);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CurrentBranchName"] = new SelectList(_context.Branches, "BranchName", "BranchName", selection.CurrentBranchName);
            ViewData["SelectionBranchName"] = new SelectList(_context.Branches, "BranchName", "BranchName", selection.SelectionBranchName);
            ViewData["StudentNatId"] = new SelectList(_context.StudentEnrollments, "StudentNatId", "StudentNatId", selection.StudentNatId);
            ViewData["AcademicYearID"] = new SelectList(_context.AcademicYears, "AcademicYearID", "AcademicYearID", selection.AcademicYearID);
            return View(selection);
        }

        // GET: Selections/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var selection = await _context.Selection.FindAsync(id);
            if (selection == null)
            {
                return NotFound();
            }
            ViewData["CurrentBranchName"] = new SelectList(_context.Branches, "BranchName", "BranchName", selection.CurrentBranchName);
            ViewData["SelectionBranchName"] = new SelectList(_context.Branches, "BranchName", "BranchName", selection.SelectionBranchName);
            ViewData["StudentNatId"] = new SelectList(_context.StudentEnrollments, "StudentNatId", "StudentNatId", selection.StudentNatId);
            ViewData["AcademicYearID"] = new SelectList(_context.AcademicYears, "AcademicYearID", "AcademicYearID", selection.AcademicYearID);
            return View(selection);
        }

        // POST: Selections/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("SelectionID,StudentNatId,AcademicYearID,SelectionNo,CurrentBranchName,SelectionBranchName")] Selection selection)
        {
            if (id != selection.SelectionID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(selection);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SelectionExists(selection.SelectionID))
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
            ViewData["CurrentBranchName"] = new SelectList(_context.Branches, "BranchName", "BranchName", selection.CurrentBranchName);
            ViewData["SelectionBranchName"] = new SelectList(_context.Branches, "BranchName", "BranchName", selection.SelectionBranchName);
            ViewData["StudentNatId"] = new SelectList(_context.StudentEnrollments, "StudentNatId", "StudentNatId", selection.StudentNatId);
            ViewData["AcademicYearID"] = new SelectList(_context.AcademicYears, "AcademicYearID", "AcademicYearID", selection.AcademicYearID);
            return View(selection);
        }

        // GET: Selections/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var selection = await _context.Selection
                .Include(s => s.CurrentBranch)
                .Include(s => s.SelectionBranch)
                .Include(s => s.StudentEnrollment)
                .FirstOrDefaultAsync(m => m.SelectionID == id);
            if (selection == null)
            {
                return NotFound();
            }

            return View(selection);
        }

        // POST: Selections/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var selection = await _context.Selection.FindAsync(id);
            _context.Selection.Remove(selection);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SelectionExists(int id)
        {
            return _context.Selection.Any(e => e.SelectionID == id);
        }
    }
}
