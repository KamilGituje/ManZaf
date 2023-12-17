namespace ManZafAPI.Profiles
{
    public class LeaveProfile : AutoMapper.Profile
    {
        public LeaveProfile()
        {
            CreateMap<Models.LeaveForUpdate, ManZafModels.BL.Leave>();
            CreateMap<ManZafModels.BL.Leave, Models.LeaveDto>();
            CreateMap<ManZafModels.BL.Leave, Models.LeaveWithoutWorkerDto>();
            CreateMap<Models.LeaveForAddingDaysDto, ManZafModels.BL.Leave>();
            CreateMap<ManZafModels.BL.Leave, Models.LeaveDto>();
        }
    }
}
