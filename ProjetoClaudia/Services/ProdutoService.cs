using Microsoft.EntityFrameworkCore;
using ProjetoClaudia.Data;
using ProjetoClaudia.Models;
using ProjetoClaudia.Services.Interface;

namespace ProjetoClaudia.Services
{
    public class ProdutoService : IProdutoService
    {
        private readonly BancoContext _db;
        public ProdutoService(BancoContext bancoContext)
        {
            _db = bancoContext;
        }
        public async Task<Produto> CreateProduto(Produto produto)
        {
            if(produto != null)
            {
                produto.Flg_Inativo = false;
                _db.Produto.Add(produto);
                await _db.SaveChangesAsync();
                return produto;
            }
            throw new Exception("Preencha todos os dados antes de enviar e tente novamente");
        }

        public async Task<Produto> DeleteProduto(int id)
        {
            if(id != 0 && id != null)
            {
                var query = await _db.Produto.FirstOrDefaultAsync(x => x.Id == id);
                if(query != null)
                {
                    _db.Produto.Remove(query);
                    await _db.SaveChangesAsync();
                    return query;
                }
                throw new Exception($"Nenhum Produto encontrado com o Id:{id}");
            }
            throw new Exception("Id nulo");
        }

        public List<Produto> GetAllProdutos()
        {
            var produtos = _db.Produto.Where(x => x.Flg_Inativo == false).Select(x => new Produto
            {
                Id = x.Id,
                Flg_Inativo = x.Flg_Inativo,
                Nome = x.Nome,
                Quantidade = x.Quantidade,
                Valor = x.Valor
            }).ToList();
            return produtos;
        }

        public Task<List<Produto>> GetFilteredProdutos(Produto produto)
        {
            IQueryable < Produto > query = _db.Produto;
            return  query.ToListAsync();
        }

        public async Task<Produto> UpdateProduto(Produto produto)
        {
            if(produto.Id != 0 && produto.Id != 0)
            {
                _db.Produto.Update(produto);
                await _db.SaveChangesAsync();
                return produto;
            }
            throw new Exception("Id Nulo");
        }
    }
}
