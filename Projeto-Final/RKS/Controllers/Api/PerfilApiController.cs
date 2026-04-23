using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using API.Data;
using API.Data.Models;

namespace API.Controllers.Api
{
    [ApiController]
    //[Route("api/[controller]")]
    [Route("api/PERFIL")]    
    public class PerfilApiController : ControllerBase
    {
        private readonly AppDbContext _context;

        public PerfilApiController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/perfilapi
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var data = await _context.PERFILs.ToListAsync();
            return Ok(data);
        }

        /*
        // GET: api/perfilapi/1
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var item = await _context.PERFILs.FindAsync(id);
            if (item == null) return NotFound();

            return Ok(item);
        }
        */


        // =========================================
        // GET: api/perfilapi/1
        // =========================================
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(string id)
        {
            // 🔥 SAFE PARSING (prevents ASP.NET 400 auto-error confusion)
            if (!int.TryParse(id, out int parsedId))
            {
                return BadRequest(new
                {
                    error = "Invalid ID format",
                    value = id
                });
            }

            // =========================================
            // DATABASE QUERY (EF CORE)
            // =========================================
            var item = await _context.PERFILs
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.idPerfil == parsedId);

            if (item == null)
            {
                return NotFound(new
                {
                    error = "PERFIL not found",
                    id = parsedId
                });
            }

            return Ok(item);
        }

        // POST: api/perfilapi
        [HttpPost]
        public async Task<IActionResult> Post(PERFIL perfil)
        {
            _context.PERFILs.Add(perfil);
            await _context.SaveChangesAsync();
            return Ok(perfil);
        }

        // PUT: api/perfilapi/1
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, PERFIL perfil)
        {
            if (id != perfil.idPerfil) return BadRequest();

            _context.PERFILs.Update(perfil);
            await _context.SaveChangesAsync();

            return Ok(perfil);
        }

        // DELETE: api/perfilapi/1
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var item = await _context.PERFILs.FindAsync(id);
            if (item == null) return NotFound();

            _context.PERFILs.Remove(item);
            await _context.SaveChangesAsync();

            return Ok();
        }
    }
}
