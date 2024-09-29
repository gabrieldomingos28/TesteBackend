

using Teste.Domain.Entities;

namespace Teste.Domain.Interfaces.Repository
{
    public interface IUsuarioRepository
    {
        Task<Usuario?> GetUsuarioAsync(string email, string senha);
        Task<IEnumerable<UsuarioPermissao>> GetPermissoesAsync(int idUsuario);
    }
}
