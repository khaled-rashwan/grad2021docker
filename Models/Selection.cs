using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace grad2021.Models
{
    public class Selection
    {
        public int SelectionID { get; set; }
        [Display(Name = "الرقم القومي للطالب")]
        public ulong StudentNatId { get; set; }

        [Display(Name = "العام الدراسي")]
        public int AcademicYearID { get; set; }

        [Display(Name = "رقم الرغبة")]
        public int SelectionNo { get; set; }

        [Display(Name = "القسم الحالي للطالب")]
        public string CurrentBranchName { get; set; }

        [Display(Name = "القسم أو الشعبة المرغوب الالتحاق بها")]
        public string SelectionBranchName { get; set; }

        public StudentEnrollment StudentEnrollment { get; set; }
        public Branch CurrentBranch { get; set; }
        public Branch SelectionBranch { get; set; }
    }
}
