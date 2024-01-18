using Microsoft.AspNetCore.Mvc;
using MbCore.EntityFramework;
using MbCore.EntityFramework.Models;
using Microsoft.EntityFrameworkCore;
using MbCore.Api.Dtos;
using AutoMapper;

namespace MbCore.Api.Controllers
{

    [ApiController]
    [Route("api/work-experience")]
    public class WorkExperienceController(DatabaseContext db, IMapper mapper) : Controller
    {
        private readonly DatabaseContext _db = db;
        private readonly IMapper _mapper = mapper;

        [HttpGet]
        public async Task<ActionResult> Get()
        {
            List<WorkExperience> items = await _db.WorkExperience
                .Include(e => e.Tags).AsSplitQuery()
                .OrderBy(e => e.Priority)
                .ToListAsync();

            List<WorkExperienceWithPicDto> itemsDto = _mapper.Map<List<WorkExperienceWithPicDto>>(items);
            return Ok(itemsDto);
        }

        [HttpPost]
        public async Task<ActionResult> Create([FromBody] WorkExperienceDto request)
        {

            WorkExperience workExperience = new()
            {
                Name = request.Name,
                Description = request.Description,
                Priority = request.Priority,
                Tags = request.Tags.Select(t => new Tag(t)).ToList(),
                StartDate = request.StartDate,
                EndDate = request.EndDate,
                CurrentPosition = request.CurrentPosition,
                Position = request.Position,
            };

            WorkExperienceDto workExperienceNoPicDto = _mapper.Map<WorkExperienceDto>(workExperience);
            await _db.AddAsync(workExperience);
            await _db.SaveChangesAsync();

            return Ok(workExperienceNoPicDto);
        }

        [HttpPut("{workExperienceId}")]
        public async Task<ActionResult> Update([FromRoute] int workExperienceId, [FromBody] WorkExperienceDto request)
        {
            WorkExperience workExperience = _db.WorkExperience.Where(e => e.Id == workExperienceId)
                .Include(e => e.Tags).AsSplitQuery()
                .FirstOrDefault();


            workExperience.Name = request.Name;
            workExperience.Description = request.Description;
            workExperience.Priority = request.Priority;
            workExperience.Tags = request.Tags.Select(t => new Tag(t)).ToList();
            workExperience.Position = request.Position;
            workExperience.StartDate = request.StartDate;
            workExperience.EndDate = request.EndDate;
            workExperience.CurrentPosition = request.CurrentPosition;

            WorkExperienceDto workExperienceNoPicDto = _mapper.Map<WorkExperienceDto>(workExperience);
            _db.Update(workExperience);
            await _db.SaveChangesAsync();

            return Ok(workExperienceNoPicDto);
        }

        [HttpPost("file/{workExperienceId}")]
        public async Task<ActionResult> Create([FromRoute] int workExperienceId, IFormFile file)
        {
            WorkExperience workExperience = _db.WorkExperience.Where(e => e.Id == workExperienceId).FirstOrDefault();
            if (workExperience == null) return BadRequest("Bad WorkExperience Id");

            byte[] fileBytes;
            using (var memoryStream = new MemoryStream())
            {
                await file.CopyToAsync(memoryStream);
                fileBytes = memoryStream.ToArray();
            }
            workExperience.Image = fileBytes;

            db.WorkExperience.Update(workExperience);
            await _db.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{workExperienceId}")]
        public async Task<ActionResult> Delete([FromRoute] int workExperienceId)
        {
            WorkExperience workExperience = _db.WorkExperience.Where(e => e.Id == workExperienceId).FirstOrDefault();

            if (workExperience == null) return BadRequest("Bad WorkExperience ID");

            _db.Remove(workExperience);
            await _db.SaveChangesAsync();

            return NoContent();
        }
    }
}
