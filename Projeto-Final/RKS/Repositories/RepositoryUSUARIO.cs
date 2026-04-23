using Microsoft.EntityFrameworkCore;
using API.Data;
using API.Data.Models;

namespace API.Repositories
{
    public class RepositoryUSUARIO : IRepositoryUSUARIO
    {
        private readonly AppDbContext _context;

        public RepositoryUSUARIO(AppDbContext context)
        {
            _context = context;
        }

        public async Task CreateUsuarioAsync(USUARIO usuario)
        {
            _context.USUARIOs.Add(usuario);
            await _context.SaveChangesAsync();
        }

        public async Task<USUARIO?> GetUsuarioByTelefoneAsync(string numeroTelefone)
        {
            return await _context.USUARIOs
                .AsNoTracking()
                .FirstOrDefaultAsync(u => u.numeroTelefone == numeroTelefone);
        }

        public async Task<bool> UpdateSenhaAsync(string numeroTelefone, string novaSenhaHash)
        {
            var usuario = await _context.USUARIOs
                .FirstOrDefaultAsync(u => u.numeroTelefone == numeroTelefone);

            if (usuario == null) return false;

            usuario.senha = novaSenhaHash;
            await _context.SaveChangesAsync();
            return true;
        }
    }
}