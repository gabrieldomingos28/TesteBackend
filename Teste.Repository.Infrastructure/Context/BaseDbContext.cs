using Microsoft.EntityFrameworkCore;
using Teste.Domain.Entities;

namespace Teste.Repository.Infrastructure.Context
{
    public class BaseDbContext : DbContext
    {
        public BaseDbContext(DbContextOptions<BaseDbContext> options) : base(options)
        { }
        
       public DbSet<Produto> Produtos { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Permissao> Permissoes { get; set; }
        public DbSet<UsuarioPermissao> UsuariosPermissoes { get; set; }
    }
}
