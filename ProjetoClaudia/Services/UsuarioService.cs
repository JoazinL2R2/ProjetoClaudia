using ProjetoClaudia.Data;
using ProjetoClaudia.Models;
using ProjetoClaudia.Services.Interface;

namespace ProjetoClaudia.Services
{
    public class UsuarioService : IUsuarioService
    {
        private readonly BancoContext _db;
        public UsuarioService(BancoContext banco)
        {
            _db = banco;
        }
        public Task<Usuario> CreateUser(Usuario user)
        {
            if(user != null)
            {
                await _db.
            }
            throw new Exception("Usuario Nulo");
        }

        public Task<bool> DeleteUser(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Usuario>> GetAllUsers()
        {
            throw new NotImplementedException();
        }

        public Task<Usuario> GetFilteredUsers(Usuario usuario)
        {
            throw new NotImplementedException();
        }

        public Task<Usuario> UpdateUser(Usuario user)
        {
            throw new NotImplementedException();
        }
    }
}
