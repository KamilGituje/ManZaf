using ManZafDatabase;
using ManZafModels.BL;
using ManZafRepositories.BL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ManZafRepositories.BL
{
    public class WorkerService : IWorkerService
    {
        public WorkerService(IWorkerRepository _workerRepository)
        {
            workerRepository = _workerRepository;
        }
        private readonly IWorkerRepository workerRepository;

        public async Task<Worker> CreateAsync(Worker worker)
        {
            if (IsValid(worker))
            {
                worker.HiringDate = DateOnly.FromDateTime(DateTime.Now);
                await workerRepository.AddAsync(worker);
                await workerRepository.SaveChangesAsync();
                return worker;
            }
            return null;
        }
        public async Task<Worker> UpdateAsync(Worker worker)
        {
            var workerToUpdate = await workerRepository.GetAsync(worker.WorkerId);
            if (workerToUpdate != null)
            {
                var properties = worker.GetType().GetProperties().ToList();
                foreach (var prop in properties)
                {
                    if (worker.GetType().GetProperty(prop.Name).GetValue(worker) != null)
                    {
                        workerToUpdate.GetType().GetProperty(prop.Name).SetValue(workerToUpdate, prop.GetValue(worker));
                    }
                }
                if (worker.ManagerId == null)
                {
                    workerToUpdate.ManagerId = null;
                }
                await workerRepository.SaveChangesAsync();
            }
            return workerToUpdate;
        }
        public bool IsValid(Worker worker)
        {
            if (!string.IsNullOrWhiteSpace(worker.FirstName))
            {
                if (!string.IsNullOrWhiteSpace(worker.LastName))
                {
                    if (!string.IsNullOrWhiteSpace(worker.Email))
                    {
                        if (!string.IsNullOrWhiteSpace(worker.BirthDate.ToString()))
                        {
                            return true;
                        }
                    }
                }
            }
            return false;
        }
    }
}