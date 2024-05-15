using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AlmoxarifadoDomain.NomeDaPasta;

namespace AlmoxarifadoAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RequisicoesController : ControllerBase
    {
        private readonly xAlmoxarifadoContext _context;

        public RequisicoesController(xAlmoxarifadoContext context)
        {
            _context = context;
        }

        // GET: api/Requisicoes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Requisicao>>> GetRequisicaos()
        {
            if (_context.Requisicaos == null)
            {
                return NotFound();
            }
            return await _context.Requisicaos.ToListAsync();
        }

        // GET: api/Requisicoes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Requisicao>> GetRequisicao(int id)
        {
            if (_context.Requisicaos == null)
            {
                return NotFound();
            }
            var requisicao = await _context.Requisicaos.FindAsync(id);

            if (requisicao == null)
            {
                return NotFound();
            }

            return requisicao;
        }

        // PUT: api/Requisicoes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRequisicao(int id, Requisicao requisicao)
        {
            if (id != requisicao.IdReq)
            {
                return BadRequest();
            }

            _context.Entry(requisicao).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RequisicaoExists(id))
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

        // POST: api/Requisicoes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Requisicao>> PostRequisicao(Requisicao requisicao)
        {
            if (_context.Requisicaos == null)
            {
                return Problem("Entity set 'xAlmoxarifadoContext.Requisicaos'  is null.");
            }
            _context.Requisicaos.Add(requisicao);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetRequisicao", new { id = requisicao.IdReq }, requisicao);
        }

        // DELETE: api/Requisicoes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRequisicao(int id)
        {
            if (_context.Requisicaos == null)
            {
                return NotFound();
            }
            var requisicao = await _context.Requisicaos.FindAsync(id);
            if (requisicao == null)
            {
                return NotFound();
            }

            _context.Requisicaos.Remove(requisicao);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool RequisicaoExists(int id)
        {
            return (_context.Requisicaos?.Any(e => e.IdReq == id)).GetValueOrDefault();
        }
    }
}
