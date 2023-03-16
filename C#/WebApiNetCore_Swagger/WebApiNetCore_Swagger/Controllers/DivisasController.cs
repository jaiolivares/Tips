using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApiNetCore.Data;
using WebApiNetCore.Models;

namespace WebApiNetCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DivisasController : ControllerBase
    {
        private readonly WebApiNetCoreContext _context;

        public DivisasController(WebApiNetCoreContext context)
        {
            _context = context;
        }

        // GET: api/Divisas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Divisa>>> GetDivisa()
        {
            if (_context.Divisas == null)
            {
                return NotFound();
            }
            return await _context.Divisas.ToListAsync();
        }

        // GET: api/Divisas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Divisa>> GetDivisa(int id)
        {
            if (_context.Divisas == null)
            {
                return NotFound();
            }
            var divisa = await _context.Divisas.FindAsync(id);

            if (divisa == null)
            {
                return NotFound();
            }

            return divisa;
        }

        // PUT: api/Divisas/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDivisa(int id, Divisa divisa)
        {
            if (id != divisa.DivisaId)
            {
                return BadRequest();
            }

            _context.Entry(divisa).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DivisaExists(id))
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

        // POST: api/Divisas
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Divisa>> PostDivisa(Divisa divisa)
        {
            if (_context.Divisas == null)
            {
                return Problem("Entity set 'WebApiNetCoreContext.Divisa'  is null.");
            }
            _context.Divisas.Add(divisa);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDivisa", new { id = divisa.DivisaId }, divisa);
        }

        // DELETE: api/Divisas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDivisa(int id)
        {
            if (_context.Divisas == null)
            {
                return NotFound();
            }
            var divisa = await _context.Divisas.FindAsync(id);
            if (divisa == null)
            {
                return NotFound();
            }

            _context.Divisas.Remove(divisa);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DivisaExists(int id)
        {
            return (_context.Divisas?.Any(e => e.DivisaId == id)).GetValueOrDefault();
        }
    }
}