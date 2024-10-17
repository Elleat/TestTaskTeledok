using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TestTaskTeledokCore.Models;
using TestTaskTeledokInfrastructure.Data;

namespace TestTaskTeledok.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientsController : ControllerBase
    {
        private readonly TeledokDbContext _context;
        public ClientsController(TeledokDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Clients>>> GetAllClients()
        {
            var clients = await _context.Clients.ToListAsync();
            return Ok(clients);
        }

        [HttpPost]
        public async Task<ActionResult<Clients>> CreateClient(Clients newClient)
        {
            _context.Clients.Add(newClient);
            await _context.SaveChangesAsync();

            /*var founders = _context.Founders.Where(f => f.ИНН_компании == newClient.ИНН);
            newClient.Учредители = founders.ToList();*/

            return Ok(newClient);
        }
        [HttpPut]
        public async Task<ActionResult<Clients>> UpdateClient(Clients updatedClient)
        {
            var dbClient = await _context.Clients.FirstOrDefaultAsync(e => e.ИНН == updatedClient.ИНН);
            if (dbClient == null)
                return BadRequest("Client not found");
            dbClient.ИНН = updatedClient.ИНН;
            dbClient.Наименование = updatedClient.Наименование;
            dbClient.Учредители = updatedClient.Учредители;
            dbClient.ЮЛИП = updatedClient.ЮЛИП;
            dbClient.ДатаОбновления = updatedClient.ДатаОбновления;

            await _context.SaveChangesAsync();
            return Ok(dbClient);
        }

        [HttpDelete]
        public async Task<ActionResult<Clients>> DeleteClient (ulong ИНН)
        {
            var dbClient = await _context.Clients.FirstOrDefaultAsync(e => e.ИНН == ИНН);
            if (dbClient == null)
                return BadRequest("Client not found");

            _context.Clients.Remove(dbClient);
            await _context.SaveChangesAsync();
            return Ok(dbClient);
        }
    }
}