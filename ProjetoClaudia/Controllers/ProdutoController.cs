using Microsoft.AspNetCore.Mvc;

namespace ProjetoClaudia.Controllers
{
    public class ProdutoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
