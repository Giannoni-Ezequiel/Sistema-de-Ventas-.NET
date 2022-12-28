using Conexion_a_BBDD.Datos;
using Conexion_a_BBDD.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Conexion_a_BBDD.Controllers
{
    public class Tipo_de_clienteController : Controller
    {
        Tipo_de_clienteDatos Tipo_de_clienteDatos = new Tipo_de_clienteDatos();

        [Authorize(Roles = "admin")]
        public IActionResult Index()
        {
            var oLista = Tipo_de_clienteDatos.ListarTipo_De_Cliente();
            return View(oLista);
        }
        public IActionResult GuardarTipo_de_cliente()
        {
            return View();
        }
        [HttpPost]
        public IActionResult GuardarTipo_de_cliente(Tipo_de_cliente oTipo_de_cliente)
        {
            var respuesta = Tipo_de_clienteDatos.GuardarTipo_De_Cliente(oTipo_de_cliente);
            if (respuesta)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
        }
        public IActionResult EditarTipo_de_cliente(int id)
        {
            var oTipo_de_cliente = Tipo_de_clienteDatos.ObtenerTipo_De_Cliente(id);
            return View(oTipo_de_cliente);
        }
        [HttpPost]
        public IActionResult EditarTipo_de_cliente(Tipo_de_cliente oTipo_de_cliente)
        {
            var respuesta = Tipo_de_clienteDatos.EditarTipo_De_Cliente(oTipo_de_cliente);
            if (respuesta)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
        }
        public IActionResult EliminarTipo_de_cliente(int id)
        {
            var oTipo_de_cliente = Tipo_de_clienteDatos.ObtenerTipo_De_Cliente(id);
            return View(oTipo_de_cliente);
        }
        [HttpPost]
        public IActionResult EliminarTipo_de_cliente(Tipo_de_cliente oTipo_de_cliente)
        {
            var respuesta = Tipo_de_clienteDatos.EliminarTipo_De_Cliente(oTipo_de_cliente.id_tipo_cliente);
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
