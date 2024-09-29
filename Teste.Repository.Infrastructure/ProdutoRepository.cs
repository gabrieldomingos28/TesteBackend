using Microsoft.EntityFrameworkCore;
using Teste.Domain.Entities;
using Teste.Domain.Interfaces.Repository;

namespace Teste.Repository.Infrastructure
{
    public class ProdutoRepository : IProdutoRespository
    {
        private readonly Context.BaseDbContext _db;
        public ProdutoRepository(Context.BaseDbContext dbContext)
        {
                _db = dbContext;
        }
        public async Task CreateAsync(Produto produto)
        {
            _db.Produtos.Add(produto);
             await _db.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
           var produto = await _db.Produtos.FirstOrDefaultAsync(_ => _.Id == id);
            if (produto != null) { 
                produto.DeletedAt = DateTime.Now;
                await _db.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Produto>> GetAllAsync()
        {
            return await _db.Produtos
                            .Where(_ => _.DeletedAt == null)
                            .ToListAsync();
        }

        public async Task<Produto?> GetByIdAsync(int id)
        {
           return await  _db.Produtos.FirstOrDefaultAsync(_ => _.Id == id);
        }

        public async Task UpdateAsync(Produto produto)
        {
            _db.Produtos.Update(produto);
            await _db.SaveChangesAsync();
        }
    }
}
