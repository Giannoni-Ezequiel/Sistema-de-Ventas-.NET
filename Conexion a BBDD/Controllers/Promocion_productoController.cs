using Conexion_a_BBDD.Datos;
using Conexion_a_BBDD.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;
using System.Data;

namespace Conexion_a_BBDD.Controllers
{
    public class Promocion_productoController : Controller
    {
        Promocion_productoDatos Promocion_productoDatos = new Promocion_productoDatos();

        [Authorize(Roles = "admin")]
        public IActionResult ListarPromocion_producto()
        {
            var oLista = Promocion_productoDatos.ListarPromocion_producto();
            return View(oLista);
        }
        public IActionResult GuardarPromocion_producto()
        {
            return View();
        }
        [HttpPost]
        public IActionResult GuardarPromocion_producto(Promocion_producto oPromocion_producto)
        {
            var respuesta = Promocion_productoDatos.GuardarPromocion_producto(oPromocion_producto);
            if (respuesta)
            {
                return RedirectToAction("ListarPromocion_producto");
            }
            else
            {
                return View();
            }
        }
        public IActionResult EditarPromocion_producto(int id)
        {
            var oPromocion_producto = Promocion_productoDatos.ObtenerPromocion_producto(id);
            return View(oPromocion_producto);
        }
        [HttpPost]
        public IActionResult EditarPromocion_producto(Promocion_producto oPromocion_producto)
        {
            var respuesta = Promocion_productoDatos.EditarPromocion_producto(oPromocion_producto);
            if (respuesta)
            {
                return RedirectToAction("ListarPromocion_producto");
            }
            else
            {
                return View();
            }
        }
        public IActionResult EliminarPromocion_producto(int id)
        {
            var oPromocion_producto = Promocion_productoDatos.ObtenerPromocion_producto(id);
            return View(oPromocion_producto);
        }
        [HttpPost]
        public ActionResult EliminarPromocion_producto(int id_promo, int id_producto, int promo_numero)
        {
            try
            {
                var conexion = new Conexion();
                using (var conexionTemp = new SqlConnection(conexion.getCadenaSQL()))
                {
                    conexionTemp.Open();
                    SqlCommand cmd = new SqlCommand("EliminarPromocion_producto", conexionTemp);
                    cmd.Parameters.AddWithValue("id_promo", id_promo);
                    cmd.Parameters.AddWithValue("id_producto", id_producto);
                    cmd.Parameters.AddWithValue("promo_numero", promo_numero);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.ExecuteNonQuery();
                }
                return RedirectToAction("ListarPromocion_producto");
            }
            catch (Exception e)
            {
                string error = e.Message;
                return View("Error");
            }
        }
    }
}
