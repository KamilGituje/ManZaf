using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManZafModels.BL
{
    public class WorkerLeave
    {
        public int WorkerId { get; set; }
        public int LeaveId { get; set; }
        public Worker Worker { get; set; }
        public Leave Leave { get; set; }
        public int Quantity { get; set; }
    }
}