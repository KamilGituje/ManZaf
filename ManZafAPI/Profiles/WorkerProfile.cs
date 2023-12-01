using AutoMapper;

namespace ManZafAPI.Profiles
{
    public class WorkerProfile : AutoMapper.Profile
    {
      public WorkerProfile()
        {
            CreateMap<ManZafModels.BL.Worker, Models.WorkerWithoutSubordinatesDto>();
            CreateMap<Models.WorkerWithoutSubordinatesDto, ManZafModels.BL.Worker>();
            CreateMap<Models.WorkerForCreationDto, ManZafModels.BL.Worker>();
            CreateMap<ManZafModels.BL.Worker, Models.WorkerDto>();
            CreateMap<Models.WorkerForUpdateDto, ManZafModels.BL.Worker>();
        }
    }
}