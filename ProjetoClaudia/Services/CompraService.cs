using Microsoft.EntityFrameworkCore;
using ProjetoClaudia.Data;
using ProjetoClaudia.Models;
using ProjetoClaudia.Services.Interface;

namespace ProjetoClaudia.Services
{
    public class CompraService : ICompraService
    {
        private readonly BancoContext _db;
        public CompraService(BancoContext context)
        {
            _db = context;
        }
        public async Task<Compra> CreateCompra(Compra compra)
        {
            if(compra != null)
            {
                _db.Compra.Add(compra);
                await _db.SaveChangesAsync();
            }
            throw new Exception("Preencha todos os campos e tente novamente");
        }

        public async Task<Compra> DeleteCompra(Compra compra)
        {
            if(compra.Id != 0 && compra.Id != null)
            {
                var query = await _db.Compra.FirstOrDefaultAsync(x => x.Id == compra.Id);
                if(query != null)
                {
                    _db.Compra.Remove(query);
                    await _db.SaveChangesAsync();
                    return compra;
                }
                throw new Exception($"Nenhuma compra encontrada com o Id:{compra.Id}");
            }
            throw new Exception("Id nulo");
        }

        public async Task<List<Compra>> GetAllCompra()
        {
            return await _db.Compra.ToListAsync();
        }

        public async Task<List<Compra>> GetFilteredCompra(Compra compra)
        {
            IQueryable<Compra> query = _db.Compra;
            bool isCheck = false;
            if(compra.Usuario.Cpf != null)
            {
                query = query.Where(x => x.Usuario.Cpf ==  compra.Usuario.Cpf);
                isCheck = true;
            }
            if(compra.DataCompra > DateTime.MinValue)
            {
                query = query.Where(x => x.DataCompra >= compra.DataCompra);
                isCheck = true;
            }
            if(compra.Valor != null)
            {
                query = query.Where(x => x.Valor == compra.Valor);
                isCheck = true;
            }
            if(compra.Produto.Nome != null)
            {
                query.Where(x => x.Produto.Nome == compra.Produto.Nome);
                isCheck = true;
            }
            if (isCheck)
            {
                query = (IQueryable<Compra>)query.Select(x => new Compra
                {
                    DataCompra = x.DataCompra,
                    Valor = x.Valor,
                    Id = x.Id,
                    Produto = new Produto
                    {
                        Id = x.Produto.Id,
                        Valor = x.Produto.Valor,
                        Nome = x.Produto.Nome,
                        Quantidade = x.Produto.Quantidade,
                        Flg_Inativo = x.Produto.Flg_Inativo
                    },
                    Usuario = new Usuario
                    {
                        Id = x.Usuario.Id,
                        Nome = x.Usuario.Nome,
                        Cpf = x.Usuario.Cpf,
                        Email = x.Usuario.Email,
                        Genero = x.Usuario.Genero,
                    }
                }).ToListAsync();
                return (List<Compra>)query;
            }
            return (List<Compra>)query.Take(0);
        }

        public async Task<Compra> UpdateCompra(Compra compra)
        {
            if(compra.Id != 0 && compra.Id != null)
            {
                var query = await _db.Compra.FirstOrDefaultAsync(x => x.Id == compra.Id);
                if(query != null)
                {
                    _db.Compra.Update(query);
                    await _db.SaveChangesAsync();
                    return compra;
                }
                throw new Exception($"Nenhuma compra encontrada com o Id:{compra.Id}");
            }
            throw new Exception("Id nulo");
        }
    }
}
