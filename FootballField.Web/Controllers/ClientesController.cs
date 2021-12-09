using System;
using FootballField.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace FootballField.Web.Controllers
{
    public class ClientesController : Controller
    {
        public IActionResult Index()
        {
            return View(FootballField.Web.Program.ClientesList);
        }

        public IActionResult Create()
        {
            return View();
        }

        public IActionResult Guardar(string nombre, string apellido, string numero)
        {
            Cliente nuevoCliente = new Cliente();
            nuevoCliente.ID = Guid.NewGuid();
            nuevoCliente.Nombre = nombre;
            nuevoCliente.Apellido = apellido;
            nuevoCliente.numeroCelular = numero;

            FootballField.Web.Program.ClientesList.Add(nuevoCliente);

            return RedirectToAction("Index");
            
        }

       

        public IActionResult Editar(Guid id)
        {
            Cliente editar = Buscar(id);
            if (editar == null)
            {
                return RedirectToAction("Index");
            }
            return View(editar);
        }

        public IActionResult Actualizar(Guid id, string nombre, string apellido, string numero)
        {
            Cliente editar = Buscar(id);
            if (editar != null)
            {   
                // string prefijo = "+54 9 ";
                editar.Nombre = nombre;
                editar.Apellido = apellido;
                editar.numeroCelular = numero;
            }
            return RedirectToAction("Index");
        }
         private Cliente Buscar(Guid id)
        {
            Cliente find  = FootballField.Web.Program.ClientesList.Find(elemento => elemento.ID == id);
            return find;
        }
    }
}