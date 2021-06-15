using grad2021.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace grad2021.Models
{
    public class StudentSorting
    {
        public ulong StudentNatId { get; set; }
        public LevelName LevelName { get; set; }
        public double CompleteLevelMark { get; set; }
    }
}
