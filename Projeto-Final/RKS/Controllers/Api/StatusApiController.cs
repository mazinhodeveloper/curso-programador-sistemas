using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using API.Data;
using API.Data.Models;

namespace API.Controllers.Api
{
    [ApiController]
    //[Route("api/[controller]")]
    [Route("api/STATUS")] 
    public class StatusApiController : ControllerBase
    {
        private readonly AppDbContext _context;

        public StatusApiController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/statusapi
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var data = await _context.STATUSs.ToListAsync();
            return Ok(data);
        }

        /*
        // GET: api/statusapi/1
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var item = await _context.STATUSs.FindAsync(id);
            if (item == null) return NotFound();

            return Ok(item);
        }
        */


        // =========================================
        // GET: api/statusapi/1
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
            var item = await _context.STATUSs
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.idStatus == parsedId);

            if (item == null)
            {
                return NotFound(new
                {
                    error = "STATUS not found",
                    id = parsedId
                });
            }

            return Ok(item);
        }

        // POST: api/statusapi
        [HttpPost]
        public async Task<IActionResult> Post(STATUS status)
        {
            _context.STATUSs.Add(status);
            await _context.SaveChangesAsync();
            return Ok(status);
        }

        // PUT: api/statusapi/1
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, STATUS status)
        {
            if (id != status.idStatus) return BadRequest();

            _context.STATUSs.Update(status);
            await _context.SaveChangesAsync();

            return Ok(status);
        }

        // DELETE: api/statusapi/1
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var item = await _context.STATUSs.FindAsync(id);
            if (item == null) return NotFound();

            _context.STATUSs.Remove(item);
            await _context.SaveChangesAsync();

            return Ok();
        }
    }
}
