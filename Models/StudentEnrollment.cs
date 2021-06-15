using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace grad2021.Models
{
    public class StudentEnrollment
    {
        //public int StudentEnrollmentID { get; set; }

        [Display(Name = "الرقم القومي")]
        public ulong StudentNatId { get; set; }

        public int AcademicYearID { get; set; }

        [Display(Name = "الفرقة")]
        public LevelName LevelName { get; set; }

        [Display(Name = "شعبة")]
        public string BranchName { get; set; }

        [Display(Name = "ناجح نوفمبر")]
        public bool IsNovember { get; set; } = false;

        //These classes are retreived to 
        public Branch Branch { get; set; }
        public Student Student { get; set; }
        public AcademicYear AcademicYear { get; set; }

        public ICollection<StudentCourse> StudentCourses { get; set; }
        public List<Selection> Selections { get; set; }
        //public ICollection<StudentDepartmentChoice> StudentDepartmentChoices { get; set; }
    }
}
