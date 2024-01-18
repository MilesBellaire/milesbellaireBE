using Microsoft.AspNetCore.Mvc;
using MbCore.EntityFramework;
using MbCore.EntityFramework.Models;
using Microsoft.EntityFrameworkCore;
using MbCore.Api.Dtos;
using AutoMapper;

namespace MbCore.Api.Controllers
{

    [ApiController]
    [Route("api/personal-project")]
    public class PersonalProjectController(DatabaseContext db, IMapper mapper) : Controller
    {
        private readonly DatabaseContext _db = db;
        private readonly IMapper _mapper = mapper;

        [HttpGet]
        public async Task<ActionResult> Get()
        {
            List<PersonalProject> items = await _db.PersonalProject
                .Include(e => e.Tags).AsSplitQuery()
                .OrderBy(e => e.Priority)
                .ToListAsync();

            List<PersonalProjectWithPicDto> itemsDto = _mapper.Map<List<PersonalProjectWithPicDto>>(items);
            return Ok(itemsDto);
        }

        [HttpPost]
        public async Task<ActionResult> Create([FromBody] PersonalProjectDto request)
        {

            PersonalProject personalProject = new()
            {
                Name = request.Name,
                Description = request.Description,
                Priority = request.Priority,
                Tags = request.Tags.Select(t => new Tag(t)).ToList(),
            };

            PersonalProjectDto personalProjectNoPicDto = _mapper.Map<PersonalProjectDto>(personalProject);
            await _db.AddAsync(personalProject);
            await _db.SaveChangesAsync();

            return Ok(personalProjectNoPicDto);
        }

        [HttpPut("{personalProjectId}")]
        public async Task<ActionResult> Update([FromRoute] int personalProjectId, [FromBody] PersonalProjectDto request)
        {

            PersonalProject personalProject = _db.PersonalProject.Where(e => e.Id == personalProjectId)
                .Include(e => e.Tags).AsSplitQuery()
                .FirstOrDefault();

            personalProject.Name = request.Name;
            personalProject.Description = request.Description;
            personalProject.Priority = request.Priority;
            personalProject.Tags = request.Tags.Select(t => new Tag(t)).ToList();

            PersonalProjectDto personalProjectNoPicDto = _mapper.Map<PersonalProjectDto>(personalProject);
            _db.Update(personalProject);
            await _db.SaveChangesAsync();

            return Ok(personalProjectNoPicDto);
        }

        [HttpPost("file/{personalProjectId}")]
        public async Task<ActionResult> Create([FromRoute] int personalProjectId, IFormFile file)
        {
            PersonalProject personalProject = _db.PersonalProject.Where(e => e.Id == personalProjectId).FirstOrDefault();
            if (personalProject == null) return BadRequest("Bad PersonalProject Id");

            byte[] fileBytes;
            using (var memoryStream = new MemoryStream())
            {
                await file.CopyToAsync(memoryStream);
                fileBytes = memoryStream.ToArray();
            }
            personalProject.Image = fileBytes;

            db.PersonalProject.Update(personalProject);
            await _db.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{personalProjectId}")]
        public async Task<ActionResult> Delete([FromRoute] int personalProjectId)
        {
            PersonalProject personalProject = _db.PersonalProject.Where(e => e.Id == personalProjectId).FirstOrDefault();

            if (personalProject == null) return BadRequest("Bad PersonalProject ID");

            _db.Remove(personalProject);
            await _db.SaveChangesAsync();

            return NoContent();
        }
    }
}
