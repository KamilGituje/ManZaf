using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManZafModels.BL
{
    public class LeaveType
    {
        public int LeaveTypeId { get; set; }
        public string Name { get; set; }
    }
}
