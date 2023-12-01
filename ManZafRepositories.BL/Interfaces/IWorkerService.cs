using ManZafModels.BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManZafRepositories.BL.Interfaces
{
    public interface IWorkerService
    {
        public Task<Worker> CreateAsync(Worker worker);
        public Task<Worker> UpdateAsync(Worker worker);
        public bool IsValid(Worker worker);
    }
}
