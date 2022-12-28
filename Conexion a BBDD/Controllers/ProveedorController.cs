using Conexion_a_BBDD.Datos;
using Conexion_a_BBDD.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Conexion_a_BBDD.Controllers
{
    public class ProveedorController : Controller
    {
        ProveedorDatos ProveedorDatos = new ProveedorDatos();

        [Authorize(Roles = "admin")]
        public IActionResult Index()
        {
            var oLista = ProveedorDatos.ListarProveedor();
            return View(oLista);
        }
        public IActionResult GuardarProveedor()
        {
            return View();
        }
        [HttpPost]
        public IActionResult GuardarProveedor(Proveedor oProveedor)
        {
            var respuesta = ProveedorDatos.GuardarProveedor(oProveedor);
            if (respuesta)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
        }
        public IActionResult EditarProveedor(int id)
        {
            var oProveedor = ProveedorDatos.ObtenerProveedor(id);
            return View(oProveedor);
        }
        [HttpPost]
        public IActionResult EditarProveedor(Proveedor oProveedor)
        {
            var respuesta = ProveedorDatos.EditarProveedor(oProveedor);
            if (respuesta)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
        }
        public IActionResult EliminarProveedor(int id)
        {
            var oProveedor = ProveedorDatos.ObtenerProveedor(id);
            return View(oProveedor);
        }
        [HttpPost]
        public IActionResult EliminarProveedor(Proveedor oProveedor)
        {
            var respuesta = ProveedorDatos.EliminarProveedor(oProveedor.id_proveedor);
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
