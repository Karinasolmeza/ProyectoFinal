using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProyectoFinal.Datos;
using ProyectoFinal.Models;
using System.Data;

namespace ProyectoFinal.Controllers
{
    public class RolesController : Controller
    {
        RolesDatos rolesDatos = new RolesDatos();


        [Authorize(Roles = "administrador, supervisor")]
        public IActionResult Index()
        {

            var oLista = rolesDatos.ListarRol();

            return View(oLista);
           

        }
        [Authorize(Roles = "administrador, supervisor")]
        public IActionResult GuardarRol()
        {
            return View();
        }

        [Authorize(Roles = "administrador, supervisor")]
        [HttpPost]
        public IActionResult GuardarRol(Roles oRol)
        {
            var respuesta = rolesDatos.GuardarRol(oRol);

            if (respuesta)
            {
                TempData["Mensaje"] = "El rol ha sido creado exitosamente";
                return RedirectToAction("Index");
               

            }

            else
            {
                return View();
                TempData["MensajeError"] = "El rol no ha sido creado exitosamente";
            }
        }

        [Authorize(Roles = "administrador, supervisor")]
        //Método para la vista
        public IActionResult EditarRol(int id)
        {

            var oRol = rolesDatos.ObtenerRol(id);

            return View(oRol);
        }




        [Authorize(Roles = "administrador, supervisor")]
        [HttpPost]
        public IActionResult EditarRol(Roles oRol)
        {
            var respuesta = rolesDatos.EditarRol(oRol);

            if (respuesta)
            {
                TempData["MensajeInfo"] = "El rol ha sido actualizado";
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
        }


        //Método para vista eliminar 
        [Authorize(Roles = "administrador, supervisor")]
        public IActionResult EliminarRol(int id)
        {
            var oRol = rolesDatos.ObtenerRol(id);

            return View(oRol);
        }


        [Authorize(Roles = "administrador, supervisor")]
        //Método para logica de eliminar 
        [HttpPost]
        public IActionResult EliminarRol(Roles oRol)
        {
            var respuesta = rolesDatos.EliminarRol(oRol.id_rol);

            if (respuesta)
            {
                TempData["MensajeError"] = "El rol ha sido eliminado";
                return RedirectToAction("Index");
            }

            else
            {
                return View();
            }
        }
    }
}
