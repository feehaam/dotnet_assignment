using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Model
{
    public class Tasks
    {
        public int Id { get; set; }
        public bool IsComplete { get; set; }
        public string TaskName { get; set; } = string.Empty;
        public DateTime DelivaryTime { get; set; }
        public string OrderFor { get; set; } = string.Empty ;
    }
}
