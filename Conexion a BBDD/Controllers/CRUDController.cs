using Microsoft.AspNetCore.Mvc;
using Conexion_a_BBDD.Datos;
using Conexion_a_BBDD.Models;

namespace Conexion_a_BBDD.Controllers
{
  
    public class CRUDController : Controller
    {
        //Creamos instancia conexion
        ClienteDatos clienteDatos = new ClienteDatos();
        public IActionResult Listar()
        {
            var objetoLista = clienteDatos.Listar();
            return View(objetoLista);
        }
        public IActionResult Guardar()
        {
            return View();
        }

        //Metodo para la logica guardar 
        [HttpPost]
        public IActionResult Guardar(Cliente objetoCliente)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            var respuesta = clienteDatos.Guardar(objetoCliente);
            if (respuesta)
            {
                return RedirectToAction("Listar");
            }
            else
            {
                return View();
            }
        }

        //Metodo para la vista
        public IActionResult Editar(int id)
        {
            //Devuelve la vista segun el ID
            var objetoCliente = clienteDatos.Obtener(id);
            return View(objetoCliente);
        }

        //Meotod para la logica, para modificar
        [HttpPost]
        public IActionResult Editar(Cliente objetoCliente)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            var respuesta = clienteDatos.Editar(objetoCliente);
            if (respuesta)
            {
                return RedirectToAction("Listar");
            }
            else
            {
                return View();
            }
        }

        //Metodo para la vista, para eliminar
        public IActionResult Eliminar(int id)
        {
            var objetoCliente = clienteDatos.Obtener(id);
            return View(objetoCliente);
        }

        [HttpPost]
        public IActionResult Eliminar(Cliente objetoCliente)
        {
            var respuesta = clienteDatos.Eliminar(objetoCliente.Id);
            if (respuesta)
            {
                return RedirectToAction("Listar");
            }
            else
            {
                return View();
            }
        }
    }
}
