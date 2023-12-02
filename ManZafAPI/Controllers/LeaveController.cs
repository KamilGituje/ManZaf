using AutoMapper;
using ManZafAPI.Models;
using ManZafModels.BL;
using ManZafRepositories.BL.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ManZafAPI.Controllers
{
    [Route("api/leaves")]
    [ApiController]
    public class LeaveController : ControllerBase
    {
        public LeaveController(IMapper _mapper, ILeaveRepository _leaveRepository, ILeaveService _leaveService)
        {
            mapper = _mapper;
            leaveRepository = _leaveRepository;
            leaveService = _leaveService;
        }
        private readonly IMapper mapper;
        private readonly ILeaveRepository leaveRepository;
        private readonly ILeaveService leaveService;

        [HttpGet("{workerId}")]
        public async Task<ActionResult<List<WorkerLeaveWithoutWorkerDto>>> GetAvailableLeavesForWorker(int workerId)
        {
            return Ok(mapper.Map<List<WorkerLeaveWithoutWorkerDto>>(await leaveRepository.GetAvailableLeavesForWorker(workerId)));
        }
        [HttpPut("{workerId}/update")]
        public async Task<ActionResult<WorkerLeaveDto>> UpdateAvailableLeaveForWorker(WorkerLeaveForUpdate leave, int workerId)
        {
            leave.WorkerId = workerId;
            var updatedLeave = await leaveService.UpdateAvailableLeavesForWorker(mapper.Map<WorkerLeave>(leave));
            return Ok(mapper.Map<WorkerLeaveDto>(updatedLeave));
        }
    }
}
