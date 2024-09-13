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
        [HttpGet]
        public IActionResult Login()
        {

            if (User.Identity.IsAuthenticated)
            {
                //Criação de sessão apenas para não aparecer "Sessão expirada" na página de login
                HttpContext.Session.SetString("nome", "teste");
                return RedirectToAction("LogOut", "Home");
            }

            if (HttpContext.Session.GetString("nome") != null)
            {
                HttpContext.Session.Clear();
            }

            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(Usuario usuario)
        {
            if(usuario != null)
            {
                await _userService.Login(usuario);
                return View();
            }
            return View();
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
