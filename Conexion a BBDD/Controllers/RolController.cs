using Conexion_a_BBDD.Datos;
using Conexion_a_BBDD.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Conexion_a_BBDD.Controllers
{
    public class RolController : Controller
    {
        RolDatos rolesDatos = new RolDatos();

        [Authorize(Roles = "administrador, supervisor")]
        public IActionResult ListarRol()
        {
            var oLista = rolesDatos.ListarRol();
            return View(oLista);
        }
        public IActionResult GuardarRol()
        {
            return View();
        }
        [HttpPost]
        public IActionResult GuardarRol(Rol oRol)
        {
            var respuesta = rolesDatos.GuardarRol(oRol);
            if (respuesta)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
        }
        public IActionResult EditarRol(int id)
        {
            var oRol = rolesDatos.ObtenerRol(id);
            return View(oRol);
        }
        [HttpPost]
        public IActionResult EditarRol(Rol oRol)
        {
            var respuesta = rolesDatos.EditarRol(oRol);
            if (respuesta)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
        }
        public IActionResult EliminarRol(int id)
        {
            var oRol = rolesDatos.ObtenerRol(id);
            return View(oRol);
        }
        [HttpPost]
        public IActionResult EliminarRol(Rol oRol)
        {
            var respuesta = rolesDatos.EliminarRol(oRol.id_rol);
            if (respuesta)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
        }
    }
}
