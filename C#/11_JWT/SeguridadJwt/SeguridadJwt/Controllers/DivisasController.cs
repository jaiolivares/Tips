using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SeguridadJwt.Data;
using SeguridadJwt.Models;
using SeguridadJwt.Services;

namespace SeguridadJwt.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DivisasController : ControllerBase
    {
        private readonly SeguridadJwtContext _context;
        private readonly ITokenService _tokenService;

        public DivisasController(SeguridadJwtContext context, ITokenService tokenService)
        {
            _context = context;
            _tokenService = tokenService;
        }

        // GET: api/Divisas
        [HttpGet]
        [Authorize] //Se pone en cada método que requiera Token
        public async Task<ActionResult<IEnumerable<Divisa>>> GetDivisa()
        {
            // Obtener el token del encabezado de autorización
            var token = HttpContext.Request.Headers["Authorization"].ToString();

            // Verificar si el token está presente y es válido
            if (string.IsNullOrWhiteSpace(token) || !token.StartsWith("Bearer "))
            {
                return Unauthorized("Token JWT no proporcionado");
            }

            // Obtener solo el token (sin "Bearer ")
            var tokenString = token.Substring("Bearer ".Length).Trim();

            // Validar el token (esto es solo un ejemplo, deberías tener una lógica de validación adecuada)
            // Aquí simplemente estamos verificando que el token no esté vacío
            if (string.IsNullOrWhiteSpace(tokenString))
            {
                return Unauthorized("Token JWT inválido");
            }

            var cc = HttpContext.User.Identity as ClaimsIdentity;

            var xx = _tokenService.ValidarToken(cc);

            return await _context.Divisas.ToListAsync();
        }

        // GET: api/Divisas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Divisa>> GetDivisa(int id)
        {
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
            _context.Divisas.Add(divisa);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDivisa", new { id = divisa.DivisaId }, divisa);
        }

        // DELETE: api/Divisas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDivisa(int id)
        {
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
            return _context.Divisas.Any(e => e.DivisaId == id);
        }
    }
}