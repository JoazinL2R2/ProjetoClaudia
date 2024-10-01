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
