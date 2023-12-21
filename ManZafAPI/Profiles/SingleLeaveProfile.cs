namespace ManZafAPI.Profiles
{
    public class SingleLeaveProfile : AutoMapper.Profile
    {
        public SingleLeaveProfile()
        {
            CreateMap<ManZafModels.BL.SingleLeave, Models.SingleLeaveDto>();
            CreateMap<Models.SingleLeaveForCreationDto, ManZafModels.BL.SingleLeave>();
            CreateMap<ManZafModels.BL.SingleLeave, Models.SingleLeaveWithIdsDto>();
        }
    }
}
