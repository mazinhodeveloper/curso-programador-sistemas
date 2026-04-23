using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using API.Data;
using API.Data.Models;

namespace API.Controllers.Web
{
    public class StatusController : Controller
    {
        private readonly AppDbContext _context;

        public StatusController(AppDbContext context)
        {
            _context = context;
        }

        // GET: /status
        public async Task<IActionResult> Index()
        {
            var data = await _context.STATUSs.ToListAsync();
            return View(data);
        }
        
        // GET: /status/details/{id}  → Lista APENAS 1 registro
        // Ou você pode usar: /status/5
        public async Task<IActionResult> Details(int id)
        {
            var item = await _context.STATUSs.FindAsync(id);

            if (item == null)
            {
                return NotFound();           // Retorna página 404
            }

            return View(item);               // Usa a view Details.cshtml
        }

        // GET: /status/create
        public IActionResult Create()
        {
            return View();
        }

        // POST: /status/create
        [HttpPost]
        public async Task<IActionResult> Create(STATUS status)
        {
            _context.STATUSs.Add(status);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        // GET: /status/edit/1
        public async Task<IActionResult> Edit(int id)
        {
            var item = await _context.STATUSs.FindAsync(id);
            return View(item);
        }

        // POST: /status/edit
        [HttpPost]
        public async Task<IActionResult> Edit(STATUS status)
        {
            _context.STATUSs.Update(status);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        // GET: /status/delete/1
        public async Task<IActionResult> Delete(int id)
        {
            var item = await _context.STATUSs.FindAsync(id);
            return View(item);
        }

        // POST: /status/deleteconfirmed
        [HttpPost]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var item = await _context.STATUSs.FindAsync(id); 
            // Substitua esta linha:
            //_context.STATUSs.Remove(item);

            // Por esta (mais segura):
            if (item != null)
            {
                _context.STATUSs.Remove(item);
            }
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
    }
}
