using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManZafModels.BL
{
    public class Worker
    {
        public int WorkerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public DateOnly BirthDate { get; set; }
        public DateOnly HiringDate { get; set; }
        public int? ManagerId { get; set; }
        public List<Worker> Workers { get; set; }
    }
}