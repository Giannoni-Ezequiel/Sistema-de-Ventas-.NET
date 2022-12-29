using Conexion_a_BBDD.Datos;
using Conexion_a_BBDD.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Conexion_a_BBDD.Controllers
{
    public class UsuarioController : Controller
    {
        UsuarioDatos UsuarioDatos = new UsuarioDatos();

        [Authorize(Roles = "admin")]
        public IActionResult ListarUsuario()
        {
            var oLista = UsuarioDatos.ListarUsuarios();
            return View(oLista);
        }
        public IActionResult GuardarUsuarios()
        {
            return View();
        }
        [HttpPost]
        public IActionResult GuardarUsuarios(Usuario oUsuario)
        {
            var respuesta = UsuarioDatos.GuardarUsuario(oUsuario);
            if (respuesta)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
        }
        public IActionResult EditarUsuario(int id)
        {
            var oUsuario = UsuarioDatos.ObtenerUsuario(id);
            return View(oUsuario);
        }
        [HttpPost]
        public IActionResult EditarUsuario(Usuario oUsuario)
        {
            var respuesta = UsuarioDatos.EditarUsuario(oUsuario);
            if (respuesta)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
        }
        public IActionResult EliminarUsuario(int id)
        {
            var oUsuario = UsuarioDatos.ObtenerUsuario(id);
            return View(oUsuario);
        }
        [HttpPost]
        public IActionResult EliminarUsuario(Usuario oUsuario)
        {
            var respuesta = UsuarioDatos.EliminarUsuario(oUsuario.id_usuario);
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
