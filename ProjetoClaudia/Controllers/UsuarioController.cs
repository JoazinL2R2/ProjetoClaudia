using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using ProjetoClaudia.Models;
using ProjetoClaudia.Services.Interface;

namespace ProjetoClaudia.Controllers
{
    public class UsuarioController : Controller
    {
        private readonly IUsuarioService _userService;
        public UsuarioController(IUsuarioService usuarioService)
        {
            _userService = usuarioService;
        }
        [HttpPost]
        public async Task<IActionResult> Login(Usuario usuario)
        {
            if(usuario != null)
            {
                await _userService.Login(usuario);
                return RedirectToAction("Index","Produto");
            }
            return RedirectToAction("Index", "Produto");
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
