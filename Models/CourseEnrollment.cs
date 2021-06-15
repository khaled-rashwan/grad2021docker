using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace grad2021.Models
{
    public class CourseEnrollment
    {
        //public int CourseEnrollmentID { get; set; }

        [Display(Name = "اسم المادة")]
        public string CourseName { get; set; }

        [Display(Name = "الفرقة")]
        public LevelName LevelName { get; set; }


        [Display(Name = "شعبة")]
        public string BranchName { get; set; }

        [Display(Name = "الفصل الدراسي")]
        public Term Term { get; set; }

        public Course Course { get; set; }
        public Branch Branch { get; set; }


        public ICollection<InstructorEnrollment> InstructorEnrollments { get; set; }
        public ICollection<StudentCourse> StudentCourses { get; set; }
    }
}