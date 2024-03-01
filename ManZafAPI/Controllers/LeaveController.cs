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
        public async Task<ActionResult<List<LeaveWithoutWorkerDto>>> GetAvailableLeavesForWorker(int workerId)
        {
            return Ok(mapper.Map<List<LeaveWithoutWorkerDto>>(await leaveRepository.GetAvailableLeaves(workerId)));
        }
        [HttpPut("{workerId}/update")]
        public async Task<ActionResult<LeaveDto>> UpdateAvailableLeaveForWorker(LeaveForUpdate leave, int workerId)
        {
            leave.WorkerId = workerId;
            var updatedLeave = await leaveService.UpdateAvailableLeaveForWorker(mapper.Map<Leave>(leave));
            return Ok(mapper.Map<LeaveDto>(updatedLeave));
        }
        [HttpPut("{workerId}/adddays")]
        public async Task<ActionResult<LeaveDto>> AddDaysToLeaveForWorkerAsync(LeaveForAddingDaysDto leave, int workerId)
        {
            leave.WorkerId = workerId;
            var leaveDaysAdded = await leaveService.AddDaysToLeaveForWorkerAsync(mapper.Map<Leave>(leave), leave.DaysNumber);
            return Ok(mapper.Map<LeaveDto>(leaveDaysAdded));
        }
    }
}
