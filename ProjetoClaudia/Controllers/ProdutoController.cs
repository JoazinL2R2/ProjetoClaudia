using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using ProjetoClaudia.Models;
using ProjetoClaudia.Services.Interface;

namespace ProjetoClaudia.Controllers
{
    public class ProdutoController : Controller
    {
        private readonly IProdutoService _produtoService;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public ProdutoController(IProdutoService produto, IWebHostEnvironment webHostEnvironment)
        {
            _produtoService = produto;
            _webHostEnvironment = webHostEnvironment;
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
        public async Task<IActionResult> AddProduto(Produto produto, IFormFile Imagem)
        {
            if (produto.Nome != null && produto.Quantidade != 0 && produto.Valor != null)
            {
                if (Imagem != null && Imagem.Length > 0)
                {
                    try
                    {
                        string uploadFolder = Path.Combine(_webHostEnvironment.WebRootPath, "ImagemProdutos");
                        if (!Directory.Exists(uploadFolder))
                        {
                            Directory.CreateDirectory(uploadFolder);
                        }
                        string fileName = Path.GetFileNameWithoutExtension(Imagem.FileName)
                                          + "_" + Path.GetRandomFileName().Substring(0, 8)
                                          + Path.GetExtension(Imagem.FileName);
                        string filePath = Path.Combine(uploadFolder, fileName);
                        using (var stream = new FileStream(filePath, FileMode.Create))
                        {
                            await Imagem.CopyToAsync(stream);
                        }
                        produto.URL_Imagem = fileName;
                        await _produtoService.CreateProduto(produto);

                        return RedirectToAction("GetAllProdutos", "Admin");
                    }
                    catch (Exception ex)
                    {
                        TempData["Exception"] = $"Erro: {ex.Message}";
                        return RedirectToAction("GetAllProdutos", "Admin");
                    }
                }

                TempData["Exception"] = "Imagem não selecionada. Por favor, selecione uma imagem.";
                return RedirectToAction("GetAllProdutos", "Admin");
            }

            TempData["Exception"] = "Preencha todos os dados e tente novamente!";
            return RedirectToAction("GetAllProdutos", "Admin");
        }
        public async Task<IActionResult> EditProduto(Produto produto)
        {
            if (produto.Nome != null && produto.Quantidade != 0 && produto.Valor != null)
            {
                try
                {
                    await _produtoService.UpdateProduto(produto);
                    TempData["SucessoMensage"] = "Sucesso ao editar produto.";
                    return RedirectToAction("GetAllProdutos", "Admin");
                }
                catch (Exception ex)
                {
                    TempData["Exception"] = $"Erro: {ex.Message}";
                    return RedirectToAction("GetAllProdutos", "Admin");
                }
            }
            TempData["Exception"] = "Preencha todos os dados e tente novamente!";
            return RedirectToAction("GetAllProdutos", "Admin");
        }
        public async Task<IActionResult> InativarProduto(int Id)
        {
            if (Id != null && Id != 0)
            {
                try
                {
                    await _produtoService.DeleteProduto(Id);
                    TempData["SucessoMensage"] = "Sucesso ao remover produto.";
                    return RedirectToAction("GetAllProdutos", "Admin");
                }
                catch (Exception ex)
                {
                    TempData["Exception"] = $"Erro: {ex.Message}";
                    return RedirectToAction("GetAllProdutos", "Admin");
                }
            }
            TempData["Exception"] = "Erro ao obter Id.";
            return RedirectToAction("GetAllProdutos", "Admin");
        }
    }
}
