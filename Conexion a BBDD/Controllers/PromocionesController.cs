using Conexion_a_BBDD.Datos;
using Conexion_a_BBDD.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Conexion_a_BBDD.Controllers
{
    public class PromocionesController : Controller
    {
        PromocionesDatos PromocionesDatos = new PromocionesDatos();

        [Authorize(Roles = "admin")]
        public IActionResult ListarPromociones()
        {
            var oLista = PromocionesDatos.ListarPromociones();
            return View(oLista);
        }
        public IActionResult GuardarPromociones()
        {
            return View();
        }
        [HttpPost]
        public IActionResult GuardarPromociones(Promociones oPromociones)
        {
            var respuesta = PromocionesDatos.GuardarPromociones(oPromociones);
            if (respuesta)
            {
                return RedirectToAction("ListarPromociones");
            }
            else
            {
                return View();
            }
        }
        public IActionResult EditarPromociones(int id)
        {
            var oPromociones = PromocionesDatos.ObtenerPromociones(id);
            return View(oPromociones);
        }
        [HttpPost]
        public IActionResult EditarPromociones(Promociones oPromociones)
        {
            var respuesta = PromocionesDatos.EditarPromociones(oPromociones);
            if (respuesta)
            {
                return RedirectToAction("ListarPromociones");
            }
            else
            {
                return View();
            }
        }
        public IActionResult EliminarPromociones(int id)
        {
            var oPromociones = PromocionesDatos.ObtenerPromociones(id);
            return View(oPromociones);
        }
        [HttpPost]
        public IActionResult EliminarPromociones(Promociones oPromociones)
        {
            var respuesta = PromocionesDatos.EliminarPromociones(oPromociones.id_promo);
            if (respuesta)
            {
                return RedirectToAction("ListarPromociones");
            }
            else
            {
                return View();
            }
        }
    }
}
