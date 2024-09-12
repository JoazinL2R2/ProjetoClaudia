using ProjetoClaudia.Models;

namespace ProjetoClaudia.Services.Interface
{
    public interface ICompraService
    {
        Task<Compra> CreateCompra(Compra compra);
        Task<Compra> UpdateCompra(Compra compra);
        Task<Compra> DeleteCompra(Compra compra);
        Task<List<Compra>> GetAllCompra();
        Task<List<Compra>> GetFilteredCompra(Compra compra);
    }
}
