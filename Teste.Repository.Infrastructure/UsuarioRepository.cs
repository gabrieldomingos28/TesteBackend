
using Microsoft.EntityFrameworkCore;
using Teste.Domain.Entities;
using Teste.Domain.Interfaces.Repository;
using Teste.Repository.Infrastructure.Context;

namespace Teste.Repository.Infrastructure
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly BaseDbContext _db;
        public UsuarioRepository(BaseDbContext dbContext)
        {
            _db = dbContext;
        }

        public async Task<IEnumerable<UsuarioPermissao>> GetPermissoesAsync(int idUsuario)
        {
            return await _db
                        .UsuariosPermissoes
                        .Include(_ => _.Permissao)
                        .Where(_ => _.UsuarioId == idUsuario)
                        .ToListAsync();
        }

        public async Task<Usuario?> GetUsuarioAsync(string email, string senha)
        {
            return await _db.Usuarios.FirstOrDefaultAsync(_ => _.Email == email && _.Senha == senha);
        }
    }
}
