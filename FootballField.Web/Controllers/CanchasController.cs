using System;
using System.Linq;
using FootballField.Web.Data;
using FootballField.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace FootballField.Web.Controllers
{
    public class CanchasController : Controller
    {
         private ApplicationDbContext _context;
          public CanchasController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View(_context.Canchas.ToList());
        }
        public IActionResult Create()
        {
            return View();
        }

        public IActionResult Guardar(string nombre, string hora,string numero)
        {
            Cancha nuevaReserva = new Cancha();
            nuevaReserva.nombreCliente = nombre;
            nuevaReserva.Hora = hora;
            nuevaReserva.numeroCelular = numero;

             _context.Canchas.Add(nuevaReserva);
             _context.SaveChanges();

            return RedirectToAction("Index");
            
        }
        public IActionResult Editar(int id)
        {
            Cancha editar = Buscar(id);
            if (editar == null)
            {
                return RedirectToAction("Index");
            }
            return View(editar);
        }

         public IActionResult Eliminar(int id)
        {
            Cancha eliminar = Buscar(id);
            if (eliminar == null)
            {
                return StatusCode(404);;
            }

            _context.Canchas.Remove(eliminar);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Actualizar(int id,string nombre, string hora)
        {
            Cancha editar = Buscar(id);
            if (editar != null)
            {   
                editar.nombreCliente = nombre;
                editar.Hora = hora;
                _context.Canchas.Update(editar);
                _context.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        private Cancha Buscar(int id)
        {
            Cancha find  = _context.Canchas.Find(id);
            return find;
        }

        


    }
}