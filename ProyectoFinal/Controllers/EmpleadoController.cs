using Microsoft.AspNetCore.Mvc;
using ProyectoFinal.Datos;
using ProyectoFinal.Models;

namespace ProyectoFinal.Controllers
{
    public class EmpleadoController : Controller
    {
        EmpleadoDatos empleadoDatos = new EmpleadoDatos();



        public IActionResult Index()
        {

            var oLista = empleadoDatos.ListarEmpleado();

            return View(oLista);
        }

        public IActionResult GuardarEmpleado()
        {
            return View();
        }


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


        //Método para la vista
        public IActionResult EditarEmpleado(int id)
        {

            var oEmpleado = empleadoDatos.ObtenerEmpleado(id);

            return View(oEmpleado);
        }





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
