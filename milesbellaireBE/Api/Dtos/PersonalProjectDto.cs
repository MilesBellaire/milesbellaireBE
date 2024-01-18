using AutoMapper;
using MbCore.Api.Dtos;
using MbCore.EntityFramework.Models;

namespace MbCore.Api.Dtos
{
    public class PersonalProjectDto : ExperienceDto
    {

    }
}

public class PersonalProjectDtoMapper : Profile
{
    public PersonalProjectDtoMapper()
    {
        CreateMap<PersonalProject, PersonalProjectDto>();
    }

}
