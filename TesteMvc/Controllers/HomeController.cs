using Microsoft.AspNetCore.Mvc;
using TesteMvc.Models;
using System.Collections.Generic;
using System.Linq;

namespace TesteMvc.Controllers
{
    public class HomeController : Controller
    {
        private static List<ClienteModel> _clientes = new List<ClienteModel>();

        
    public IActionResult Index()
        {
            return View();
        }
        public IActionResult ListaCliente()
        {
            return View(_clientes);
        }

        public IActionResult AddCliente(int? id)
        {
            ClienteModel cliente = new ClienteModel();
            if (id.HasValue)
            {
                cliente = _clientes.FirstOrDefault(c => c.Id == id.Value);
                if (cliente == null)
                {
                    return NotFound();
                }
            }
            return View(cliente);
        }

        [HttpPost]
        public IActionResult SaveCliente(ClienteModel cliente)
        {
            if (ModelState.IsValid)
            {
                if (cliente.Id == 0)
                {
                    cliente.Id = _clientes.Count > 0 ? _clientes.Max(c => c.Id) + 1 : 1;
                    _clientes.Add(cliente);
                    TempData["MensagemSucesso"] = "Cliente adicionado com sucesso!";
                }
                else
                {
                    var existingCliente = _clientes.FirstOrDefault(c => c.Id == cliente.Id);
                    if (existingCliente != null)
                    {
                        existingCliente.Nome = cliente.Nome;
                        existingCliente.CPF = cliente.CPF;
                        existingCliente.Telefone = cliente.Telefone;
                        existingCliente.Email = cliente.Email;
                        existingCliente.Endereco = cliente.Endereco;
                        TempData["MensagemSucesso"] = "Cliente atualizado com sucesso!";
                    }
                }
                return RedirectToAction("ListaCliente");
            }
            return View("AddCliente", cliente);
        }

        public IActionResult Delete(int id)
        {
            ClienteModel cliente = _clientes.FirstOrDefault(c => c.Id == id);
            if (cliente == null)
            {
                return NotFound();
            }
            return View(cliente);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            ClienteModel cliente = _clientes.FirstOrDefault(c => c.Id == id);
            if (cliente != null)
            {
                _clientes.Remove(cliente);
            }
            return RedirectToAction("ListaCliente");
        }

        public IActionResult Edit(int id)
        {
            ClienteModel cliente = _clientes.FirstOrDefault(c => c.Id == id);
            if (cliente == null)
            {
                return NotFound();
            }
            return View("AddCliente", cliente);
        }
    }
}
