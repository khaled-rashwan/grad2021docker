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
    public class DepartmentCodesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DepartmentCodesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: DepartmentCodes
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.DepartmentCodes.Include(d => d.Department);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: DepartmentCodes/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var departmentCode = await _context.DepartmentCodes
                .Include(d => d.Department)
                .FirstOrDefaultAsync(m => m.DepartmentCodeValue == id);
            if (departmentCode == null)
            {
                return NotFound();
            }

            return View(departmentCode);
        }

        // GET: DepartmentCodes/Create
        public IActionResult Create()
        {
            ViewData["DepartmentName"] = new SelectList(_context.Departments, "DepartmentName", "DepartmentName");
            return View();
        }

        // POST: DepartmentCodes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DepartmentCodeValue,DepartmentName")] DepartmentCode departmentCode)
        {
            if (ModelState.IsValid)
            {
                _context.Add(departmentCode);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["DepartmentName"] = new SelectList(_context.Departments, "DepartmentName", "DepartmentName", departmentCode.DepartmentName);
            return View(departmentCode);
        }

        // GET: DepartmentCodes/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var departmentCode = await _context.DepartmentCodes.FindAsync(id);
            if (departmentCode == null)
            {
                return NotFound();
            }
            ViewData["DepartmentName"] = new SelectList(_context.Departments, "DepartmentName", "DepartmentName", departmentCode.DepartmentName);
            return View(departmentCode);
        }

        // POST: DepartmentCodes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("DepartmentCodeValue,DepartmentName")] DepartmentCode departmentCode)
        {
            if (id != departmentCode.DepartmentCodeValue)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(departmentCode);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DepartmentCodeExists(departmentCode.DepartmentCodeValue))
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
            ViewData["DepartmentName"] = new SelectList(_context.Departments, "DepartmentName", "DepartmentName", departmentCode.DepartmentName);
            return View(departmentCode);
        }

        // GET: DepartmentCodes/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var departmentCode = await _context.DepartmentCodes
                .Include(d => d.Department)
                .FirstOrDefaultAsync(m => m.DepartmentCodeValue == id);
            if (departmentCode == null)
            {
                return NotFound();
            }

            return View(departmentCode);
        }

        // POST: DepartmentCodes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var departmentCode = await _context.DepartmentCodes.FindAsync(id);
            _context.DepartmentCodes.Remove(departmentCode);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DepartmentCodeExists(string id)
        {
            return _context.DepartmentCodes.Any(e => e.DepartmentCodeValue == id);
        }
    }
}
