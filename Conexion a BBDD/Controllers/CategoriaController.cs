using Conexion_a_BBDD.Datos;
using Conexion_a_BBDD.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Conexion_a_BBDD.Controllers
{
    public class CategoriaController : Controller
    {
        CategoriaDatos categoriaDatos = new CategoriaDatos();

        [Authorize(Roles = "admin, vendedor")]
        public IActionResult Listar()
        {
            var oLista = categoriaDatos.ListarCategoria();
            return View(oLista);
        }
        public IActionResult GuardarCategoria()
        {
            return View();
        }
        [HttpPost]
        public IActionResult GuardarCategoria(Categoria oCategoria)

        {
            var respuesta = categoriaDatos.GuardarCategoria(oCategoria);
            if (respuesta)
            {
                return RedirectToAction("Listar");
            }
            else
            {
                return View();
            }
        }
        public IActionResult EditarCategoria(int id)
        {
            var oCategoria = categoriaDatos.ObtenerCategoria(id);
            return View(oCategoria);
        }
        [HttpPost]
        public IActionResult EditarCategoria(Categoria oCategoria)
        {
            var respuesta = categoriaDatos.EditarCategoria(oCategoria);
            if (respuesta)
            {
                return RedirectToAction("Listar");
            }
            else
            {
                return View();
            }
        }
        public IActionResult EliminarCategoria(int id)
        {
            var oCategoria = categoriaDatos.ObtenerCategoria(id);
            return View(oCategoria);
        }
        [HttpPost]
        public IActionResult EliminarCategoria(Categoria oCategoria)
        {
            var respuesta = categoriaDatos.EliminarCategoria(oCategoria.id_categoria);
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
