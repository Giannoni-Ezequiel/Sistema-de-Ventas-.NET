using Conexion_a_BBDD.Datos;
using Conexion_a_BBDD.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Conexion_a_BBDD.Controllers
{
    public class ProductoController : Controller
    {
        ProductoDatos ProductoDatos = new ProductoDatos();

        [Authorize(Roles = "admin, vendedor")]
        public IActionResult ListarProducto()
        {
            var oLista = ProductoDatos.ListarProductos();
            return View(oLista);
        }
        [Authorize(Roles = "cliente, admin")]
        public IActionResult VisualizarProductos()
        {
            var oLista = ProductoDatos.VisualizarProductos();
            return View(oLista);
        }
        public IActionResult GuardarProductos()
        {
            return View();
        }
        [HttpPost]
        public IActionResult GuardarProductos(Producto oProducto)
        {
            var respuesta = ProductoDatos.GuardarProductos(oProducto);
            if (respuesta)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
        }
        public IActionResult EditarProductos(int id)
        {
            var oProducto = ProductoDatos.ObtenerProductos(id);
            return View(oProducto);
        }
        [HttpPost]
        public IActionResult EditarProductos(Producto oProducto)
        {
            var respuesta = ProductoDatos.EditarProductos(oProducto);
            if (respuesta)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
        }
        public IActionResult EliminarProductos(int id)
        {
            var oProducto = ProductoDatos.ObtenerProductos(id);
            return View(oProducto);
        }
        [HttpPost]
        public IActionResult EliminarProductos(Producto oProducto)
        {
            var respuesta = ProductoDatos.EliminarProductos(oProducto.id_producto);
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
