using Microsoft.AspNetCore.Mvc;
using ProyectoFinal.Models;
using ProyectoFinal.Datos;
using Microsoft.AspNetCore.Authentication.Cookies; //USING PARA COOKIES
using Microsoft.AspNetCore.Authentication;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using System.Data;

namespace ProyectoFinal.Controllers
{
    public class AccesoController : Controller
    {
        //INDEX ACCESO LOGIN
        public IActionResult Index()
        {
            return View();
        }


        DA_Logica daDatos = new DA_Logica();
        [Authorize(Roles = "administrador, supervisor")]
        //INDEX LISTAR DE USUARIOS
        public IActionResult IndexUsuario()
        {

            var oLista = daDatos.ListarUsuarioRol();

            return View(oLista);
        }

        //VISTA GUARDAR USUARIO
        [Authorize(Roles = "administrador, supervisor")]
        public IActionResult GuardarUsuario()
        {
            return View();
        }

        [Authorize(Roles = "administrador, supervisor")]
        [HttpPost]
        public IActionResult GuardarUsuario(Usuario oUsuario)
        {
            var respuesta = daDatos.GuardarUsuario(oUsuario);

            if (respuesta)
            {

                TempData["Mensaje"] = "Usuario guardado exitosamente";
                return RedirectToAction("IndexUsuario");

            }

            else
            {
                return View();
            }
        }

        [Authorize(Roles = "administrador, supervisor")]
        //Método para la vista
        public IActionResult EditarUsuario(int id)
        {

            var oUsuario = daDatos.ObtenerUsuario(id);

            return View(oUsuario);
        }




        [Authorize(Roles = "administrador, supervisor")]
        [HttpPost]
        public IActionResult EditarUsuario(Usuario oUsuario)
        {
            var respuesta = daDatos.EditarUsuario(oUsuario);

            if (respuesta)
            {
                TempData["MensajeInfo"] = "El Usuario ha sido actualizado";
                return RedirectToAction("IndexUsuario");
            }
            else
            {
                return View();
            }
        }


        //Método para vista eliminar 
        [Authorize(Roles = "administrador, supervisor")]
        public IActionResult EliminarUsuario(int id)
        {
            var oUsuario = daDatos.ObtenerUsuario(id);

            return View(oUsuario);
        }

        [Authorize(Roles = "administrador, supervisor")]
        //Método para logica de eliminar 
        [HttpPost]
        public IActionResult EliminarUsuario(Usuario oUsuario)
        {
            var respuesta = daDatos.EliminarUsuario(oUsuario.id_usuario);

            if (respuesta)
            {
                TempData["MensajeError"] = "El Usuario ha sido eliminado";
                return RedirectToAction("IndexUsuario");
            }

            else
            {
                return View();
            }
        }


        [HttpPost]
        public async Task<IActionResult> Index(Usuario _usuario)  //Task para método async por la cookie
        {

            DA_Logica _da_usuario = new DA_Logica();
            //var usuario = _da_usuario.ValidarUsuario(_usuario.Correo, _usuario.Clave);
            var usuario = _da_usuario.AutenticarUsuario(_usuario.Correo, _usuario.Clave);

            if (usuario != null)
            {
                var claims = new List<Claim> {  //dos principales para usuario

                new Claim(ClaimTypes.Name, usuario.Nombre),
                new Claim("Correo",usuario.Correo)

                };



                //    foreach ( string rol in usuario.Roles) //.Roles  Iteramos roles desde var claime ingresamos alli, almacenamos en var rol de un array de strings de usuarios 
                //{
                //    claims.Add(new Claim(ClaimTypes.Role, rol));
                //}

                claims.Add(new Claim(ClaimTypes.Role, usuario.rolAsociado.rol_detalle));


                var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);


                //Usamos var claimsIdentity pasamos al esquema los datos y creamos la cookie
                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity));




                return RedirectToAction("Index", "Home");
            }

            else {

                TempData["Mensaje"] = "El usuario no existe!";
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
