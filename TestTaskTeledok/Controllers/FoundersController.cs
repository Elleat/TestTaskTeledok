using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TestTaskTeledokCore.Models;
using TestTaskTeledokInfrastructure.Data;

namespace TestTaskTeledok.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FoundersController : ControllerBase
    {
        private readonly TeledokDbContext _context;
        public FoundersController(TeledokDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Founders>>> GetAllFounders()
        {
            var founders = await _context.Founders.ToListAsync();
            return Ok(founders);
        }

        [HttpPost]
        public async Task<ActionResult<Founders>> CreateFounder([FromBody] Founders newFounder)
        {
            if (newFounder.Компании != null)
            {
                newFounder.Компании = null;
            }
            _context.Founders.Add(newFounder);
            await _context.SaveChangesAsync();
            return Ok(newFounder);
        }
        [HttpPut]
        public async Task<ActionResult<Founders>> UpdateClient(Founders updatedFounder)
        {
            var dbFounder = await _context.Founders.FirstOrDefaultAsync(e => e.ИНН == updatedFounder.ИНН);
            if (dbFounder == null)
                return BadRequest("Founder not found");
            dbFounder.ИНН = updatedFounder.ИНН;
            dbFounder.ФИО = updatedFounder.ФИО;
            dbFounder.ДатаОбновления = updatedFounder.ДатаОбновления;

            await _context.SaveChangesAsync();
            return Ok(dbFounder);
        }

        [HttpDelete]
        public async Task<ActionResult<Founders>> DeleteFounder(ulong ИНН)
        {
            var dbFounder = await _context.Founders.FirstOrDefaultAsync(e => e.ИНН == ИНН);
            if (dbFounder == null)
                return BadRequest("Client not found");

            _context.Founders.Remove(dbFounder);
            await _context.SaveChangesAsync();
            return Ok(dbFounder);
        }
    }
}