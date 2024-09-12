using Microsoft.AspNetCore.Mvc;

namespace ProjetoClaudia.Controllers
{
    public class UsuarioController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
