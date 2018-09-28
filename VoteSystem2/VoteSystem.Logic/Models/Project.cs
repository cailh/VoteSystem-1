using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VoteSystem.Logic.Models
{
    public class Project
    {
        public string ProjectName { get; set; }
        public string ProjectIntroduction { get; set; }
        public int VoteNumber { get; set; }
        public int ActivityID { get; set; }
        public int ProjectID { get; set; }
        public string ActivityName { get; set; }
    }
}
