namespace ManZafAPI.Profiles
{
    public class WorkerLeaveProfile : AutoMapper.Profile
    {
        public WorkerLeaveProfile()
        {
            CreateMap<Models.LeaveForUpdate, ManZafModels.BL.Leave>();
            CreateMap<ManZafModels.BL.Leave, Models.LeaveDto>();
            CreateMap<ManZafModels.BL.Leave, Models.LeaveWithoutWorkerDto>();
        }
    }
}
