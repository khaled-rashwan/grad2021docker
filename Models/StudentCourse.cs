using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace grad2021.Models
{
    public class StudentCourse
    {
        public int StudentCourseID { get; set; }

        [Display(Name = "اسم المقرر")]
        public string CourseName { get; set; }

        [Display(Name = "العام الدراسي")]
        public int AcademicYearID { get; set; }

        [Display(Name = "شعبة")]
        public string BranchName { get; set; }
      
        [Display(Name = "الرقم القومي")]
        public ulong StudentNatId { get; set; }

        //[Display(Name = "دور نوفمبر")]
        //public bool IsNovember { get; set; } = false;

        [Display(Name = "درجة امتحان منتصف الفصل الدراسي")]
        public double MidTermMark { get; set; } = 0;

        [Display(Name = "درجة أعمال السنة")]
        public double CourseWorkMark { get; set; } = 0;

        [Display(Name = "درجة امتحان الشفوي")]
        public double OralExamMark { get; set; } = 0;

        [Display(Name = "درجة الامتحان النهائي")]
        public double FinalExamMark { get; set; } = 0;

        [Display(Name = "درجات الرأفة")]
        public double MerciMark { get; set; } = 0;

        [Display(Name = "امتحان نوفمبر")]
        public bool IsNovember { get; set; } = false;

        //[Display(Name = "المجموع الكلي للمقرر")]

        //public double TotalMark { get; set; }

        //[Display(Name = "حالة النجاح")]
        //public bool SucceedInTotalMark { get; set; }

        public StudentEnrollment StudentEnrollment { get; set; }
        public CourseEnrollment CourseEnrollment { get; set; }
    }
}
