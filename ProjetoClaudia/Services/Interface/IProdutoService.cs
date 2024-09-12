using ProjetoClaudia.Models;

namespace ProjetoClaudia.Services.Interface
{
    public interface IProdutoService
    {
        Task<Produto> CreateProduto(Produto produto);
        Task<Produto> UpdateProduto(Produto produto);
        Task<Produto> DeleteProduto(int id);
        Task<List<Produto>> GetAllProdutos();
        Task<List<Produto>> GetFilteredProdutos(Produto produto);
    }
}
