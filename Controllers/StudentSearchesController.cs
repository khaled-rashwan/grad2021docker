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
    public class StudentSearchesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public StudentSearchesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Students
        public async Task<IActionResult> Index(string searchString)
        {
            ViewData["CurrentFilter"] = searchString;

            var student = await _context.Students
                .Include(s => s.StudentEnrollments)
                .ThenInclude(s => s.StudentCourses)
                .FirstOrDefaultAsync(s => s.StudentName.Contains(searchString));
            
            return View(student);
        }
    }
}
