using Microsoft.AspNetCore.Mvc;
using ProjetoClaudia.Models;
using ProjetoClaudia.Services;
using ProjetoClaudia.Services.Interface;

namespace ProjetoClaudia.Controllers
{
    public class CarrinhoController : Controller
    {
        private readonly ICarrinhoService _carrinho;
        public CarrinhoController(ICarrinhoService service)
        {
            _carrinho = service;
        }
        public async Task<IActionResult> Index()
        {
            var carrinho = await _carrinho.GetCarrinhoAsync();
            return View(carrinho);
        }
        public async Task<IActionResult> RemoveProduto(int id)
        {
            if (id != null && id != 0)
            {
                if (await _carrinho.RemoveCarrinho(id))
                {
                    TempData["Sucesso"] = $"Sucesso: Item removido do carrinho";
                     return RedirectToAction("Index");
                }
                TempData["Exception"] = $"Erro: Nenhum carrinho encontrado com o Id informado";
                return RedirectToAction("Index");
            }
            TempData["Exception"] = $"Erro: Nenhum carrinho encontrado com o Id informado";
            return RedirectToAction("Index");
        }
    }
}
