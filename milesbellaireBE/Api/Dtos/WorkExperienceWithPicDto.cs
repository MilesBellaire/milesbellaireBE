using AutoMapper;
using MbCore.Api.Dtos;
using MbCore.EntityFramework.Models;

namespace MbCore.Api.Dtos
{
    public class WorkExperienceWithPicDto : WorkExperienceDto
    {
        public byte[] Image { get; set; }
    }
}
public class WorkExperienceNoPicDtoMapper : Profile
{
    public WorkExperienceNoPicDtoMapper()
    {
        CreateMap<WorkExperience, WorkExperienceWithPicDto>();
    }

}