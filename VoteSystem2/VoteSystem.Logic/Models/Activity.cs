using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VoteSystem.Logic.Models
{
    public class Activity
    {
        public string ActivityName { get; set; }
        public int ActivityID { get; set; }
        public string ActivityIntroduction { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
    }
}
