using AutoMapper;
using MbCore.Api.Dtos;
using MbCore.EntityFramework.Models;

namespace MbCore.Api.Dtos
{
    public class ExperienceWithPicDto : ExperienceDto
    {
        public byte[] Image { get; set; }
    }
}
public class ExperienceNoPicDtoMapper : Profile
{
    public ExperienceNoPicDtoMapper()
    {
        CreateMap<Experience, ExperienceWithPicDto>();
    }

}
