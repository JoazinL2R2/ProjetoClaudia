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
        public async Task<IActionResult> ExcluirUsuario(int Id)
        {
            try
            {
                if (Id != null)
                {
                    await _userService.DeleteUser(Id);
                    TempData["SucessMensage"] = "Sucesso ao excluir usuário";
                    return RedirectToAction("GetAllUsuarios", "Admin");
                }
                throw new Exception("usuario nulo");
            }
            catch (Exception ex)
            {
                TempData["Exception"] = "Erro ao excluir usuário";
                return RedirectToAction("GetAllUsuarios", "Admin");
            }
        }
        public async Task<IActionResult> AdicioarUsuario(Usuario usuario)
        {
            if (usuario != null)
            {
                await _userService.CreateUser(usuario);
                return RedirectToAction("GetAllUsuarios", "Admin");
            }
            throw new Exception();
        }
        public IActionResult CadastroUsuario()
        {
            return View();
        }
        public async Task<IActionResult> EditarUsuario(Usuario usuario)
        {
            try
            {
                if (usuario != null)
                {
                    await _userService.UpdateUser(usuario);
                    TempData["SucessMensage"] = "Sucesso ao editar usuário";
                    return RedirectToAction("GetAllUsuarios", "Admin");
                }
                throw new Exception("usuario nulo");
            }
            catch (Exception ex)
            {
                TempData["Exception"] = "Erro ao editar usuário";
                return RedirectToAction("GetAllUsuarios", "Admin");
            }
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
