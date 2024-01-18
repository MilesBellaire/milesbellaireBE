using AutoMapper;
using MbCore.Api.Dtos;
using MbCore.EntityFramework.Models;

namespace MbCore.Api.Dtos
{
    public class WorkExperienceDto : ExperienceDto
    {
        public string Position { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public bool CurrentPosition { get; set; }
    }
}
public class WorkExperienceDtoMapper : Profile
{
    public WorkExperienceDtoMapper()
    {
        CreateMap<WorkExperience, WorkExperienceDto>();
    }

}
