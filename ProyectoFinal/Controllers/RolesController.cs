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

        public IActionResult GuardarRol()
        {
            return View();
        }


        [HttpPost]
        public IActionResult GuardarRol(Roles oRol)
        {
            var respuesta = rolesDatos.GuardarRol(oRol);

            if (respuesta)
            {

                return RedirectToAction("Index");

            }

            else
            {
                return View();
            }
        }


        //Método para la vista
        public IActionResult EditarRol(int id)
        {

            var oRol = rolesDatos.ObtenerRol(id);

            return View(oRol);
        }





        [HttpPost]
        public IActionResult EditarRol(Roles oRol)
        {
            var respuesta = rolesDatos.EditarRol(oRol);

            if (respuesta)
            {

                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
        }


        //Método para vista eliminar 

        public IActionResult EliminarRol(int id)
        {
            var oRol = rolesDatos.ObtenerRol(id);

            return View(oRol);
        }

        //Método para logica de eliminar 
        [HttpPost]
        public IActionResult EliminarRol(Roles oRol)
        {
            var respuesta = rolesDatos.EliminarRol(oRol.id_rol);

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
