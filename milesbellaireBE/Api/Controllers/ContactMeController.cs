using Microsoft.AspNetCore.Mvc;
using MbCore.EntityFramework;
using MbCore.EntityFramework.Models;
using Microsoft.EntityFrameworkCore;
using MbCore.Api.Dtos;

namespace MbCore.Api.Controllers
{

    [ApiController]
    [Route("api/contactme")]
    public class ContactMeController(DatabaseContext db) : Controller
    {
        private readonly DatabaseContext _db = db;

        [HttpGet]
        public async Task<ActionResult> Get()
        {
            List<Message> items = await _db.Message.OrderBy(e => e.Id).ToListAsync();

            return Ok(items);
        }

        [HttpPost]
        public async Task<ActionResult> Create([FromBody] MessageDto request)
        {
            Message message = new()
            {
                Name = request.Name,
                Email = request.Email,
                Text = request.Text,
            };

            await _db.Message.AddAsync(message);
            await _db.SaveChangesAsync();

            return Ok(message);
        }
    }
}
