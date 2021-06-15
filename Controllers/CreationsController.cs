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
    public class CreationsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CreationsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Students
        public async Task<IActionResult> Index()
        {

            var studentEnrollments = await _context.StudentEnrollments
                .Include(m => m.Branch)
                .ThenInclude(m => m.CourseEnrollments)
                .ToListAsync();
            //var studentEnrollments = from s in _context.StudentEnrollments
            //                         .Include(m => m.Branch)
            //                         .ThenInclude(m => m.CourseEnrollments)
            //                         select s;

            List<string> FirstToThirdBranch = new();
            FirstToThirdBranch.Add("الهندسة المدنية");
            FirstToThirdBranch.Add("الهندسة المعمارية");
            FirstToThirdBranch.Add("هندسة القوى والآلات الكهربية");
            FirstToThirdBranch.Add("هندسة الإلكترونيات والاتصالات الكهربية");
            FirstToThirdBranch.Add("هندسة الحاسبات والنظم");
            FirstToThirdBranch.Add("الهندسة الميكانيكية");

            List<string> MechBranch = new();
            MechBranch.Add("هندسة الإنتاج والتصميم الميكانيكي");
            MechBranch.Add("الهندسة الصناعية");
            MechBranch.Add("هندسة القوى الميكانيكية");

            Random rnd = new Random();

            foreach (StudentEnrollment studentEnrollment in studentEnrollments)
            {
                foreach (CourseEnrollment courseEnrollment in studentEnrollment.Branch.CourseEnrollments)
                {
                    StudentCourse studentCourse = new();
                    studentCourse.AcademicYearID = 2024;
                    studentCourse.StudentNatId = studentEnrollment.StudentNatId;
                    studentCourse.BranchName = studentEnrollment.BranchName;
                    studentCourse.CourseName = courseEnrollment.CourseName;
                    studentCourse.FinalExamMark = rnd.Next(60) + 40;

                    _context.Add(studentCourse);
                    await _context.SaveChangesAsync();
                }

                if (studentEnrollment.BranchName == "الرياضيات والفيزيقا الهندسية")
                {
                    for (int i = 1; i <= 6; i++)
                    {
                        Selection selection = new();
                        selection.AcademicYearID = 2024;
                        selection.CurrentBranchName = "الرياضيات والفيزيقا الهندسية";
                        selection.SelectionNo = i;
                        selection.StudentNatId = studentEnrollment.StudentNatId;
                        selection.SelectionBranchName = FirstToThirdBranch[i - 1];

                        _context.Add(selection);
                        await _context.SaveChangesAsync();
                    }
                }
                else if (studentEnrollment.BranchName == "الهندسة الميكانيكية" && studentEnrollment.LevelName == LevelName.الثالثة)
                {
                    for (int i = 1; i <= 3; i++)
                    {
                        Selection selection = new();
                        selection.AcademicYearID = 2024;
                        selection.CurrentBranchName = "الهندسة الميكانيكية";
                        selection.SelectionNo = i;
                        selection.StudentNatId = studentEnrollment.StudentNatId;
                        selection.SelectionBranchName = MechBranch[i - 1];

                        _context.Add(selection);
                        await _context.SaveChangesAsync();
                    }
                }
            }

            return View(await _context.Students.ToListAsync());
        }
    }
}
