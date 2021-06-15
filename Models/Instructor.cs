using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace grad2021.Models
{
    public class Instructor
    {
        [Display(Name = "الاسم بالكامل")]
        public string InstructorName { get; set; }

        [Display(Name = "الرقم القومي")]
        public ulong InstructorNatId { get; set; }

        [Display(Name = "تاريخ الميلاد")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? BirthDate { get; set; }

        [Display(Name = "محل الميلاد")]
        public string? BirthPlace { get; set; }

        [Display(Name = "النوع")]
        public Gender? Gender { get; set; }

        [Display(Name = "رقم المحمول")]
        [DisplayFormat(DataFormatString = "{0:###-###-####}", ApplyFormatInEditMode = true)]
        public long? Phone { get; set; }
        [Display(Name = "تاريخ التعيين")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? HireDate { get; set; }

        [Display(Name = "قسم")]
        public string DepartmentName { get; set; }


        public Department Department { get; set; }


        public ICollection<InstructorProfession> InstructorProfessions { get; set; }
        public ICollection<InstructorEnrollment> InstructorEnrollments { get; set; }
    }
}
