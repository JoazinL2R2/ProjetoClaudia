using Microsoft.AspNetCore.Mvc;
using ProjetoClaudia.Models;
using ProjetoClaudia.Services;
using ProjetoClaudia.Services.Interface;

namespace ProjetoClaudia.Controllers
{
    public class CarrinhoController : Controller
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly ICarrinhoService _carrinho;
        public CarrinhoController(ICarrinhoService service, IHttpContextAccessor httpContextAccessor)
        {
            _carrinho = service;
            _httpContextAccessor = httpContextAccessor;
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
        [HttpPost]
        public IActionResult AdicionarAoCarrinho([FromBody] int produtoId)
        {
            var usuarioId = _httpContextAccessor.HttpContext.Session.GetInt32("Id");

            if (usuarioId.HasValue)
            {
                _carrinho.AdicionarAoCarrinho(produtoId, usuarioId.Value);
                return Json(new { sucesso = true, usuarioId = usuarioId.Value, produtoId = produtoId });
            }
            return RedirectToAction("Index","Produto");
        }
    }
}
