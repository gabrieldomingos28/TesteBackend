
using Teste.Domain.Entities;

namespace Teste.Domain.Interfaces.Repository
{
    public interface IProdutoRespository
    {
        Task CreateAsync(Produto produto);
        Task DeleteAsync(int id);
        Task UpdateAsync(Produto produto);
        Task<Produto?> GetByIdAsync(int id);
        Task<IEnumerable<Produto>> GetAllAsync();
    }
}
