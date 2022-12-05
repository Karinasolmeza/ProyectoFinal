using Microsoft.AspNetCore.Mvc;
using ProyectoFinal.Models;
using ProyectoFinal.Datos;
using Microsoft.AspNetCore.Authentication.Cookies; //USING PARA COOKIES
using Microsoft.AspNetCore.Authentication;
using System.Security.Claims;

namespace ProyectoFinal.Controllers
{
    public class AccesoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Index(Usuario _usuario)  //Task para método async por la cookie
        {

            DA_Logica _da_usuario = new DA_Logica();
            var usuario = _da_usuario.ValidarUsuario(_usuario.Correo, _usuario.Clave);

            if (usuario != null)
            {
                var claims = new List<Claim> {  //dos principales para usuario

                new Claim(ClaimTypes.Name, usuario.Nombre),
                new Claim("Correo",usuario.Correo)

                };

                foreach(string rol in usuario.Roles) //Iteramos roles desde var claime ingresamos alli, almacenamos en var rol de un array de strings de usuarios 
                {
                    claims.Add(new Claim(ClaimTypes.Role, rol));
                }

                var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);


                //Usamos var claimsIdentity pasamos al esquema los datos y creamos la cookie
                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity));




                return RedirectToAction("Index", "Home");
            }
            else {
                return View();
            }
        }



        public async Task<IActionResult> Salir()
        {

            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme); //await para poder eliminar la cookie al salir 
            return RedirectToAction("Index","Acceso");
        }

    }
}
