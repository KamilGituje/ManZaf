using AutoMapper;
using ManZafAPI.Models;
using ManZafModels.BL;
using ManZafRepositories.BL;
using ManZafRepositories.BL.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ManZafAPI.Controllers
{
    [Route("api/workers")]
    [ApiController]
    public class WorkerController : ControllerBase
    {
        public WorkerController(IWorkerRepository _workerRepository, IWorkerService _workerService, IMapper _mapper)
        {
            workerRepository = _workerRepository;
            workerService = _workerService;
            mapper = _mapper;
        }
        private readonly IMapper mapper;
        private readonly IWorkerRepository workerRepository;
        private readonly IWorkerService workerService;

        [HttpGet("{workerId}", Name = "GetWorker")]
        public async Task<ActionResult<WorkerDto>> GetWorkerAsync(int workerId)
        {
            var worker = await workerRepository.GetWithSubordinatesAsync(workerId);
            if (worker != null)
            {
                return Ok(mapper.Map<WorkerDto>(worker));
            }
            return NotFound();
        }
        [HttpGet("{workerId}/subordinates")]
        public async Task<ActionResult<WorkerWithoutSubordinatesDto>> GetWorkerWithoutSubordinatesAsync(int workerId)
        {
            var worker = await workerRepository.GetAsync(workerId);
            if (worker != null)
            {
                return Ok(mapper.Map<WorkerWithoutSubordinatesDto>(worker));
            }
            return NotFound();
        }
        [HttpPost("create")]
        public async Task<ActionResult<WorkerWithoutSubordinatesDto>> CreateWorkerAsync(WorkerForCreationDto workerToAdd)
        {
            var workerAdded = await workerService.CreateAsync(mapper.Map<Worker>(workerToAdd));
            return CreatedAtRoute("GetWorker",
                new
                {
                    workerId = workerAdded.WorkerId,
                },
                    mapper.Map<WorkerWithoutSubordinatesDto>(workerAdded));
        }
        [HttpPut("{workerId}/update")]
        public async Task<ActionResult<WorkerDto>> UpdateWorkerAsync(WorkerForUpdateDto worker, int workerId)
        {
            var updatedWorker = mapper.Map<Worker>(worker);
            updatedWorker.WorkerId = workerId;
            await workerService.UpdateAsync(updatedWorker);
            if (updatedWorker != null)
            {
                return Ok(mapper.Map<WorkerDto>(updatedWorker));
            }
            return NotFound();
        }
        [HttpDelete("{workerId}/delete")]
        public async Task<ActionResult<bool>> RemoveWorkerAsync(int workerId)
        {
            var isRemoved = await workerRepository.RemoveAsync(workerId);
            if (isRemoved)
            {
                return Ok();
            }
            return NotFound();
        }
    }
}