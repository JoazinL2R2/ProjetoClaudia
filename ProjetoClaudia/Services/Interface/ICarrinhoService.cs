using ProjetoClaudia.Migrations;

namespace ProjetoClaudia.Services.Interface
{
    public interface ICarrinhoService
    {
        Task<IEnumerable<ProjetoClaudia.Models.Carrinho>> GetCarrinhoAsync();
        Task<bool> RemoveCarrinho(int id);
        Task<bool> AdicionarAoCarrinho(int idProduto, int idUser);
    }
}
