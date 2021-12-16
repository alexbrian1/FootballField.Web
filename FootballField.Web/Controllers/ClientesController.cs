using System;
using System.Linq;
using FootballField.Web.Data;
using FootballField.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace FootballField.Web.Controllers
{
    public class ClientesController : Controller
    {
        private ApplicationDbContext _context;
        public ClientesController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View(_context.Clientes.ToList());
        }

        public IActionResult Create()
        {
            return View();
        }

        public IActionResult Guardar(string nombre, string apellido, string numero)
        {
            Cliente nuevoCliente = new Cliente();
            nuevoCliente.Nombre = nombre;
            nuevoCliente.Apellido = apellido;
            nuevoCliente.numeroCelular = numero;

            _context.Clientes.Add(nuevoCliente);
            _context.SaveChanges();

            return RedirectToAction("Index");
            
        }

       

        public IActionResult Editar(int id)
        {
            Cliente editar = Buscar(id);
            if (editar == null)
            {
                return RedirectToAction("Index");
            }
            return View(editar);
        }
        public IActionResult Eliminar(int id)
        {
            Cliente eliminar = Buscar(id);
            if (eliminar == null)
            {
                return StatusCode(404);;
            }

            _context.Clientes.Remove(eliminar);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Actualizar(int id, string nombre, string apellido, string numero)
        {
            Cliente editar = Buscar(id);
            if (editar != null)
            {   
                // string prefijo = "+54 9 ";
                editar.Nombre = nombre;
                editar.Apellido = apellido;
                editar.numeroCelular = numero;
                _context.Clientes.Update(editar);
                _context.SaveChanges();
            }
            return RedirectToAction("Index");
        }

      
         private Cliente Buscar(int id)
        {
            Cliente find  = _context.Clientes.Find(id);
            return find;
        }
    }
}