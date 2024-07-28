using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TesteMvc.Data;
using TesteMvc.Models;
using System.Linq;
using System.Threading.Tasks;

namespace TesteMvc.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppDbContext _context;

        public HomeController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> ListaCliente()
        {
            var clientes = await _context.Clientes.ToListAsync();
            return View(clientes);
        }

        public IActionResult AddCliente()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddCliente(ClienteModel cliente)
        {
            if (ModelState.IsValid)
            {
                _context.Clientes.Add(cliente);
                await _context.SaveChangesAsync();
                return RedirectToAction("ListaCliente");
            }
            return View(cliente);
        }

        public async Task<IActionResult> EditCliente(int id)
        {
            var cliente = await _context.Clientes.FindAsync(id);
            if (cliente == null)
            {
                return NotFound();
            }
            return View(cliente);
        }

        [HttpPost]
        public async Task<IActionResult> EditCliente(ClienteModel cliente)
        {
            if (ModelState.IsValid)
            {
                _context.Clientes.Update(cliente);
                await _context.SaveChangesAsync();
                return RedirectToAction("ListaCliente");
            }
            return View(cliente);
        }

        public async Task<IActionResult> DeleteCliente(int id)
        {
            var cliente = await _context.Clientes.FindAsync(id);
            if (cliente == null)
            {
                return NotFound();
            }
            return View(cliente);
        }

        [HttpPost, ActionName("DeleteCliente")]
        public async Task<IActionResult> DeleteClienteConfirmed(int id)
        {
            var cliente = await _context.Clientes.FindAsync(id);
            if (cliente != null)
            {
                _context.Clientes.Remove(cliente);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction("ListaCliente");
        }

        [HttpPost]
        public async Task<IActionResult> DeleteSelectedClientes(int[] selectedClientes)
        {
            var clientes = await _context.Clientes.Where(c => selectedClientes.Contains(c.Id)).ToListAsync();
            if (clientes.Any())
            {
                _context.Clientes.RemoveRange(clientes);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction("ListaCliente");
        }
    }
}
