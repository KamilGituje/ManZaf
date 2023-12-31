﻿using ManZafModels.BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManZafRepositories.BL.Interfaces
{
    public interface IWorkerService
    {
        Task<Worker> CreateAsync(Worker worker);
        Task<Worker> UpdateAsync(Worker worker);
    }
}