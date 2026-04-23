using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using API.Data;
using API.Data.Models;

namespace API.Controllers.Api
{
    [ApiController]
    //[Route("api/[controller]")]
    [Route("api/ACL")]
    public class AclApiController : ControllerBase
    {
        private readonly AppDbContext _context;

        public AclApiController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/acl
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var data = await _context.ACLs.ToListAsync();
            return Ok(data);
        }

        /*
        // GET: api/acl/1
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var item = await _context.ACLs.FindAsync(id);
            if (item == null) return NotFound();

            return Ok(item);
        }
        */


        // =========================================
        // GET: api/aclapi/1
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
            var item = await _context.ACLs
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.idACL == parsedId);

            if (item == null)
            {
                return NotFound(new
                {
                    error = "ACL not found",
                    id = parsedId
                });
            }

            return Ok(item);
        }

        // POST: api/aclapi
        [HttpPost]
        public async Task<IActionResult> Post(ACL acl)
        {
            _context.ACLs.Add(acl);
            await _context.SaveChangesAsync();
            return Ok(acl);
        }

        // PUT: api/aclapi/1
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, ACL acl)
        {
            if (id != acl.idACL) return BadRequest();

            _context.ACLs.Update(acl);
            await _context.SaveChangesAsync();

            return Ok(acl);
        }

        // DELETE: api/aclapi/1
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var item = await _context.ACLs.FindAsync(id);
            if (item == null) return NotFound();

            _context.ACLs.Remove(item);
            await _context.SaveChangesAsync();

            return Ok();
        }
    }
}
