using AutoMapper;
using MbCore.Api.Dtos;
using MbCore.EntityFramework.Models;

namespace MbCore.Api.Dtos
{
    public class ExperienceDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Priority { get; set; }
        public List<string> Tags { get; set; }
    }
}
public class ExperienceDtoMapper : Profile
{
    public ExperienceDtoMapper()
    {
        CreateMap<Experience, ExperienceDto>()
            .Include<WorkExperience, WorkExperienceDto>()
            .Include<WorkExperience, WorkExperienceWithPicDto>()
            .Include<PersonalProject, PersonalProjectDto>()
            .Include<PersonalProject, PersonalProjectWithPicDto>()
            .ForMember(e => e.Tags, opt => opt.MapFrom(e => e.Tags.Select(t => t.Name)));
    }

}
