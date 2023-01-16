using Conexion_a_BBDD.Datos;
using Conexion_a_BBDD.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;
using System.Data;

namespace Conexion_a_BBDD.Controllers
{
    public class Detalle_ordenController : Controller
    {
        Detalle_ordenDatos Detalle_ordenDatos = new Detalle_ordenDatos();
        [Authorize(Roles = "admin, vendedor")]
        public IActionResult ListarDetalle_orden()
        {
            var oLista = Detalle_ordenDatos.ListarDetalle_orden();
            return View(oLista);
        }
        public IActionResult GuardarDetalle_orden()
        {
            return View();
        }
        [HttpPost]
        public IActionResult GuardarDetalle_orden(Detalle_orden oDetalle_orden)
        {
            var respuesta = Detalle_ordenDatos.GuardarDetalle_orden(oDetalle_orden);
            if (respuesta)
            {
                return RedirectToAction("ListarDetalle_orden");
            }
            else
            {
                return View();
            }
        }
        public IActionResult EditarDetalle_orden(int id)
        {
            var oDetalle_orden = Detalle_ordenDatos.ObtenerDetalle_orden(id);
            return View(oDetalle_orden);
        }
        [HttpPost]
        public IActionResult EditarDetalle_orden(Detalle_orden oDetalle_orden)
        {
            var respuesta = Detalle_ordenDatos.EditarDetalle_orden(oDetalle_orden);
            if (respuesta)
            {
                return RedirectToAction("ListarDetalle_orden");
            }
            else
            {
                return View();
            }
        }
        public IActionResult EliminarDetalle_orden(int id)
        {
            var oDetalle_orden = Detalle_ordenDatos.ObtenerDetalle_orden(id);
            return View(oDetalle_orden);
        }
        [HttpPost]
        public IActionResult EliminarDetalle_orden(int id_orden, int id_detalle_orden)
        {
            try
            {
                var conexion = new Conexion();
                using (var conexionTemp = new SqlConnection(conexion.getCadenaSQL()))
                {
                    conexionTemp.Open();
                    SqlCommand cmd = new SqlCommand("EliminarDetalle_orden", conexionTemp);
                    cmd.Parameters.AddWithValue("id_detalle_orden", id_detalle_orden);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.ExecuteNonQuery();
                }
                return RedirectToAction("ListarDetalle_orden");
            }
            catch (Exception e)
            {
                string error = e.Message;
                return View("Error");
            }
        }
    }
}
