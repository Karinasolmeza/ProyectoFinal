using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProyectoFinal.Datos;
using ProyectoFinal.Models;
using System.Data;

namespace ProyectoFinal.Controllers
{
    public class EmpleadoController : Controller
    {
        EmpleadoDatos empleadoDatos = new EmpleadoDatos();


        [Authorize(Roles = "administrador, supervisor")]
        public IActionResult Index()
        {

            var oLista = empleadoDatos.ListarEmpleado();

            return View(oLista);
        }

        [Authorize(Roles = "administrador, supervisor")]
        public IActionResult GuardarEmpleado()
        {
            return View();
        }

        [Authorize(Roles = "administrador, supervisor")]
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

        [Authorize(Roles = "administrador, supervisor")]
        //Método para la vista
        public IActionResult EditarEmpleado(int id)
        {

            var oEmpleado = empleadoDatos.ObtenerEmpleado(id);

            return View(oEmpleado);
        }




        [Authorize(Roles = "administrador, supervisor")]
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


        //Método para vista eliminar 
        [Authorize(Roles = "administrador, supervisor")]
        public IActionResult EliminarEmpleado(int id)
        {
            var oEmpleado = empleadoDatos.ObtenerEmpleado(id);

            return View(oEmpleado);
        }



        [Authorize(Roles = "administrador, supervisor")]
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
