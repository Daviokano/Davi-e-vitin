using Microsoft.AspNetCore.Mvc;
using Projeto3.Models;
using Projeto3.Repository;

namespace Projeto3.Controllers
{
    public class EnderecoController : Controller
    {
        private IEnderecoRepository _enderecoRepository;

        public EnderecoController(IEnderecoRepository enderecoRepository)
        {
            _enderecoRepository = enderecoRepository;
        }

        public IActionResult Index()
        {
            return View( _enderecoRepository.ObterTodosEnderecos());
        }

        [HttpGet]
        public IActionResult Cadastrar()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Cadastrar(Endereco endereco)
        {
            if (ModelState.IsValid)
            {
                _enderecoRepository.Cadastrar(endereco);
                return RedirectToAction(nameof(Index));
            }

            return View();
        }
    }
}
