using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using API.Data;
using API.Data.Models;

namespace API.Controllers.Web
{
    public class AclController : Controller
    {
        private readonly AppDbContext _context;

        public AclController(AppDbContext context)
        {
            _context = context;
        }

        // GET: /acl
        public async Task<IActionResult> Index()
        {
            var data = await _context.ACLs.ToListAsync();
            return View(data);
        }
        
        // GET: /acl/details/{id}  → Lista APENAS 1 registro
        // Ou você pode usar: /acl/5
        public async Task<IActionResult> Details(int id)
        {
            var item = await _context.ACLs.FindAsync(id);

            if (item == null)
            {
                return NotFound();           // Retorna página 404
            }

            return View(item);               // Usa a view Details.cshtml
        }

        // GET: /acl/create
        public IActionResult Create()
        {
            return View();
        }

        // POST: /acl/create
        [HttpPost]
        public async Task<IActionResult> Create(ACL acl)
        {
            _context.ACLs.Add(acl);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        // GET: /acl/edit/1
        public async Task<IActionResult> Edit(int id)
        {
            var item = await _context.ACLs.FindAsync(id);
            return View(item);
        }

        // POST: /acl/edit
        [HttpPost]
        public async Task<IActionResult> Edit(ACL acl)
        {
            _context.ACLs.Update(acl);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        // GET: /acl/delete/1
        public async Task<IActionResult> Delete(int id)
        {
            var item = await _context.ACLs.FindAsync(id);
            return View(item);
        }

        // POST: /acl/deleteconfirmed
        [HttpPost]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var item = await _context.ACLs.FindAsync(id); 
            // Substitua esta linha:
            //_context.ACLs.Remove(item);

            // Por esta (mais segura):
            if (item != null)
            {
                _context.ACLs.Remove(item);
            }
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
    }
}
