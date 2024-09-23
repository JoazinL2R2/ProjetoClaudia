using Microsoft.AspNetCore.Mvc;
using ProjetoClaudia.Services.Interface;

namespace ProjetoClaudia.Controllers
{
    public class ProdutoController : Controller
    {
        private readonly IProdutoService _produtoService;
        public ProdutoController(IProdutoService produto)
        {
            _produtoService = produto;
        }
        public  IActionResult Index()
        {
            var produtos = _produtoService.GetAllProdutos();
            if (produtos == null)
            {
                ViewBag.Message = "Nenhum produto encontrado";
            }
            return View(produtos);
        }
    }
}
