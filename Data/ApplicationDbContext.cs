using grad2021.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace grad2021.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<AcademicYear> AcademicYears { get; set; }
        public DbSet<Branch> Branches { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<CourseEnrollment> CourseEnrollments { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<DepartmentCode> DepartmentCodes { get; set; }
        public DbSet<Instructor> Instructors { get; set; }
        public DbSet<InstructorEnrollment> InstructorEnrollments { get; set; }
        public DbSet<InstructorProfession> InstructorProfessions { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<StudentEnrollment> StudentEnrollments { get; set; }
        public DbSet<StudentCourse> StudentCourses { get; set; }
        public DbSet<grad2021.Models.Selection> Selection { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //modelBuilder.Entity<AcademicYear>().ToTable("AcademicYear");
            //modelBuilder.Entity<Branch>().ToTable("Branch");
            //modelBuilder.Entity<Course>().ToTable("Course");
            //modelBuilder.Entity<CourseEnrollment>().ToTable("CourseEnrollment");
            //modelBuilder.Entity<Department>().ToTable("Department");
            //modelBuilder.Entity<DepartmentCode>().ToTable("DepartmentCode");
            //modelBuilder.Entity<Instructor>().ToTable("Instructor");
            //modelBuilder.Entity<InstructorEnrollment>().ToTable("InstructorEnrollment");
            //modelBuilder.Entity<InstructorProfession>().ToTable("InstructorProfession");
            //modelBuilder.Entity<Student>().ToTable("Student");
            //modelBuilder.Entity<StudentEnrollment>().ToTable("StudentEnrollment");
            //modelBuilder.Entity<StudentCourse>().ToTable("StudentCourse");


            //Key Management: HasKey, HasAlternateKey, (HasOne, WithMany, HasForeignKey)

            modelBuilder.Entity<AcademicYear>()
                .HasKey(ay => ay.AcademicYearID);

            modelBuilder.Entity<Branch>()
                .HasKey(b => b.BranchName);
            modelBuilder.Entity<Branch>()
                 .HasOne(bh => bh.Department)
                 .WithMany(bw => bw.Branches)
                 .HasForeignKey(bf => bf.DepartmentName);

            modelBuilder.Entity<Course>()
                .HasKey(c => c.CourseName);
            //modelBuilder.Entity<Course>()
            //    .HasAlternateKey(ce => new { ce.CourseCode, ce.DepartmentCodeValue });
            modelBuilder.Entity<Course>()
                 .HasOne(ch => ch.DepartmentCode)
                 .WithMany(cw => cw.Courses)
                 .HasForeignKey(cf => cf.DepartmentCodeValue);

            modelBuilder.Entity<CourseEnrollment>()
                .HasKey(ce => new { ce.CourseName, ce.BranchName });
            modelBuilder.Entity<CourseEnrollment>()
                 .HasOne(ceh => ceh.Course)
                 .WithMany(cew => cew.CourseEnrollments)
                 .HasForeignKey(dcf => dcf.CourseName);
            modelBuilder.Entity<CourseEnrollment>()
                 .HasOne(ceh => ceh.Branch)
                 .WithMany(cew => cew.CourseEnrollments)
                 .HasForeignKey(dcf => dcf.BranchName);

            modelBuilder.Entity<Department>()
                .HasKey(d => d.DepartmentName);

            modelBuilder.Entity<DepartmentCode>()
                .HasKey(dc => dc.DepartmentCodeValue);
            modelBuilder.Entity<DepartmentCode>()
                 .HasOne(dch => dch.Department)
                 .WithMany(dcw => dcw.DepartmentCodes)
                 .HasForeignKey(dcf => dcf.DepartmentName);

            modelBuilder.Entity<Instructor>()
                .HasKey(i => i.InstructorNatId);
            //modelBuilder.Entity<Instructor>()
            //    .HasAlternateKey(i => i.InstructorName);
            modelBuilder.Entity<Instructor>()
                 .HasOne(p => p.Department)
                 .WithMany(b => b.Instructors)
                 .HasForeignKey(s => s.DepartmentName);

            modelBuilder.Entity<InstructorEnrollment>()
                .HasKey(ie => ie.InstructorEnrollmentID);
            //modelBuilder.Entity<InstructorEnrollment>()
            //    .HasAlternateKey(ie => new { ie.InstructorNatId, ie.AcademicYearID, ie.CourseEnrollmentID });
            modelBuilder.Entity<InstructorEnrollment>()
                 .HasOne(p => p.Instructor)
                 .WithMany(b => b.InstructorEnrollments)
                 .HasForeignKey(s => s.InstructorNatId)
                 .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<InstructorEnrollment>()
                 .HasOne(pa => pa.AcademicYear)
                 .WithMany(ba => ba.InstructorEnrollments)
                 .HasForeignKey(sa => sa.AcademicYearID)
                 .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<InstructorEnrollment>()
                 .HasOne(pc => pc.CourseEnrollment)
                 .WithMany(bc => bc.InstructorEnrollments)
                 .HasForeignKey(ce => new { ce.CourseName, ce.BranchName })
                 .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<InstructorProfession>()
                .HasKey(ie => ie.InstructorProfessionID);
            //modelBuilder.Entity<InstructorProfession>()
            //    .HasAlternateKey(ie => new { ie.InstructorNatId, ie.ProfessionDegree });
            modelBuilder.Entity<InstructorProfession>()
                 .HasOne(p => p.Instructor)
                 .WithMany(b => b.InstructorProfessions)
                 .HasForeignKey(s => s.InstructorNatId);

            modelBuilder.Entity<Selection>()
                .HasKey(ie => ie.SelectionID);
            modelBuilder.Entity<Selection>()
                .HasOne(ie => ie.StudentEnrollment)
                 .WithMany(b => b.Selections)
                 .HasForeignKey(ie => new { ie.StudentNatId, ie.AcademicYearID })
                 .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Selection>()
                .HasOne(ie => ie.CurrentBranch)
                 .WithMany(b => b.CurrentBranches)
                 .HasForeignKey(s => s.CurrentBranchName)
                 .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Selection>()
                .HasOne(ie => ie.SelectionBranch)
                 .WithMany(b => b.SelectionBranches)
                 .HasForeignKey(s => s.SelectionBranchName)
                 .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Student>()
                .HasKey(ie => ie.StudentNatId);

            modelBuilder.Entity<StudentEnrollment>()
                .HasKey(ie => new { ie.StudentNatId, ie.AcademicYearID });
            //modelBuilder.Entity<StudentEnrollment>()
            //    .HasAlternateKey(ie => new { ie.StudentNatId, ie.FirstSemesterStartDate });
            modelBuilder.Entity<StudentEnrollment>()
                 .HasOne(p => p.Student)
                 .WithMany(b => b.StudentEnrollments)
                 .HasForeignKey(s => s.StudentNatId);
            modelBuilder.Entity<StudentEnrollment>()
                 .HasOne(p => p.AcademicYear)
                 .WithMany(b => b.StudentEnrollments)
                 .HasForeignKey(s => s.AcademicYearID);
            modelBuilder.Entity<StudentEnrollment>()
                 .HasOne(p => p.Branch)
                 .WithMany(b => b.StudentEnrollments)
                 .HasForeignKey(s => s.BranchName);

            modelBuilder.Entity<StudentCourse>()
                .HasKey(ie => ie.StudentCourseID);
            modelBuilder.Entity<StudentCourse>()
                 .HasOne(p => p.StudentEnrollment)
                 .WithMany(b => b.StudentCourses)
                 .HasForeignKey(s => new { s.StudentNatId, s.AcademicYearID });
            modelBuilder.Entity<StudentCourse>()
                 .HasOne(p => p.CourseEnrollment)
                 .WithMany(b => b.StudentCourses)
                 .HasForeignKey(s => new { s.CourseName, s.BranchName });

            // adding intial data

            modelBuilder.Entity<AcademicYear>().HasData(new AcademicYear { AcademicYearID = 2020 });
            modelBuilder.Entity<AcademicYear>().HasData(new AcademicYear { AcademicYearID = 2021 });
            modelBuilder.Entity<AcademicYear>().HasData(new AcademicYear { AcademicYearID = 2022 });
            modelBuilder.Entity<AcademicYear>().HasData(new AcademicYear { AcademicYearID = 2023 });
            modelBuilder.Entity<AcademicYear>().HasData(new AcademicYear { AcademicYearID = 2024 });

            modelBuilder.Entity<Department>().HasData(new Department { DepartmentName = "الرياضيات والفيزيقا الهندسية", DepartmentDescription = "وصف قسم الرياضيات والفيزيقا الهندسية" });
            modelBuilder.Entity<Department>().HasData(new Department { DepartmentName = "الهندسة المدنية", DepartmentDescription = "وصف قسم الهندسة المدنية" });
            modelBuilder.Entity<Department>().HasData(new Department { DepartmentName = "الهندسة الكهربية", DepartmentDescription = "وصف قسم الهندسة الكهربية" });
            modelBuilder.Entity<Department>().HasData(new Department { DepartmentName = "الهندسة المعمارية", DepartmentDescription = "وصف قسم الهندسة المعمارية" });
            modelBuilder.Entity<Department>().HasData(new Department { DepartmentName = "الهندسة الميكانيكية", DepartmentDescription = "وصف قسم الهندسة الميكانيكية" });

            modelBuilder.Entity<Branch>().HasData(new Branch { BranchName = "الهندسة المدنية", DepartmentName = "الهندسة المدنية", BranchDescription = "وصف قسم الهندسة المدنية", FullCapacity = 20 }); ;
            modelBuilder.Entity<Branch>().HasData(new Branch { BranchName = "الهندسة المعمارية", DepartmentName = "الهندسة المعمارية", BranchDescription = "وصف قسم الهندسة المعمارية", FullCapacity = 20 });
            modelBuilder.Entity<Branch>().HasData(new Branch { BranchName = "الرياضيات والفيزيقا الهندسية", DepartmentName = "الرياضيات والفيزيقا الهندسية", BranchDescription = "وصف قسم الرياضيات والفيزيقا الهندسية", FullCapacity = 20 });
            modelBuilder.Entity<Branch>().HasData(new Branch { BranchName = "هندسة القوى والآلات الكهربية", DepartmentName = "الهندسة الكهربية", BranchDescription = "وصف شعبة هندسة القوى والآلات الكهربية", FullCapacity = 20 });
            modelBuilder.Entity<Branch>().HasData(new Branch { BranchName = "هندسة الإلكترونيات والاتصالات الكهربية", DepartmentName = "الهندسة الكهربية", BranchDescription = "وصف شعبة هندسة الإلكترونيات والاتصالات الكهربية", FullCapacity = 20 });
            modelBuilder.Entity<Branch>().HasData(new Branch { BranchName = "هندسة الحاسبات والنظم", DepartmentName = "الهندسة الكهربية", BranchDescription = "وصف شعبة هندسة الحاسبات والنظم", FullCapacity = 20 });
            modelBuilder.Entity<Branch>().HasData(new Branch { BranchName = "الهندسة الميكانيكية", DepartmentName = "الهندسة الميكانيكية", BranchDescription = "وصف قسم الهندسة الميكانيكية", FullCapacity = 20 });
            modelBuilder.Entity<Branch>().HasData(new Branch { BranchName = "هندسة الإنتاج والتصميم الميكانيكي", DepartmentName = "الهندسة الميكانيكية", BranchDescription = "وصف شعبة هندسة الإنتاج والتصميم الميكانيكي", FullCapacity = 20 });
            modelBuilder.Entity<Branch>().HasData(new Branch { BranchName = "الهندسة الصناعية", DepartmentName = "الهندسة الميكانيكية", BranchDescription = "وصف شعبة الهندسة الصناعية", FullCapacity = 20 });
            modelBuilder.Entity<Branch>().HasData(new Branch { BranchName = "هندسة القوى الميكانيكية", DepartmentName = "الهندسة الميكانيكية", BranchDescription = "وصف شعبة هندسة القوى الميكانيكية", FullCapacity = 20 });

            modelBuilder.Entity<DepartmentCode>().HasData(new DepartmentCode { DepartmentCodeValue = "ريض", DepartmentName = "الرياضيات والفيزيقا الهندسية" });
            modelBuilder.Entity<DepartmentCode>().HasData(new DepartmentCode { DepartmentCodeValue = "فيز", DepartmentName = "الرياضيات والفيزيقا الهندسية" });
            modelBuilder.Entity<DepartmentCode>().HasData(new DepartmentCode { DepartmentCodeValue = "ميك", DepartmentName = "الرياضيات والفيزيقا الهندسية" });
            modelBuilder.Entity<DepartmentCode>().HasData(new DepartmentCode { DepartmentCodeValue = "عام", DepartmentName = "الرياضيات والفيزيقا الهندسية" });
            modelBuilder.Entity<DepartmentCode>().HasData(new DepartmentCode { DepartmentCodeValue = "هند", DepartmentName = "الرياضيات والفيزيقا الهندسية" });
            modelBuilder.Entity<DepartmentCode>().HasData(new DepartmentCode { DepartmentCodeValue = "مدن", DepartmentName = "الهندسة المدنية" });
            modelBuilder.Entity<DepartmentCode>().HasData(new DepartmentCode { DepartmentCodeValue = "عمر", DepartmentName = "الهندسة المعمارية" });
            modelBuilder.Entity<DepartmentCode>().HasData(new DepartmentCode { DepartmentCodeValue = "كھع", DepartmentName = "الهندسة الكهربية" });
            modelBuilder.Entity<DepartmentCode>().HasData(new DepartmentCode { DepartmentCodeValue = "كهق", DepartmentName = "الهندسة الكهربية" });
            modelBuilder.Entity<DepartmentCode>().HasData(new DepartmentCode { DepartmentCodeValue = "كهت", DepartmentName = "الهندسة الكهربية" });
            modelBuilder.Entity<DepartmentCode>().HasData(new DepartmentCode { DepartmentCodeValue = "كهح", DepartmentName = "الهندسة الكهربية" });
            modelBuilder.Entity<DepartmentCode>().HasData(new DepartmentCode { DepartmentCodeValue = "تمج", DepartmentName = "الهندسة الميكانيكية" });
            modelBuilder.Entity<DepartmentCode>().HasData(new DepartmentCode { DepartmentCodeValue = "صنع", DepartmentName = "الهندسة الميكانيكية" });
            modelBuilder.Entity<DepartmentCode>().HasData(new DepartmentCode { DepartmentCodeValue = "قوى", DepartmentName = "الهندسة الميكانيكية" });

            //courses

            modelBuilder.Entity<Course>().HasData(new Course { CourseName = "CourseName 1", CourseCode = "1", DepartmentCodeValue = "ريض" });
            modelBuilder.Entity<Course>().HasData(new Course { CourseName = "CourseName 2", CourseCode = "2", DepartmentCodeValue = "فيز" });
            modelBuilder.Entity<Course>().HasData(new Course { CourseName = "CourseName 3", CourseCode = "3", DepartmentCodeValue = "ميك" });
            modelBuilder.Entity<Course>().HasData(new Course { CourseName = "CourseName 4", CourseCode = "4", DepartmentCodeValue = "عام" });
            modelBuilder.Entity<Course>().HasData(new Course { CourseName = "CourseName 5", CourseCode = "5", DepartmentCodeValue = "هند" });
            modelBuilder.Entity<Course>().HasData(new Course { CourseName = "CourseName 6", CourseCode = "6", DepartmentCodeValue = "مدن" });
            modelBuilder.Entity<Course>().HasData(new Course { CourseName = "CourseName 7", CourseCode = "7", DepartmentCodeValue = "كھع" });
            modelBuilder.Entity<Course>().HasData(new Course { CourseName = "CourseName 8", CourseCode = "8", DepartmentCodeValue = "كهق" });
            modelBuilder.Entity<Course>().HasData(new Course { CourseName = "CourseName 9", CourseCode = "9", DepartmentCodeValue = "كهت" });
            modelBuilder.Entity<Course>().HasData(new Course { CourseName = "CourseName 10", CourseCode = "10", DepartmentCodeValue = "كهح" });
            modelBuilder.Entity<Course>().HasData(new Course { CourseName = "CourseName 11", CourseCode = "11", DepartmentCodeValue = "قوى" });
            modelBuilder.Entity<Course>().HasData(new Course { CourseName = "CourseName 12", CourseCode = "12", DepartmentCodeValue = "تمج" });
            modelBuilder.Entity<Course>().HasData(new Course { CourseName = "CourseName 13", CourseCode = "13", DepartmentCodeValue = "صنع" });
            modelBuilder.Entity<Course>().HasData(new Course { CourseName = "CourseName 14", CourseCode = "14", DepartmentCodeValue = "عمر" });
            modelBuilder.Entity<Course>().HasData(new Course { CourseName = "CourseName 15", CourseCode = "15", DepartmentCodeValue = "ريض" });
            modelBuilder.Entity<Course>().HasData(new Course { CourseName = "CourseName 16", CourseCode = "16", DepartmentCodeValue = "فيز" });
            modelBuilder.Entity<Course>().HasData(new Course { CourseName = "CourseName 17", CourseCode = "17", DepartmentCodeValue = "ميك" });
            modelBuilder.Entity<Course>().HasData(new Course { CourseName = "CourseName 18", CourseCode = "18", DepartmentCodeValue = "عام" });
            modelBuilder.Entity<Course>().HasData(new Course { CourseName = "CourseName 19", CourseCode = "19", DepartmentCodeValue = "هند" });
            modelBuilder.Entity<Course>().HasData(new Course { CourseName = "CourseName 20", CourseCode = "20", DepartmentCodeValue = "مدن" });
            modelBuilder.Entity<Course>().HasData(new Course { CourseName = "CourseName 21", CourseCode = "21", DepartmentCodeValue = "كھع" });
            modelBuilder.Entity<Course>().HasData(new Course { CourseName = "CourseName 22", CourseCode = "22", DepartmentCodeValue = "كهق" });
            modelBuilder.Entity<Course>().HasData(new Course { CourseName = "CourseName 23", CourseCode = "23", DepartmentCodeValue = "كهت" });
            modelBuilder.Entity<Course>().HasData(new Course { CourseName = "CourseName 24", CourseCode = "24", DepartmentCodeValue = "كهح" });
            modelBuilder.Entity<Course>().HasData(new Course { CourseName = "CourseName 25", CourseCode = "25", DepartmentCodeValue = "قوى" });
            modelBuilder.Entity<Course>().HasData(new Course { CourseName = "CourseName 26", CourseCode = "26", DepartmentCodeValue = "تمج" });
            modelBuilder.Entity<Course>().HasData(new Course { CourseName = "CourseName 27", CourseCode = "27", DepartmentCodeValue = "صنع" });
            modelBuilder.Entity<Course>().HasData(new Course { CourseName = "CourseName 28", CourseCode = "28", DepartmentCodeValue = "عمر" });
            modelBuilder.Entity<Course>().HasData(new Course { CourseName = "CourseName 29", CourseCode = "29", DepartmentCodeValue = "ريض" });
            modelBuilder.Entity<Course>().HasData(new Course { CourseName = "CourseName 30", CourseCode = "30", DepartmentCodeValue = "فيز" });
            modelBuilder.Entity<Course>().HasData(new Course { CourseName = "CourseName 31", CourseCode = "31", DepartmentCodeValue = "ميك" });
            modelBuilder.Entity<Course>().HasData(new Course { CourseName = "CourseName 32", CourseCode = "32", DepartmentCodeValue = "عام" });
            modelBuilder.Entity<Course>().HasData(new Course { CourseName = "CourseName 33", CourseCode = "33", DepartmentCodeValue = "هند" });
            modelBuilder.Entity<Course>().HasData(new Course { CourseName = "CourseName 34", CourseCode = "34", DepartmentCodeValue = "مدن" });
            modelBuilder.Entity<Course>().HasData(new Course { CourseName = "CourseName 35", CourseCode = "35", DepartmentCodeValue = "كھع" });
            modelBuilder.Entity<Course>().HasData(new Course { CourseName = "CourseName 36", CourseCode = "36", DepartmentCodeValue = "كهق" });
            modelBuilder.Entity<Course>().HasData(new Course { CourseName = "CourseName 37", CourseCode = "37", DepartmentCodeValue = "كهت" });
            modelBuilder.Entity<Course>().HasData(new Course { CourseName = "CourseName 38", CourseCode = "38", DepartmentCodeValue = "كهح" });
            modelBuilder.Entity<Course>().HasData(new Course { CourseName = "CourseName 39", CourseCode = "39", DepartmentCodeValue = "قوى" });
            modelBuilder.Entity<Course>().HasData(new Course { CourseName = "CourseName 40", CourseCode = "40", DepartmentCodeValue = "تمج" });
            modelBuilder.Entity<Course>().HasData(new Course { CourseName = "CourseName 41", CourseCode = "41", DepartmentCodeValue = "صنع" });
            modelBuilder.Entity<Course>().HasData(new Course { CourseName = "CourseName 42", CourseCode = "42", DepartmentCodeValue = "عمر" });
            modelBuilder.Entity<Course>().HasData(new Course { CourseName = "CourseName 43", CourseCode = "43", DepartmentCodeValue = "ريض" });
            modelBuilder.Entity<Course>().HasData(new Course { CourseName = "CourseName 44", CourseCode = "44", DepartmentCodeValue = "فيز" });
            modelBuilder.Entity<Course>().HasData(new Course { CourseName = "CourseName 45", CourseCode = "45", DepartmentCodeValue = "ميك" });
            modelBuilder.Entity<Course>().HasData(new Course { CourseName = "CourseName 46", CourseCode = "46", DepartmentCodeValue = "عام" });
            modelBuilder.Entity<Course>().HasData(new Course { CourseName = "CourseName 47", CourseCode = "47", DepartmentCodeValue = "هند" });
            modelBuilder.Entity<Course>().HasData(new Course { CourseName = "CourseName 48", CourseCode = "48", DepartmentCodeValue = "مدن" });
            modelBuilder.Entity<Course>().HasData(new Course { CourseName = "CourseName 49", CourseCode = "49", DepartmentCodeValue = "كھع" });
            modelBuilder.Entity<Course>().HasData(new Course { CourseName = "CourseName 50", CourseCode = "50", DepartmentCodeValue = "كهق" });
            modelBuilder.Entity<Course>().HasData(new Course { CourseName = "CourseName 51", CourseCode = "51", DepartmentCodeValue = "كهت" });
            modelBuilder.Entity<Course>().HasData(new Course { CourseName = "CourseName 52", CourseCode = "52", DepartmentCodeValue = "كهح" });
            modelBuilder.Entity<Course>().HasData(new Course { CourseName = "CourseName 53", CourseCode = "53", DepartmentCodeValue = "قوى" });
            modelBuilder.Entity<Course>().HasData(new Course { CourseName = "CourseName 54", CourseCode = "54", DepartmentCodeValue = "تمج" });
            modelBuilder.Entity<Course>().HasData(new Course { CourseName = "CourseName 55", CourseCode = "55", DepartmentCodeValue = "صنع" });
            modelBuilder.Entity<Course>().HasData(new Course { CourseName = "CourseName 56", CourseCode = "56", DepartmentCodeValue = "عمر" });
            modelBuilder.Entity<Course>().HasData(new Course { CourseName = "CourseName 57", CourseCode = "57", DepartmentCodeValue = "ريض" });
            modelBuilder.Entity<Course>().HasData(new Course { CourseName = "CourseName 58", CourseCode = "58", DepartmentCodeValue = "فيز" });
            modelBuilder.Entity<Course>().HasData(new Course { CourseName = "CourseName 59", CourseCode = "59", DepartmentCodeValue = "ميك" });
            modelBuilder.Entity<Course>().HasData(new Course { CourseName = "CourseName 60", CourseCode = "60", DepartmentCodeValue = "عام" });
            modelBuilder.Entity<Course>().HasData(new Course { CourseName = "CourseName 61", CourseCode = "61", DepartmentCodeValue = "هند" });
            modelBuilder.Entity<Course>().HasData(new Course { CourseName = "CourseName 62", CourseCode = "62", DepartmentCodeValue = "مدن" });
            modelBuilder.Entity<Course>().HasData(new Course { CourseName = "CourseName 63", CourseCode = "63", DepartmentCodeValue = "كھع" });
            modelBuilder.Entity<Course>().HasData(new Course { CourseName = "CourseName 64", CourseCode = "64", DepartmentCodeValue = "كهق" });
            modelBuilder.Entity<Course>().HasData(new Course { CourseName = "CourseName 65", CourseCode = "65", DepartmentCodeValue = "كهت" });
            modelBuilder.Entity<Course>().HasData(new Course { CourseName = "CourseName 66", CourseCode = "66", DepartmentCodeValue = "كهح" });
            modelBuilder.Entity<Course>().HasData(new Course { CourseName = "CourseName 67", CourseCode = "67", DepartmentCodeValue = "قوى" });
            modelBuilder.Entity<Course>().HasData(new Course { CourseName = "CourseName 68", CourseCode = "68", DepartmentCodeValue = "تمج" });
            modelBuilder.Entity<Course>().HasData(new Course { CourseName = "CourseName 69", CourseCode = "69", DepartmentCodeValue = "صنع" });
            modelBuilder.Entity<Course>().HasData(new Course { CourseName = "CourseName 70", CourseCode = "70", DepartmentCodeValue = "عمر" });
            modelBuilder.Entity<Course>().HasData(new Course { CourseName = "CourseName 71", CourseCode = "71", DepartmentCodeValue = "ريض" });
            modelBuilder.Entity<Course>().HasData(new Course { CourseName = "CourseName 72", CourseCode = "72", DepartmentCodeValue = "فيز" });
            modelBuilder.Entity<Course>().HasData(new Course { CourseName = "CourseName 73", CourseCode = "73", DepartmentCodeValue = "ميك" });
            modelBuilder.Entity<Course>().HasData(new Course { CourseName = "CourseName 74", CourseCode = "74", DepartmentCodeValue = "عام" });
            modelBuilder.Entity<Course>().HasData(new Course { CourseName = "CourseName 75", CourseCode = "75", DepartmentCodeValue = "هند" });
            modelBuilder.Entity<Course>().HasData(new Course { CourseName = "CourseName 76", CourseCode = "76", DepartmentCodeValue = "مدن" });
            modelBuilder.Entity<Course>().HasData(new Course { CourseName = "CourseName 77", CourseCode = "77", DepartmentCodeValue = "كھع" });
            modelBuilder.Entity<Course>().HasData(new Course { CourseName = "CourseName 78", CourseCode = "78", DepartmentCodeValue = "كهق" });
            modelBuilder.Entity<Course>().HasData(new Course { CourseName = "CourseName 79", CourseCode = "79", DepartmentCodeValue = "كهت" });
            modelBuilder.Entity<Course>().HasData(new Course { CourseName = "CourseName 80", CourseCode = "80", DepartmentCodeValue = "كهح" });
            modelBuilder.Entity<Course>().HasData(new Course { CourseName = "CourseName 81", CourseCode = "81", DepartmentCodeValue = "قوى" });
            modelBuilder.Entity<Course>().HasData(new Course { CourseName = "CourseName 82", CourseCode = "82", DepartmentCodeValue = "تمج" });
            modelBuilder.Entity<Course>().HasData(new Course { CourseName = "CourseName 83", CourseCode = "83", DepartmentCodeValue = "صنع" });
            modelBuilder.Entity<Course>().HasData(new Course { CourseName = "CourseName 84", CourseCode = "84", DepartmentCodeValue = "عمر" });
            modelBuilder.Entity<Course>().HasData(new Course { CourseName = "CourseName 85", CourseCode = "85", DepartmentCodeValue = "ريض" });
            modelBuilder.Entity<Course>().HasData(new Course { CourseName = "CourseName 86", CourseCode = "86", DepartmentCodeValue = "فيز" });
            modelBuilder.Entity<Course>().HasData(new Course { CourseName = "CourseName 87", CourseCode = "87", DepartmentCodeValue = "ميك" });
            modelBuilder.Entity<Course>().HasData(new Course { CourseName = "CourseName 88", CourseCode = "88", DepartmentCodeValue = "عام" });
            modelBuilder.Entity<Course>().HasData(new Course { CourseName = "CourseName 89", CourseCode = "89", DepartmentCodeValue = "هند" });
            modelBuilder.Entity<Course>().HasData(new Course { CourseName = "CourseName 90", CourseCode = "90", DepartmentCodeValue = "مدن" });
            modelBuilder.Entity<Course>().HasData(new Course { CourseName = "CourseName 91", CourseCode = "91", DepartmentCodeValue = "كھع" });
            modelBuilder.Entity<Course>().HasData(new Course { CourseName = "CourseName 92", CourseCode = "92", DepartmentCodeValue = "كهق" });
            modelBuilder.Entity<Course>().HasData(new Course { CourseName = "CourseName 93", CourseCode = "93", DepartmentCodeValue = "كهت" });
            modelBuilder.Entity<Course>().HasData(new Course { CourseName = "CourseName 94", CourseCode = "94", DepartmentCodeValue = "كهح" });
            modelBuilder.Entity<Course>().HasData(new Course { CourseName = "CourseName 95", CourseCode = "95", DepartmentCodeValue = "قوى" });
            modelBuilder.Entity<Course>().HasData(new Course { CourseName = "CourseName 96", CourseCode = "96", DepartmentCodeValue = "تمج" });
            modelBuilder.Entity<Course>().HasData(new Course { CourseName = "CourseName 97", CourseCode = "97", DepartmentCodeValue = "صنع" });
            modelBuilder.Entity<Course>().HasData(new Course { CourseName = "CourseName 98", CourseCode = "98", DepartmentCodeValue = "عمر" });
            modelBuilder.Entity<Course>().HasData(new Course { CourseName = "CourseName 99", CourseCode = "99", DepartmentCodeValue = "ريض" });
            modelBuilder.Entity<Course>().HasData(new Course { CourseName = "CourseName 100", CourseCode = "100", DepartmentCodeValue = "فيز" });
            modelBuilder.Entity<Course>().HasData(new Course { CourseName = "CourseName 101", CourseCode = "101", DepartmentCodeValue = "ميك" });
            modelBuilder.Entity<Course>().HasData(new Course { CourseName = "CourseName 102", CourseCode = "102", DepartmentCodeValue = "عام" });
            modelBuilder.Entity<Course>().HasData(new Course { CourseName = "CourseName 103", CourseCode = "103", DepartmentCodeValue = "هند" });
            modelBuilder.Entity<Course>().HasData(new Course { CourseName = "CourseName 104", CourseCode = "104", DepartmentCodeValue = "مدن" });
            modelBuilder.Entity<Course>().HasData(new Course { CourseName = "CourseName 105", CourseCode = "105", DepartmentCodeValue = "كھع" });
            modelBuilder.Entity<Course>().HasData(new Course { CourseName = "CourseName 106", CourseCode = "106", DepartmentCodeValue = "كهق" });
            modelBuilder.Entity<Course>().HasData(new Course { CourseName = "CourseName 107", CourseCode = "107", DepartmentCodeValue = "كهت" });
            modelBuilder.Entity<Course>().HasData(new Course { CourseName = "CourseName 108", CourseCode = "108", DepartmentCodeValue = "كهح" });
            modelBuilder.Entity<Course>().HasData(new Course { CourseName = "CourseName 109", CourseCode = "109", DepartmentCodeValue = "قوى" });
            modelBuilder.Entity<Course>().HasData(new Course { CourseName = "CourseName 110", CourseCode = "110", DepartmentCodeValue = "تمج" });
            modelBuilder.Entity<Course>().HasData(new Course { CourseName = "CourseName 111", CourseCode = "111", DepartmentCodeValue = "صنع" });
            modelBuilder.Entity<Course>().HasData(new Course { CourseName = "CourseName 112", CourseCode = "112", DepartmentCodeValue = "عمر" });
            modelBuilder.Entity<Course>().HasData(new Course { CourseName = "CourseName 113", CourseCode = "113", DepartmentCodeValue = "ريض" });
            modelBuilder.Entity<Course>().HasData(new Course { CourseName = "CourseName 114", CourseCode = "114", DepartmentCodeValue = "فيز" });
            modelBuilder.Entity<Course>().HasData(new Course { CourseName = "CourseName 115", CourseCode = "115", DepartmentCodeValue = "ميك" });
            modelBuilder.Entity<Course>().HasData(new Course { CourseName = "CourseName 116", CourseCode = "116", DepartmentCodeValue = "عام" });
            modelBuilder.Entity<Course>().HasData(new Course { CourseName = "CourseName 117", CourseCode = "117", DepartmentCodeValue = "هند" });
            modelBuilder.Entity<Course>().HasData(new Course { CourseName = "CourseName 118", CourseCode = "118", DepartmentCodeValue = "مدن" });
            modelBuilder.Entity<Course>().HasData(new Course { CourseName = "CourseName 119", CourseCode = "119", DepartmentCodeValue = "كھع" });
            modelBuilder.Entity<Course>().HasData(new Course { CourseName = "CourseName 120", CourseCode = "120", DepartmentCodeValue = "كهق" });
            modelBuilder.Entity<Course>().HasData(new Course { CourseName = "CourseName 121", CourseCode = "121", DepartmentCodeValue = "كهت" });
            modelBuilder.Entity<Course>().HasData(new Course { CourseName = "CourseName 122", CourseCode = "122", DepartmentCodeValue = "كهح" });
            modelBuilder.Entity<Course>().HasData(new Course { CourseName = "CourseName 123", CourseCode = "123", DepartmentCodeValue = "قوى" });
            modelBuilder.Entity<Course>().HasData(new Course { CourseName = "CourseName 124", CourseCode = "124", DepartmentCodeValue = "تمج" });
            modelBuilder.Entity<Course>().HasData(new Course { CourseName = "CourseName 125", CourseCode = "125", DepartmentCodeValue = "صنع" });
            modelBuilder.Entity<Course>().HasData(new Course { CourseName = "CourseName 126", CourseCode = "126", DepartmentCodeValue = "عمر" });
            modelBuilder.Entity<Course>().HasData(new Course { CourseName = "CourseName 127", CourseCode = "127", DepartmentCodeValue = "ريض" });
            modelBuilder.Entity<Course>().HasData(new Course { CourseName = "CourseName 128", CourseCode = "128", DepartmentCodeValue = "فيز" });
            modelBuilder.Entity<Course>().HasData(new Course { CourseName = "CourseName 129", CourseCode = "129", DepartmentCodeValue = "ميك" });
            modelBuilder.Entity<Course>().HasData(new Course { CourseName = "CourseName 130", CourseCode = "130", DepartmentCodeValue = "عام" });
            modelBuilder.Entity<Course>().HasData(new Course { CourseName = "CourseName 131", CourseCode = "131", DepartmentCodeValue = "هند" });
            modelBuilder.Entity<Course>().HasData(new Course { CourseName = "CourseName 132", CourseCode = "132", DepartmentCodeValue = "مدن" });
            modelBuilder.Entity<Course>().HasData(new Course { CourseName = "CourseName 133", CourseCode = "133", DepartmentCodeValue = "كھع" });
            modelBuilder.Entity<Course>().HasData(new Course { CourseName = "CourseName 134", CourseCode = "134", DepartmentCodeValue = "كهق" });
            modelBuilder.Entity<Course>().HasData(new Course { CourseName = "CourseName 135", CourseCode = "135", DepartmentCodeValue = "كهت" });
            modelBuilder.Entity<Course>().HasData(new Course { CourseName = "CourseName 136", CourseCode = "136", DepartmentCodeValue = "كهح" });
            modelBuilder.Entity<Course>().HasData(new Course { CourseName = "CourseName 137", CourseCode = "137", DepartmentCodeValue = "قوى" });
            modelBuilder.Entity<Course>().HasData(new Course { CourseName = "CourseName 138", CourseCode = "138", DepartmentCodeValue = "تمج" });
            modelBuilder.Entity<Course>().HasData(new Course { CourseName = "CourseName 139", CourseCode = "139", DepartmentCodeValue = "صنع" });
            modelBuilder.Entity<Course>().HasData(new Course { CourseName = "CourseName 140", CourseCode = "140", DepartmentCodeValue = "عمر" });
            modelBuilder.Entity<Course>().HasData(new Course { CourseName = "CourseName 141", CourseCode = "141", DepartmentCodeValue = "ريض" });
            modelBuilder.Entity<Course>().HasData(new Course { CourseName = "CourseName 142", CourseCode = "142", DepartmentCodeValue = "فيز" });
            modelBuilder.Entity<Course>().HasData(new Course { CourseName = "CourseName 143", CourseCode = "143", DepartmentCodeValue = "ميك" });
            modelBuilder.Entity<Course>().HasData(new Course { CourseName = "CourseName 144", CourseCode = "144", DepartmentCodeValue = "عام" });
            modelBuilder.Entity<Course>().HasData(new Course { CourseName = "CourseName 145", CourseCode = "145", DepartmentCodeValue = "هند" });
            modelBuilder.Entity<Course>().HasData(new Course { CourseName = "CourseName 146", CourseCode = "146", DepartmentCodeValue = "مدن" });
            modelBuilder.Entity<Course>().HasData(new Course { CourseName = "CourseName 147", CourseCode = "147", DepartmentCodeValue = "كھع" });
            modelBuilder.Entity<Course>().HasData(new Course { CourseName = "CourseName 148", CourseCode = "148", DepartmentCodeValue = "كهق" });
            modelBuilder.Entity<Course>().HasData(new Course { CourseName = "CourseName 149", CourseCode = "149", DepartmentCodeValue = "كهت" });
            modelBuilder.Entity<Course>().HasData(new Course { CourseName = "CourseName 150", CourseCode = "150", DepartmentCodeValue = "كهح" });
            modelBuilder.Entity<Course>().HasData(new Course { CourseName = "CourseName 151", CourseCode = "151", DepartmentCodeValue = "قوى" });
            modelBuilder.Entity<Course>().HasData(new Course { CourseName = "CourseName 152", CourseCode = "152", DepartmentCodeValue = "تمج" });
            modelBuilder.Entity<Course>().HasData(new Course { CourseName = "CourseName 153", CourseCode = "153", DepartmentCodeValue = "صنع" });
            modelBuilder.Entity<Course>().HasData(new Course { CourseName = "CourseName 154", CourseCode = "154", DepartmentCodeValue = "عمر" });
            modelBuilder.Entity<Course>().HasData(new Course { CourseName = "CourseName 155", CourseCode = "155", DepartmentCodeValue = "ريض" });
            modelBuilder.Entity<Course>().HasData(new Course { CourseName = "CourseName 156", CourseCode = "156", DepartmentCodeValue = "فيز" });
            modelBuilder.Entity<Course>().HasData(new Course { CourseName = "CourseName 157", CourseCode = "157", DepartmentCodeValue = "ميك" });
            modelBuilder.Entity<Course>().HasData(new Course { CourseName = "CourseName 158", CourseCode = "158", DepartmentCodeValue = "عام" });
            modelBuilder.Entity<Course>().HasData(new Course { CourseName = "CourseName 159", CourseCode = "159", DepartmentCodeValue = "هند" });
            modelBuilder.Entity<Course>().HasData(new Course { CourseName = "CourseName 160", CourseCode = "160", DepartmentCodeValue = "مدن" });
            modelBuilder.Entity<Course>().HasData(new Course { CourseName = "CourseName 161", CourseCode = "161", DepartmentCodeValue = "كھع" });
            modelBuilder.Entity<Course>().HasData(new Course { CourseName = "CourseName 162", CourseCode = "162", DepartmentCodeValue = "كهق" });
            modelBuilder.Entity<Course>().HasData(new Course { CourseName = "CourseName 163", CourseCode = "163", DepartmentCodeValue = "كهت" });
            modelBuilder.Entity<Course>().HasData(new Course { CourseName = "CourseName 164", CourseCode = "164", DepartmentCodeValue = "كهح" });
            modelBuilder.Entity<Course>().HasData(new Course { CourseName = "CourseName 165", CourseCode = "165", DepartmentCodeValue = "قوى" });
            modelBuilder.Entity<Course>().HasData(new Course { CourseName = "CourseName 166", CourseCode = "166", DepartmentCodeValue = "تمج" });
            modelBuilder.Entity<Course>().HasData(new Course { CourseName = "CourseName 167", CourseCode = "167", DepartmentCodeValue = "صنع" });
            modelBuilder.Entity<Course>().HasData(new Course { CourseName = "CourseName 168", CourseCode = "168", DepartmentCodeValue = "عمر" });
            modelBuilder.Entity<Course>().HasData(new Course { CourseName = "CourseName 169", CourseCode = "169", DepartmentCodeValue = "ريض" });
            modelBuilder.Entity<Course>().HasData(new Course { CourseName = "CourseName 170", CourseCode = "170", DepartmentCodeValue = "فيز" });
            modelBuilder.Entity<Course>().HasData(new Course { CourseName = "CourseName 171", CourseCode = "171", DepartmentCodeValue = "ميك" });
            modelBuilder.Entity<Course>().HasData(new Course { CourseName = "CourseName 172", CourseCode = "172", DepartmentCodeValue = "عام" });
            modelBuilder.Entity<Course>().HasData(new Course { CourseName = "CourseName 173", CourseCode = "173", DepartmentCodeValue = "هند" });
            modelBuilder.Entity<Course>().HasData(new Course { CourseName = "CourseName 174", CourseCode = "174", DepartmentCodeValue = "مدن" });
            modelBuilder.Entity<Course>().HasData(new Course { CourseName = "CourseName 175", CourseCode = "175", DepartmentCodeValue = "كھع" });
            modelBuilder.Entity<Course>().HasData(new Course { CourseName = "CourseName 176", CourseCode = "176", DepartmentCodeValue = "كهق" });
            modelBuilder.Entity<Course>().HasData(new Course { CourseName = "CourseName 177", CourseCode = "177", DepartmentCodeValue = "كهت" });
            modelBuilder.Entity<Course>().HasData(new Course { CourseName = "CourseName 178", CourseCode = "178", DepartmentCodeValue = "كهح" });
            modelBuilder.Entity<Course>().HasData(new Course { CourseName = "CourseName 179", CourseCode = "179", DepartmentCodeValue = "قوى" });
            modelBuilder.Entity<Course>().HasData(new Course { CourseName = "CourseName 180", CourseCode = "180", DepartmentCodeValue = "تمج" });
            modelBuilder.Entity<Course>().HasData(new Course { CourseName = "CourseName 181", CourseCode = "181", DepartmentCodeValue = "صنع" });
            modelBuilder.Entity<Course>().HasData(new Course { CourseName = "CourseName 182", CourseCode = "182", DepartmentCodeValue = "عمر" });
            modelBuilder.Entity<Course>().HasData(new Course { CourseName = "CourseName 183", CourseCode = "183", DepartmentCodeValue = "ريض" });
            modelBuilder.Entity<Course>().HasData(new Course { CourseName = "CourseName 184", CourseCode = "184", DepartmentCodeValue = "فيز" });
            modelBuilder.Entity<Course>().HasData(new Course { CourseName = "CourseName 185", CourseCode = "185", DepartmentCodeValue = "ميك" });
            modelBuilder.Entity<Course>().HasData(new Course { CourseName = "CourseName 186", CourseCode = "186", DepartmentCodeValue = "عام" });
            modelBuilder.Entity<Course>().HasData(new Course { CourseName = "CourseName 187", CourseCode = "187", DepartmentCodeValue = "هند" });
            modelBuilder.Entity<Course>().HasData(new Course { CourseName = "CourseName 188", CourseCode = "188", DepartmentCodeValue = "مدن" });
            modelBuilder.Entity<Course>().HasData(new Course { CourseName = "CourseName 189", CourseCode = "189", DepartmentCodeValue = "كھع" });
            modelBuilder.Entity<Course>().HasData(new Course { CourseName = "CourseName 190", CourseCode = "190", DepartmentCodeValue = "كهق" });
            modelBuilder.Entity<Course>().HasData(new Course { CourseName = "CourseName 191", CourseCode = "191", DepartmentCodeValue = "كهت" });
            modelBuilder.Entity<Course>().HasData(new Course { CourseName = "CourseName 192", CourseCode = "192", DepartmentCodeValue = "كهح" });
            modelBuilder.Entity<Course>().HasData(new Course { CourseName = "CourseName 193", CourseCode = "193", DepartmentCodeValue = "قوى" });
            modelBuilder.Entity<Course>().HasData(new Course { CourseName = "CourseName 194", CourseCode = "194", DepartmentCodeValue = "تمج" });
            modelBuilder.Entity<Course>().HasData(new Course { CourseName = "CourseName 195", CourseCode = "195", DepartmentCodeValue = "صنع" });
            modelBuilder.Entity<Course>().HasData(new Course { CourseName = "CourseName 196", CourseCode = "196", DepartmentCodeValue = "عمر" });
            modelBuilder.Entity<Course>().HasData(new Course { CourseName = "CourseName 197", CourseCode = "197", DepartmentCodeValue = "ريض" });
            modelBuilder.Entity<Course>().HasData(new Course { CourseName = "CourseName 198", CourseCode = "198", DepartmentCodeValue = "فيز" });
            modelBuilder.Entity<Course>().HasData(new Course { CourseName = "CourseName 199", CourseCode = "199", DepartmentCodeValue = "ميك" });
            modelBuilder.Entity<Course>().HasData(new Course { CourseName = "CourseName 200", CourseCode = "200", DepartmentCodeValue = "عام" });
            modelBuilder.Entity<Course>().HasData(new Course { CourseName = "CourseName 201", CourseCode = "201", DepartmentCodeValue = "هند" });
            modelBuilder.Entity<Course>().HasData(new Course { CourseName = "CourseName 202", CourseCode = "202", DepartmentCodeValue = "مدن" });
            modelBuilder.Entity<Course>().HasData(new Course { CourseName = "CourseName 203", CourseCode = "203", DepartmentCodeValue = "كھع" });
            modelBuilder.Entity<Course>().HasData(new Course { CourseName = "CourseName 204", CourseCode = "204", DepartmentCodeValue = "كهق" });
            modelBuilder.Entity<Course>().HasData(new Course { CourseName = "CourseName 205", CourseCode = "205", DepartmentCodeValue = "كهت" });
            modelBuilder.Entity<Course>().HasData(new Course { CourseName = "CourseName 206", CourseCode = "206", DepartmentCodeValue = "كهح" });
            modelBuilder.Entity<Course>().HasData(new Course { CourseName = "CourseName 207", CourseCode = "207", DepartmentCodeValue = "قوى" });
            modelBuilder.Entity<Course>().HasData(new Course { CourseName = "CourseName 208", CourseCode = "208", DepartmentCodeValue = "تمج" });
            modelBuilder.Entity<Course>().HasData(new Course { CourseName = "CourseName 209", CourseCode = "209", DepartmentCodeValue = "صنع" });
            modelBuilder.Entity<Course>().HasData(new Course { CourseName = "CourseName 210", CourseCode = "210", DepartmentCodeValue = "عمر" });
            modelBuilder.Entity<Course>().HasData(new Course { CourseName = "CourseName 211", CourseCode = "211", DepartmentCodeValue = "ريض" });
            modelBuilder.Entity<Course>().HasData(new Course { CourseName = "CourseName 212", CourseCode = "212", DepartmentCodeValue = "فيز" });
            modelBuilder.Entity<Course>().HasData(new Course { CourseName = "CourseName 213", CourseCode = "213", DepartmentCodeValue = "ميك" });
            modelBuilder.Entity<Course>().HasData(new Course { CourseName = "CourseName 214", CourseCode = "214", DepartmentCodeValue = "عام" });
            modelBuilder.Entity<Course>().HasData(new Course { CourseName = "CourseName 215", CourseCode = "215", DepartmentCodeValue = "هند" });
            modelBuilder.Entity<Course>().HasData(new Course { CourseName = "CourseName 216", CourseCode = "216", DepartmentCodeValue = "مدن" });
            modelBuilder.Entity<Course>().HasData(new Course { CourseName = "CourseName 217", CourseCode = "217", DepartmentCodeValue = "كھع" });
            modelBuilder.Entity<Course>().HasData(new Course { CourseName = "CourseName 218", CourseCode = "218", DepartmentCodeValue = "كهق" });
            modelBuilder.Entity<Course>().HasData(new Course { CourseName = "CourseName 219", CourseCode = "219", DepartmentCodeValue = "كهت" });
            modelBuilder.Entity<Course>().HasData(new Course { CourseName = "CourseName 220", CourseCode = "220", DepartmentCodeValue = "كهح" });
            modelBuilder.Entity<Course>().HasData(new Course { CourseName = "CourseName 221", CourseCode = "221", DepartmentCodeValue = "قوى" });
            modelBuilder.Entity<Course>().HasData(new Course { CourseName = "CourseName 222", CourseCode = "222", DepartmentCodeValue = "تمج" });
            modelBuilder.Entity<Course>().HasData(new Course { CourseName = "CourseName 223", CourseCode = "223", DepartmentCodeValue = "صنع" });
            modelBuilder.Entity<Course>().HasData(new Course { CourseName = "CourseName 224", CourseCode = "224", DepartmentCodeValue = "عمر" });
            modelBuilder.Entity<Course>().HasData(new Course { CourseName = "CourseName 225", CourseCode = "225", DepartmentCodeValue = "ريض" });
            modelBuilder.Entity<Course>().HasData(new Course { CourseName = "CourseName 226", CourseCode = "226", DepartmentCodeValue = "فيز" });
            modelBuilder.Entity<Course>().HasData(new Course { CourseName = "CourseName 227", CourseCode = "227", DepartmentCodeValue = "ميك" });
            modelBuilder.Entity<Course>().HasData(new Course { CourseName = "CourseName 228", CourseCode = "228", DepartmentCodeValue = "عام" });
            modelBuilder.Entity<Course>().HasData(new Course { CourseName = "CourseName 229", CourseCode = "229", DepartmentCodeValue = "هند" });
            modelBuilder.Entity<Course>().HasData(new Course { CourseName = "CourseName 230", CourseCode = "230", DepartmentCodeValue = "مدن" });
            modelBuilder.Entity<Course>().HasData(new Course { CourseName = "CourseName 231", CourseCode = "231", DepartmentCodeValue = "كھع" });
            modelBuilder.Entity<Course>().HasData(new Course { CourseName = "CourseName 232", CourseCode = "232", DepartmentCodeValue = "كهق" });
            modelBuilder.Entity<Course>().HasData(new Course { CourseName = "CourseName 233", CourseCode = "233", DepartmentCodeValue = "كهت" });
            modelBuilder.Entity<Course>().HasData(new Course { CourseName = "CourseName 234", CourseCode = "234", DepartmentCodeValue = "كهح" });
            modelBuilder.Entity<Course>().HasData(new Course { CourseName = "CourseName 235", CourseCode = "235", DepartmentCodeValue = "قوى" });
            modelBuilder.Entity<Course>().HasData(new Course { CourseName = "CourseName 236", CourseCode = "236", DepartmentCodeValue = "تمج" });
            modelBuilder.Entity<Course>().HasData(new Course { CourseName = "CourseName 237", CourseCode = "237", DepartmentCodeValue = "صنع" });
            modelBuilder.Entity<Course>().HasData(new Course { CourseName = "CourseName 238", CourseCode = "238", DepartmentCodeValue = "عمر" });
            modelBuilder.Entity<Course>().HasData(new Course { CourseName = "CourseName 239", CourseCode = "239", DepartmentCodeValue = "ريض" });
            modelBuilder.Entity<Course>().HasData(new Course { CourseName = "CourseName 240", CourseCode = "240", DepartmentCodeValue = "فيز" });
            modelBuilder.Entity<Course>().HasData(new Course { CourseName = "CourseName 241", CourseCode = "241", DepartmentCodeValue = "ميك" });
            modelBuilder.Entity<Course>().HasData(new Course { CourseName = "CourseName 242", CourseCode = "242", DepartmentCodeValue = "عام" });
            modelBuilder.Entity<Course>().HasData(new Course { CourseName = "CourseName 243", CourseCode = "243", DepartmentCodeValue = "هند" });
            modelBuilder.Entity<Course>().HasData(new Course { CourseName = "CourseName 244", CourseCode = "244", DepartmentCodeValue = "مدن" });
            modelBuilder.Entity<Course>().HasData(new Course { CourseName = "CourseName 245", CourseCode = "245", DepartmentCodeValue = "كھع" });
            modelBuilder.Entity<Course>().HasData(new Course { CourseName = "CourseName 246", CourseCode = "246", DepartmentCodeValue = "كهق" });
            modelBuilder.Entity<Course>().HasData(new Course { CourseName = "CourseName 247", CourseCode = "247", DepartmentCodeValue = "كهت" });
            modelBuilder.Entity<Course>().HasData(new Course { CourseName = "CourseName 248", CourseCode = "248", DepartmentCodeValue = "كهح" });
            modelBuilder.Entity<Course>().HasData(new Course { CourseName = "CourseName 249", CourseCode = "249", DepartmentCodeValue = "قوى" });
            modelBuilder.Entity<Course>().HasData(new Course { CourseName = "CourseName 250", CourseCode = "250", DepartmentCodeValue = "تمج" });
            modelBuilder.Entity<Course>().HasData(new Course { CourseName = "CourseName 251", CourseCode = "251", DepartmentCodeValue = "صنع" });
            modelBuilder.Entity<Course>().HasData(new Course { CourseName = "CourseName 252", CourseCode = "252", DepartmentCodeValue = "عمر" });
            modelBuilder.Entity<Course>().HasData(new Course { CourseName = "CourseName 253", CourseCode = "253", DepartmentCodeValue = "ريض" });
            modelBuilder.Entity<Course>().HasData(new Course { CourseName = "CourseName 254", CourseCode = "254", DepartmentCodeValue = "فيز" });
            modelBuilder.Entity<Course>().HasData(new Course { CourseName = "CourseName 255", CourseCode = "255", DepartmentCodeValue = "ميك" });
            modelBuilder.Entity<Course>().HasData(new Course { CourseName = "CourseName 256", CourseCode = "256", DepartmentCodeValue = "عام" });
            modelBuilder.Entity<Course>().HasData(new Course { CourseName = "CourseName 257", CourseCode = "257", DepartmentCodeValue = "هند" });
            modelBuilder.Entity<Course>().HasData(new Course { CourseName = "CourseName 258", CourseCode = "258", DepartmentCodeValue = "مدن" });
            modelBuilder.Entity<Course>().HasData(new Course { CourseName = "CourseName 259", CourseCode = "259", DepartmentCodeValue = "كھع" });
            modelBuilder.Entity<Course>().HasData(new Course { CourseName = "CourseName 260", CourseCode = "260", DepartmentCodeValue = "كهق" });
            modelBuilder.Entity<Course>().HasData(new Course { CourseName = "CourseName 261", CourseCode = "261", DepartmentCodeValue = "كهت" });
            modelBuilder.Entity<Course>().HasData(new Course { CourseName = "CourseName 262", CourseCode = "262", DepartmentCodeValue = "كهح" });
            modelBuilder.Entity<Course>().HasData(new Course { CourseName = "CourseName 263", CourseCode = "263", DepartmentCodeValue = "قوى" });
            modelBuilder.Entity<Course>().HasData(new Course { CourseName = "CourseName 264", CourseCode = "264", DepartmentCodeValue = "تمج" });
            modelBuilder.Entity<Course>().HasData(new Course { CourseName = "CourseName 265", CourseCode = "265", DepartmentCodeValue = "صنع" });
            modelBuilder.Entity<Course>().HasData(new Course { CourseName = "CourseName 266", CourseCode = "266", DepartmentCodeValue = "عمر" });
            modelBuilder.Entity<Course>().HasData(new Course { CourseName = "CourseName 267", CourseCode = "267", DepartmentCodeValue = "ريض" });
            modelBuilder.Entity<Course>().HasData(new Course { CourseName = "CourseName 268", CourseCode = "268", DepartmentCodeValue = "فيز" });
            modelBuilder.Entity<Course>().HasData(new Course { CourseName = "CourseName 269", CourseCode = "269", DepartmentCodeValue = "ميك" });
            modelBuilder.Entity<Course>().HasData(new Course { CourseName = "CourseName 270", CourseCode = "270", DepartmentCodeValue = "عام" });
            modelBuilder.Entity<Course>().HasData(new Course { CourseName = "CourseName 271", CourseCode = "271", DepartmentCodeValue = "هند" });
            modelBuilder.Entity<Course>().HasData(new Course { CourseName = "CourseName 272", CourseCode = "272", DepartmentCodeValue = "مدن" });
            modelBuilder.Entity<Course>().HasData(new Course { CourseName = "CourseName 273", CourseCode = "273", DepartmentCodeValue = "كھع" });
            modelBuilder.Entity<Course>().HasData(new Course { CourseName = "CourseName 274", CourseCode = "274", DepartmentCodeValue = "كهق" });
            modelBuilder.Entity<Course>().HasData(new Course { CourseName = "CourseName 275", CourseCode = "275", DepartmentCodeValue = "كهت" });
            modelBuilder.Entity<Course>().HasData(new Course { CourseName = "CourseName 276", CourseCode = "276", DepartmentCodeValue = "كهح" });
            modelBuilder.Entity<Course>().HasData(new Course { CourseName = "CourseName 277", CourseCode = "277", DepartmentCodeValue = "قوى" });
            modelBuilder.Entity<Course>().HasData(new Course { CourseName = "CourseName 278", CourseCode = "278", DepartmentCodeValue = "تمج" });
            modelBuilder.Entity<Course>().HasData(new Course { CourseName = "CourseName 279", CourseCode = "279", DepartmentCodeValue = "صنع" });
            modelBuilder.Entity<Course>().HasData(new Course { CourseName = "CourseName 280", CourseCode = "280", DepartmentCodeValue = "عمر" });
            modelBuilder.Entity<Course>().HasData(new Course { CourseName = "CourseName 281", CourseCode = "281", DepartmentCodeValue = "ريض" });
            modelBuilder.Entity<Course>().HasData(new Course { CourseName = "CourseName 282", CourseCode = "282", DepartmentCodeValue = "فيز" });
            modelBuilder.Entity<Course>().HasData(new Course { CourseName = "CourseName 283", CourseCode = "283", DepartmentCodeValue = "ميك" });
            modelBuilder.Entity<Course>().HasData(new Course { CourseName = "CourseName 284", CourseCode = "284", DepartmentCodeValue = "عام" });
            modelBuilder.Entity<Course>().HasData(new Course { CourseName = "CourseName 285", CourseCode = "285", DepartmentCodeValue = "هند" });
            modelBuilder.Entity<Course>().HasData(new Course { CourseName = "CourseName 286", CourseCode = "286", DepartmentCodeValue = "مدن" });
            modelBuilder.Entity<Course>().HasData(new Course { CourseName = "CourseName 287", CourseCode = "287", DepartmentCodeValue = "كھع" });
            modelBuilder.Entity<Course>().HasData(new Course { CourseName = "CourseName 288", CourseCode = "288", DepartmentCodeValue = "كهق" });
            modelBuilder.Entity<Course>().HasData(new Course { CourseName = "CourseName 289", CourseCode = "289", DepartmentCodeValue = "كهت" });
            modelBuilder.Entity<Course>().HasData(new Course { CourseName = "CourseName 290", CourseCode = "290", DepartmentCodeValue = "كهح" });
            modelBuilder.Entity<Course>().HasData(new Course { CourseName = "CourseName 291", CourseCode = "291", DepartmentCodeValue = "قوى" });
            modelBuilder.Entity<Course>().HasData(new Course { CourseName = "CourseName 292", CourseCode = "292", DepartmentCodeValue = "تمج" });
            modelBuilder.Entity<Course>().HasData(new Course { CourseName = "CourseName 293", CourseCode = "293", DepartmentCodeValue = "صنع" });
            modelBuilder.Entity<Course>().HasData(new Course { CourseName = "CourseName 294", CourseCode = "294", DepartmentCodeValue = "عمر" });
            modelBuilder.Entity<Course>().HasData(new Course { CourseName = "CourseName 295", CourseCode = "295", DepartmentCodeValue = "ريض" });
            modelBuilder.Entity<Course>().HasData(new Course { CourseName = "CourseName 296", CourseCode = "296", DepartmentCodeValue = "فيز" });
            modelBuilder.Entity<Course>().HasData(new Course { CourseName = "CourseName 297", CourseCode = "297", DepartmentCodeValue = "ميك" });
            modelBuilder.Entity<Course>().HasData(new Course { CourseName = "CourseName 298", CourseCode = "298", DepartmentCodeValue = "عام" });
            modelBuilder.Entity<Course>().HasData(new Course { CourseName = "CourseName 299", CourseCode = "299", DepartmentCodeValue = "هند" });
            modelBuilder.Entity<Course>().HasData(new Course { CourseName = "CourseName 300", CourseCode = "300", DepartmentCodeValue = "مدن" });
            modelBuilder.Entity<Course>().HasData(new Course { CourseName = "CourseName 301", CourseCode = "301", DepartmentCodeValue = "كھع" });
            modelBuilder.Entity<Course>().HasData(new Course { CourseName = "CourseName 302", CourseCode = "302", DepartmentCodeValue = "كهق" });
            modelBuilder.Entity<Course>().HasData(new Course { CourseName = "CourseName 303", CourseCode = "303", DepartmentCodeValue = "كهت" });
            modelBuilder.Entity<Course>().HasData(new Course { CourseName = "CourseName 304", CourseCode = "304", DepartmentCodeValue = "كهح" });
            modelBuilder.Entity<Course>().HasData(new Course { CourseName = "CourseName 305", CourseCode = "305", DepartmentCodeValue = "قوى" });
            modelBuilder.Entity<Course>().HasData(new Course { CourseName = "CourseName 306", CourseCode = "306", DepartmentCodeValue = "تمج" });
            modelBuilder.Entity<Course>().HasData(new Course { CourseName = "CourseName 307", CourseCode = "307", DepartmentCodeValue = "صنع" });
            modelBuilder.Entity<Course>().HasData(new Course { CourseName = "CourseName 308", CourseCode = "308", DepartmentCodeValue = "عمر" });
            modelBuilder.Entity<Course>().HasData(new Course { CourseName = "CourseName 309", CourseCode = "309", DepartmentCodeValue = "ريض" });
            modelBuilder.Entity<Course>().HasData(new Course { CourseName = "CourseName 310", CourseCode = "310", DepartmentCodeValue = "فيز" });
            modelBuilder.Entity<Course>().HasData(new Course { CourseName = "CourseName 311", CourseCode = "311", DepartmentCodeValue = "ميك" });
            modelBuilder.Entity<Course>().HasData(new Course { CourseName = "CourseName 312", CourseCode = "312", DepartmentCodeValue = "عام" });
            modelBuilder.Entity<Course>().HasData(new Course { CourseName = "CourseName 313", CourseCode = "313", DepartmentCodeValue = "هند" });
            modelBuilder.Entity<Course>().HasData(new Course { CourseName = "CourseName 314", CourseCode = "314", DepartmentCodeValue = "مدن" });
            modelBuilder.Entity<Course>().HasData(new Course { CourseName = "CourseName 315", CourseCode = "315", DepartmentCodeValue = "كھع" });
            modelBuilder.Entity<Course>().HasData(new Course { CourseName = "CourseName 316", CourseCode = "316", DepartmentCodeValue = "كهق" });
            modelBuilder.Entity<Course>().HasData(new Course { CourseName = "CourseName 317", CourseCode = "317", DepartmentCodeValue = "كهت" });
            modelBuilder.Entity<Course>().HasData(new Course { CourseName = "CourseName 318", CourseCode = "318", DepartmentCodeValue = "كهح" });
            modelBuilder.Entity<Course>().HasData(new Course { CourseName = "CourseName 319", CourseCode = "319", DepartmentCodeValue = "قوى" });
            modelBuilder.Entity<Course>().HasData(new Course { CourseName = "CourseName 320", CourseCode = "320", DepartmentCodeValue = "تمج" });
            modelBuilder.Entity<Course>().HasData(new Course { CourseName = "CourseName 321", CourseCode = "321", DepartmentCodeValue = "صنع" });
            modelBuilder.Entity<Course>().HasData(new Course { CourseName = "CourseName 322", CourseCode = "322", DepartmentCodeValue = "عمر" });
            modelBuilder.Entity<Course>().HasData(new Course { CourseName = "CourseName 323", CourseCode = "323", DepartmentCodeValue = "ريض" });
            modelBuilder.Entity<Course>().HasData(new Course { CourseName = "CourseName 324", CourseCode = "324", DepartmentCodeValue = "فيز" });

            //courseEnrollments:

            modelBuilder.Entity<CourseEnrollment>().HasData(new CourseEnrollment { CourseName = "CourseName 1", LevelName = grad2021.Models.LevelName.الإعدادية, BranchName = "الرياضيات والفيزيقا الهندسية", Term = grad2021.Models.Term.الأول });
            modelBuilder.Entity<CourseEnrollment>().HasData(new CourseEnrollment { CourseName = "CourseName 2", LevelName = grad2021.Models.LevelName.الإعدادية, BranchName = "الرياضيات والفيزيقا الهندسية", Term = grad2021.Models.Term.الثاني });
            modelBuilder.Entity<CourseEnrollment>().HasData(new CourseEnrollment { CourseName = "CourseName 3", LevelName = grad2021.Models.LevelName.الإعدادية, BranchName = "الرياضيات والفيزيقا الهندسية", Term = grad2021.Models.Term.الأول });
            modelBuilder.Entity<CourseEnrollment>().HasData(new CourseEnrollment { CourseName = "CourseName 4", LevelName = grad2021.Models.LevelName.الإعدادية, BranchName = "الرياضيات والفيزيقا الهندسية", Term = grad2021.Models.Term.الثاني });
            modelBuilder.Entity<CourseEnrollment>().HasData(new CourseEnrollment { CourseName = "CourseName 5", LevelName = grad2021.Models.LevelName.الإعدادية, BranchName = "الرياضيات والفيزيقا الهندسية", Term = grad2021.Models.Term.الأول });
            modelBuilder.Entity<CourseEnrollment>().HasData(new CourseEnrollment { CourseName = "CourseName 6", LevelName = grad2021.Models.LevelName.الإعدادية, BranchName = "الرياضيات والفيزيقا الهندسية", Term = grad2021.Models.Term.الثاني });
            modelBuilder.Entity<CourseEnrollment>().HasData(new CourseEnrollment { CourseName = "CourseName 7", LevelName = grad2021.Models.LevelName.الإعدادية, BranchName = "الرياضيات والفيزيقا الهندسية", Term = grad2021.Models.Term.الأول });
            modelBuilder.Entity<CourseEnrollment>().HasData(new CourseEnrollment { CourseName = "CourseName 8", LevelName = grad2021.Models.LevelName.الإعدادية, BranchName = "الرياضيات والفيزيقا الهندسية", Term = grad2021.Models.Term.الثاني });
            modelBuilder.Entity<CourseEnrollment>().HasData(new CourseEnrollment { CourseName = "CourseName 9", LevelName = grad2021.Models.LevelName.الإعدادية, BranchName = "الرياضيات والفيزيقا الهندسية", Term = grad2021.Models.Term.الأول });
            modelBuilder.Entity<CourseEnrollment>().HasData(new CourseEnrollment { CourseName = "CourseName 10", LevelName = grad2021.Models.LevelName.الإعدادية, BranchName = "الرياضيات والفيزيقا الهندسية", Term = grad2021.Models.Term.الثاني });
            modelBuilder.Entity<CourseEnrollment>().HasData(new CourseEnrollment { CourseName = "CourseName 11", LevelName = grad2021.Models.LevelName.الإعدادية, BranchName = "الرياضيات والفيزيقا الهندسية", Term = grad2021.Models.Term.الأول });
            modelBuilder.Entity<CourseEnrollment>().HasData(new CourseEnrollment { CourseName = "CourseName 12", LevelName = grad2021.Models.LevelName.الإعدادية, BranchName = "الرياضيات والفيزيقا الهندسية", Term = grad2021.Models.Term.الثاني });
            modelBuilder.Entity<CourseEnrollment>().HasData(new CourseEnrollment { CourseName = "CourseName 13", LevelName = grad2021.Models.LevelName.الأولى, BranchName = "الهندسة المدنية", Term = grad2021.Models.Term.الأول });
            modelBuilder.Entity<CourseEnrollment>().HasData(new CourseEnrollment { CourseName = "CourseName 14", LevelName = grad2021.Models.LevelName.الثانية, BranchName = "الهندسة المعمارية", Term = grad2021.Models.Term.الثاني });
            modelBuilder.Entity<CourseEnrollment>().HasData(new CourseEnrollment { CourseName = "CourseName 15", LevelName = grad2021.Models.LevelName.الثالثة, BranchName = "هندسة القوى والآلات الكهربية", Term = grad2021.Models.Term.الأول });
            modelBuilder.Entity<CourseEnrollment>().HasData(new CourseEnrollment { CourseName = "CourseName 16", LevelName = grad2021.Models.LevelName.الأولى, BranchName = "هندسة الإلكترونيات والاتصالات الكهربية", Term = grad2021.Models.Term.الثاني });
            modelBuilder.Entity<CourseEnrollment>().HasData(new CourseEnrollment { CourseName = "CourseName 17", LevelName = grad2021.Models.LevelName.الثانية, BranchName = "هندسة الحاسبات والنظم", Term = grad2021.Models.Term.الأول });
            modelBuilder.Entity<CourseEnrollment>().HasData(new CourseEnrollment { CourseName = "CourseName 18", LevelName = grad2021.Models.LevelName.الثالثة, BranchName = "الهندسة الميكانيكية", Term = grad2021.Models.Term.الثاني });
            modelBuilder.Entity<CourseEnrollment>().HasData(new CourseEnrollment { CourseName = "CourseName 19", LevelName = grad2021.Models.LevelName.الأولى, BranchName = "الهندسة المدنية", Term = grad2021.Models.Term.الأول });
            modelBuilder.Entity<CourseEnrollment>().HasData(new CourseEnrollment { CourseName = "CourseName 20", LevelName = grad2021.Models.LevelName.الثانية, BranchName = "الهندسة المعمارية", Term = grad2021.Models.Term.الثاني });
            modelBuilder.Entity<CourseEnrollment>().HasData(new CourseEnrollment { CourseName = "CourseName 21", LevelName = grad2021.Models.LevelName.الثالثة, BranchName = "هندسة القوى والآلات الكهربية", Term = grad2021.Models.Term.الأول });
            modelBuilder.Entity<CourseEnrollment>().HasData(new CourseEnrollment { CourseName = "CourseName 22", LevelName = grad2021.Models.LevelName.الأولى, BranchName = "هندسة الإلكترونيات والاتصالات الكهربية", Term = grad2021.Models.Term.الثاني });
            modelBuilder.Entity<CourseEnrollment>().HasData(new CourseEnrollment { CourseName = "CourseName 23", LevelName = grad2021.Models.LevelName.الثانية, BranchName = "هندسة الحاسبات والنظم", Term = grad2021.Models.Term.الأول });
            modelBuilder.Entity<CourseEnrollment>().HasData(new CourseEnrollment { CourseName = "CourseName 24", LevelName = grad2021.Models.LevelName.الثالثة, BranchName = "الهندسة الميكانيكية", Term = grad2021.Models.Term.الثاني });
            modelBuilder.Entity<CourseEnrollment>().HasData(new CourseEnrollment { CourseName = "CourseName 25", LevelName = grad2021.Models.LevelName.الأولى, BranchName = "الهندسة المدنية", Term = grad2021.Models.Term.الأول });
            modelBuilder.Entity<CourseEnrollment>().HasData(new CourseEnrollment { CourseName = "CourseName 26", LevelName = grad2021.Models.LevelName.الثانية, BranchName = "الهندسة المعمارية", Term = grad2021.Models.Term.الثاني });
            modelBuilder.Entity<CourseEnrollment>().HasData(new CourseEnrollment { CourseName = "CourseName 27", LevelName = grad2021.Models.LevelName.الثالثة, BranchName = "هندسة القوى والآلات الكهربية", Term = grad2021.Models.Term.الأول });
            modelBuilder.Entity<CourseEnrollment>().HasData(new CourseEnrollment { CourseName = "CourseName 28", LevelName = grad2021.Models.LevelName.الأولى, BranchName = "هندسة الإلكترونيات والاتصالات الكهربية", Term = grad2021.Models.Term.الثاني });
            modelBuilder.Entity<CourseEnrollment>().HasData(new CourseEnrollment { CourseName = "CourseName 29", LevelName = grad2021.Models.LevelName.الثانية, BranchName = "هندسة الحاسبات والنظم", Term = grad2021.Models.Term.الأول });
            modelBuilder.Entity<CourseEnrollment>().HasData(new CourseEnrollment { CourseName = "CourseName 30", LevelName = grad2021.Models.LevelName.الثالثة, BranchName = "الهندسة الميكانيكية", Term = grad2021.Models.Term.الثاني });
            modelBuilder.Entity<CourseEnrollment>().HasData(new CourseEnrollment { CourseName = "CourseName 31", LevelName = grad2021.Models.LevelName.الأولى, BranchName = "الهندسة المدنية", Term = grad2021.Models.Term.الأول });
            modelBuilder.Entity<CourseEnrollment>().HasData(new CourseEnrollment { CourseName = "CourseName 32", LevelName = grad2021.Models.LevelName.الثانية, BranchName = "الهندسة المعمارية", Term = grad2021.Models.Term.الثاني });
            modelBuilder.Entity<CourseEnrollment>().HasData(new CourseEnrollment { CourseName = "CourseName 33", LevelName = grad2021.Models.LevelName.الثالثة, BranchName = "هندسة القوى والآلات الكهربية", Term = grad2021.Models.Term.الأول });
            modelBuilder.Entity<CourseEnrollment>().HasData(new CourseEnrollment { CourseName = "CourseName 34", LevelName = grad2021.Models.LevelName.الأولى, BranchName = "هندسة الإلكترونيات والاتصالات الكهربية", Term = grad2021.Models.Term.الثاني });
            modelBuilder.Entity<CourseEnrollment>().HasData(new CourseEnrollment { CourseName = "CourseName 35", LevelName = grad2021.Models.LevelName.الثانية, BranchName = "هندسة الحاسبات والنظم", Term = grad2021.Models.Term.الأول });
            modelBuilder.Entity<CourseEnrollment>().HasData(new CourseEnrollment { CourseName = "CourseName 36", LevelName = grad2021.Models.LevelName.الثالثة, BranchName = "الهندسة الميكانيكية", Term = grad2021.Models.Term.الثاني });
            modelBuilder.Entity<CourseEnrollment>().HasData(new CourseEnrollment { CourseName = "CourseName 37", LevelName = grad2021.Models.LevelName.الأولى, BranchName = "الهندسة المدنية", Term = grad2021.Models.Term.الأول });
            modelBuilder.Entity<CourseEnrollment>().HasData(new CourseEnrollment { CourseName = "CourseName 38", LevelName = grad2021.Models.LevelName.الثانية, BranchName = "الهندسة المعمارية", Term = grad2021.Models.Term.الثاني });
            modelBuilder.Entity<CourseEnrollment>().HasData(new CourseEnrollment { CourseName = "CourseName 39", LevelName = grad2021.Models.LevelName.الثالثة, BranchName = "هندسة القوى والآلات الكهربية", Term = grad2021.Models.Term.الأول });
            modelBuilder.Entity<CourseEnrollment>().HasData(new CourseEnrollment { CourseName = "CourseName 40", LevelName = grad2021.Models.LevelName.الأولى, BranchName = "هندسة الإلكترونيات والاتصالات الكهربية", Term = grad2021.Models.Term.الثاني });
            modelBuilder.Entity<CourseEnrollment>().HasData(new CourseEnrollment { CourseName = "CourseName 41", LevelName = grad2021.Models.LevelName.الثانية, BranchName = "هندسة الحاسبات والنظم", Term = grad2021.Models.Term.الأول });
            modelBuilder.Entity<CourseEnrollment>().HasData(new CourseEnrollment { CourseName = "CourseName 42", LevelName = grad2021.Models.LevelName.الثالثة, BranchName = "الهندسة الميكانيكية", Term = grad2021.Models.Term.الثاني });
            modelBuilder.Entity<CourseEnrollment>().HasData(new CourseEnrollment { CourseName = "CourseName 43", LevelName = grad2021.Models.LevelName.الأولى, BranchName = "الهندسة المدنية", Term = grad2021.Models.Term.الأول });
            modelBuilder.Entity<CourseEnrollment>().HasData(new CourseEnrollment { CourseName = "CourseName 44", LevelName = grad2021.Models.LevelName.الثانية, BranchName = "الهندسة المعمارية", Term = grad2021.Models.Term.الثاني });
            modelBuilder.Entity<CourseEnrollment>().HasData(new CourseEnrollment { CourseName = "CourseName 45", LevelName = grad2021.Models.LevelName.الثالثة, BranchName = "هندسة القوى والآلات الكهربية", Term = grad2021.Models.Term.الأول });
            modelBuilder.Entity<CourseEnrollment>().HasData(new CourseEnrollment { CourseName = "CourseName 46", LevelName = grad2021.Models.LevelName.الأولى, BranchName = "هندسة الإلكترونيات والاتصالات الكهربية", Term = grad2021.Models.Term.الثاني });
            modelBuilder.Entity<CourseEnrollment>().HasData(new CourseEnrollment { CourseName = "CourseName 47", LevelName = grad2021.Models.LevelName.الثانية, BranchName = "هندسة الحاسبات والنظم", Term = grad2021.Models.Term.الأول });
            modelBuilder.Entity<CourseEnrollment>().HasData(new CourseEnrollment { CourseName = "CourseName 48", LevelName = grad2021.Models.LevelName.الثالثة, BranchName = "الهندسة الميكانيكية", Term = grad2021.Models.Term.الثاني });
            modelBuilder.Entity<CourseEnrollment>().HasData(new CourseEnrollment { CourseName = "CourseName 49", LevelName = grad2021.Models.LevelName.الأولى, BranchName = "الهندسة المدنية", Term = grad2021.Models.Term.الأول });
            modelBuilder.Entity<CourseEnrollment>().HasData(new CourseEnrollment { CourseName = "CourseName 50", LevelName = grad2021.Models.LevelName.الثانية, BranchName = "الهندسة المعمارية", Term = grad2021.Models.Term.الثاني });
            modelBuilder.Entity<CourseEnrollment>().HasData(new CourseEnrollment { CourseName = "CourseName 51", LevelName = grad2021.Models.LevelName.الثالثة, BranchName = "هندسة القوى والآلات الكهربية", Term = grad2021.Models.Term.الأول });
            modelBuilder.Entity<CourseEnrollment>().HasData(new CourseEnrollment { CourseName = "CourseName 52", LevelName = grad2021.Models.LevelName.الأولى, BranchName = "هندسة الإلكترونيات والاتصالات الكهربية", Term = grad2021.Models.Term.الثاني });
            modelBuilder.Entity<CourseEnrollment>().HasData(new CourseEnrollment { CourseName = "CourseName 53", LevelName = grad2021.Models.LevelName.الثانية, BranchName = "هندسة الحاسبات والنظم", Term = grad2021.Models.Term.الأول });
            modelBuilder.Entity<CourseEnrollment>().HasData(new CourseEnrollment { CourseName = "CourseName 54", LevelName = grad2021.Models.LevelName.الثالثة, BranchName = "الهندسة الميكانيكية", Term = grad2021.Models.Term.الثاني });
            modelBuilder.Entity<CourseEnrollment>().HasData(new CourseEnrollment { CourseName = "CourseName 55", LevelName = grad2021.Models.LevelName.الأولى, BranchName = "الهندسة المدنية", Term = grad2021.Models.Term.الأول });
            modelBuilder.Entity<CourseEnrollment>().HasData(new CourseEnrollment { CourseName = "CourseName 56", LevelName = grad2021.Models.LevelName.الثانية, BranchName = "الهندسة المعمارية", Term = grad2021.Models.Term.الثاني });
            modelBuilder.Entity<CourseEnrollment>().HasData(new CourseEnrollment { CourseName = "CourseName 57", LevelName = grad2021.Models.LevelName.الثالثة, BranchName = "هندسة القوى والآلات الكهربية", Term = grad2021.Models.Term.الأول });
            modelBuilder.Entity<CourseEnrollment>().HasData(new CourseEnrollment { CourseName = "CourseName 58", LevelName = grad2021.Models.LevelName.الأولى, BranchName = "هندسة الإلكترونيات والاتصالات الكهربية", Term = grad2021.Models.Term.الثاني });
            modelBuilder.Entity<CourseEnrollment>().HasData(new CourseEnrollment { CourseName = "CourseName 59", LevelName = grad2021.Models.LevelName.الثانية, BranchName = "هندسة الحاسبات والنظم", Term = grad2021.Models.Term.الأول });
            modelBuilder.Entity<CourseEnrollment>().HasData(new CourseEnrollment { CourseName = "CourseName 60", LevelName = grad2021.Models.LevelName.الثالثة, BranchName = "الهندسة الميكانيكية", Term = grad2021.Models.Term.الثاني });
            modelBuilder.Entity<CourseEnrollment>().HasData(new CourseEnrollment { CourseName = "CourseName 61", LevelName = grad2021.Models.LevelName.الأولى, BranchName = "الهندسة المدنية", Term = grad2021.Models.Term.الأول });
            modelBuilder.Entity<CourseEnrollment>().HasData(new CourseEnrollment { CourseName = "CourseName 62", LevelName = grad2021.Models.LevelName.الثانية, BranchName = "الهندسة المعمارية", Term = grad2021.Models.Term.الثاني });
            modelBuilder.Entity<CourseEnrollment>().HasData(new CourseEnrollment { CourseName = "CourseName 63", LevelName = grad2021.Models.LevelName.الثالثة, BranchName = "هندسة القوى والآلات الكهربية", Term = grad2021.Models.Term.الأول });
            modelBuilder.Entity<CourseEnrollment>().HasData(new CourseEnrollment { CourseName = "CourseName 64", LevelName = grad2021.Models.LevelName.الأولى, BranchName = "هندسة الإلكترونيات والاتصالات الكهربية", Term = grad2021.Models.Term.الثاني });
            modelBuilder.Entity<CourseEnrollment>().HasData(new CourseEnrollment { CourseName = "CourseName 65", LevelName = grad2021.Models.LevelName.الثانية, BranchName = "هندسة الحاسبات والنظم", Term = grad2021.Models.Term.الأول });
            modelBuilder.Entity<CourseEnrollment>().HasData(new CourseEnrollment { CourseName = "CourseName 66", LevelName = grad2021.Models.LevelName.الثالثة, BranchName = "الهندسة الميكانيكية", Term = grad2021.Models.Term.الثاني });
            modelBuilder.Entity<CourseEnrollment>().HasData(new CourseEnrollment { CourseName = "CourseName 67", LevelName = grad2021.Models.LevelName.الأولى, BranchName = "الهندسة المدنية", Term = grad2021.Models.Term.الأول });
            modelBuilder.Entity<CourseEnrollment>().HasData(new CourseEnrollment { CourseName = "CourseName 68", LevelName = grad2021.Models.LevelName.الثانية, BranchName = "الهندسة المعمارية", Term = grad2021.Models.Term.الثاني });
            modelBuilder.Entity<CourseEnrollment>().HasData(new CourseEnrollment { CourseName = "CourseName 69", LevelName = grad2021.Models.LevelName.الثالثة, BranchName = "هندسة القوى والآلات الكهربية", Term = grad2021.Models.Term.الأول });
            modelBuilder.Entity<CourseEnrollment>().HasData(new CourseEnrollment { CourseName = "CourseName 70", LevelName = grad2021.Models.LevelName.الأولى, BranchName = "هندسة الإلكترونيات والاتصالات الكهربية", Term = grad2021.Models.Term.الثاني });
            modelBuilder.Entity<CourseEnrollment>().HasData(new CourseEnrollment { CourseName = "CourseName 71", LevelName = grad2021.Models.LevelName.الثانية, BranchName = "هندسة الحاسبات والنظم", Term = grad2021.Models.Term.الأول });
            modelBuilder.Entity<CourseEnrollment>().HasData(new CourseEnrollment { CourseName = "CourseName 72", LevelName = grad2021.Models.LevelName.الثالثة, BranchName = "الهندسة الميكانيكية", Term = grad2021.Models.Term.الثاني });
            modelBuilder.Entity<CourseEnrollment>().HasData(new CourseEnrollment { CourseName = "CourseName 73", LevelName = grad2021.Models.LevelName.الأولى, BranchName = "الهندسة المدنية", Term = grad2021.Models.Term.الأول });
            modelBuilder.Entity<CourseEnrollment>().HasData(new CourseEnrollment { CourseName = "CourseName 74", LevelName = grad2021.Models.LevelName.الثانية, BranchName = "الهندسة المعمارية", Term = grad2021.Models.Term.الثاني });
            modelBuilder.Entity<CourseEnrollment>().HasData(new CourseEnrollment { CourseName = "CourseName 75", LevelName = grad2021.Models.LevelName.الثالثة, BranchName = "هندسة القوى والآلات الكهربية", Term = grad2021.Models.Term.الأول });
            modelBuilder.Entity<CourseEnrollment>().HasData(new CourseEnrollment { CourseName = "CourseName 76", LevelName = grad2021.Models.LevelName.الأولى, BranchName = "هندسة الإلكترونيات والاتصالات الكهربية", Term = grad2021.Models.Term.الثاني });
            modelBuilder.Entity<CourseEnrollment>().HasData(new CourseEnrollment { CourseName = "CourseName 77", LevelName = grad2021.Models.LevelName.الثانية, BranchName = "هندسة الحاسبات والنظم", Term = grad2021.Models.Term.الأول });
            modelBuilder.Entity<CourseEnrollment>().HasData(new CourseEnrollment { CourseName = "CourseName 78", LevelName = grad2021.Models.LevelName.الثالثة, BranchName = "الهندسة الميكانيكية", Term = grad2021.Models.Term.الثاني });
            modelBuilder.Entity<CourseEnrollment>().HasData(new CourseEnrollment { CourseName = "CourseName 79", LevelName = grad2021.Models.LevelName.الأولى, BranchName = "الهندسة المدنية", Term = grad2021.Models.Term.الأول });
            modelBuilder.Entity<CourseEnrollment>().HasData(new CourseEnrollment { CourseName = "CourseName 80", LevelName = grad2021.Models.LevelName.الثانية, BranchName = "الهندسة المعمارية", Term = grad2021.Models.Term.الثاني });
            modelBuilder.Entity<CourseEnrollment>().HasData(new CourseEnrollment { CourseName = "CourseName 81", LevelName = grad2021.Models.LevelName.الثالثة, BranchName = "هندسة القوى والآلات الكهربية", Term = grad2021.Models.Term.الأول });
            modelBuilder.Entity<CourseEnrollment>().HasData(new CourseEnrollment { CourseName = "CourseName 82", LevelName = grad2021.Models.LevelName.الأولى, BranchName = "هندسة الإلكترونيات والاتصالات الكهربية", Term = grad2021.Models.Term.الثاني });
            modelBuilder.Entity<CourseEnrollment>().HasData(new CourseEnrollment { CourseName = "CourseName 83", LevelName = grad2021.Models.LevelName.الثانية, BranchName = "هندسة الحاسبات والنظم", Term = grad2021.Models.Term.الأول });
            modelBuilder.Entity<CourseEnrollment>().HasData(new CourseEnrollment { CourseName = "CourseName 84", LevelName = grad2021.Models.LevelName.الثالثة, BranchName = "الهندسة الميكانيكية", Term = grad2021.Models.Term.الثاني });
            modelBuilder.Entity<CourseEnrollment>().HasData(new CourseEnrollment { CourseName = "CourseName 85", LevelName = grad2021.Models.LevelName.الأولى, BranchName = "الهندسة المدنية", Term = grad2021.Models.Term.الأول });
            modelBuilder.Entity<CourseEnrollment>().HasData(new CourseEnrollment { CourseName = "CourseName 86", LevelName = grad2021.Models.LevelName.الثانية, BranchName = "الهندسة المعمارية", Term = grad2021.Models.Term.الثاني });
            modelBuilder.Entity<CourseEnrollment>().HasData(new CourseEnrollment { CourseName = "CourseName 87", LevelName = grad2021.Models.LevelName.الثالثة, BranchName = "هندسة القوى والآلات الكهربية", Term = grad2021.Models.Term.الأول });
            modelBuilder.Entity<CourseEnrollment>().HasData(new CourseEnrollment { CourseName = "CourseName 88", LevelName = grad2021.Models.LevelName.الأولى, BranchName = "هندسة الإلكترونيات والاتصالات الكهربية", Term = grad2021.Models.Term.الثاني });
            modelBuilder.Entity<CourseEnrollment>().HasData(new CourseEnrollment { CourseName = "CourseName 89", LevelName = grad2021.Models.LevelName.الثانية, BranchName = "هندسة الحاسبات والنظم", Term = grad2021.Models.Term.الأول });
            modelBuilder.Entity<CourseEnrollment>().HasData(new CourseEnrollment { CourseName = "CourseName 90", LevelName = grad2021.Models.LevelName.الثالثة, BranchName = "الهندسة الميكانيكية", Term = grad2021.Models.Term.الثاني });
            modelBuilder.Entity<CourseEnrollment>().HasData(new CourseEnrollment { CourseName = "CourseName 91", LevelName = grad2021.Models.LevelName.الأولى, BranchName = "الهندسة المدنية", Term = grad2021.Models.Term.الأول });
            modelBuilder.Entity<CourseEnrollment>().HasData(new CourseEnrollment { CourseName = "CourseName 92", LevelName = grad2021.Models.LevelName.الثانية, BranchName = "الهندسة المعمارية", Term = grad2021.Models.Term.الثاني });
            modelBuilder.Entity<CourseEnrollment>().HasData(new CourseEnrollment { CourseName = "CourseName 93", LevelName = grad2021.Models.LevelName.الثالثة, BranchName = "هندسة القوى والآلات الكهربية", Term = grad2021.Models.Term.الأول });
            modelBuilder.Entity<CourseEnrollment>().HasData(new CourseEnrollment { CourseName = "CourseName 94", LevelName = grad2021.Models.LevelName.الأولى, BranchName = "هندسة الإلكترونيات والاتصالات الكهربية", Term = grad2021.Models.Term.الثاني });
            modelBuilder.Entity<CourseEnrollment>().HasData(new CourseEnrollment { CourseName = "CourseName 95", LevelName = grad2021.Models.LevelName.الثانية, BranchName = "هندسة الحاسبات والنظم", Term = grad2021.Models.Term.الأول });
            modelBuilder.Entity<CourseEnrollment>().HasData(new CourseEnrollment { CourseName = "CourseName 96", LevelName = grad2021.Models.LevelName.الثالثة, BranchName = "الهندسة الميكانيكية", Term = grad2021.Models.Term.الثاني });
            modelBuilder.Entity<CourseEnrollment>().HasData(new CourseEnrollment { CourseName = "CourseName 97", LevelName = grad2021.Models.LevelName.الأولى, BranchName = "الهندسة المدنية", Term = grad2021.Models.Term.الأول });
            modelBuilder.Entity<CourseEnrollment>().HasData(new CourseEnrollment { CourseName = "CourseName 98", LevelName = grad2021.Models.LevelName.الثانية, BranchName = "الهندسة المعمارية", Term = grad2021.Models.Term.الثاني });
            modelBuilder.Entity<CourseEnrollment>().HasData(new CourseEnrollment { CourseName = "CourseName 99", LevelName = grad2021.Models.LevelName.الثالثة, BranchName = "هندسة القوى والآلات الكهربية", Term = grad2021.Models.Term.الأول });
            modelBuilder.Entity<CourseEnrollment>().HasData(new CourseEnrollment { CourseName = "CourseName 100", LevelName = grad2021.Models.LevelName.الأولى, BranchName = "هندسة الإلكترونيات والاتصالات الكهربية", Term = grad2021.Models.Term.الثاني });
            modelBuilder.Entity<CourseEnrollment>().HasData(new CourseEnrollment { CourseName = "CourseName 101", LevelName = grad2021.Models.LevelName.الثانية, BranchName = "هندسة الحاسبات والنظم", Term = grad2021.Models.Term.الأول });
            modelBuilder.Entity<CourseEnrollment>().HasData(new CourseEnrollment { CourseName = "CourseName 102", LevelName = grad2021.Models.LevelName.الثالثة, BranchName = "الهندسة الميكانيكية", Term = grad2021.Models.Term.الثاني });
            modelBuilder.Entity<CourseEnrollment>().HasData(new CourseEnrollment { CourseName = "CourseName 103", LevelName = grad2021.Models.LevelName.الأولى, BranchName = "الهندسة المدنية", Term = grad2021.Models.Term.الأول });
            modelBuilder.Entity<CourseEnrollment>().HasData(new CourseEnrollment { CourseName = "CourseName 104", LevelName = grad2021.Models.LevelName.الثانية, BranchName = "الهندسة المعمارية", Term = grad2021.Models.Term.الثاني });
            modelBuilder.Entity<CourseEnrollment>().HasData(new CourseEnrollment { CourseName = "CourseName 105", LevelName = grad2021.Models.LevelName.الثالثة, BranchName = "هندسة القوى والآلات الكهربية", Term = grad2021.Models.Term.الأول });
            modelBuilder.Entity<CourseEnrollment>().HasData(new CourseEnrollment { CourseName = "CourseName 106", LevelName = grad2021.Models.LevelName.الأولى, BranchName = "هندسة الإلكترونيات والاتصالات الكهربية", Term = grad2021.Models.Term.الثاني });
            modelBuilder.Entity<CourseEnrollment>().HasData(new CourseEnrollment { CourseName = "CourseName 107", LevelName = grad2021.Models.LevelName.الثانية, BranchName = "هندسة الحاسبات والنظم", Term = grad2021.Models.Term.الأول });
            modelBuilder.Entity<CourseEnrollment>().HasData(new CourseEnrollment { CourseName = "CourseName 108", LevelName = grad2021.Models.LevelName.الثالثة, BranchName = "الهندسة الميكانيكية", Term = grad2021.Models.Term.الثاني });
            modelBuilder.Entity<CourseEnrollment>().HasData(new CourseEnrollment { CourseName = "CourseName 109", LevelName = grad2021.Models.LevelName.الأولى, BranchName = "الهندسة المدنية", Term = grad2021.Models.Term.الأول });
            modelBuilder.Entity<CourseEnrollment>().HasData(new CourseEnrollment { CourseName = "CourseName 110", LevelName = grad2021.Models.LevelName.الثانية, BranchName = "الهندسة المعمارية", Term = grad2021.Models.Term.الثاني });
            modelBuilder.Entity<CourseEnrollment>().HasData(new CourseEnrollment { CourseName = "CourseName 111", LevelName = grad2021.Models.LevelName.الثالثة, BranchName = "هندسة القوى والآلات الكهربية", Term = grad2021.Models.Term.الأول });
            modelBuilder.Entity<CourseEnrollment>().HasData(new CourseEnrollment { CourseName = "CourseName 112", LevelName = grad2021.Models.LevelName.الأولى, BranchName = "هندسة الإلكترونيات والاتصالات الكهربية", Term = grad2021.Models.Term.الثاني });
            modelBuilder.Entity<CourseEnrollment>().HasData(new CourseEnrollment { CourseName = "CourseName 113", LevelName = grad2021.Models.LevelName.الثانية, BranchName = "هندسة الحاسبات والنظم", Term = grad2021.Models.Term.الأول });
            modelBuilder.Entity<CourseEnrollment>().HasData(new CourseEnrollment { CourseName = "CourseName 114", LevelName = grad2021.Models.LevelName.الثالثة, BranchName = "الهندسة الميكانيكية", Term = grad2021.Models.Term.الثاني });
            modelBuilder.Entity<CourseEnrollment>().HasData(new CourseEnrollment { CourseName = "CourseName 115", LevelName = grad2021.Models.LevelName.الأولى, BranchName = "الهندسة المدنية", Term = grad2021.Models.Term.الأول });
            modelBuilder.Entity<CourseEnrollment>().HasData(new CourseEnrollment { CourseName = "CourseName 116", LevelName = grad2021.Models.LevelName.الثانية, BranchName = "الهندسة المعمارية", Term = grad2021.Models.Term.الثاني });
            modelBuilder.Entity<CourseEnrollment>().HasData(new CourseEnrollment { CourseName = "CourseName 117", LevelName = grad2021.Models.LevelName.الثالثة, BranchName = "هندسة القوى والآلات الكهربية", Term = grad2021.Models.Term.الأول });
            modelBuilder.Entity<CourseEnrollment>().HasData(new CourseEnrollment { CourseName = "CourseName 118", LevelName = grad2021.Models.LevelName.الأولى, BranchName = "هندسة الإلكترونيات والاتصالات الكهربية", Term = grad2021.Models.Term.الثاني });
            modelBuilder.Entity<CourseEnrollment>().HasData(new CourseEnrollment { CourseName = "CourseName 119", LevelName = grad2021.Models.LevelName.الثانية, BranchName = "هندسة الحاسبات والنظم", Term = grad2021.Models.Term.الأول });
            modelBuilder.Entity<CourseEnrollment>().HasData(new CourseEnrollment { CourseName = "CourseName 120", LevelName = grad2021.Models.LevelName.الثالثة, BranchName = "الهندسة الميكانيكية", Term = grad2021.Models.Term.الثاني });
            modelBuilder.Entity<CourseEnrollment>().HasData(new CourseEnrollment { CourseName = "CourseName 121", LevelName = grad2021.Models.LevelName.الأولى, BranchName = "الهندسة المدنية", Term = grad2021.Models.Term.الأول });
            modelBuilder.Entity<CourseEnrollment>().HasData(new CourseEnrollment { CourseName = "CourseName 122", LevelName = grad2021.Models.LevelName.الثانية, BranchName = "الهندسة المعمارية", Term = grad2021.Models.Term.الثاني });
            modelBuilder.Entity<CourseEnrollment>().HasData(new CourseEnrollment { CourseName = "CourseName 123", LevelName = grad2021.Models.LevelName.الثالثة, BranchName = "هندسة القوى والآلات الكهربية", Term = grad2021.Models.Term.الأول });
            modelBuilder.Entity<CourseEnrollment>().HasData(new CourseEnrollment { CourseName = "CourseName 124", LevelName = grad2021.Models.LevelName.الأولى, BranchName = "هندسة الإلكترونيات والاتصالات الكهربية", Term = grad2021.Models.Term.الثاني });
            modelBuilder.Entity<CourseEnrollment>().HasData(new CourseEnrollment { CourseName = "CourseName 125", LevelName = grad2021.Models.LevelName.الثانية, BranchName = "هندسة الحاسبات والنظم", Term = grad2021.Models.Term.الأول });
            modelBuilder.Entity<CourseEnrollment>().HasData(new CourseEnrollment { CourseName = "CourseName 126", LevelName = grad2021.Models.LevelName.الثالثة, BranchName = "الهندسة الميكانيكية", Term = grad2021.Models.Term.الثاني });
            modelBuilder.Entity<CourseEnrollment>().HasData(new CourseEnrollment { CourseName = "CourseName 127", LevelName = grad2021.Models.LevelName.الأولى, BranchName = "الهندسة المدنية", Term = grad2021.Models.Term.الأول });
            modelBuilder.Entity<CourseEnrollment>().HasData(new CourseEnrollment { CourseName = "CourseName 128", LevelName = grad2021.Models.LevelName.الثانية, BranchName = "الهندسة المعمارية", Term = grad2021.Models.Term.الثاني });
            modelBuilder.Entity<CourseEnrollment>().HasData(new CourseEnrollment { CourseName = "CourseName 129", LevelName = grad2021.Models.LevelName.الثالثة, BranchName = "هندسة القوى والآلات الكهربية", Term = grad2021.Models.Term.الأول });
            modelBuilder.Entity<CourseEnrollment>().HasData(new CourseEnrollment { CourseName = "CourseName 130", LevelName = grad2021.Models.LevelName.الأولى, BranchName = "هندسة الإلكترونيات والاتصالات الكهربية", Term = grad2021.Models.Term.الثاني });
            modelBuilder.Entity<CourseEnrollment>().HasData(new CourseEnrollment { CourseName = "CourseName 131", LevelName = grad2021.Models.LevelName.الثانية, BranchName = "هندسة الحاسبات والنظم", Term = grad2021.Models.Term.الأول });
            modelBuilder.Entity<CourseEnrollment>().HasData(new CourseEnrollment { CourseName = "CourseName 132", LevelName = grad2021.Models.LevelName.الثالثة, BranchName = "الهندسة الميكانيكية", Term = grad2021.Models.Term.الثاني });
            modelBuilder.Entity<CourseEnrollment>().HasData(new CourseEnrollment { CourseName = "CourseName 133", LevelName = grad2021.Models.LevelName.الأولى, BranchName = "الهندسة المدنية", Term = grad2021.Models.Term.الأول });
            modelBuilder.Entity<CourseEnrollment>().HasData(new CourseEnrollment { CourseName = "CourseName 134", LevelName = grad2021.Models.LevelName.الثانية, BranchName = "الهندسة المعمارية", Term = grad2021.Models.Term.الثاني });
            modelBuilder.Entity<CourseEnrollment>().HasData(new CourseEnrollment { CourseName = "CourseName 135", LevelName = grad2021.Models.LevelName.الثالثة, BranchName = "هندسة القوى والآلات الكهربية", Term = grad2021.Models.Term.الأول });
            modelBuilder.Entity<CourseEnrollment>().HasData(new CourseEnrollment { CourseName = "CourseName 136", LevelName = grad2021.Models.LevelName.الأولى, BranchName = "هندسة الإلكترونيات والاتصالات الكهربية", Term = grad2021.Models.Term.الثاني });
            modelBuilder.Entity<CourseEnrollment>().HasData(new CourseEnrollment { CourseName = "CourseName 137", LevelName = grad2021.Models.LevelName.الثانية, BranchName = "هندسة الحاسبات والنظم", Term = grad2021.Models.Term.الأول });
            modelBuilder.Entity<CourseEnrollment>().HasData(new CourseEnrollment { CourseName = "CourseName 138", LevelName = grad2021.Models.LevelName.الثالثة, BranchName = "الهندسة الميكانيكية", Term = grad2021.Models.Term.الثاني });
            modelBuilder.Entity<CourseEnrollment>().HasData(new CourseEnrollment { CourseName = "CourseName 139", LevelName = grad2021.Models.LevelName.الأولى, BranchName = "الهندسة المدنية", Term = grad2021.Models.Term.الأول });
            modelBuilder.Entity<CourseEnrollment>().HasData(new CourseEnrollment { CourseName = "CourseName 140", LevelName = grad2021.Models.LevelName.الثانية, BranchName = "الهندسة المعمارية", Term = grad2021.Models.Term.الثاني });
            modelBuilder.Entity<CourseEnrollment>().HasData(new CourseEnrollment { CourseName = "CourseName 141", LevelName = grad2021.Models.LevelName.الثالثة, BranchName = "هندسة القوى والآلات الكهربية", Term = grad2021.Models.Term.الأول });
            modelBuilder.Entity<CourseEnrollment>().HasData(new CourseEnrollment { CourseName = "CourseName 142", LevelName = grad2021.Models.LevelName.الأولى, BranchName = "هندسة الإلكترونيات والاتصالات الكهربية", Term = grad2021.Models.Term.الثاني });
            modelBuilder.Entity<CourseEnrollment>().HasData(new CourseEnrollment { CourseName = "CourseName 143", LevelName = grad2021.Models.LevelName.الثانية, BranchName = "هندسة الحاسبات والنظم", Term = grad2021.Models.Term.الأول });
            modelBuilder.Entity<CourseEnrollment>().HasData(new CourseEnrollment { CourseName = "CourseName 144", LevelName = grad2021.Models.LevelName.الثالثة, BranchName = "الهندسة الميكانيكية", Term = grad2021.Models.Term.الثاني });
            modelBuilder.Entity<CourseEnrollment>().HasData(new CourseEnrollment { CourseName = "CourseName 145", LevelName = grad2021.Models.LevelName.الأولى, BranchName = "الهندسة المدنية", Term = grad2021.Models.Term.الأول });
            modelBuilder.Entity<CourseEnrollment>().HasData(new CourseEnrollment { CourseName = "CourseName 146", LevelName = grad2021.Models.LevelName.الثانية, BranchName = "الهندسة المعمارية", Term = grad2021.Models.Term.الثاني });
            modelBuilder.Entity<CourseEnrollment>().HasData(new CourseEnrollment { CourseName = "CourseName 147", LevelName = grad2021.Models.LevelName.الثالثة, BranchName = "هندسة القوى والآلات الكهربية", Term = grad2021.Models.Term.الأول });
            modelBuilder.Entity<CourseEnrollment>().HasData(new CourseEnrollment { CourseName = "CourseName 148", LevelName = grad2021.Models.LevelName.الأولى, BranchName = "هندسة الإلكترونيات والاتصالات الكهربية", Term = grad2021.Models.Term.الثاني });
            modelBuilder.Entity<CourseEnrollment>().HasData(new CourseEnrollment { CourseName = "CourseName 149", LevelName = grad2021.Models.LevelName.الثانية, BranchName = "هندسة الحاسبات والنظم", Term = grad2021.Models.Term.الأول });
            modelBuilder.Entity<CourseEnrollment>().HasData(new CourseEnrollment { CourseName = "CourseName 150", LevelName = grad2021.Models.LevelName.الثالثة, BranchName = "الهندسة الميكانيكية", Term = grad2021.Models.Term.الثاني });
            modelBuilder.Entity<CourseEnrollment>().HasData(new CourseEnrollment { CourseName = "CourseName 151", LevelName = grad2021.Models.LevelName.الأولى, BranchName = "الهندسة المدنية", Term = grad2021.Models.Term.الأول });
            modelBuilder.Entity<CourseEnrollment>().HasData(new CourseEnrollment { CourseName = "CourseName 152", LevelName = grad2021.Models.LevelName.الثانية, BranchName = "الهندسة المعمارية", Term = grad2021.Models.Term.الثاني });
            modelBuilder.Entity<CourseEnrollment>().HasData(new CourseEnrollment { CourseName = "CourseName 153", LevelName = grad2021.Models.LevelName.الثالثة, BranchName = "هندسة القوى والآلات الكهربية", Term = grad2021.Models.Term.الأول });
            modelBuilder.Entity<CourseEnrollment>().HasData(new CourseEnrollment { CourseName = "CourseName 154", LevelName = grad2021.Models.LevelName.الأولى, BranchName = "هندسة الإلكترونيات والاتصالات الكهربية", Term = grad2021.Models.Term.الثاني });
            modelBuilder.Entity<CourseEnrollment>().HasData(new CourseEnrollment { CourseName = "CourseName 155", LevelName = grad2021.Models.LevelName.الثانية, BranchName = "هندسة الحاسبات والنظم", Term = grad2021.Models.Term.الأول });
            modelBuilder.Entity<CourseEnrollment>().HasData(new CourseEnrollment { CourseName = "CourseName 156", LevelName = grad2021.Models.LevelName.الثالثة, BranchName = "الهندسة الميكانيكية", Term = grad2021.Models.Term.الثاني });
            modelBuilder.Entity<CourseEnrollment>().HasData(new CourseEnrollment { CourseName = "CourseName 157", LevelName = grad2021.Models.LevelName.الأولى, BranchName = "الهندسة المدنية", Term = grad2021.Models.Term.الأول });
            modelBuilder.Entity<CourseEnrollment>().HasData(new CourseEnrollment { CourseName = "CourseName 158", LevelName = grad2021.Models.LevelName.الثانية, BranchName = "الهندسة المعمارية", Term = grad2021.Models.Term.الثاني });
            modelBuilder.Entity<CourseEnrollment>().HasData(new CourseEnrollment { CourseName = "CourseName 159", LevelName = grad2021.Models.LevelName.الثالثة, BranchName = "هندسة القوى والآلات الكهربية", Term = grad2021.Models.Term.الأول });
            modelBuilder.Entity<CourseEnrollment>().HasData(new CourseEnrollment { CourseName = "CourseName 160", LevelName = grad2021.Models.LevelName.الأولى, BranchName = "هندسة الإلكترونيات والاتصالات الكهربية", Term = grad2021.Models.Term.الثاني });
            modelBuilder.Entity<CourseEnrollment>().HasData(new CourseEnrollment { CourseName = "CourseName 161", LevelName = grad2021.Models.LevelName.الثانية, BranchName = "هندسة الحاسبات والنظم", Term = grad2021.Models.Term.الأول });
            modelBuilder.Entity<CourseEnrollment>().HasData(new CourseEnrollment { CourseName = "CourseName 162", LevelName = grad2021.Models.LevelName.الثالثة, BranchName = "الهندسة الميكانيكية", Term = grad2021.Models.Term.الثاني });
            modelBuilder.Entity<CourseEnrollment>().HasData(new CourseEnrollment { CourseName = "CourseName 163", LevelName = grad2021.Models.LevelName.الأولى, BranchName = "الهندسة المدنية", Term = grad2021.Models.Term.الأول });
            modelBuilder.Entity<CourseEnrollment>().HasData(new CourseEnrollment { CourseName = "CourseName 164", LevelName = grad2021.Models.LevelName.الثانية, BranchName = "الهندسة المعمارية", Term = grad2021.Models.Term.الثاني });
            modelBuilder.Entity<CourseEnrollment>().HasData(new CourseEnrollment { CourseName = "CourseName 165", LevelName = grad2021.Models.LevelName.الثالثة, BranchName = "هندسة القوى والآلات الكهربية", Term = grad2021.Models.Term.الأول });
            modelBuilder.Entity<CourseEnrollment>().HasData(new CourseEnrollment { CourseName = "CourseName 166", LevelName = grad2021.Models.LevelName.الأولى, BranchName = "هندسة الإلكترونيات والاتصالات الكهربية", Term = grad2021.Models.Term.الثاني });
            modelBuilder.Entity<CourseEnrollment>().HasData(new CourseEnrollment { CourseName = "CourseName 167", LevelName = grad2021.Models.LevelName.الثانية, BranchName = "هندسة الحاسبات والنظم", Term = grad2021.Models.Term.الأول });
            modelBuilder.Entity<CourseEnrollment>().HasData(new CourseEnrollment { CourseName = "CourseName 168", LevelName = grad2021.Models.LevelName.الثالثة, BranchName = "الهندسة الميكانيكية", Term = grad2021.Models.Term.الثاني });
            modelBuilder.Entity<CourseEnrollment>().HasData(new CourseEnrollment { CourseName = "CourseName 169", LevelName = grad2021.Models.LevelName.الأولى, BranchName = "الهندسة المدنية", Term = grad2021.Models.Term.الأول });
            modelBuilder.Entity<CourseEnrollment>().HasData(new CourseEnrollment { CourseName = "CourseName 170", LevelName = grad2021.Models.LevelName.الثانية, BranchName = "الهندسة المعمارية", Term = grad2021.Models.Term.الثاني });
            modelBuilder.Entity<CourseEnrollment>().HasData(new CourseEnrollment { CourseName = "CourseName 171", LevelName = grad2021.Models.LevelName.الثالثة, BranchName = "هندسة القوى والآلات الكهربية", Term = grad2021.Models.Term.الأول });
            modelBuilder.Entity<CourseEnrollment>().HasData(new CourseEnrollment { CourseName = "CourseName 172", LevelName = grad2021.Models.LevelName.الأولى, BranchName = "هندسة الإلكترونيات والاتصالات الكهربية", Term = grad2021.Models.Term.الثاني });
            modelBuilder.Entity<CourseEnrollment>().HasData(new CourseEnrollment { CourseName = "CourseName 173", LevelName = grad2021.Models.LevelName.الثانية, BranchName = "هندسة الحاسبات والنظم", Term = grad2021.Models.Term.الأول });
            modelBuilder.Entity<CourseEnrollment>().HasData(new CourseEnrollment { CourseName = "CourseName 174", LevelName = grad2021.Models.LevelName.الثالثة, BranchName = "الهندسة الميكانيكية", Term = grad2021.Models.Term.الثاني });
            modelBuilder.Entity<CourseEnrollment>().HasData(new CourseEnrollment { CourseName = "CourseName 175", LevelName = grad2021.Models.LevelName.الأولى, BranchName = "الهندسة المدنية", Term = grad2021.Models.Term.الأول });
            modelBuilder.Entity<CourseEnrollment>().HasData(new CourseEnrollment { CourseName = "CourseName 176", LevelName = grad2021.Models.LevelName.الثانية, BranchName = "الهندسة المعمارية", Term = grad2021.Models.Term.الثاني });
            modelBuilder.Entity<CourseEnrollment>().HasData(new CourseEnrollment { CourseName = "CourseName 177", LevelName = grad2021.Models.LevelName.الثالثة, BranchName = "هندسة القوى والآلات الكهربية", Term = grad2021.Models.Term.الأول });
            modelBuilder.Entity<CourseEnrollment>().HasData(new CourseEnrollment { CourseName = "CourseName 178", LevelName = grad2021.Models.LevelName.الأولى, BranchName = "هندسة الإلكترونيات والاتصالات الكهربية", Term = grad2021.Models.Term.الثاني });
            modelBuilder.Entity<CourseEnrollment>().HasData(new CourseEnrollment { CourseName = "CourseName 179", LevelName = grad2021.Models.LevelName.الثانية, BranchName = "هندسة الحاسبات والنظم", Term = grad2021.Models.Term.الأول });
            modelBuilder.Entity<CourseEnrollment>().HasData(new CourseEnrollment { CourseName = "CourseName 180", LevelName = grad2021.Models.LevelName.الثالثة, BranchName = "الهندسة الميكانيكية", Term = grad2021.Models.Term.الثاني });
            modelBuilder.Entity<CourseEnrollment>().HasData(new CourseEnrollment { CourseName = "CourseName 181", LevelName = grad2021.Models.LevelName.الأولى, BranchName = "الهندسة المدنية", Term = grad2021.Models.Term.الأول });
            modelBuilder.Entity<CourseEnrollment>().HasData(new CourseEnrollment { CourseName = "CourseName 182", LevelName = grad2021.Models.LevelName.الثانية, BranchName = "الهندسة المعمارية", Term = grad2021.Models.Term.الثاني });
            modelBuilder.Entity<CourseEnrollment>().HasData(new CourseEnrollment { CourseName = "CourseName 183", LevelName = grad2021.Models.LevelName.الثالثة, BranchName = "هندسة القوى والآلات الكهربية", Term = grad2021.Models.Term.الأول });
            modelBuilder.Entity<CourseEnrollment>().HasData(new CourseEnrollment { CourseName = "CourseName 184", LevelName = grad2021.Models.LevelName.الأولى, BranchName = "هندسة الإلكترونيات والاتصالات الكهربية", Term = grad2021.Models.Term.الثاني });
            modelBuilder.Entity<CourseEnrollment>().HasData(new CourseEnrollment { CourseName = "CourseName 185", LevelName = grad2021.Models.LevelName.الثانية, BranchName = "هندسة الحاسبات والنظم", Term = grad2021.Models.Term.الأول });
            modelBuilder.Entity<CourseEnrollment>().HasData(new CourseEnrollment { CourseName = "CourseName 186", LevelName = grad2021.Models.LevelName.الثالثة, BranchName = "الهندسة الميكانيكية", Term = grad2021.Models.Term.الثاني });
            modelBuilder.Entity<CourseEnrollment>().HasData(new CourseEnrollment { CourseName = "CourseName 187", LevelName = grad2021.Models.LevelName.الأولى, BranchName = "الهندسة المدنية", Term = grad2021.Models.Term.الأول });
            modelBuilder.Entity<CourseEnrollment>().HasData(new CourseEnrollment { CourseName = "CourseName 188", LevelName = grad2021.Models.LevelName.الثانية, BranchName = "الهندسة المعمارية", Term = grad2021.Models.Term.الثاني });
            modelBuilder.Entity<CourseEnrollment>().HasData(new CourseEnrollment { CourseName = "CourseName 189", LevelName = grad2021.Models.LevelName.الثالثة, BranchName = "هندسة القوى والآلات الكهربية", Term = grad2021.Models.Term.الأول });
            modelBuilder.Entity<CourseEnrollment>().HasData(new CourseEnrollment { CourseName = "CourseName 190", LevelName = grad2021.Models.LevelName.الأولى, BranchName = "هندسة الإلكترونيات والاتصالات الكهربية", Term = grad2021.Models.Term.الثاني });
            modelBuilder.Entity<CourseEnrollment>().HasData(new CourseEnrollment { CourseName = "CourseName 191", LevelName = grad2021.Models.LevelName.الثانية, BranchName = "هندسة الحاسبات والنظم", Term = grad2021.Models.Term.الأول });
            modelBuilder.Entity<CourseEnrollment>().HasData(new CourseEnrollment { CourseName = "CourseName 192", LevelName = grad2021.Models.LevelName.الثالثة, BranchName = "الهندسة الميكانيكية", Term = grad2021.Models.Term.الثاني });
            modelBuilder.Entity<CourseEnrollment>().HasData(new CourseEnrollment { CourseName = "CourseName 193", LevelName = grad2021.Models.LevelName.الأولى, BranchName = "الهندسة المدنية", Term = grad2021.Models.Term.الأول });
            modelBuilder.Entity<CourseEnrollment>().HasData(new CourseEnrollment { CourseName = "CourseName 194", LevelName = grad2021.Models.LevelName.الثانية, BranchName = "الهندسة المعمارية", Term = grad2021.Models.Term.الثاني });
            modelBuilder.Entity<CourseEnrollment>().HasData(new CourseEnrollment { CourseName = "CourseName 195", LevelName = grad2021.Models.LevelName.الثالثة, BranchName = "هندسة القوى والآلات الكهربية", Term = grad2021.Models.Term.الأول });
            modelBuilder.Entity<CourseEnrollment>().HasData(new CourseEnrollment { CourseName = "CourseName 196", LevelName = grad2021.Models.LevelName.الأولى, BranchName = "هندسة الإلكترونيات والاتصالات الكهربية", Term = grad2021.Models.Term.الثاني });
            modelBuilder.Entity<CourseEnrollment>().HasData(new CourseEnrollment { CourseName = "CourseName 197", LevelName = grad2021.Models.LevelName.الثانية, BranchName = "هندسة الحاسبات والنظم", Term = grad2021.Models.Term.الأول });
            modelBuilder.Entity<CourseEnrollment>().HasData(new CourseEnrollment { CourseName = "CourseName 198", LevelName = grad2021.Models.LevelName.الثالثة, BranchName = "الهندسة الميكانيكية", Term = grad2021.Models.Term.الثاني });
            modelBuilder.Entity<CourseEnrollment>().HasData(new CourseEnrollment { CourseName = "CourseName 199", LevelName = grad2021.Models.LevelName.الأولى, BranchName = "الهندسة المدنية", Term = grad2021.Models.Term.الأول });
            modelBuilder.Entity<CourseEnrollment>().HasData(new CourseEnrollment { CourseName = "CourseName 200", LevelName = grad2021.Models.LevelName.الثانية, BranchName = "الهندسة المعمارية", Term = grad2021.Models.Term.الثاني });
            modelBuilder.Entity<CourseEnrollment>().HasData(new CourseEnrollment { CourseName = "CourseName 201", LevelName = grad2021.Models.LevelName.الثالثة, BranchName = "هندسة القوى والآلات الكهربية", Term = grad2021.Models.Term.الأول });
            modelBuilder.Entity<CourseEnrollment>().HasData(new CourseEnrollment { CourseName = "CourseName 202", LevelName = grad2021.Models.LevelName.الأولى, BranchName = "هندسة الإلكترونيات والاتصالات الكهربية", Term = grad2021.Models.Term.الثاني });
            modelBuilder.Entity<CourseEnrollment>().HasData(new CourseEnrollment { CourseName = "CourseName 203", LevelName = grad2021.Models.LevelName.الثانية, BranchName = "هندسة الحاسبات والنظم", Term = grad2021.Models.Term.الأول });
            modelBuilder.Entity<CourseEnrollment>().HasData(new CourseEnrollment { CourseName = "CourseName 204", LevelName = grad2021.Models.LevelName.الثالثة, BranchName = "الهندسة الميكانيكية", Term = grad2021.Models.Term.الثاني });
            modelBuilder.Entity<CourseEnrollment>().HasData(new CourseEnrollment { CourseName = "CourseName 205", LevelName = grad2021.Models.LevelName.الأولى, BranchName = "الهندسة المدنية", Term = grad2021.Models.Term.الأول });
            modelBuilder.Entity<CourseEnrollment>().HasData(new CourseEnrollment { CourseName = "CourseName 206", LevelName = grad2021.Models.LevelName.الثانية, BranchName = "الهندسة المعمارية", Term = grad2021.Models.Term.الثاني });
            modelBuilder.Entity<CourseEnrollment>().HasData(new CourseEnrollment { CourseName = "CourseName 207", LevelName = grad2021.Models.LevelName.الثالثة, BranchName = "هندسة القوى والآلات الكهربية", Term = grad2021.Models.Term.الأول });
            modelBuilder.Entity<CourseEnrollment>().HasData(new CourseEnrollment { CourseName = "CourseName 208", LevelName = grad2021.Models.LevelName.الأولى, BranchName = "هندسة الإلكترونيات والاتصالات الكهربية", Term = grad2021.Models.Term.الثاني });
            modelBuilder.Entity<CourseEnrollment>().HasData(new CourseEnrollment { CourseName = "CourseName 209", LevelName = grad2021.Models.LevelName.الثانية, BranchName = "هندسة الحاسبات والنظم", Term = grad2021.Models.Term.الأول });
            modelBuilder.Entity<CourseEnrollment>().HasData(new CourseEnrollment { CourseName = "CourseName 210", LevelName = grad2021.Models.LevelName.الثالثة, BranchName = "الهندسة الميكانيكية", Term = grad2021.Models.Term.الثاني });
            modelBuilder.Entity<CourseEnrollment>().HasData(new CourseEnrollment { CourseName = "CourseName 211", LevelName = grad2021.Models.LevelName.الأولى, BranchName = "الهندسة المدنية", Term = grad2021.Models.Term.الأول });
            modelBuilder.Entity<CourseEnrollment>().HasData(new CourseEnrollment { CourseName = "CourseName 212", LevelName = grad2021.Models.LevelName.الثانية, BranchName = "الهندسة المعمارية", Term = grad2021.Models.Term.الثاني });
            modelBuilder.Entity<CourseEnrollment>().HasData(new CourseEnrollment { CourseName = "CourseName 213", LevelName = grad2021.Models.LevelName.الثالثة, BranchName = "هندسة القوى والآلات الكهربية", Term = grad2021.Models.Term.الأول });
            modelBuilder.Entity<CourseEnrollment>().HasData(new CourseEnrollment { CourseName = "CourseName 214", LevelName = grad2021.Models.LevelName.الأولى, BranchName = "هندسة الإلكترونيات والاتصالات الكهربية", Term = grad2021.Models.Term.الثاني });
            modelBuilder.Entity<CourseEnrollment>().HasData(new CourseEnrollment { CourseName = "CourseName 215", LevelName = grad2021.Models.LevelName.الثانية, BranchName = "هندسة الحاسبات والنظم", Term = grad2021.Models.Term.الأول });
            modelBuilder.Entity<CourseEnrollment>().HasData(new CourseEnrollment { CourseName = "CourseName 216", LevelName = grad2021.Models.LevelName.الثالثة, BranchName = "الهندسة الميكانيكية", Term = grad2021.Models.Term.الثاني });
            modelBuilder.Entity<CourseEnrollment>().HasData(new CourseEnrollment { CourseName = "CourseName 217", LevelName = grad2021.Models.LevelName.الأولى, BranchName = "الهندسة المدنية", Term = grad2021.Models.Term.الأول });
            modelBuilder.Entity<CourseEnrollment>().HasData(new CourseEnrollment { CourseName = "CourseName 218", LevelName = grad2021.Models.LevelName.الثانية, BranchName = "الهندسة المعمارية", Term = grad2021.Models.Term.الثاني });
            modelBuilder.Entity<CourseEnrollment>().HasData(new CourseEnrollment { CourseName = "CourseName 219", LevelName = grad2021.Models.LevelName.الثالثة, BranchName = "هندسة القوى والآلات الكهربية", Term = grad2021.Models.Term.الأول });
            modelBuilder.Entity<CourseEnrollment>().HasData(new CourseEnrollment { CourseName = "CourseName 220", LevelName = grad2021.Models.LevelName.الأولى, BranchName = "هندسة الإلكترونيات والاتصالات الكهربية", Term = grad2021.Models.Term.الثاني });
            modelBuilder.Entity<CourseEnrollment>().HasData(new CourseEnrollment { CourseName = "CourseName 221", LevelName = grad2021.Models.LevelName.الثانية, BranchName = "هندسة الحاسبات والنظم", Term = grad2021.Models.Term.الأول });
            modelBuilder.Entity<CourseEnrollment>().HasData(new CourseEnrollment { CourseName = "CourseName 222", LevelName = grad2021.Models.LevelName.الثالثة, BranchName = "الهندسة الميكانيكية", Term = grad2021.Models.Term.الثاني });
            modelBuilder.Entity<CourseEnrollment>().HasData(new CourseEnrollment { CourseName = "CourseName 223", LevelName = grad2021.Models.LevelName.الأولى, BranchName = "الهندسة المدنية", Term = grad2021.Models.Term.الأول });
            modelBuilder.Entity<CourseEnrollment>().HasData(new CourseEnrollment { CourseName = "CourseName 224", LevelName = grad2021.Models.LevelName.الثانية, BranchName = "الهندسة المعمارية", Term = grad2021.Models.Term.الثاني });
            modelBuilder.Entity<CourseEnrollment>().HasData(new CourseEnrollment { CourseName = "CourseName 225", LevelName = grad2021.Models.LevelName.الثالثة, BranchName = "هندسة القوى والآلات الكهربية", Term = grad2021.Models.Term.الأول });
            modelBuilder.Entity<CourseEnrollment>().HasData(new CourseEnrollment { CourseName = "CourseName 226", LevelName = grad2021.Models.LevelName.الأولى, BranchName = "هندسة الإلكترونيات والاتصالات الكهربية", Term = grad2021.Models.Term.الثاني });
            modelBuilder.Entity<CourseEnrollment>().HasData(new CourseEnrollment { CourseName = "CourseName 227", LevelName = grad2021.Models.LevelName.الثانية, BranchName = "هندسة الحاسبات والنظم", Term = grad2021.Models.Term.الأول });
            modelBuilder.Entity<CourseEnrollment>().HasData(new CourseEnrollment { CourseName = "CourseName 228", LevelName = grad2021.Models.LevelName.الثالثة, BranchName = "الهندسة الميكانيكية", Term = grad2021.Models.Term.الثاني });
            modelBuilder.Entity<CourseEnrollment>().HasData(new CourseEnrollment { CourseName = "CourseName 229", LevelName = grad2021.Models.LevelName.الرابعة, BranchName = "هندسة الحاسبات والنظم", Term = grad2021.Models.Term.الأول });
            modelBuilder.Entity<CourseEnrollment>().HasData(new CourseEnrollment { CourseName = "CourseName 230", LevelName = grad2021.Models.LevelName.الرابعة, BranchName = "هندسة الإنتاج والتصميم الميكانيكي", Term = grad2021.Models.Term.الثاني });
            modelBuilder.Entity<CourseEnrollment>().HasData(new CourseEnrollment { CourseName = "CourseName 231", LevelName = grad2021.Models.LevelName.الرابعة, BranchName = "الهندسة الصناعية", Term = grad2021.Models.Term.الأول });
            modelBuilder.Entity<CourseEnrollment>().HasData(new CourseEnrollment { CourseName = "CourseName 232", LevelName = grad2021.Models.LevelName.الرابعة, BranchName = "هندسة القوى الميكانيكية", Term = grad2021.Models.Term.الثاني });
            modelBuilder.Entity<CourseEnrollment>().HasData(new CourseEnrollment { CourseName = "CourseName 233", LevelName = grad2021.Models.LevelName.الرابعة, BranchName = "الهندسة المدنية", Term = grad2021.Models.Term.الأول });
            modelBuilder.Entity<CourseEnrollment>().HasData(new CourseEnrollment { CourseName = "CourseName 234", LevelName = grad2021.Models.LevelName.الرابعة, BranchName = "الهندسة المعمارية", Term = grad2021.Models.Term.الثاني });
            modelBuilder.Entity<CourseEnrollment>().HasData(new CourseEnrollment { CourseName = "CourseName 235", LevelName = grad2021.Models.LevelName.الرابعة, BranchName = "هندسة القوى والآلات الكهربية", Term = grad2021.Models.Term.الأول });
            modelBuilder.Entity<CourseEnrollment>().HasData(new CourseEnrollment { CourseName = "CourseName 236", LevelName = grad2021.Models.LevelName.الرابعة, BranchName = "هندسة الإلكترونيات والاتصالات الكهربية", Term = grad2021.Models.Term.الثاني });
            modelBuilder.Entity<CourseEnrollment>().HasData(new CourseEnrollment { CourseName = "CourseName 237", LevelName = grad2021.Models.LevelName.الرابعة, BranchName = "هندسة الحاسبات والنظم", Term = grad2021.Models.Term.الأول });
            modelBuilder.Entity<CourseEnrollment>().HasData(new CourseEnrollment { CourseName = "CourseName 238", LevelName = grad2021.Models.LevelName.الرابعة, BranchName = "هندسة الإنتاج والتصميم الميكانيكي", Term = grad2021.Models.Term.الثاني });
            modelBuilder.Entity<CourseEnrollment>().HasData(new CourseEnrollment { CourseName = "CourseName 239", LevelName = grad2021.Models.LevelName.الرابعة, BranchName = "الهندسة الصناعية", Term = grad2021.Models.Term.الأول });
            modelBuilder.Entity<CourseEnrollment>().HasData(new CourseEnrollment { CourseName = "CourseName 240", LevelName = grad2021.Models.LevelName.الرابعة, BranchName = "هندسة القوى الميكانيكية", Term = grad2021.Models.Term.الثاني });
            modelBuilder.Entity<CourseEnrollment>().HasData(new CourseEnrollment { CourseName = "CourseName 241", LevelName = grad2021.Models.LevelName.الرابعة, BranchName = "الهندسة المدنية", Term = grad2021.Models.Term.الأول });
            modelBuilder.Entity<CourseEnrollment>().HasData(new CourseEnrollment { CourseName = "CourseName 242", LevelName = grad2021.Models.LevelName.الرابعة, BranchName = "الهندسة المعمارية", Term = grad2021.Models.Term.الثاني });
            modelBuilder.Entity<CourseEnrollment>().HasData(new CourseEnrollment { CourseName = "CourseName 243", LevelName = grad2021.Models.LevelName.الرابعة, BranchName = "هندسة القوى والآلات الكهربية", Term = grad2021.Models.Term.الأول });
            modelBuilder.Entity<CourseEnrollment>().HasData(new CourseEnrollment { CourseName = "CourseName 244", LevelName = grad2021.Models.LevelName.الرابعة, BranchName = "هندسة الإلكترونيات والاتصالات الكهربية", Term = grad2021.Models.Term.الثاني });
            modelBuilder.Entity<CourseEnrollment>().HasData(new CourseEnrollment { CourseName = "CourseName 245", LevelName = grad2021.Models.LevelName.الرابعة, BranchName = "هندسة الحاسبات والنظم", Term = grad2021.Models.Term.الأول });
            modelBuilder.Entity<CourseEnrollment>().HasData(new CourseEnrollment { CourseName = "CourseName 246", LevelName = grad2021.Models.LevelName.الرابعة, BranchName = "هندسة الإنتاج والتصميم الميكانيكي", Term = grad2021.Models.Term.الثاني });
            modelBuilder.Entity<CourseEnrollment>().HasData(new CourseEnrollment { CourseName = "CourseName 247", LevelName = grad2021.Models.LevelName.الرابعة, BranchName = "الهندسة الصناعية", Term = grad2021.Models.Term.الأول });
            modelBuilder.Entity<CourseEnrollment>().HasData(new CourseEnrollment { CourseName = "CourseName 248", LevelName = grad2021.Models.LevelName.الرابعة, BranchName = "هندسة القوى الميكانيكية", Term = grad2021.Models.Term.الثاني });
            modelBuilder.Entity<CourseEnrollment>().HasData(new CourseEnrollment { CourseName = "CourseName 249", LevelName = grad2021.Models.LevelName.الرابعة, BranchName = "الهندسة المدنية", Term = grad2021.Models.Term.الأول });
            modelBuilder.Entity<CourseEnrollment>().HasData(new CourseEnrollment { CourseName = "CourseName 250", LevelName = grad2021.Models.LevelName.الرابعة, BranchName = "الهندسة المعمارية", Term = grad2021.Models.Term.الثاني });
            modelBuilder.Entity<CourseEnrollment>().HasData(new CourseEnrollment { CourseName = "CourseName 251", LevelName = grad2021.Models.LevelName.الرابعة, BranchName = "هندسة القوى والآلات الكهربية", Term = grad2021.Models.Term.الأول });
            modelBuilder.Entity<CourseEnrollment>().HasData(new CourseEnrollment { CourseName = "CourseName 252", LevelName = grad2021.Models.LevelName.الرابعة, BranchName = "هندسة الإلكترونيات والاتصالات الكهربية", Term = grad2021.Models.Term.الثاني });
            modelBuilder.Entity<CourseEnrollment>().HasData(new CourseEnrollment { CourseName = "CourseName 253", LevelName = grad2021.Models.LevelName.الرابعة, BranchName = "هندسة الحاسبات والنظم", Term = grad2021.Models.Term.الأول });
            modelBuilder.Entity<CourseEnrollment>().HasData(new CourseEnrollment { CourseName = "CourseName 254", LevelName = grad2021.Models.LevelName.الرابعة, BranchName = "هندسة الإنتاج والتصميم الميكانيكي", Term = grad2021.Models.Term.الثاني });
            modelBuilder.Entity<CourseEnrollment>().HasData(new CourseEnrollment { CourseName = "CourseName 255", LevelName = grad2021.Models.LevelName.الرابعة, BranchName = "الهندسة الصناعية", Term = grad2021.Models.Term.الأول });
            modelBuilder.Entity<CourseEnrollment>().HasData(new CourseEnrollment { CourseName = "CourseName 256", LevelName = grad2021.Models.LevelName.الرابعة, BranchName = "هندسة القوى الميكانيكية", Term = grad2021.Models.Term.الثاني });
            modelBuilder.Entity<CourseEnrollment>().HasData(new CourseEnrollment { CourseName = "CourseName 257", LevelName = grad2021.Models.LevelName.الرابعة, BranchName = "الهندسة المدنية", Term = grad2021.Models.Term.الأول });
            modelBuilder.Entity<CourseEnrollment>().HasData(new CourseEnrollment { CourseName = "CourseName 258", LevelName = grad2021.Models.LevelName.الرابعة, BranchName = "الهندسة المعمارية", Term = grad2021.Models.Term.الثاني });
            modelBuilder.Entity<CourseEnrollment>().HasData(new CourseEnrollment { CourseName = "CourseName 259", LevelName = grad2021.Models.LevelName.الرابعة, BranchName = "هندسة القوى والآلات الكهربية", Term = grad2021.Models.Term.الأول });
            modelBuilder.Entity<CourseEnrollment>().HasData(new CourseEnrollment { CourseName = "CourseName 260", LevelName = grad2021.Models.LevelName.الرابعة, BranchName = "هندسة الإلكترونيات والاتصالات الكهربية", Term = grad2021.Models.Term.الثاني });
            modelBuilder.Entity<CourseEnrollment>().HasData(new CourseEnrollment { CourseName = "CourseName 261", LevelName = grad2021.Models.LevelName.الرابعة, BranchName = "هندسة الحاسبات والنظم", Term = grad2021.Models.Term.الأول });
            modelBuilder.Entity<CourseEnrollment>().HasData(new CourseEnrollment { CourseName = "CourseName 262", LevelName = grad2021.Models.LevelName.الرابعة, BranchName = "هندسة الإنتاج والتصميم الميكانيكي", Term = grad2021.Models.Term.الثاني });
            modelBuilder.Entity<CourseEnrollment>().HasData(new CourseEnrollment { CourseName = "CourseName 263", LevelName = grad2021.Models.LevelName.الرابعة, BranchName = "الهندسة الصناعية", Term = grad2021.Models.Term.الأول });
            modelBuilder.Entity<CourseEnrollment>().HasData(new CourseEnrollment { CourseName = "CourseName 264", LevelName = grad2021.Models.LevelName.الرابعة, BranchName = "هندسة القوى الميكانيكية", Term = grad2021.Models.Term.الثاني });
            modelBuilder.Entity<CourseEnrollment>().HasData(new CourseEnrollment { CourseName = "CourseName 265", LevelName = grad2021.Models.LevelName.الرابعة, BranchName = "الهندسة المدنية", Term = grad2021.Models.Term.الأول });
            modelBuilder.Entity<CourseEnrollment>().HasData(new CourseEnrollment { CourseName = "CourseName 266", LevelName = grad2021.Models.LevelName.الرابعة, BranchName = "الهندسة المعمارية", Term = grad2021.Models.Term.الثاني });
            modelBuilder.Entity<CourseEnrollment>().HasData(new CourseEnrollment { CourseName = "CourseName 267", LevelName = grad2021.Models.LevelName.الرابعة, BranchName = "هندسة القوى والآلات الكهربية", Term = grad2021.Models.Term.الأول });
            modelBuilder.Entity<CourseEnrollment>().HasData(new CourseEnrollment { CourseName = "CourseName 268", LevelName = grad2021.Models.LevelName.الرابعة, BranchName = "هندسة الإلكترونيات والاتصالات الكهربية", Term = grad2021.Models.Term.الثاني });
            modelBuilder.Entity<CourseEnrollment>().HasData(new CourseEnrollment { CourseName = "CourseName 269", LevelName = grad2021.Models.LevelName.الرابعة, BranchName = "هندسة الحاسبات والنظم", Term = grad2021.Models.Term.الأول });
            modelBuilder.Entity<CourseEnrollment>().HasData(new CourseEnrollment { CourseName = "CourseName 270", LevelName = grad2021.Models.LevelName.الرابعة, BranchName = "هندسة الإنتاج والتصميم الميكانيكي", Term = grad2021.Models.Term.الثاني });
            modelBuilder.Entity<CourseEnrollment>().HasData(new CourseEnrollment { CourseName = "CourseName 271", LevelName = grad2021.Models.LevelName.الرابعة, BranchName = "الهندسة الصناعية", Term = grad2021.Models.Term.الأول });
            modelBuilder.Entity<CourseEnrollment>().HasData(new CourseEnrollment { CourseName = "CourseName 272", LevelName = grad2021.Models.LevelName.الرابعة, BranchName = "هندسة القوى الميكانيكية", Term = grad2021.Models.Term.الثاني });
            modelBuilder.Entity<CourseEnrollment>().HasData(new CourseEnrollment { CourseName = "CourseName 273", LevelName = grad2021.Models.LevelName.الرابعة, BranchName = "الهندسة المدنية", Term = grad2021.Models.Term.الأول });
            modelBuilder.Entity<CourseEnrollment>().HasData(new CourseEnrollment { CourseName = "CourseName 274", LevelName = grad2021.Models.LevelName.الرابعة, BranchName = "الهندسة المعمارية", Term = grad2021.Models.Term.الثاني });
            modelBuilder.Entity<CourseEnrollment>().HasData(new CourseEnrollment { CourseName = "CourseName 275", LevelName = grad2021.Models.LevelName.الرابعة, BranchName = "هندسة القوى والآلات الكهربية", Term = grad2021.Models.Term.الأول });
            modelBuilder.Entity<CourseEnrollment>().HasData(new CourseEnrollment { CourseName = "CourseName 276", LevelName = grad2021.Models.LevelName.الرابعة, BranchName = "هندسة الإلكترونيات والاتصالات الكهربية", Term = grad2021.Models.Term.الثاني });
            modelBuilder.Entity<CourseEnrollment>().HasData(new CourseEnrollment { CourseName = "CourseName 277", LevelName = grad2021.Models.LevelName.الرابعة, BranchName = "هندسة الحاسبات والنظم", Term = grad2021.Models.Term.الأول });
            modelBuilder.Entity<CourseEnrollment>().HasData(new CourseEnrollment { CourseName = "CourseName 278", LevelName = grad2021.Models.LevelName.الرابعة, BranchName = "هندسة الإنتاج والتصميم الميكانيكي", Term = grad2021.Models.Term.الثاني });
            modelBuilder.Entity<CourseEnrollment>().HasData(new CourseEnrollment { CourseName = "CourseName 279", LevelName = grad2021.Models.LevelName.الرابعة, BranchName = "الهندسة الصناعية", Term = grad2021.Models.Term.الأول });
            modelBuilder.Entity<CourseEnrollment>().HasData(new CourseEnrollment { CourseName = "CourseName 280", LevelName = grad2021.Models.LevelName.الرابعة, BranchName = "هندسة القوى الميكانيكية", Term = grad2021.Models.Term.الثاني });
            modelBuilder.Entity<CourseEnrollment>().HasData(new CourseEnrollment { CourseName = "CourseName 281", LevelName = grad2021.Models.LevelName.الرابعة, BranchName = "الهندسة المدنية", Term = grad2021.Models.Term.الأول });
            modelBuilder.Entity<CourseEnrollment>().HasData(new CourseEnrollment { CourseName = "CourseName 282", LevelName = grad2021.Models.LevelName.الرابعة, BranchName = "الهندسة المعمارية", Term = grad2021.Models.Term.الثاني });
            modelBuilder.Entity<CourseEnrollment>().HasData(new CourseEnrollment { CourseName = "CourseName 283", LevelName = grad2021.Models.LevelName.الرابعة, BranchName = "هندسة القوى والآلات الكهربية", Term = grad2021.Models.Term.الأول });
            modelBuilder.Entity<CourseEnrollment>().HasData(new CourseEnrollment { CourseName = "CourseName 284", LevelName = grad2021.Models.LevelName.الرابعة, BranchName = "هندسة الإلكترونيات والاتصالات الكهربية", Term = grad2021.Models.Term.الثاني });
            modelBuilder.Entity<CourseEnrollment>().HasData(new CourseEnrollment { CourseName = "CourseName 285", LevelName = grad2021.Models.LevelName.الرابعة, BranchName = "هندسة الحاسبات والنظم", Term = grad2021.Models.Term.الأول });
            modelBuilder.Entity<CourseEnrollment>().HasData(new CourseEnrollment { CourseName = "CourseName 286", LevelName = grad2021.Models.LevelName.الرابعة, BranchName = "هندسة الإنتاج والتصميم الميكانيكي", Term = grad2021.Models.Term.الثاني });
            modelBuilder.Entity<CourseEnrollment>().HasData(new CourseEnrollment { CourseName = "CourseName 287", LevelName = grad2021.Models.LevelName.الرابعة, BranchName = "الهندسة الصناعية", Term = grad2021.Models.Term.الأول });
            modelBuilder.Entity<CourseEnrollment>().HasData(new CourseEnrollment { CourseName = "CourseName 288", LevelName = grad2021.Models.LevelName.الرابعة, BranchName = "هندسة القوى الميكانيكية", Term = grad2021.Models.Term.الثاني });
            modelBuilder.Entity<CourseEnrollment>().HasData(new CourseEnrollment { CourseName = "CourseName 289", LevelName = grad2021.Models.LevelName.الرابعة, BranchName = "الهندسة المدنية", Term = grad2021.Models.Term.الأول });
            modelBuilder.Entity<CourseEnrollment>().HasData(new CourseEnrollment { CourseName = "CourseName 290", LevelName = grad2021.Models.LevelName.الرابعة, BranchName = "الهندسة المعمارية", Term = grad2021.Models.Term.الثاني });
            modelBuilder.Entity<CourseEnrollment>().HasData(new CourseEnrollment { CourseName = "CourseName 291", LevelName = grad2021.Models.LevelName.الرابعة, BranchName = "هندسة القوى والآلات الكهربية", Term = grad2021.Models.Term.الأول });
            modelBuilder.Entity<CourseEnrollment>().HasData(new CourseEnrollment { CourseName = "CourseName 292", LevelName = grad2021.Models.LevelName.الرابعة, BranchName = "هندسة الإلكترونيات والاتصالات الكهربية", Term = grad2021.Models.Term.الثاني });
            modelBuilder.Entity<CourseEnrollment>().HasData(new CourseEnrollment { CourseName = "CourseName 293", LevelName = grad2021.Models.LevelName.الرابعة, BranchName = "هندسة الحاسبات والنظم", Term = grad2021.Models.Term.الأول });
            modelBuilder.Entity<CourseEnrollment>().HasData(new CourseEnrollment { CourseName = "CourseName 294", LevelName = grad2021.Models.LevelName.الرابعة, BranchName = "هندسة الإنتاج والتصميم الميكانيكي", Term = grad2021.Models.Term.الثاني });
            modelBuilder.Entity<CourseEnrollment>().HasData(new CourseEnrollment { CourseName = "CourseName 295", LevelName = grad2021.Models.LevelName.الرابعة, BranchName = "الهندسة الصناعية", Term = grad2021.Models.Term.الأول });
            modelBuilder.Entity<CourseEnrollment>().HasData(new CourseEnrollment { CourseName = "CourseName 296", LevelName = grad2021.Models.LevelName.الرابعة, BranchName = "هندسة القوى الميكانيكية", Term = grad2021.Models.Term.الثاني });
            modelBuilder.Entity<CourseEnrollment>().HasData(new CourseEnrollment { CourseName = "CourseName 297", LevelName = grad2021.Models.LevelName.الرابعة, BranchName = "الهندسة المدنية", Term = grad2021.Models.Term.الأول });
            modelBuilder.Entity<CourseEnrollment>().HasData(new CourseEnrollment { CourseName = "CourseName 298", LevelName = grad2021.Models.LevelName.الرابعة, BranchName = "الهندسة المعمارية", Term = grad2021.Models.Term.الثاني });
            modelBuilder.Entity<CourseEnrollment>().HasData(new CourseEnrollment { CourseName = "CourseName 299", LevelName = grad2021.Models.LevelName.الرابعة, BranchName = "هندسة القوى والآلات الكهربية", Term = grad2021.Models.Term.الأول });
            modelBuilder.Entity<CourseEnrollment>().HasData(new CourseEnrollment { CourseName = "CourseName 300", LevelName = grad2021.Models.LevelName.الرابعة, BranchName = "هندسة الإلكترونيات والاتصالات الكهربية", Term = grad2021.Models.Term.الثاني });
            modelBuilder.Entity<CourseEnrollment>().HasData(new CourseEnrollment { CourseName = "CourseName 301", LevelName = grad2021.Models.LevelName.الرابعة, BranchName = "هندسة الحاسبات والنظم", Term = grad2021.Models.Term.الأول });
            modelBuilder.Entity<CourseEnrollment>().HasData(new CourseEnrollment { CourseName = "CourseName 302", LevelName = grad2021.Models.LevelName.الرابعة, BranchName = "هندسة الإنتاج والتصميم الميكانيكي", Term = grad2021.Models.Term.الثاني });
            modelBuilder.Entity<CourseEnrollment>().HasData(new CourseEnrollment { CourseName = "CourseName 303", LevelName = grad2021.Models.LevelName.الرابعة, BranchName = "الهندسة الصناعية", Term = grad2021.Models.Term.الأول });
            modelBuilder.Entity<CourseEnrollment>().HasData(new CourseEnrollment { CourseName = "CourseName 304", LevelName = grad2021.Models.LevelName.الرابعة, BranchName = "هندسة القوى الميكانيكية", Term = grad2021.Models.Term.الثاني });
            modelBuilder.Entity<CourseEnrollment>().HasData(new CourseEnrollment { CourseName = "CourseName 305", LevelName = grad2021.Models.LevelName.الرابعة, BranchName = "الهندسة المدنية", Term = grad2021.Models.Term.الأول });
            modelBuilder.Entity<CourseEnrollment>().HasData(new CourseEnrollment { CourseName = "CourseName 306", LevelName = grad2021.Models.LevelName.الرابعة, BranchName = "الهندسة المعمارية", Term = grad2021.Models.Term.الثاني });
            modelBuilder.Entity<CourseEnrollment>().HasData(new CourseEnrollment { CourseName = "CourseName 307", LevelName = grad2021.Models.LevelName.الرابعة, BranchName = "هندسة القوى والآلات الكهربية", Term = grad2021.Models.Term.الأول });
            modelBuilder.Entity<CourseEnrollment>().HasData(new CourseEnrollment { CourseName = "CourseName 308", LevelName = grad2021.Models.LevelName.الرابعة, BranchName = "هندسة الإلكترونيات والاتصالات الكهربية", Term = grad2021.Models.Term.الثاني });
            modelBuilder.Entity<CourseEnrollment>().HasData(new CourseEnrollment { CourseName = "CourseName 309", LevelName = grad2021.Models.LevelName.الرابعة, BranchName = "هندسة الحاسبات والنظم", Term = grad2021.Models.Term.الأول });
            modelBuilder.Entity<CourseEnrollment>().HasData(new CourseEnrollment { CourseName = "CourseName 310", LevelName = grad2021.Models.LevelName.الرابعة, BranchName = "هندسة الإنتاج والتصميم الميكانيكي", Term = grad2021.Models.Term.الثاني });
            modelBuilder.Entity<CourseEnrollment>().HasData(new CourseEnrollment { CourseName = "CourseName 311", LevelName = grad2021.Models.LevelName.الرابعة, BranchName = "الهندسة الصناعية", Term = grad2021.Models.Term.الأول });
            modelBuilder.Entity<CourseEnrollment>().HasData(new CourseEnrollment { CourseName = "CourseName 312", LevelName = grad2021.Models.LevelName.الرابعة, BranchName = "هندسة القوى الميكانيكية", Term = grad2021.Models.Term.الثاني });
            modelBuilder.Entity<CourseEnrollment>().HasData(new CourseEnrollment { CourseName = "CourseName 313", LevelName = grad2021.Models.LevelName.الرابعة, BranchName = "الهندسة المدنية", Term = grad2021.Models.Term.الأول });
            modelBuilder.Entity<CourseEnrollment>().HasData(new CourseEnrollment { CourseName = "CourseName 314", LevelName = grad2021.Models.LevelName.الرابعة, BranchName = "الهندسة المعمارية", Term = grad2021.Models.Term.الثاني });
            modelBuilder.Entity<CourseEnrollment>().HasData(new CourseEnrollment { CourseName = "CourseName 315", LevelName = grad2021.Models.LevelName.الرابعة, BranchName = "هندسة القوى والآلات الكهربية", Term = grad2021.Models.Term.الأول });
            modelBuilder.Entity<CourseEnrollment>().HasData(new CourseEnrollment { CourseName = "CourseName 316", LevelName = grad2021.Models.LevelName.الرابعة, BranchName = "هندسة الإلكترونيات والاتصالات الكهربية", Term = grad2021.Models.Term.الثاني });
            modelBuilder.Entity<CourseEnrollment>().HasData(new CourseEnrollment { CourseName = "CourseName 317", LevelName = grad2021.Models.LevelName.الرابعة, BranchName = "هندسة الحاسبات والنظم", Term = grad2021.Models.Term.الأول });
            modelBuilder.Entity<CourseEnrollment>().HasData(new CourseEnrollment { CourseName = "CourseName 318", LevelName = grad2021.Models.LevelName.الرابعة, BranchName = "هندسة الإنتاج والتصميم الميكانيكي", Term = grad2021.Models.Term.الثاني });
            modelBuilder.Entity<CourseEnrollment>().HasData(new CourseEnrollment { CourseName = "CourseName 319", LevelName = grad2021.Models.LevelName.الرابعة, BranchName = "الهندسة الصناعية", Term = grad2021.Models.Term.الأول });
            modelBuilder.Entity<CourseEnrollment>().HasData(new CourseEnrollment { CourseName = "CourseName 320", LevelName = grad2021.Models.LevelName.الرابعة, BranchName = "هندسة القوى الميكانيكية", Term = grad2021.Models.Term.الثاني });
            modelBuilder.Entity<CourseEnrollment>().HasData(new CourseEnrollment { CourseName = "CourseName 321", LevelName = grad2021.Models.LevelName.الرابعة, BranchName = "الهندسة المدنية", Term = grad2021.Models.Term.الأول });
            modelBuilder.Entity<CourseEnrollment>().HasData(new CourseEnrollment { CourseName = "CourseName 322", LevelName = grad2021.Models.LevelName.الرابعة, BranchName = "الهندسة المعمارية", Term = grad2021.Models.Term.الثاني });
            modelBuilder.Entity<CourseEnrollment>().HasData(new CourseEnrollment { CourseName = "CourseName 323", LevelName = grad2021.Models.LevelName.الرابعة, BranchName = "هندسة القوى والآلات الكهربية", Term = grad2021.Models.Term.الأول });
            modelBuilder.Entity<CourseEnrollment>().HasData(new CourseEnrollment { CourseName = "CourseName 324", LevelName = grad2021.Models.LevelName.الرابعة, BranchName = "هندسة الإلكترونيات والاتصالات الكهربية", Term = grad2021.Models.Term.الثاني });


            //students:

            modelBuilder.Entity<Student>().HasData(new Student { StudentName = "StudentName 1", StudentNatId = 1, Gender = grad2021.Models.Gender.ذكر });
            modelBuilder.Entity<Student>().HasData(new Student { StudentName = "StudentName 2", StudentNatId = 2, Gender = grad2021.Models.Gender.أنثى });
            modelBuilder.Entity<Student>().HasData(new Student { StudentName = "StudentName 3", StudentNatId = 3, Gender = grad2021.Models.Gender.ذكر });
            modelBuilder.Entity<Student>().HasData(new Student { StudentName = "StudentName 4", StudentNatId = 4, Gender = grad2021.Models.Gender.أنثى });
            modelBuilder.Entity<Student>().HasData(new Student { StudentName = "StudentName 5", StudentNatId = 5, Gender = grad2021.Models.Gender.ذكر });
            modelBuilder.Entity<Student>().HasData(new Student { StudentName = "StudentName 6", StudentNatId = 6, Gender = grad2021.Models.Gender.أنثى });
            modelBuilder.Entity<Student>().HasData(new Student { StudentName = "StudentName 7", StudentNatId = 7, Gender = grad2021.Models.Gender.ذكر });
            modelBuilder.Entity<Student>().HasData(new Student { StudentName = "StudentName 8", StudentNatId = 8, Gender = grad2021.Models.Gender.أنثى });
            modelBuilder.Entity<Student>().HasData(new Student { StudentName = "StudentName 9", StudentNatId = 9, Gender = grad2021.Models.Gender.ذكر });
            modelBuilder.Entity<Student>().HasData(new Student { StudentName = "StudentName 10", StudentNatId = 10, Gender = grad2021.Models.Gender.أنثى });
            modelBuilder.Entity<Student>().HasData(new Student { StudentName = "StudentName 11", StudentNatId = 11, Gender = grad2021.Models.Gender.ذكر });
            modelBuilder.Entity<Student>().HasData(new Student { StudentName = "StudentName 12", StudentNatId = 12, Gender = grad2021.Models.Gender.أنثى });
            modelBuilder.Entity<Student>().HasData(new Student { StudentName = "StudentName 13", StudentNatId = 13, Gender = grad2021.Models.Gender.ذكر });
            modelBuilder.Entity<Student>().HasData(new Student { StudentName = "StudentName 14", StudentNatId = 14, Gender = grad2021.Models.Gender.أنثى });
            modelBuilder.Entity<Student>().HasData(new Student { StudentName = "StudentName 15", StudentNatId = 15, Gender = grad2021.Models.Gender.ذكر });
            modelBuilder.Entity<Student>().HasData(new Student { StudentName = "StudentName 16", StudentNatId = 16, Gender = grad2021.Models.Gender.أنثى });
            modelBuilder.Entity<Student>().HasData(new Student { StudentName = "StudentName 17", StudentNatId = 17, Gender = grad2021.Models.Gender.ذكر });
            modelBuilder.Entity<Student>().HasData(new Student { StudentName = "StudentName 18", StudentNatId = 18, Gender = grad2021.Models.Gender.أنثى });
            modelBuilder.Entity<Student>().HasData(new Student { StudentName = "StudentName 19", StudentNatId = 19, Gender = grad2021.Models.Gender.ذكر });
            modelBuilder.Entity<Student>().HasData(new Student { StudentName = "StudentName 20", StudentNatId = 20, Gender = grad2021.Models.Gender.أنثى });
            modelBuilder.Entity<Student>().HasData(new Student { StudentName = "StudentName 21", StudentNatId = 21, Gender = grad2021.Models.Gender.ذكر });
            modelBuilder.Entity<Student>().HasData(new Student { StudentName = "StudentName 22", StudentNatId = 22, Gender = grad2021.Models.Gender.أنثى });
            modelBuilder.Entity<Student>().HasData(new Student { StudentName = "StudentName 23", StudentNatId = 23, Gender = grad2021.Models.Gender.ذكر });
            modelBuilder.Entity<Student>().HasData(new Student { StudentName = "StudentName 24", StudentNatId = 24, Gender = grad2021.Models.Gender.أنثى });
            modelBuilder.Entity<Student>().HasData(new Student { StudentName = "StudentName 25", StudentNatId = 25, Gender = grad2021.Models.Gender.ذكر });
            modelBuilder.Entity<Student>().HasData(new Student { StudentName = "StudentName 26", StudentNatId = 26, Gender = grad2021.Models.Gender.أنثى });
            modelBuilder.Entity<Student>().HasData(new Student { StudentName = "StudentName 27", StudentNatId = 27, Gender = grad2021.Models.Gender.ذكر });
            modelBuilder.Entity<Student>().HasData(new Student { StudentName = "StudentName 28", StudentNatId = 28, Gender = grad2021.Models.Gender.أنثى });
            modelBuilder.Entity<Student>().HasData(new Student { StudentName = "StudentName 29", StudentNatId = 29, Gender = grad2021.Models.Gender.ذكر });
            modelBuilder.Entity<Student>().HasData(new Student { StudentName = "StudentName 30", StudentNatId = 30, Gender = grad2021.Models.Gender.أنثى });
            modelBuilder.Entity<Student>().HasData(new Student { StudentName = "StudentName 31", StudentNatId = 31, Gender = grad2021.Models.Gender.ذكر });
            modelBuilder.Entity<Student>().HasData(new Student { StudentName = "StudentName 32", StudentNatId = 32, Gender = grad2021.Models.Gender.أنثى });
            modelBuilder.Entity<Student>().HasData(new Student { StudentName = "StudentName 33", StudentNatId = 33, Gender = grad2021.Models.Gender.ذكر });
            modelBuilder.Entity<Student>().HasData(new Student { StudentName = "StudentName 34", StudentNatId = 34, Gender = grad2021.Models.Gender.أنثى });
            modelBuilder.Entity<Student>().HasData(new Student { StudentName = "StudentName 35", StudentNatId = 35, Gender = grad2021.Models.Gender.ذكر });
            modelBuilder.Entity<Student>().HasData(new Student { StudentName = "StudentName 36", StudentNatId = 36, Gender = grad2021.Models.Gender.أنثى });
            modelBuilder.Entity<Student>().HasData(new Student { StudentName = "StudentName 37", StudentNatId = 37, Gender = grad2021.Models.Gender.ذكر });
            modelBuilder.Entity<Student>().HasData(new Student { StudentName = "StudentName 38", StudentNatId = 38, Gender = grad2021.Models.Gender.أنثى });
            modelBuilder.Entity<Student>().HasData(new Student { StudentName = "StudentName 39", StudentNatId = 39, Gender = grad2021.Models.Gender.ذكر });
            modelBuilder.Entity<Student>().HasData(new Student { StudentName = "StudentName 40", StudentNatId = 40, Gender = grad2021.Models.Gender.أنثى });
            modelBuilder.Entity<Student>().HasData(new Student { StudentName = "StudentName 41", StudentNatId = 41, Gender = grad2021.Models.Gender.ذكر });
            modelBuilder.Entity<Student>().HasData(new Student { StudentName = "StudentName 42", StudentNatId = 42, Gender = grad2021.Models.Gender.أنثى });
            modelBuilder.Entity<Student>().HasData(new Student { StudentName = "StudentName 43", StudentNatId = 43, Gender = grad2021.Models.Gender.ذكر });
            modelBuilder.Entity<Student>().HasData(new Student { StudentName = "StudentName 44", StudentNatId = 44, Gender = grad2021.Models.Gender.أنثى });
            modelBuilder.Entity<Student>().HasData(new Student { StudentName = "StudentName 45", StudentNatId = 45, Gender = grad2021.Models.Gender.ذكر });
            modelBuilder.Entity<Student>().HasData(new Student { StudentName = "StudentName 46", StudentNatId = 46, Gender = grad2021.Models.Gender.أنثى });
            modelBuilder.Entity<Student>().HasData(new Student { StudentName = "StudentName 47", StudentNatId = 47, Gender = grad2021.Models.Gender.ذكر });
            modelBuilder.Entity<Student>().HasData(new Student { StudentName = "StudentName 48", StudentNatId = 48, Gender = grad2021.Models.Gender.أنثى });
            modelBuilder.Entity<Student>().HasData(new Student { StudentName = "StudentName 49", StudentNatId = 49, Gender = grad2021.Models.Gender.ذكر });
            modelBuilder.Entity<Student>().HasData(new Student { StudentName = "StudentName 50", StudentNatId = 50, Gender = grad2021.Models.Gender.أنثى });
            modelBuilder.Entity<Student>().HasData(new Student { StudentName = "StudentName 51", StudentNatId = 51, Gender = grad2021.Models.Gender.ذكر });
            modelBuilder.Entity<Student>().HasData(new Student { StudentName = "StudentName 52", StudentNatId = 52, Gender = grad2021.Models.Gender.أنثى });
            modelBuilder.Entity<Student>().HasData(new Student { StudentName = "StudentName 53", StudentNatId = 53, Gender = grad2021.Models.Gender.ذكر });
            modelBuilder.Entity<Student>().HasData(new Student { StudentName = "StudentName 54", StudentNatId = 54, Gender = grad2021.Models.Gender.أنثى });
            modelBuilder.Entity<Student>().HasData(new Student { StudentName = "StudentName 55", StudentNatId = 55, Gender = grad2021.Models.Gender.ذكر });
            modelBuilder.Entity<Student>().HasData(new Student { StudentName = "StudentName 56", StudentNatId = 56, Gender = grad2021.Models.Gender.أنثى });
            modelBuilder.Entity<Student>().HasData(new Student { StudentName = "StudentName 57", StudentNatId = 57, Gender = grad2021.Models.Gender.ذكر });
            modelBuilder.Entity<Student>().HasData(new Student { StudentName = "StudentName 58", StudentNatId = 58, Gender = grad2021.Models.Gender.أنثى });
            modelBuilder.Entity<Student>().HasData(new Student { StudentName = "StudentName 59", StudentNatId = 59, Gender = grad2021.Models.Gender.ذكر });
            modelBuilder.Entity<Student>().HasData(new Student { StudentName = "StudentName 60", StudentNatId = 60, Gender = grad2021.Models.Gender.أنثى });
            modelBuilder.Entity<Student>().HasData(new Student { StudentName = "StudentName 61", StudentNatId = 61, Gender = grad2021.Models.Gender.ذكر });
            modelBuilder.Entity<Student>().HasData(new Student { StudentName = "StudentName 62", StudentNatId = 62, Gender = grad2021.Models.Gender.أنثى });
            modelBuilder.Entity<Student>().HasData(new Student { StudentName = "StudentName 63", StudentNatId = 63, Gender = grad2021.Models.Gender.ذكر });
            modelBuilder.Entity<Student>().HasData(new Student { StudentName = "StudentName 64", StudentNatId = 64, Gender = grad2021.Models.Gender.أنثى });
            modelBuilder.Entity<Student>().HasData(new Student { StudentName = "StudentName 65", StudentNatId = 65, Gender = grad2021.Models.Gender.ذكر });
            modelBuilder.Entity<Student>().HasData(new Student { StudentName = "StudentName 66", StudentNatId = 66, Gender = grad2021.Models.Gender.أنثى });
            modelBuilder.Entity<Student>().HasData(new Student { StudentName = "StudentName 67", StudentNatId = 67, Gender = grad2021.Models.Gender.ذكر });
            modelBuilder.Entity<Student>().HasData(new Student { StudentName = "StudentName 68", StudentNatId = 68, Gender = grad2021.Models.Gender.أنثى });
            modelBuilder.Entity<Student>().HasData(new Student { StudentName = "StudentName 69", StudentNatId = 69, Gender = grad2021.Models.Gender.ذكر });
            modelBuilder.Entity<Student>().HasData(new Student { StudentName = "StudentName 70", StudentNatId = 70, Gender = grad2021.Models.Gender.أنثى });
            modelBuilder.Entity<Student>().HasData(new Student { StudentName = "StudentName 71", StudentNatId = 71, Gender = grad2021.Models.Gender.ذكر });
            modelBuilder.Entity<Student>().HasData(new Student { StudentName = "StudentName 72", StudentNatId = 72, Gender = grad2021.Models.Gender.أنثى });
            modelBuilder.Entity<Student>().HasData(new Student { StudentName = "StudentName 73", StudentNatId = 73, Gender = grad2021.Models.Gender.ذكر });
            modelBuilder.Entity<Student>().HasData(new Student { StudentName = "StudentName 74", StudentNatId = 74, Gender = grad2021.Models.Gender.أنثى });
            modelBuilder.Entity<Student>().HasData(new Student { StudentName = "StudentName 75", StudentNatId = 75, Gender = grad2021.Models.Gender.ذكر });
            modelBuilder.Entity<Student>().HasData(new Student { StudentName = "StudentName 76", StudentNatId = 76, Gender = grad2021.Models.Gender.أنثى });
            modelBuilder.Entity<Student>().HasData(new Student { StudentName = "StudentName 77", StudentNatId = 77, Gender = grad2021.Models.Gender.ذكر });
            modelBuilder.Entity<Student>().HasData(new Student { StudentName = "StudentName 78", StudentNatId = 78, Gender = grad2021.Models.Gender.أنثى });
            modelBuilder.Entity<Student>().HasData(new Student { StudentName = "StudentName 79", StudentNatId = 79, Gender = grad2021.Models.Gender.ذكر });
            modelBuilder.Entity<Student>().HasData(new Student { StudentName = "StudentName 80", StudentNatId = 80, Gender = grad2021.Models.Gender.أنثى });
            modelBuilder.Entity<Student>().HasData(new Student { StudentName = "StudentName 81", StudentNatId = 81, Gender = grad2021.Models.Gender.ذكر });
            modelBuilder.Entity<Student>().HasData(new Student { StudentName = "StudentName 82", StudentNatId = 82, Gender = grad2021.Models.Gender.أنثى });
            modelBuilder.Entity<Student>().HasData(new Student { StudentName = "StudentName 83", StudentNatId = 83, Gender = grad2021.Models.Gender.ذكر });
            modelBuilder.Entity<Student>().HasData(new Student { StudentName = "StudentName 84", StudentNatId = 84, Gender = grad2021.Models.Gender.أنثى });
            modelBuilder.Entity<Student>().HasData(new Student { StudentName = "StudentName 85", StudentNatId = 85, Gender = grad2021.Models.Gender.ذكر });
            modelBuilder.Entity<Student>().HasData(new Student { StudentName = "StudentName 86", StudentNatId = 86, Gender = grad2021.Models.Gender.أنثى });
            modelBuilder.Entity<Student>().HasData(new Student { StudentName = "StudentName 87", StudentNatId = 87, Gender = grad2021.Models.Gender.ذكر });
            modelBuilder.Entity<Student>().HasData(new Student { StudentName = "StudentName 88", StudentNatId = 88, Gender = grad2021.Models.Gender.أنثى });
            modelBuilder.Entity<Student>().HasData(new Student { StudentName = "StudentName 89", StudentNatId = 89, Gender = grad2021.Models.Gender.ذكر });
            modelBuilder.Entity<Student>().HasData(new Student { StudentName = "StudentName 90", StudentNatId = 90, Gender = grad2021.Models.Gender.أنثى });
            modelBuilder.Entity<Student>().HasData(new Student { StudentName = "StudentName 91", StudentNatId = 91, Gender = grad2021.Models.Gender.ذكر });
            modelBuilder.Entity<Student>().HasData(new Student { StudentName = "StudentName 92", StudentNatId = 92, Gender = grad2021.Models.Gender.أنثى });
            modelBuilder.Entity<Student>().HasData(new Student { StudentName = "StudentName 93", StudentNatId = 93, Gender = grad2021.Models.Gender.ذكر });
            modelBuilder.Entity<Student>().HasData(new Student { StudentName = "StudentName 94", StudentNatId = 94, Gender = grad2021.Models.Gender.أنثى });
            modelBuilder.Entity<Student>().HasData(new Student { StudentName = "StudentName 95", StudentNatId = 95, Gender = grad2021.Models.Gender.ذكر });
            modelBuilder.Entity<Student>().HasData(new Student { StudentName = "StudentName 96", StudentNatId = 96, Gender = grad2021.Models.Gender.أنثى });
            modelBuilder.Entity<Student>().HasData(new Student { StudentName = "StudentName 97", StudentNatId = 97, Gender = grad2021.Models.Gender.ذكر });
            modelBuilder.Entity<Student>().HasData(new Student { StudentName = "StudentName 98", StudentNatId = 98, Gender = grad2021.Models.Gender.أنثى });
            modelBuilder.Entity<Student>().HasData(new Student { StudentName = "StudentName 99", StudentNatId = 99, Gender = grad2021.Models.Gender.ذكر });
            modelBuilder.Entity<Student>().HasData(new Student { StudentName = "StudentName 100", StudentNatId = 100, Gender = grad2021.Models.Gender.أنثى });
            modelBuilder.Entity<Student>().HasData(new Student { StudentName = "StudentName 101", StudentNatId = 101, Gender = grad2021.Models.Gender.ذكر });
            modelBuilder.Entity<Student>().HasData(new Student { StudentName = "StudentName 102", StudentNatId = 102, Gender = grad2021.Models.Gender.أنثى });
            modelBuilder.Entity<Student>().HasData(new Student { StudentName = "StudentName 103", StudentNatId = 103, Gender = grad2021.Models.Gender.ذكر });
            modelBuilder.Entity<Student>().HasData(new Student { StudentName = "StudentName 104", StudentNatId = 104, Gender = grad2021.Models.Gender.أنثى });
            modelBuilder.Entity<Student>().HasData(new Student { StudentName = "StudentName 105", StudentNatId = 105, Gender = grad2021.Models.Gender.ذكر });
            modelBuilder.Entity<Student>().HasData(new Student { StudentName = "StudentName 106", StudentNatId = 106, Gender = grad2021.Models.Gender.أنثى });
            modelBuilder.Entity<Student>().HasData(new Student { StudentName = "StudentName 107", StudentNatId = 107, Gender = grad2021.Models.Gender.ذكر });
            modelBuilder.Entity<Student>().HasData(new Student { StudentName = "StudentName 108", StudentNatId = 108, Gender = grad2021.Models.Gender.أنثى });
            modelBuilder.Entity<Student>().HasData(new Student { StudentName = "StudentName 109", StudentNatId = 109, Gender = grad2021.Models.Gender.ذكر });
            modelBuilder.Entity<Student>().HasData(new Student { StudentName = "StudentName 110", StudentNatId = 110, Gender = grad2021.Models.Gender.أنثى });
            modelBuilder.Entity<Student>().HasData(new Student { StudentName = "StudentName 111", StudentNatId = 111, Gender = grad2021.Models.Gender.ذكر });
            modelBuilder.Entity<Student>().HasData(new Student { StudentName = "StudentName 112", StudentNatId = 112, Gender = grad2021.Models.Gender.أنثى });
            modelBuilder.Entity<Student>().HasData(new Student { StudentName = "StudentName 113", StudentNatId = 113, Gender = grad2021.Models.Gender.ذكر });
            modelBuilder.Entity<Student>().HasData(new Student { StudentName = "StudentName 114", StudentNatId = 114, Gender = grad2021.Models.Gender.أنثى });
            modelBuilder.Entity<Student>().HasData(new Student { StudentName = "StudentName 115", StudentNatId = 115, Gender = grad2021.Models.Gender.ذكر });
            modelBuilder.Entity<Student>().HasData(new Student { StudentName = "StudentName 116", StudentNatId = 116, Gender = grad2021.Models.Gender.أنثى });
            modelBuilder.Entity<Student>().HasData(new Student { StudentName = "StudentName 117", StudentNatId = 117, Gender = grad2021.Models.Gender.ذكر });
            modelBuilder.Entity<Student>().HasData(new Student { StudentName = "StudentName 118", StudentNatId = 118, Gender = grad2021.Models.Gender.أنثى });
            modelBuilder.Entity<Student>().HasData(new Student { StudentName = "StudentName 119", StudentNatId = 119, Gender = grad2021.Models.Gender.ذكر });
            modelBuilder.Entity<Student>().HasData(new Student { StudentName = "StudentName 120", StudentNatId = 120, Gender = grad2021.Models.Gender.أنثى });


            //studentEnrollment

            modelBuilder.Entity<StudentEnrollment>().HasData(new StudentEnrollment { StudentNatId = 1, AcademicYearID = 2024, LevelName = grad2021.Models.LevelName.الإعدادية, BranchName = "الرياضيات والفيزيقا الهندسية" });
            modelBuilder.Entity<StudentEnrollment>().HasData(new StudentEnrollment { StudentNatId = 2, AcademicYearID = 2024, LevelName = grad2021.Models.LevelName.الإعدادية, BranchName = "الرياضيات والفيزيقا الهندسية" });
            modelBuilder.Entity<StudentEnrollment>().HasData(new StudentEnrollment { StudentNatId = 3, AcademicYearID = 2024, LevelName = grad2021.Models.LevelName.الإعدادية, BranchName = "الرياضيات والفيزيقا الهندسية" });
            modelBuilder.Entity<StudentEnrollment>().HasData(new StudentEnrollment { StudentNatId = 4, AcademicYearID = 2024, LevelName = grad2021.Models.LevelName.الإعدادية, BranchName = "الرياضيات والفيزيقا الهندسية" });
            modelBuilder.Entity<StudentEnrollment>().HasData(new StudentEnrollment { StudentNatId = 5, AcademicYearID = 2024, LevelName = grad2021.Models.LevelName.الإعدادية, BranchName = "الرياضيات والفيزيقا الهندسية" });
            modelBuilder.Entity<StudentEnrollment>().HasData(new StudentEnrollment { StudentNatId = 6, AcademicYearID = 2024, LevelName = grad2021.Models.LevelName.الإعدادية, BranchName = "الرياضيات والفيزيقا الهندسية" });
            modelBuilder.Entity<StudentEnrollment>().HasData(new StudentEnrollment { StudentNatId = 7, AcademicYearID = 2024, LevelName = grad2021.Models.LevelName.الإعدادية, BranchName = "الرياضيات والفيزيقا الهندسية" });
            modelBuilder.Entity<StudentEnrollment>().HasData(new StudentEnrollment { StudentNatId = 8, AcademicYearID = 2024, LevelName = grad2021.Models.LevelName.الإعدادية, BranchName = "الرياضيات والفيزيقا الهندسية" });
            modelBuilder.Entity<StudentEnrollment>().HasData(new StudentEnrollment { StudentNatId = 9, AcademicYearID = 2024, LevelName = grad2021.Models.LevelName.الإعدادية, BranchName = "الرياضيات والفيزيقا الهندسية" });
            modelBuilder.Entity<StudentEnrollment>().HasData(new StudentEnrollment { StudentNatId = 10, AcademicYearID = 2024, LevelName = grad2021.Models.LevelName.الإعدادية, BranchName = "الرياضيات والفيزيقا الهندسية" });
            modelBuilder.Entity<StudentEnrollment>().HasData(new StudentEnrollment { StudentNatId = 11, AcademicYearID = 2024, LevelName = grad2021.Models.LevelName.الإعدادية, BranchName = "الرياضيات والفيزيقا الهندسية" });
            modelBuilder.Entity<StudentEnrollment>().HasData(new StudentEnrollment { StudentNatId = 12, AcademicYearID = 2024, LevelName = grad2021.Models.LevelName.الإعدادية, BranchName = "الرياضيات والفيزيقا الهندسية" });
            modelBuilder.Entity<StudentEnrollment>().HasData(new StudentEnrollment { StudentNatId = 13, AcademicYearID = 2024, LevelName = grad2021.Models.LevelName.الإعدادية, BranchName = "الرياضيات والفيزيقا الهندسية" });
            modelBuilder.Entity<StudentEnrollment>().HasData(new StudentEnrollment { StudentNatId = 14, AcademicYearID = 2024, LevelName = grad2021.Models.LevelName.الإعدادية, BranchName = "الرياضيات والفيزيقا الهندسية" });
            modelBuilder.Entity<StudentEnrollment>().HasData(new StudentEnrollment { StudentNatId = 15, AcademicYearID = 2024, LevelName = grad2021.Models.LevelName.الإعدادية, BranchName = "الرياضيات والفيزيقا الهندسية" });
            modelBuilder.Entity<StudentEnrollment>().HasData(new StudentEnrollment { StudentNatId = 16, AcademicYearID = 2024, LevelName = grad2021.Models.LevelName.الإعدادية, BranchName = "الرياضيات والفيزيقا الهندسية" });
            modelBuilder.Entity<StudentEnrollment>().HasData(new StudentEnrollment { StudentNatId = 17, AcademicYearID = 2024, LevelName = grad2021.Models.LevelName.الإعدادية, BranchName = "الرياضيات والفيزيقا الهندسية" });
            modelBuilder.Entity<StudentEnrollment>().HasData(new StudentEnrollment { StudentNatId = 18, AcademicYearID = 2024, LevelName = grad2021.Models.LevelName.الإعدادية, BranchName = "الرياضيات والفيزيقا الهندسية" });
            modelBuilder.Entity<StudentEnrollment>().HasData(new StudentEnrollment { StudentNatId = 19, AcademicYearID = 2024, LevelName = grad2021.Models.LevelName.الإعدادية, BranchName = "الرياضيات والفيزيقا الهندسية" });
            modelBuilder.Entity<StudentEnrollment>().HasData(new StudentEnrollment { StudentNatId = 20, AcademicYearID = 2024, LevelName = grad2021.Models.LevelName.الإعدادية, BranchName = "الرياضيات والفيزيقا الهندسية" });
            modelBuilder.Entity<StudentEnrollment>().HasData(new StudentEnrollment { StudentNatId = 21, AcademicYearID = 2024, LevelName = grad2021.Models.LevelName.الإعدادية, BranchName = "الرياضيات والفيزيقا الهندسية" });
            modelBuilder.Entity<StudentEnrollment>().HasData(new StudentEnrollment { StudentNatId = 22, AcademicYearID = 2024, LevelName = grad2021.Models.LevelName.الإعدادية, BranchName = "الرياضيات والفيزيقا الهندسية" });
            modelBuilder.Entity<StudentEnrollment>().HasData(new StudentEnrollment { StudentNatId = 23, AcademicYearID = 2024, LevelName = grad2021.Models.LevelName.الإعدادية, BranchName = "الرياضيات والفيزيقا الهندسية" });
            modelBuilder.Entity<StudentEnrollment>().HasData(new StudentEnrollment { StudentNatId = 24, AcademicYearID = 2024, LevelName = grad2021.Models.LevelName.الإعدادية, BranchName = "الرياضيات والفيزيقا الهندسية" });
            modelBuilder.Entity<StudentEnrollment>().HasData(new StudentEnrollment { StudentNatId = 25, AcademicYearID = 2024, LevelName = grad2021.Models.LevelName.الإعدادية, BranchName = "الرياضيات والفيزيقا الهندسية" });
            modelBuilder.Entity<StudentEnrollment>().HasData(new StudentEnrollment { StudentNatId = 26, AcademicYearID = 2024, LevelName = grad2021.Models.LevelName.الإعدادية, BranchName = "الرياضيات والفيزيقا الهندسية" });
            modelBuilder.Entity<StudentEnrollment>().HasData(new StudentEnrollment { StudentNatId = 27, AcademicYearID = 2024, LevelName = grad2021.Models.LevelName.الإعدادية, BranchName = "الرياضيات والفيزيقا الهندسية" });
            modelBuilder.Entity<StudentEnrollment>().HasData(new StudentEnrollment { StudentNatId = 28, AcademicYearID = 2024, LevelName = grad2021.Models.LevelName.الإعدادية, BranchName = "الرياضيات والفيزيقا الهندسية" });
            modelBuilder.Entity<StudentEnrollment>().HasData(new StudentEnrollment { StudentNatId = 29, AcademicYearID = 2024, LevelName = grad2021.Models.LevelName.الإعدادية, BranchName = "الرياضيات والفيزيقا الهندسية" });
            modelBuilder.Entity<StudentEnrollment>().HasData(new StudentEnrollment { StudentNatId = 30, AcademicYearID = 2024, LevelName = grad2021.Models.LevelName.الإعدادية, BranchName = "الرياضيات والفيزيقا الهندسية" });
            modelBuilder.Entity<StudentEnrollment>().HasData(new StudentEnrollment { StudentNatId = 31, AcademicYearID = 2024, LevelName = grad2021.Models.LevelName.الإعدادية, BranchName = "الرياضيات والفيزيقا الهندسية" });
            modelBuilder.Entity<StudentEnrollment>().HasData(new StudentEnrollment { StudentNatId = 32, AcademicYearID = 2024, LevelName = grad2021.Models.LevelName.الإعدادية, BranchName = "الرياضيات والفيزيقا الهندسية" });
            modelBuilder.Entity<StudentEnrollment>().HasData(new StudentEnrollment { StudentNatId = 33, AcademicYearID = 2024, LevelName = grad2021.Models.LevelName.الإعدادية, BranchName = "الرياضيات والفيزيقا الهندسية" });
            modelBuilder.Entity<StudentEnrollment>().HasData(new StudentEnrollment { StudentNatId = 34, AcademicYearID = 2024, LevelName = grad2021.Models.LevelName.الإعدادية, BranchName = "الرياضيات والفيزيقا الهندسية" });
            modelBuilder.Entity<StudentEnrollment>().HasData(new StudentEnrollment { StudentNatId = 35, AcademicYearID = 2024, LevelName = grad2021.Models.LevelName.الإعدادية, BranchName = "الرياضيات والفيزيقا الهندسية" });
            modelBuilder.Entity<StudentEnrollment>().HasData(new StudentEnrollment { StudentNatId = 36, AcademicYearID = 2024, LevelName = grad2021.Models.LevelName.الإعدادية, BranchName = "الرياضيات والفيزيقا الهندسية" });
            modelBuilder.Entity<StudentEnrollment>().HasData(new StudentEnrollment { StudentNatId = 37, AcademicYearID = 2024, LevelName = grad2021.Models.LevelName.الإعدادية, BranchName = "الرياضيات والفيزيقا الهندسية" });
            modelBuilder.Entity<StudentEnrollment>().HasData(new StudentEnrollment { StudentNatId = 38, AcademicYearID = 2024, LevelName = grad2021.Models.LevelName.الإعدادية, BranchName = "الرياضيات والفيزيقا الهندسية" });
            modelBuilder.Entity<StudentEnrollment>().HasData(new StudentEnrollment { StudentNatId = 39, AcademicYearID = 2024, LevelName = grad2021.Models.LevelName.الإعدادية, BranchName = "الرياضيات والفيزيقا الهندسية" });
            modelBuilder.Entity<StudentEnrollment>().HasData(new StudentEnrollment { StudentNatId = 40, AcademicYearID = 2024, LevelName = grad2021.Models.LevelName.الإعدادية, BranchName = "الرياضيات والفيزيقا الهندسية" });
            modelBuilder.Entity<StudentEnrollment>().HasData(new StudentEnrollment { StudentNatId = 41, AcademicYearID = 2024, LevelName = grad2021.Models.LevelName.الإعدادية, BranchName = "الرياضيات والفيزيقا الهندسية" });
            modelBuilder.Entity<StudentEnrollment>().HasData(new StudentEnrollment { StudentNatId = 42, AcademicYearID = 2024, LevelName = grad2021.Models.LevelName.الإعدادية, BranchName = "الرياضيات والفيزيقا الهندسية" });
            modelBuilder.Entity<StudentEnrollment>().HasData(new StudentEnrollment { StudentNatId = 43, AcademicYearID = 2024, LevelName = grad2021.Models.LevelName.الإعدادية, BranchName = "الرياضيات والفيزيقا الهندسية" });
            modelBuilder.Entity<StudentEnrollment>().HasData(new StudentEnrollment { StudentNatId = 44, AcademicYearID = 2024, LevelName = grad2021.Models.LevelName.الإعدادية, BranchName = "الرياضيات والفيزيقا الهندسية" });
            modelBuilder.Entity<StudentEnrollment>().HasData(new StudentEnrollment { StudentNatId = 45, AcademicYearID = 2024, LevelName = grad2021.Models.LevelName.الإعدادية, BranchName = "الرياضيات والفيزيقا الهندسية" });
            modelBuilder.Entity<StudentEnrollment>().HasData(new StudentEnrollment { StudentNatId = 46, AcademicYearID = 2024, LevelName = grad2021.Models.LevelName.الإعدادية, BranchName = "الرياضيات والفيزيقا الهندسية" });
            modelBuilder.Entity<StudentEnrollment>().HasData(new StudentEnrollment { StudentNatId = 47, AcademicYearID = 2024, LevelName = grad2021.Models.LevelName.الإعدادية, BranchName = "الرياضيات والفيزيقا الهندسية" });
            modelBuilder.Entity<StudentEnrollment>().HasData(new StudentEnrollment { StudentNatId = 48, AcademicYearID = 2024, LevelName = grad2021.Models.LevelName.الإعدادية, BranchName = "الرياضيات والفيزيقا الهندسية" });
            modelBuilder.Entity<StudentEnrollment>().HasData(new StudentEnrollment { StudentNatId = 49, AcademicYearID = 2024, LevelName = grad2021.Models.LevelName.الإعدادية, BranchName = "الرياضيات والفيزيقا الهندسية" });
            modelBuilder.Entity<StudentEnrollment>().HasData(new StudentEnrollment { StudentNatId = 50, AcademicYearID = 2024, LevelName = grad2021.Models.LevelName.الإعدادية, BranchName = "الرياضيات والفيزيقا الهندسية" });
            modelBuilder.Entity<StudentEnrollment>().HasData(new StudentEnrollment { StudentNatId = 51, AcademicYearID = 2024, LevelName = grad2021.Models.LevelName.الإعدادية, BranchName = "الرياضيات والفيزيقا الهندسية" });
            modelBuilder.Entity<StudentEnrollment>().HasData(new StudentEnrollment { StudentNatId = 52, AcademicYearID = 2024, LevelName = grad2021.Models.LevelName.الإعدادية, BranchName = "الرياضيات والفيزيقا الهندسية" });
            modelBuilder.Entity<StudentEnrollment>().HasData(new StudentEnrollment { StudentNatId = 53, AcademicYearID = 2024, LevelName = grad2021.Models.LevelName.الإعدادية, BranchName = "الرياضيات والفيزيقا الهندسية" });
            modelBuilder.Entity<StudentEnrollment>().HasData(new StudentEnrollment { StudentNatId = 54, AcademicYearID = 2024, LevelName = grad2021.Models.LevelName.الإعدادية, BranchName = "الرياضيات والفيزيقا الهندسية" });
            modelBuilder.Entity<StudentEnrollment>().HasData(new StudentEnrollment { StudentNatId = 55, AcademicYearID = 2024, LevelName = grad2021.Models.LevelName.الإعدادية, BranchName = "الرياضيات والفيزيقا الهندسية" });
            modelBuilder.Entity<StudentEnrollment>().HasData(new StudentEnrollment { StudentNatId = 56, AcademicYearID = 2024, LevelName = grad2021.Models.LevelName.الإعدادية, BranchName = "الرياضيات والفيزيقا الهندسية" });
            modelBuilder.Entity<StudentEnrollment>().HasData(new StudentEnrollment { StudentNatId = 57, AcademicYearID = 2024, LevelName = grad2021.Models.LevelName.الإعدادية, BranchName = "الرياضيات والفيزيقا الهندسية" });
            modelBuilder.Entity<StudentEnrollment>().HasData(new StudentEnrollment { StudentNatId = 58, AcademicYearID = 2024, LevelName = grad2021.Models.LevelName.الإعدادية, BranchName = "الرياضيات والفيزيقا الهندسية" });
            modelBuilder.Entity<StudentEnrollment>().HasData(new StudentEnrollment { StudentNatId = 59, AcademicYearID = 2024, LevelName = grad2021.Models.LevelName.الإعدادية, BranchName = "الرياضيات والفيزيقا الهندسية" });
            modelBuilder.Entity<StudentEnrollment>().HasData(new StudentEnrollment { StudentNatId = 60, AcademicYearID = 2024, LevelName = grad2021.Models.LevelName.الإعدادية, BranchName = "الرياضيات والفيزيقا الهندسية" });
            modelBuilder.Entity<StudentEnrollment>().HasData(new StudentEnrollment { StudentNatId = 61, AcademicYearID = 2024, LevelName = grad2021.Models.LevelName.الإعدادية, BranchName = "الرياضيات والفيزيقا الهندسية" });
            modelBuilder.Entity<StudentEnrollment>().HasData(new StudentEnrollment { StudentNatId = 62, AcademicYearID = 2024, LevelName = grad2021.Models.LevelName.الإعدادية, BranchName = "الرياضيات والفيزيقا الهندسية" });
            modelBuilder.Entity<StudentEnrollment>().HasData(new StudentEnrollment { StudentNatId = 63, AcademicYearID = 2024, LevelName = grad2021.Models.LevelName.الإعدادية, BranchName = "الرياضيات والفيزيقا الهندسية" });
            modelBuilder.Entity<StudentEnrollment>().HasData(new StudentEnrollment { StudentNatId = 64, AcademicYearID = 2024, LevelName = grad2021.Models.LevelName.الإعدادية, BranchName = "الرياضيات والفيزيقا الهندسية" });
            modelBuilder.Entity<StudentEnrollment>().HasData(new StudentEnrollment { StudentNatId = 65, AcademicYearID = 2024, LevelName = grad2021.Models.LevelName.الإعدادية, BranchName = "الرياضيات والفيزيقا الهندسية" });
            modelBuilder.Entity<StudentEnrollment>().HasData(new StudentEnrollment { StudentNatId = 66, AcademicYearID = 2024, LevelName = grad2021.Models.LevelName.الإعدادية, BranchName = "الرياضيات والفيزيقا الهندسية" });
            modelBuilder.Entity<StudentEnrollment>().HasData(new StudentEnrollment { StudentNatId = 67, AcademicYearID = 2024, LevelName = grad2021.Models.LevelName.الإعدادية, BranchName = "الرياضيات والفيزيقا الهندسية" });
            modelBuilder.Entity<StudentEnrollment>().HasData(new StudentEnrollment { StudentNatId = 68, AcademicYearID = 2024, LevelName = grad2021.Models.LevelName.الإعدادية, BranchName = "الرياضيات والفيزيقا الهندسية" });
            modelBuilder.Entity<StudentEnrollment>().HasData(new StudentEnrollment { StudentNatId = 69, AcademicYearID = 2024, LevelName = grad2021.Models.LevelName.الإعدادية, BranchName = "الرياضيات والفيزيقا الهندسية" });
            modelBuilder.Entity<StudentEnrollment>().HasData(new StudentEnrollment { StudentNatId = 70, AcademicYearID = 2024, LevelName = grad2021.Models.LevelName.الإعدادية, BranchName = "الرياضيات والفيزيقا الهندسية" });
            modelBuilder.Entity<StudentEnrollment>().HasData(new StudentEnrollment { StudentNatId = 71, AcademicYearID = 2024, LevelName = grad2021.Models.LevelName.الإعدادية, BranchName = "الرياضيات والفيزيقا الهندسية" });
            modelBuilder.Entity<StudentEnrollment>().HasData(new StudentEnrollment { StudentNatId = 72, AcademicYearID = 2024, LevelName = grad2021.Models.LevelName.الإعدادية, BranchName = "الرياضيات والفيزيقا الهندسية" });
            modelBuilder.Entity<StudentEnrollment>().HasData(new StudentEnrollment { StudentNatId = 73, AcademicYearID = 2024, LevelName = grad2021.Models.LevelName.الإعدادية, BranchName = "الرياضيات والفيزيقا الهندسية" });
            modelBuilder.Entity<StudentEnrollment>().HasData(new StudentEnrollment { StudentNatId = 74, AcademicYearID = 2024, LevelName = grad2021.Models.LevelName.الإعدادية, BranchName = "الرياضيات والفيزيقا الهندسية" });
            modelBuilder.Entity<StudentEnrollment>().HasData(new StudentEnrollment { StudentNatId = 75, AcademicYearID = 2024, LevelName = grad2021.Models.LevelName.الإعدادية, BranchName = "الرياضيات والفيزيقا الهندسية" });
            modelBuilder.Entity<StudentEnrollment>().HasData(new StudentEnrollment { StudentNatId = 76, AcademicYearID = 2024, LevelName = grad2021.Models.LevelName.الإعدادية, BranchName = "الرياضيات والفيزيقا الهندسية" });
            modelBuilder.Entity<StudentEnrollment>().HasData(new StudentEnrollment { StudentNatId = 77, AcademicYearID = 2024, LevelName = grad2021.Models.LevelName.الإعدادية, BranchName = "الرياضيات والفيزيقا الهندسية" });
            modelBuilder.Entity<StudentEnrollment>().HasData(new StudentEnrollment { StudentNatId = 78, AcademicYearID = 2024, LevelName = grad2021.Models.LevelName.الإعدادية, BranchName = "الرياضيات والفيزيقا الهندسية" });
            modelBuilder.Entity<StudentEnrollment>().HasData(new StudentEnrollment { StudentNatId = 79, AcademicYearID = 2024, LevelName = grad2021.Models.LevelName.الإعدادية, BranchName = "الرياضيات والفيزيقا الهندسية" });
            modelBuilder.Entity<StudentEnrollment>().HasData(new StudentEnrollment { StudentNatId = 80, AcademicYearID = 2024, LevelName = grad2021.Models.LevelName.الإعدادية, BranchName = "الرياضيات والفيزيقا الهندسية" });
            modelBuilder.Entity<StudentEnrollment>().HasData(new StudentEnrollment { StudentNatId = 81, AcademicYearID = 2024, LevelName = grad2021.Models.LevelName.الإعدادية, BranchName = "الرياضيات والفيزيقا الهندسية" });
            modelBuilder.Entity<StudentEnrollment>().HasData(new StudentEnrollment { StudentNatId = 82, AcademicYearID = 2024, LevelName = grad2021.Models.LevelName.الإعدادية, BranchName = "الرياضيات والفيزيقا الهندسية" });
            modelBuilder.Entity<StudentEnrollment>().HasData(new StudentEnrollment { StudentNatId = 83, AcademicYearID = 2024, LevelName = grad2021.Models.LevelName.الإعدادية, BranchName = "الرياضيات والفيزيقا الهندسية" });
            modelBuilder.Entity<StudentEnrollment>().HasData(new StudentEnrollment { StudentNatId = 84, AcademicYearID = 2024, LevelName = grad2021.Models.LevelName.الإعدادية, BranchName = "الرياضيات والفيزيقا الهندسية" });
            modelBuilder.Entity<StudentEnrollment>().HasData(new StudentEnrollment { StudentNatId = 85, AcademicYearID = 2024, LevelName = grad2021.Models.LevelName.الإعدادية, BranchName = "الرياضيات والفيزيقا الهندسية" });
            modelBuilder.Entity<StudentEnrollment>().HasData(new StudentEnrollment { StudentNatId = 86, AcademicYearID = 2024, LevelName = grad2021.Models.LevelName.الإعدادية, BranchName = "الرياضيات والفيزيقا الهندسية" });
            modelBuilder.Entity<StudentEnrollment>().HasData(new StudentEnrollment { StudentNatId = 87, AcademicYearID = 2024, LevelName = grad2021.Models.LevelName.الإعدادية, BranchName = "الرياضيات والفيزيقا الهندسية" });
            modelBuilder.Entity<StudentEnrollment>().HasData(new StudentEnrollment { StudentNatId = 88, AcademicYearID = 2024, LevelName = grad2021.Models.LevelName.الإعدادية, BranchName = "الرياضيات والفيزيقا الهندسية" });
            modelBuilder.Entity<StudentEnrollment>().HasData(new StudentEnrollment { StudentNatId = 89, AcademicYearID = 2024, LevelName = grad2021.Models.LevelName.الإعدادية, BranchName = "الرياضيات والفيزيقا الهندسية" });
            modelBuilder.Entity<StudentEnrollment>().HasData(new StudentEnrollment { StudentNatId = 90, AcademicYearID = 2024, LevelName = grad2021.Models.LevelName.الإعدادية, BranchName = "الرياضيات والفيزيقا الهندسية" });
            modelBuilder.Entity<StudentEnrollment>().HasData(new StudentEnrollment { StudentNatId = 91, AcademicYearID = 2024, LevelName = grad2021.Models.LevelName.الإعدادية, BranchName = "الرياضيات والفيزيقا الهندسية" });
            modelBuilder.Entity<StudentEnrollment>().HasData(new StudentEnrollment { StudentNatId = 92, AcademicYearID = 2024, LevelName = grad2021.Models.LevelName.الإعدادية, BranchName = "الرياضيات والفيزيقا الهندسية" });
            modelBuilder.Entity<StudentEnrollment>().HasData(new StudentEnrollment { StudentNatId = 93, AcademicYearID = 2024, LevelName = grad2021.Models.LevelName.الإعدادية, BranchName = "الرياضيات والفيزيقا الهندسية" });
            modelBuilder.Entity<StudentEnrollment>().HasData(new StudentEnrollment { StudentNatId = 94, AcademicYearID = 2024, LevelName = grad2021.Models.LevelName.الإعدادية, BranchName = "الرياضيات والفيزيقا الهندسية" });
            modelBuilder.Entity<StudentEnrollment>().HasData(new StudentEnrollment { StudentNatId = 95, AcademicYearID = 2024, LevelName = grad2021.Models.LevelName.الإعدادية, BranchName = "الرياضيات والفيزيقا الهندسية" });
            modelBuilder.Entity<StudentEnrollment>().HasData(new StudentEnrollment { StudentNatId = 96, AcademicYearID = 2024, LevelName = grad2021.Models.LevelName.الإعدادية, BranchName = "الرياضيات والفيزيقا الهندسية" });
            modelBuilder.Entity<StudentEnrollment>().HasData(new StudentEnrollment { StudentNatId = 97, AcademicYearID = 2024, LevelName = grad2021.Models.LevelName.الإعدادية, BranchName = "الرياضيات والفيزيقا الهندسية" });
            modelBuilder.Entity<StudentEnrollment>().HasData(new StudentEnrollment { StudentNatId = 98, AcademicYearID = 2024, LevelName = grad2021.Models.LevelName.الإعدادية, BranchName = "الرياضيات والفيزيقا الهندسية" });
            modelBuilder.Entity<StudentEnrollment>().HasData(new StudentEnrollment { StudentNatId = 99, AcademicYearID = 2024, LevelName = grad2021.Models.LevelName.الإعدادية, BranchName = "الرياضيات والفيزيقا الهندسية" });
            modelBuilder.Entity<StudentEnrollment>().HasData(new StudentEnrollment { StudentNatId = 100, AcademicYearID = 2024, LevelName = grad2021.Models.LevelName.الإعدادية, BranchName = "الرياضيات والفيزيقا الهندسية" });
            modelBuilder.Entity<StudentEnrollment>().HasData(new StudentEnrollment { StudentNatId = 101, AcademicYearID = 2024, LevelName = grad2021.Models.LevelName.الإعدادية, BranchName = "الرياضيات والفيزيقا الهندسية" });
            modelBuilder.Entity<StudentEnrollment>().HasData(new StudentEnrollment { StudentNatId = 102, AcademicYearID = 2024, LevelName = grad2021.Models.LevelName.الإعدادية, BranchName = "الرياضيات والفيزيقا الهندسية" });
            modelBuilder.Entity<StudentEnrollment>().HasData(new StudentEnrollment { StudentNatId = 103, AcademicYearID = 2024, LevelName = grad2021.Models.LevelName.الإعدادية, BranchName = "الرياضيات والفيزيقا الهندسية" });
            modelBuilder.Entity<StudentEnrollment>().HasData(new StudentEnrollment { StudentNatId = 104, AcademicYearID = 2024, LevelName = grad2021.Models.LevelName.الإعدادية, BranchName = "الرياضيات والفيزيقا الهندسية" });
            modelBuilder.Entity<StudentEnrollment>().HasData(new StudentEnrollment { StudentNatId = 105, AcademicYearID = 2024, LevelName = grad2021.Models.LevelName.الإعدادية, BranchName = "الرياضيات والفيزيقا الهندسية" });
            modelBuilder.Entity<StudentEnrollment>().HasData(new StudentEnrollment { StudentNatId = 106, AcademicYearID = 2024, LevelName = grad2021.Models.LevelName.الإعدادية, BranchName = "الرياضيات والفيزيقا الهندسية" });
            modelBuilder.Entity<StudentEnrollment>().HasData(new StudentEnrollment { StudentNatId = 107, AcademicYearID = 2024, LevelName = grad2021.Models.LevelName.الإعدادية, BranchName = "الرياضيات والفيزيقا الهندسية" });
            modelBuilder.Entity<StudentEnrollment>().HasData(new StudentEnrollment { StudentNatId = 108, AcademicYearID = 2024, LevelName = grad2021.Models.LevelName.الإعدادية, BranchName = "الرياضيات والفيزيقا الهندسية" });
            modelBuilder.Entity<StudentEnrollment>().HasData(new StudentEnrollment { StudentNatId = 109, AcademicYearID = 2024, LevelName = grad2021.Models.LevelName.الإعدادية, BranchName = "الرياضيات والفيزيقا الهندسية" });
            modelBuilder.Entity<StudentEnrollment>().HasData(new StudentEnrollment { StudentNatId = 110, AcademicYearID = 2024, LevelName = grad2021.Models.LevelName.الإعدادية, BranchName = "الرياضيات والفيزيقا الهندسية" });
            modelBuilder.Entity<StudentEnrollment>().HasData(new StudentEnrollment { StudentNatId = 111, AcademicYearID = 2024, LevelName = grad2021.Models.LevelName.الإعدادية, BranchName = "الرياضيات والفيزيقا الهندسية" });
            modelBuilder.Entity<StudentEnrollment>().HasData(new StudentEnrollment { StudentNatId = 112, AcademicYearID = 2024, LevelName = grad2021.Models.LevelName.الإعدادية, BranchName = "الرياضيات والفيزيقا الهندسية" });
            modelBuilder.Entity<StudentEnrollment>().HasData(new StudentEnrollment { StudentNatId = 113, AcademicYearID = 2024, LevelName = grad2021.Models.LevelName.الإعدادية, BranchName = "الرياضيات والفيزيقا الهندسية" });
            modelBuilder.Entity<StudentEnrollment>().HasData(new StudentEnrollment { StudentNatId = 114, AcademicYearID = 2024, LevelName = grad2021.Models.LevelName.الإعدادية, BranchName = "الرياضيات والفيزيقا الهندسية" });
            modelBuilder.Entity<StudentEnrollment>().HasData(new StudentEnrollment { StudentNatId = 115, AcademicYearID = 2024, LevelName = grad2021.Models.LevelName.الإعدادية, BranchName = "الرياضيات والفيزيقا الهندسية" });
            modelBuilder.Entity<StudentEnrollment>().HasData(new StudentEnrollment { StudentNatId = 116, AcademicYearID = 2024, LevelName = grad2021.Models.LevelName.الإعدادية, BranchName = "الرياضيات والفيزيقا الهندسية" });
            modelBuilder.Entity<StudentEnrollment>().HasData(new StudentEnrollment { StudentNatId = 117, AcademicYearID = 2024, LevelName = grad2021.Models.LevelName.الإعدادية, BranchName = "الرياضيات والفيزيقا الهندسية" });
            modelBuilder.Entity<StudentEnrollment>().HasData(new StudentEnrollment { StudentNatId = 118, AcademicYearID = 2024, LevelName = grad2021.Models.LevelName.الإعدادية, BranchName = "الرياضيات والفيزيقا الهندسية" });
            modelBuilder.Entity<StudentEnrollment>().HasData(new StudentEnrollment { StudentNatId = 119, AcademicYearID = 2024, LevelName = grad2021.Models.LevelName.الإعدادية, BranchName = "الرياضيات والفيزيقا الهندسية" });
            modelBuilder.Entity<StudentEnrollment>().HasData(new StudentEnrollment { StudentNatId = 120, AcademicYearID = 2024, LevelName = grad2021.Models.LevelName.الإعدادية, BranchName = "الرياضيات والفيزيقا الهندسية" });


            //Calculated Column Entities

            //modelBuilder.Entity<Mark>()
            //.Property(c => c.TotalMark)
            //.HasComputedColumnSql("[MidTermMark] + [CourseWorkMark] + [OralExamMark] + [FinalExamMark] + [MerciMark]");


        }
    }
}