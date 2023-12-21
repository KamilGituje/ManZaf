using AutoMapper;
using ManZafAPI.Models;
using ManZafModels.BL;
using ManZafRepositories.BL.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ManZafAPI.Controllers
{
    [Route("api/singleleaves")]
    [ApiController]
    public class SingleLeaveController : ControllerBase
    {
        public SingleLeaveController(IMapper _mapper, ISingleLeaveRepository _singleLeaveRepository, ISingleLeaveService _singleLeaveService)
        {
            mapper = _mapper;
            singleLeaveRepository = _singleLeaveRepository;
            singleLeaveService = _singleLeaveService;
        }
        private readonly IMapper mapper;
        private readonly ISingleLeaveRepository singleLeaveRepository;
        private readonly ISingleLeaveService singleLeaveService;

        [HttpGet("{singleLeaveId}", Name = "GetSingleLeave")]
        public async Task<ActionResult<SingleLeaveDto>> GetSingleLeaveAsync(int singleLeaveId)
        {
            return mapper.Map<SingleLeaveDto>(await singleLeaveRepository.GetAsync(singleLeaveId));
        }
        [HttpGet("workers/{workerId}")]
        public async Task<ActionResult<List<SingleLeaveDto>>> GetSingleLeavesAsync(int workerId)
        {
            return Ok(mapper.Map<List<SingleLeaveDto>>(await singleLeaveRepository.GetSingleLeavesAsync(workerId)));
        }
        [HttpGet("managers/{managerId}")]
        public async Task<ActionResult<List<SingleLeaveDto>>> GetSingleLeavesByManagerId(int managerId, bool unmanaged = false)
        {
            if (unmanaged)
            {
                return Ok(mapper.Map<List<SingleLeaveDto>>(await singleLeaveRepository.GetSingleLeavesUnmanagedByManagerIdAsync(managerId)));
            }
            return Ok(mapper.Map<List<SingleLeaveDto>>(await singleLeaveRepository.GetSingleLeavesByManagerIdAsync(managerId)));
        }
        [HttpPost("workers/{workerId}/create")]
        public async Task<ActionResult<SingleLeaveWithIdsDto>> AddSingleLeaveAsync(SingleLeaveForCreationDto singleLeave, int workerId)
        {
            singleLeave.WorkerId = workerId;
            var singleLeaveAdded = await singleLeaveService.AddSingleLeaveAsync(mapper.Map<SingleLeave>(singleLeave));
            if (singleLeaveAdded != null)
            {
                return CreatedAtRoute("GetSingleLeave",
                    new
                    {
                        singleLeaveId = singleLeaveAdded.SingleLeaveId
                    },
                    mapper.Map<SingleLeaveWithIdsDto>(singleLeaveAdded));
            }
            return BadRequest();
        }
    }
}
