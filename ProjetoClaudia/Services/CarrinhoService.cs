using Microsoft.EntityFrameworkCore;
using ProjetoClaudia.Data;
using ProjetoClaudia.Migrations;
using ProjetoClaudia.Services.Interface;

namespace ProjetoClaudia.Services
{
    public class CarrinhoService : ICarrinhoService
    {
        private readonly BancoContext _bancoContext;
        public CarrinhoService(BancoContext context)
        {
            _bancoContext = context;
        }

        public async Task<bool> AdicionarAoCarrinho(int idProduto, int idUser)
        {
            if(idProduto == 0)
            {
                throw new Exception("Id nulo");
            }
            var queryProduto = await _bancoContext.Produto.FirstOrDefaultAsync(x => x.Id == idProduto);
            var queryUser = await _bancoContext.Usuario.FirstOrDefaultAsync(x => x.Id == idUser);
            if(queryProduto == null)
            {
                throw new Exception("Nenhum produto encontrado com o Id");
            }
            if (queryUser == null)
            {
                throw new Exception("Nenhum usuario encontrado com o Id");
            }
            var carrinho = new ProjetoClaudia.Models.Carrinho
            {
                Produto = queryProduto,
                Usuario = queryUser,
                Flg_Inativo = false,
            };
            _bancoContext.Carrinho.Add(carrinho);
            await _bancoContext.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<ProjetoClaudia.Models.Carrinho>> GetCarrinhoAsync()
        {
            return await _bancoContext.Carrinho.Where(x => x.Flg_Inativo == false).ToListAsync();
        }


        public async Task<bool> RemoveCarrinho(int id)
        {
            var query = await _bancoContext.Carrinho.FirstOrDefaultAsync(x => x.Id == id);
            if(query != null)
            {
                query.Flg_Inativo = true;
                _bancoContext.Carrinho.Update(query);
                await _bancoContext.SaveChangesAsync();
                return true;
            }
            throw new Exception("Nenhum carrinho encontrado com o Id fornecido");
        }
    }
}
