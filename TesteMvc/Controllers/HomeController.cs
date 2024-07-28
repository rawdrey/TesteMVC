using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using TesteMvc.Models;

namespace TesteMvc.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ListaClientes()
        {
            return View();
        }

        public IActionResult AddCliente()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddCliente(ClienteModel cliente)
        {
            if (ModelState.IsValid)
            {
                ViewBag.Message = "Cliente adicionado com sucesso!";
                return RedirectToAction("Index");
            }
            return View(cliente);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
