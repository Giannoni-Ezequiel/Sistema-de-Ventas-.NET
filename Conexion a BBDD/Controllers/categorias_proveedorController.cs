using Conexion_a_BBDD.Datos;
using Conexion_a_BBDD.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;
using System.Data;

namespace Conexion_a_BBDD.Controllers
{
    public class categorias_proveedorController : Controller
    {
        categorias_proveedorDatos categorias_proveedorDatos = new categorias_proveedorDatos();

        [Authorize(Roles = "admin, vendedor")]
        public IActionResult Listarcategorias_proveedor()
        {
            var oLista = categorias_proveedorDatos.Listarcategorias_proveedor();
            return View(oLista);
        }
        public IActionResult Guardarcategorias_proveedor()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Guardarcategorias_proveedor(categorias_proveedor ocategorias_proveedor)
        {
            var respuesta = categorias_proveedorDatos.Guardarcategorias_proveedor(ocategorias_proveedor);
            if (respuesta)
            {
                return RedirectToAction("Listarcategorias_proveedor");
            }
            else
            {
                return View();
            }
        }
        public IActionResult Editarcategorias_proveedor(int id)
        {
            var ocategorias_proveedor = categorias_proveedorDatos.Obtenercategorias_proveedor(id);
            return View(ocategorias_proveedor);
        }
        [HttpPost]
        public IActionResult Editarcategorias_proveedor(categorias_proveedor ocategorias_proveedor)
        {
            var respuesta = categorias_proveedorDatos.Editarcategorias_proveedor(ocategorias_proveedor);
            if (respuesta)
            {
                return RedirectToAction("Listarcategorias_proveedor");
            }
            else
            {
                return View();
            }
        }
        public IActionResult Eliminarcategorias_proveedor(int id)
        {
            var ocategorias_proveedor = categorias_proveedorDatos.Obtenercategorias_proveedor(id);
            return View(ocategorias_proveedor);
        }
        [HttpPost]
        public IActionResult Eliminarcategorias_proveedor(int id_proveedor, int id_categoria)
        {
            try
            {
                var conexion = new Conexion();
                using (var conexionTemp = new SqlConnection(conexion.getCadenaSQL()))
                {
                    conexionTemp.Open();
                    SqlCommand cmd = new SqlCommand("Eliminarcategorias_proveedor", conexionTemp);
                    cmd.Parameters.AddWithValue("id_proveedor", id_proveedor);
                    cmd.Parameters.AddWithValue("id_categoria", id_categoria);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.ExecuteNonQuery();
                }
                return RedirectToAction("Listarcategorias_proveedor");
            }
            catch (Exception e)
            {
                string error = e.Message;
                return View("Error");
            }
        }
    }
}
