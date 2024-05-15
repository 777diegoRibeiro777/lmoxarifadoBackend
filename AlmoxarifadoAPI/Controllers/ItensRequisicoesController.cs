using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AlmoxarifadoDomain.NomeDaPasta;

namespace AlmoxarifadoAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItensRequisicoesController : ControllerBase
    {
        private readonly xAlmoxarifadoContext _context;

        public ItensRequisicoesController(xAlmoxarifadoContext context)
        {
            _context = context;
        }

        // GET: api/ItensRequisicoes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ItensReq>>> GetItensReqs()
        {
            if (_context.ItensReqs == null)
            {
                return NotFound();
            }
            return await _context.ItensReqs.ToListAsync();
        }

        // GET: api/ItensRequisicoes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ItensReq>> GetItensReq(int id)
        {
            if (_context.ItensReqs == null)
            {
                return NotFound();
            }
            var itensReq = await _context.ItensReqs.FindAsync(id);

            if (itensReq == null)
            {
                return NotFound();
            }

            return itensReq;
        }

        // PUT: api/ItensRequisicoes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutItensReq(int id, ItensReq itensReq)
        {
            if (id != itensReq.NumItem)
            {
                return BadRequest();
            }

            _context.Entry(itensReq).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ItensReqExists(id))
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

        // POST: api/ItensRequisicoes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ItensReq>> PostItensReq(ItensReq itensReq)
        {
            if (_context.ItensReqs == null)
            {
                return Problem("Entity set 'xAlmoxarifadoContext.ItensReqs'  is null.");
            }
            _context.ItensReqs.Add(itensReq);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (ItensReqExists(itensReq.NumItem))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetItensReq", new { id = itensReq.NumItem }, itensReq);
        }

        // DELETE: api/ItensRequisicoes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteItensReq(int id)
        {
            if (_context.ItensReqs == null)
            {
                return NotFound();
            }
            var itensReq = await _context.ItensReqs.FindAsync(id);
            if (itensReq == null)
            {
                return NotFound();
            }

            _context.ItensReqs.Remove(itensReq);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ItensReqExists(int id)
        {
            return (_context.ItensReqs?.Any(e => e.NumItem == id)).GetValueOrDefault();
        }
    }
}
