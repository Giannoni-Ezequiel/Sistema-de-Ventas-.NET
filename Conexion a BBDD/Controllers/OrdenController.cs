using Conexion_a_BBDD.Datos;
using Conexion_a_BBDD.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Conexion_a_BBDD.Controllers
{
    public class OrdenController : Controller
    {
        OrdenDatos OrdenDatos = new OrdenDatos();

        [Authorize(Roles = "admin")]
        public IActionResult Index()
        {
            var oLista = OrdenDatos.ListarOrden();
            return View(oLista);
        }
        public IActionResult GuardarOrden()
        {
            return View();
        }
        [HttpPost]
        public IActionResult GuardarOrden(Orden oOrden)
        {
            var respuesta = OrdenDatos.GuardarOrden(oOrden);
            if (respuesta)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
        }
        public IActionResult EditarOrden(int id)
        {
            var oOrden = OrdenDatos.ObtenerOrden(id);
            return View(oOrden);
        }
        [HttpPost]
        public IActionResult EditarOrden(Orden oOrden)
        {
            var respuesta = OrdenDatos.EditarOrden(oOrden);
            if (respuesta)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
        }
        public IActionResult EliminarOrden(int id)
        {
            var oOrden = OrdenDatos.ObtenerOrden(id);
            return View(oOrden);
        }
        [HttpPost]
        public IActionResult EliminarOrden(Orden oOrden)
        {
            var respuesta = OrdenDatos.EliminarOrden(oOrden.id_orden);
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
