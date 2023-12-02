using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManZafModels.BL
{
    public class Leave
    {
        public int WorkerId { get; set; }
        public int LeaveTypeId { get; set; }
        public Worker Worker { get; set; }
        public LeaveType LeaveType { get; set; }
        public int Quantity { get; set; }
    }
}