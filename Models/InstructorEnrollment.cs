using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace grad2021.Models
{
    public class InstructorEnrollment
    {
        public int InstructorEnrollmentID { get; set; }

        [Display(Name = "اسم عضو هيئة التدريس")]
        public ulong InstructorNatId { get; set; }

        [Display(Name = "تاريخ بداية الفصل الدراسي")]
        public int AcademicYearID { get; set; }

        [Display(Name = "اسم المادة")]
        public string CourseName { get; set; }

        [Display(Name = "شعبة")]
        public string BranchName { get; set; }


        public Instructor Instructor { get; set; }
        public AcademicYear AcademicYear { get; set; }
        public CourseEnrollment CourseEnrollment { get; set; }
    }
}
