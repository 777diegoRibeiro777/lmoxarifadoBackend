using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AlmoxarifadoDomain.NomeDaPasta;

namespace AlmoxarifadoAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotasFiscaisController : ControllerBase
    {
        private readonly xAlmoxarifadoContext _context;

        public NotasFiscaisController(xAlmoxarifadoContext context)
        {
            _context = context;
        }

        // GET: api/NotasFiscais
        [HttpGet]
        public async Task<ActionResult<IEnumerable<NotaFiscal>>> GetNotaFiscals()
        {
            if (_context.NotaFiscals == null)
            {
                return NotFound();
            }
            return await _context.NotaFiscals.ToListAsync();
        }

        // GET: api/NotasFiscais/5
        [HttpGet("{id}")]
        public async Task<ActionResult<NotaFiscal>> GetNotaFiscal(int id)
        {
            if (_context.NotaFiscals == null)
            {
                return NotFound();
            }
            var notaFiscal = await _context.NotaFiscals.FindAsync(id);

            if (notaFiscal == null)
            {
                return NotFound();
            }

            return notaFiscal;
        }

        // PUT: api/NotasFiscais/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutNotaFiscal(int id, NotaFiscal notaFiscal)
        {
            if (id != notaFiscal.IdNota)
            {
                return BadRequest();
            }

            _context.Entry(notaFiscal).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!NotaFiscalExists(id))
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

        // POST: api/NotasFiscais
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<NotaFiscal>> PostNotaFiscal(NotaFiscal notaFiscal)
        {
            if (_context.NotaFiscals == null)
            {
                return Problem("Entity set 'xAlmoxarifadoContext.NotaFiscals'  is null.");
            }
            _context.NotaFiscals.Add(notaFiscal);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetNotaFiscal", new { id = notaFiscal.IdNota }, notaFiscal);
        }

        // DELETE: api/NotasFiscais/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteNotaFiscal(int id)
        {
            if (_context.NotaFiscals == null)
            {
                return NotFound();
            }
            var notaFiscal = await _context.NotaFiscals.FindAsync(id);
            if (notaFiscal == null)
            {
                return NotFound();
            }

            _context.NotaFiscals.Remove(notaFiscal);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool NotaFiscalExists(int id)
        {
            return (_context.NotaFiscals?.Any(e => e.IdNota == id)).GetValueOrDefault();
        }
    }
}
