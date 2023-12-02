namespace ManZafAPI.Profiles
{
    public class WorkerLeaveProfile : AutoMapper.Profile
    {
        public WorkerLeaveProfile()
        {
            CreateMap<Models.WorkerLeaveForUpdate, ManZafModels.BL.WorkerLeave>();
            CreateMap<ManZafModels.BL.WorkerLeave, Models.WorkerLeaveDto>();
            CreateMap<ManZafModels.BL.WorkerLeave, Models.WorkerLeaveWithoutWorkerDto>();
        }
    }
}
