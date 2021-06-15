using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace grad2021.Models
{
    public class Student
    {
        [Display(Name = "الاسم بالكامل")]
        public string StudentName { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Display(Name = "الرقم القومي")]
        public ulong StudentNatId { get; set; }

        [Display(Name = "تاريخ الميلاد")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? BirthDate { get; set; }

        [Display(Name = "محل الميلاد")]
        public string? BirthPlace { get; set; }

        [Display(Name = "النوع")]
        public Gender Gender { get; set; }

        [Display(Name = "رقم المحمول")]
        [DisplayFormat(DataFormatString = "{0:###-###-####}", ApplyFormatInEditMode = true)]
        public long? Phone { get; set; }

        [Display(Name = "تاريخ الالتحاق بالكلية")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? EnrollmentDate { get; set; }

        [Display(Name = "رقم الجلوس")]
        public int? SeatNo { get; set; }


        public ICollection<StudentEnrollment> StudentEnrollments { get; set; }
        public ICollection<Selection> Selections { get; set; }

    }
}
