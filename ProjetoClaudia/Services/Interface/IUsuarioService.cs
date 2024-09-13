using ProjetoClaudia.Models;

namespace ProjetoClaudia.Services.Interface
{
    public interface IUsuarioService
    {
        Task<IEnumerable<Usuario>> GetAllUsers();
        Task<List<Usuario>> GetFilteredUsers(Usuario usuario);
        Task<bool> DeleteUser(int id);
        Task<Usuario> UpdateUser(Usuario user);
        Task<Usuario> CreateUser(Usuario user);
        Task<bool> Login(Usuario usuario);
        void CreateSession(Usuario user);
    }
}
