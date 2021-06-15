using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace grad2021.Models
{
    public class StudentTransfer : Student
    {
        [Display(Name = "شعبة")]
        public string BranchName { get; set; }

        [Display(Name = "الفرقة")]
        public LevelName LevelName { get; set; }
    }
}
