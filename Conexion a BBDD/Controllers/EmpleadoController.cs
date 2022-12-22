using Conexion_a_BBDD.Datos;
using Conexion_a_BBDD.Models;
using Microsoft.AspNetCore.Mvc;

namespace Conexion_a_BBDD.Controllers
{
    public class EmpleadoController : Controller
    {
        EmpleadoDatos empleadoDatos = new EmpleadoDatos();
        public IActionResult Index()
        {
            //Traigo la informacion en forma de objeto
            var oLista = empleadoDatos.ListarEmpleado();
            //Le paso el objeto con la informacion a la vista
            return View(oLista);
        }

        //Método para la vista - editar
        public IActionResult GuardarEmpleado()
        {
            return View();
        }
        
        //Método para logica - guardar
        [HttpPost]
        public IActionResult GuardarEmpleado(Empleado oEmpleado)
        {
            var respuesta = empleadoDatos.GuardarEmpleado(oEmpleado);

            if (respuesta)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
        }
        
        //Método para la vista - editar
        public IActionResult EditarEmpleado(int id)
        {

            var oEmpleado = empleadoDatos.ObtenerEmpleado(id);

            return View(oEmpleado);
        }

        //Método para logica - editar 
        [HttpPost]
        public IActionResult EditarEmpleado(Empleado oEmpleado)
        {
            var respuesta = empleadoDatos.EditarEmpleado(oEmpleado);
            if (respuesta)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
        }

        //Método para vista - eliminar 
        public IActionResult EliminarEmpleado(int id)
        {
            var oEmpleado = empleadoDatos.ObtenerEmpleado(id);

            return View(oEmpleado);
        }

        //Método para logica de eliminar 
        [HttpPost]
        public IActionResult EliminarEmpleado(Empleado oEmpleado)
        {
            var respuesta = empleadoDatos.EliminarEmpleado(oEmpleado.id_empleado);
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
