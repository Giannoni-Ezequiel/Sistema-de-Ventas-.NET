using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Conexion_a_BBDD.Datos;
using Conexion_a_BBDD.Models;

namespace Conexion_a_BBDD.Controllers
{
    public class AuthController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(Usuario _usuario)
        {
            UsuarioDatos infoUser = new UsuarioDatos();
            var usuario = infoUser.Autenticar(_usuario.usua_correo, _usuario.usua_pass);
            if (usuario != null)
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, usuario.usua_nombre),
                    new Claim("usua_correo", usuario.usua_correo)
                };

                /* foreach (int rol in userAutenticado.id_Rol)
                 {
                     claims.Add(new Claim(ClaimTypes.Role, rol));
                 }*/
                claims.Add(new Claim(ClaimTypes.Role, usuario.rolAsociado.rol_detalle));

                var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity));

                return RedirectToAction("Listar", "CRUD");
            }
            else 
            {
                TempData["Mensaje"] = "El usuario no existe!";
                return View(); }
        }
        public async Task<IActionResult> Salir()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index", "Auth");
        }
    }
}
