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
    public class AcademicYearsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AcademicYearsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: AcademicYears
        public async Task<IActionResult> Index()
        {
            return View(await _context.AcademicYears.ToListAsync());
        }

        // GET: AcademicYears/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var academicYear = await _context.AcademicYears
                .FirstOrDefaultAsync(m => m.AcademicYearID == id);
            if (academicYear == null)
            {
                return NotFound();
            }

            return View(academicYear);
        }

        // GET: AcademicYears/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: AcademicYears/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AcademicYearID,FirstSemesterStartDate,FirstSemesterExamsStartDate,FirstSemesterControlStartDate,FirstSemesterObjectionStartDate,FirstSemesterObjectionEndDate,SecondSemesterStartDate,SecondSemesterExamsStartDate,SecondSemesterControlStartDate,SecondSemesterObjectionStartDate,SecondSemesterObjectionEndDate,NovemberExamsStartDate,NovemberControlStartDate,NovemberObjectionStartDate,NovemberObjectionEndDate")] AcademicYear academicYear)
        {
            if (ModelState.IsValid)
            {
                _context.Add(academicYear);
                await _context.SaveChangesAsync();

                //create new student
                //get all students enrolled in the previous year
                var studentEnrollments = await _context.StudentEnrollments
                    .Include(m => m.Selections)
                    .Include(m => m.StudentCourses)
                    .ThenInclude(m => m.CourseEnrollment)
                    .ThenInclude(m => m.Course)
                    .Where(m => m.AcademicYearID == academicYear.AcademicYearID - 1)
                    .ToListAsync();

                var branches = await _context.Branches
                    .ToListAsync();
                foreach(Branch branch in branches) { branch.CurrentCapacity = 0; }

                List<StudentSorting> x = new();
                foreach (StudentEnrollment studentEnrollment in studentEnrollments)
                {
                    StudentSorting studentSorting = new();
                    studentSorting.StudentNatId = studentEnrollment.StudentNatId;
                    studentSorting.LevelName = studentEnrollment.LevelName;
                    studentSorting.CompleteLevelMark = CompleteLevelMark(studentEnrollment);
                    x.Add(studentSorting);
                }
                IOrderedEnumerable<StudentSorting> studentSortings =
                    x.OrderBy(x => x.LevelName).ThenByDescending(x => x.CompleteLevelMark);
                foreach (StudentSorting ss in studentSortings)
                {
                    StudentEnrollment se = studentEnrollments.Find(x => x.StudentNatId == ss.StudentNatId);
                    
                    //check if student succeeded this year or failed
                    int failCounter = 0;
                    List<StudentCourse> failedCourses = new List<StudentCourse>();
                    foreach (StudentCourse d in se.StudentCourses)
                    {
                        if (CourseFail(d, d.CourseEnrollment.Course))
                        {
                            failCounter++;
                            StudentCourse studentCourse = new StudentCourse();
                            studentCourse.CourseName = d.CourseName;
                            studentCourse.BranchName = d.BranchName;
                            studentCourse.StudentNatId = d.StudentNatId;
                            studentCourse.AcademicYearID = academicYear.AcademicYearID;
                            studentCourse.MerciMark = 0;
                            studentCourse.FinalExamMark = 0;
                            failedCourses.Add(studentCourse);
                        }
                    }
                    bool yearFail = failCounter > 2;
                    if (yearFail)
                    {
                        //create new enrollment
                        StudentEnrollment studentEnrollment = new StudentEnrollment();
                        studentEnrollment.StudentNatId = se.StudentNatId;
                        studentEnrollment.AcademicYearID = academicYear.AcademicYearID;
                        studentEnrollment.BranchName = se.BranchName;
                        studentEnrollment.LevelName = se.LevelName;
                        _context.Add(studentEnrollment);
                        await _context.SaveChangesAsync();
                        //إضافة مواد الرسوب من العام الماضي للطالب الراسب
                        _context.AddRange(failedCourses);
                        await _context.SaveChangesAsync();

                        branches.Find(s => s.BranchName == studentEnrollment.BranchName).CurrentCapacity += 1;

                    }
                    //خريج بدون مواد
                    else if (se.LevelName == LevelName.الرابعة && failCounter == 0) { }

                    else if (se.LevelName != LevelName.الرابعة && !Branching(se.BranchName, se.LevelName))
                    {
                        StudentEnrollment studentEnrollment = new StudentEnrollment();
                        studentEnrollment.StudentNatId = se.StudentNatId;
                        studentEnrollment.AcademicYearID = academicYear.AcademicYearID;
                        studentEnrollment.LevelName = NextLevel(se.LevelName);
                        studentEnrollment.BranchName = se.BranchName;
                        _context.Add(studentEnrollment);
                        await _context.SaveChangesAsync();
                        //إضافة مواد الرسوب من العام الماضي
                        _context.AddRange(failedCourses);
                        await _context.SaveChangesAsync();
                        //إضافة مواد العام الجديد للطالب الناجح
                        var courseEnrollments = await _context.CourseEnrollments
                            .Where(m => m.LevelName == NextLevel(se.LevelName) && m.BranchName == se.BranchName)
                            .ToListAsync();
                        foreach (CourseEnrollment ce in courseEnrollments)
                        {
                            StudentCourse studentCourse = new StudentCourse();
                            studentCourse.AcademicYearID = academicYear.AcademicYearID;
                            studentCourse.BranchName = ce.BranchName;
                            studentCourse.CourseName = ce.CourseName;
                            studentCourse.StudentNatId = se.StudentNatId;
                            _context.Add(studentCourse);
                            await _context.SaveChangesAsync();
                        }
                    }
                    else if (se.LevelName == LevelName.الرابعة && failCounter != 0 && !se.IsNovember)
                    {
                        se.IsNovember = true;
                        //إضافة مواد الرسوب لدور نوفمبر
                        foreach (StudentCourse failedCourse in failedCourses)
                        {
                            failedCourse.IsNovember = true;
                        }
                    }
                    else if (Branching(se.BranchName, se.LevelName))
                    {
                        //create new enrollment for the next year (branchname will be selected)
                        //تحديد الشعبة عن طريق التنسيق وكثافة الأقسام
                        StudentEnrollment studentEnrollment = new StudentEnrollment();
                        studentEnrollment.StudentNatId = se.StudentNatId;
                        studentEnrollment.AcademicYearID = academicYear.AcademicYearID;
                        studentEnrollment.LevelName = NextLevel(se.LevelName);

                        int selectionCounter = 1;
                        //اختيار الرغبة الأولى للطالب
                        studentEnrollment.BranchName = se.Selections.
                            Find(s => s.SelectionNo == 1).SelectionBranchName;
                        branches.Find(s => s.BranchName == studentEnrollment.BranchName).CurrentCapacity += 1;
                        _context.Update(branches.Find(s => s.BranchName == studentEnrollment.BranchName));
                        await _context.SaveChangesAsync();
                        int currentCapacity = branches.Find(s => s.BranchName == studentEnrollment.BranchName).CurrentCapacity;
                        int fullCapacity = branches.Find(s => s.BranchName == studentEnrollment.BranchName).FullCapacity;

                        while (se.Selections.Any(s => s.SelectionNo == selectionCounter) && currentCapacity > fullCapacity)
                        {
                            selectionCounter++;
                            branches.Find(s => s.BranchName == studentEnrollment.BranchName).CurrentCapacity -= 1;
                            _context.Update(branches.Find(s => s.BranchName == studentEnrollment.BranchName));
                            await _context.SaveChangesAsync();
                            studentEnrollment.BranchName = se.Selections.
                                Find(s => s.SelectionNo == selectionCounter).SelectionBranchName;
                            branches.Find(s => s.BranchName == studentEnrollment.BranchName).CurrentCapacity += 1;
                            _context.Update(branches.Find(s => s.BranchName == studentEnrollment.BranchName));
                            await _context.SaveChangesAsync();
                            currentCapacity = branches.Find(s => s.BranchName == studentEnrollment.BranchName).CurrentCapacity;
                        }
                        _context.Add(studentEnrollment);
                        await _context.SaveChangesAsync();
                        //إضافة مواد الرسوب من العام الماضي للطالب الراسب
                        _context.AddRange(failedCourses);
                        await _context.SaveChangesAsync();
                        //إضافة مواد العام الجديد للطالب الناجح
                        var courseEnrollments = await _context.CourseEnrollments
                            .Where(m => m.LevelName == NextLevel(se.LevelName) && m.BranchName == studentEnrollment.BranchName)
                            .ToListAsync();
                        foreach (CourseEnrollment ce in courseEnrollments)
                        {
                            StudentCourse studentCourse = new StudentCourse();
                            studentCourse.AcademicYearID = academicYear.AcademicYearID;
                            studentCourse.BranchName = ce.BranchName;
                            studentCourse.CourseName = ce.CourseName;
                            studentCourse.StudentNatId = se.StudentNatId;
                            _context.Add(studentCourse);
                            await _context.SaveChangesAsync();
                        }
                    }
                }


                return RedirectToAction(nameof(Index));
            }
            return View(academicYear);
        }

        // GET: AcademicYears/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var academicYear = await _context.AcademicYears.FindAsync(id);
            if (academicYear == null)
            {
                return NotFound();
            }
            return View(academicYear);
        }

        // POST: AcademicYears/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("AcademicYearID,FirstSemesterStartDate,FirstSemesterExamsStartDate,FirstSemesterControlStartDate,FirstSemesterObjectionStartDate,FirstSemesterObjectionEndDate,SecondSemesterStartDate,SecondSemesterExamsStartDate,SecondSemesterControlStartDate,SecondSemesterObjectionStartDate,SecondSemesterObjectionEndDate,NovemberExamsStartDate,NovemberControlStartDate,NovemberObjectionStartDate,NovemberObjectionEndDate")] AcademicYear academicYear)
        {
            if (id != academicYear.AcademicYearID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(academicYear);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AcademicYearExists(academicYear.AcademicYearID))
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
            return View(academicYear);
        }

        // GET: AcademicYears/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var academicYear = await _context.AcademicYears
                .FirstOrDefaultAsync(m => m.AcademicYearID == id);
            if (academicYear == null)
            {
                return NotFound();
            }

            return View(academicYear);
        }

        // POST: AcademicYears/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var academicYear = await _context.AcademicYears.FindAsync(id);
            _context.AcademicYears.Remove(academicYear);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AcademicYearExists(int id)
        {
            return _context.AcademicYears.Any(e => e.AcademicYearID == id);
        }
        public LevelName NextLevel(LevelName a)
        {
            LevelName nextLevel = LevelName.الأولى;
            switch (a)
            {
                case LevelName.الإعدادية:
                    break;
                case LevelName.الأولى:
                    nextLevel = LevelName.الثانية;
                    break;
                case LevelName.الثانية:
                    nextLevel = LevelName.الثالثة;
                    break;
                case LevelName.الثالثة:
                    nextLevel = LevelName.الرابعة;
                    break;
                case LevelName.الرابعة:
                    break;
            }
            return nextLevel;
        }
        public double FullMark(Course course) {
            return course.CourseWorkMaxScore + course.MidTermExamMaxScore +
                course.OralExamMaxScore + course.TermExamMaxScore;
        }
        public double TotalMark(StudentCourse studentCourse)
        {
            return studentCourse.MidTermMark + studentCourse.CourseWorkMark + studentCourse.OralExamMark +
                studentCourse.MerciMark + studentCourse.FinalExamMark;
        }
        public double CompleteLevelMark(StudentEnrollment studentEnrollment)
        {
            double completeLevelMark = 0;
            foreach (StudentCourse studentCourse in studentEnrollment.StudentCourses)
            {
                if (studentCourse.CourseEnrollment.LevelName == studentEnrollment.LevelName)
                {
                    completeLevelMark += TotalMark(studentCourse);
                }
            }
            return completeLevelMark;
        }
        public IOrderedEnumerable<StudentSorting> SortStudents(ICollection<StudentEnrollment> studentEnrollments) 
        {
            List<StudentSorting> studentSortings = new();
            foreach (StudentEnrollment studentEnrollment in studentEnrollments)
            {
                StudentSorting studentSorting = new();
                studentSorting.StudentNatId = studentEnrollment.StudentNatId;
                studentSorting.LevelName = studentEnrollment.LevelName;
                studentSorting.CompleteLevelMark = CompleteLevelMark(studentEnrollment);
                studentSortings.Add(studentSorting);
            }
            return studentSortings.OrderBy(x => x.LevelName).ThenByDescending(x => x.CompleteLevelMark);
        }

            public bool CourseFail(StudentCourse studentCourse, Course course)
        {
            return TotalMark(studentCourse) < FullMark(course) / 2 ||
                studentCourse.FinalExamMark < 30 / 100 * course.TermExamMaxScore;
        }
        public bool Branching(string branchName, LevelName levelName)
        {
            return branchName == "الرياضيات والفيزيقا الهندسية" ||
                (branchName == "الهندسة الميكانيكية" && levelName == LevelName.الثالثة);
        }
    }
}
