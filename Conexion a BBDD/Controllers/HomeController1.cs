using Microsoft.AspNetCore.Mvc;
using Conexion_a_BBDD.Datos;

namespace Conexion_a_BBDD.Controllers
{
    public class HomeController1 : Controller
    {
        //Creamos instancia conexion
        ClienteDatos clienteDatos = new ClienteDatos();
        public IActionResult Index()
        {
            var objetoLista = clienteDatos.Listar();
            return View(objetoLista);
        }
    }
}
