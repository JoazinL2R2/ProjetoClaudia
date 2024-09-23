using Microsoft.AspNetCore.Mvc;
using ProjetoClaudia.Services.Interface;

namespace ProjetoClaudia.Controllers
{
    public class AdminController : Controller
    {
        private readonly IUsuarioService _usuarioService;
        private readonly IProdutoService _produtoService;
        public AdminController(IProdutoService produtoService, IUsuarioService usuarioService)
        {
            _produtoService = produtoService;
            _usuarioService = usuarioService;
        }
        public IActionResult GetAllProdutos()
        {          
            return View("Adicionar-RemoverProdutos", _produtoService.GetAllProdutos());
        }
        public IActionResult GetAllUsuarios()
        {
            return View("Adicionar-RemoverUsuarios", _usuarioService.GetAllUsers());
        }
    }
}
