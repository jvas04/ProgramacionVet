using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using Veterinary.API.Data;
using Veterinary.Shared.Entities;

namespace Veterinary.API.Controllers
{


    [ApiController]
    [Route("/api/owners")]
    public class OwnersController:ControllerBase
    {
        private readonly DataContext _context;

        public OwnersController(DataContext context)
        {
            _context = context;
        }

        //Metodo Get- Lista
        [HttpGet]
        public async Task<ActionResult> Get()
        {
            return Ok(await _context.Owners.ToListAsync());
        }

        [HttpPost]
        public async Task<ActionResult> Post(Owner owner)
        {
            _context.Add(owner);
            await _context.SaveChangesAsync();
            return Ok(owner);
        }


        //Metodo Get- Por id
        [HttpGet("id:int")]
        public async Task<ActionResult> Get(int id)
        {
            var owner = await 
                _context.Owners.FirstOrDefaultAsync(x => x.Id
                == id);
            if (owner == null)
            {
                return NotFound();
            }
            return Ok(owner);
        }

        //Update
        [HttpPut]
        public async Task<ActionResult> Put(Owner owner)
        {
            _context.Update(owner);
            await _context.SaveChangesAsync();
            return Ok(owner);
        }

        //Delete
        [HttpDelete("id:int")]
        public async Task<ActionResult> Delete(int id)
        {

            var FilasAfectadas = await _context.Owners

                .Where(x => x.Id == id)
                .ExecuteDeleteAsync();

            if (FilasAfectadas == 0)
            {
                return NotFound();
            }
            return NoContent();
        }

    }
}
