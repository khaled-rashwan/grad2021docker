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
    public class InstructorProfessionsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public InstructorProfessionsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: InstructorProfessions
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.InstructorProfessions.Include(i => i.Instructor);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: InstructorProfessions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var instructorProfession = await _context.InstructorProfessions
                .Include(i => i.Instructor)
                .FirstOrDefaultAsync(m => m.InstructorProfessionID == id);
            if (instructorProfession == null)
            {
                return NotFound();
            }

            return View(instructorProfession);
        }

        // GET: InstructorProfessions/Create
        public IActionResult Create()
        {
            ViewData["InstructorNatId"] = new SelectList(_context.Instructors, "InstructorNatId", "InstructorNatId");
            return View();
        }

        // POST: InstructorProfessions/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("InstructorProfessionID,InstructorNatId,ProfessionDegree,PromotionDate")] InstructorProfession instructorProfession)
        {
            if (ModelState.IsValid)
            {
                _context.Add(instructorProfession);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["InstructorNatId"] = new SelectList(_context.Instructors, "InstructorNatId", "InstructorNatId", instructorProfession.InstructorNatId);
            return View(instructorProfession);
        }

        // GET: InstructorProfessions/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var instructorProfession = await _context.InstructorProfessions.FindAsync(id);
            if (instructorProfession == null)
            {
                return NotFound();
            }
            ViewData["InstructorNatId"] = new SelectList(_context.Instructors, "InstructorNatId", "InstructorNatId", instructorProfession.InstructorNatId);
            return View(instructorProfession);
        }

        // POST: InstructorProfessions/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("InstructorProfessionID,InstructorNatId,ProfessionDegree,PromotionDate")] InstructorProfession instructorProfession)
        {
            if (id != instructorProfession.InstructorProfessionID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(instructorProfession);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!InstructorProfessionExists(instructorProfession.InstructorProfessionID))
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
            ViewData["InstructorNatId"] = new SelectList(_context.Instructors, "InstructorNatId", "InstructorNatId", instructorProfession.InstructorNatId);
            return View(instructorProfession);
        }

        // GET: InstructorProfessions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var instructorProfession = await _context.InstructorProfessions
                .Include(i => i.Instructor)
                .FirstOrDefaultAsync(m => m.InstructorProfessionID == id);
            if (instructorProfession == null)
            {
                return NotFound();
            }

            return View(instructorProfession);
        }

        // POST: InstructorProfessions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var instructorProfession = await _context.InstructorProfessions.FindAsync(id);
            _context.InstructorProfessions.Remove(instructorProfession);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool InstructorProfessionExists(int id)
        {
            return _context.InstructorProfessions.Any(e => e.InstructorProfessionID == id);
        }
    }
}
