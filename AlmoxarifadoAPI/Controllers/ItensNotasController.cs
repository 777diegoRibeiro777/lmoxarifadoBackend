using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AlmoxarifadoDomain.NomeDaPasta;

namespace AlmoxarifadoAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItensNotasController : ControllerBase
    {
        private readonly xAlmoxarifadoContext _context;

        public ItensNotasController(xAlmoxarifadoContext context)
        {
            _context = context;
        }

        // GET: api/ItensNotas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ItensNotum>>> GetItensNota()
        {
            if (_context.ItensNota == null)
            {
                return NotFound();
            }
            return await _context.ItensNota.ToListAsync();
        }

        // GET: api/ItensNotas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ItensNotum>> GetItensNotum(int id)
        {
            if (_context.ItensNota == null)
            {
                return NotFound();
            }
            var itensNotum = await _context.ItensNota.FindAsync(id);

            if (itensNotum == null)
            {
                return NotFound();
            }

            return itensNotum;
        }

        // PUT: api/ItensNotas/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutItensNotum(int id, ItensNotum itensNotum)
        {
            if (id != itensNotum.ItemNum)
            {
                return BadRequest();
            }

            _context.Entry(itensNotum).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ItensNotumExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/ItensNotas
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ItensNotum>> PostItensNotum(ItensNotum itensNotum)
        {
            if (_context.ItensNota == null)
            {
                return Problem("Entity set 'xAlmoxarifadoContext.ItensNota'  is null.");
            }
            _context.ItensNota.Add(itensNotum);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (ItensNotumExists(itensNotum.ItemNum))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetItensNotum", new { id = itensNotum.ItemNum }, itensNotum);
        }

        // DELETE: api/ItensNotas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteItensNotum(int id)
        {
            if (_context.ItensNota == null)
            {
                return NotFound();
            }
            var itensNotum = await _context.ItensNota.FindAsync(id);
            if (itensNotum == null)
            {
                return NotFound();
            }

            _context.ItensNota.Remove(itensNotum);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ItensNotumExists(int id)
        {
            return (_context.ItensNota?.Any(e => e.ItemNum == id)).GetValueOrDefault();
        }
    }
}
