using Microsoft.EntityFrameworkCore;
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
        public async Task<Usuario> CreateUser(Usuario user)
        {
            if(user != null)
            {
                _db.Add(user);
                await _db.SaveChangesAsync();
                return user;
            }
            throw new Exception("Usuario Nulo");
        }

        public async Task<bool> DeleteUser(int id)
        {
            var query = await _db.Usuario.FirstOrDefaultAsync(x => x.Id == id);
            if(query != null)
            {
                _db.Usuario.Remove(query);
                await _db.SaveChangesAsync();
                return true;
            }
            throw new Exception($"Nenhum usuário encontrado com o Id Informado, Id:{id}");
        }

        public async Task<IEnumerable<Usuario>> GetAllUsers()
        {
            var query = await _db.Usuario.Where(x => x.Id != 0).Select(x => new Usuario
            {
                Id = x.Id,
                Cpf = x.Cpf,
                Email = x.Email,
                Genero = x.Genero,
                Nome = x.Nome,
            }).ToListAsync();
            return query;
        }

        public async Task<List<Usuario>> GetFilteredUsers(Usuario usuario)
        {
            IQueryable<Usuario> query = _db.Usuario;
            bool isCheck = false;
            if(usuario.Cpf != null)
            {
                query = query.Where(x => x.Cpf == usuario.Cpf);
                isCheck = true;
            }
            if(usuario.Email != null)
            {
                query = query.Where(x => x.Email == usuario.Email);
                isCheck = true;
            }
            if(usuario.Nome != null)
            {
                query = query.Where(x => x.Nome == usuario.Nome);
                isCheck = true;
            }
            if(usuario.Genero != null)
            {
                query = query.Where(x => x.Genero == usuario.Genero);
                isCheck = true;
            }
            if (isCheck)
            {
                query = (IQueryable<Usuario>)query.Select(x => new Usuario
                {
                    Id = x.Id,
                    Cpf = x.Cpf,
                    Email = x.Email,
                    Genero = x.Genero,
                    Nome = x.Nome,
                }).ToListAsync();
                return (List<Usuario>)query;
            }
            return (List<Usuario>)query.Take(0);
        }

        public async Task<Usuario> UpdateUser(Usuario user)
        {
            if (user.Id == null && user.Id != 0)
            {
                var query = await _db.Usuario.FirstOrDefaultAsync(x => x.Id == user.Id);
                if (query != null)
                {
                    _db.Usuario.Update(query);
                    await _db.SaveChangesAsync();
                    return user;
                }
                throw new Exception($"Nenhum usuario enctronado com o Id:{user.Id}");
            }
            throw new Exception("Id nulo");
        }
    }
}
