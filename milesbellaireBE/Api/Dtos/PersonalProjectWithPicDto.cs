using AutoMapper;
using MbCore.Api.Dtos;
using MbCore.EntityFramework.Models;

namespace MbCore.Api.Dtos
{
    public class PersonalProjectWithPicDto : PersonalProjectDto
    {
        public byte[] Image { get; set; }
    }
}

public class PersonalProjectWithPicDtoMapper : Profile
{
    public PersonalProjectWithPicDtoMapper()
    {
        CreateMap<PersonalProject, PersonalProjectWithPicDto>();
    }

}
