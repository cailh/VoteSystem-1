using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VoteSystem.Logic.Models
{
    public class Record
    {
        public DateTime VoteTime { get; set; }
        public string VoteUserName { get; set; }
        public string ActivityName { get; set; }
        public string ProjectName { get; set; }
        public int ActivityID { get; set; }
        public int ProjectID { get; set; }
        public int UserID { get; set; }
    }
}
