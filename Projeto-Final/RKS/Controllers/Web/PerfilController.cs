using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using API.Data;
using API.Data.Models;

namespace API.Controllers.Web
{
    public class PerfilController : Controller
    {
        private readonly AppDbContext _context;

        public PerfilController(AppDbContext context)
        {
            _context = context;
        }

        // GET: /perfil
        public async Task<IActionResult> Index()
        {
            var data = await _context.PERFILs.ToListAsync();
            return View(data);
        }
        
        // GET: /perfil/details/{id}  → Lista APENAS 1 registro
        // Ou você pode usar: /perfil/5
        public async Task<IActionResult> Details(int id)
        {
            var item = await _context.PERFILs.FindAsync(id);

            if (item == null)
            {
                return NotFound();           // Retorna página 404
            }

            return View(item);               // Usa a view Details.cshtml
        }

        // GET: /perfil/create
        public IActionResult Create()
        {
            return View();
        }

        // POST: /perfil/create
        [HttpPost]
        public async Task<IActionResult> Create(PERFIL perfil)
        {
            _context.PERFILs.Add(perfil);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        // GET: /perfil/edit/1
        public async Task<IActionResult> Edit(int id)
        {
            var item = await _context.PERFILs.FindAsync(id);
            return View(item);
        }

        // POST: /perfil/edit
        [HttpPost]
        public async Task<IActionResult> Edit(PERFIL perfil)
        {
            _context.PERFILs.Update(perfil);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        // GET: /perfil/delete/1
        public async Task<IActionResult> Delete(int id)
        {
            var item = await _context.PERFILs.FindAsync(id);
            return View(item);
        }

        // POST: /perfil/deleteconfirmed
        [HttpPost]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var item = await _context.PERFILs.FindAsync(id); 
            // Substitua esta linha:
            //_context.PERFILs.Remove(item);

            // Por esta (mais segura):
            if (item != null)
            {
                _context.PERFILs.Remove(item);
            }
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
    }
}
