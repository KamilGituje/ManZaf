using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManZafModels.BL
{
    public class Leave
    {
        public Leave()
        {

        }
        public int LeaveId { get; set; }
        public string Type { get; set; }
    }
}
