using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProyectoFinal.Datos;
using ProyectoFinal.Models;
using System.Data;


namespace ProyectoFinal.Controllers

{
    public class ClienteController : Controller
    {
        ClienteDatos clienteDatos = new ClienteDatos();


        [Authorize(Roles = "administrador, empleado, supervisor")]
        public IActionResult Index()
        {

            var oLista = clienteDatos.ListarCliente();

            return View(oLista);
        }

        [Authorize(Roles = "administrador, empleado, supervisor")]
        public IActionResult GuardarCliente()
        {
            return View();
        }

        [Authorize(Roles = "administrador, empleado, supervisor")]
        [HttpPost]
        public IActionResult GuardarCliente(Cliente oCliente)
        {
            var respuesta = clienteDatos.GuardarCliente(oCliente);

            if (respuesta){

                TempData["Mensaje"] = "El Cliente ha sido guardado exitosamente";
                return RedirectToAction("Index");

            }

            else
            {
                return View();
            }
        }

        [Authorize(Roles = "administrador, empleado, supervisor")]
        //Método para la vista
        public IActionResult EditarCliente(int id)
        {
            
            var oCliente = clienteDatos.ObtenerCliente(id);

            return View(oCliente);
        }




        [Authorize(Roles = "administrador, empleado, supervisor")]
        [HttpPost]
        public IActionResult EditarCliente(Cliente oCliente)
        {
            var respuesta = clienteDatos.EditarCliente(oCliente);

            if (respuesta) {

                TempData["MensajeInfo"] = "El Cliente ha sido actualizado";
                return RedirectToAction("Index");
                    }
            else
            {
                return View();
            }
        }


        //Método para vista eliminar 
        [Authorize(Roles = "administrador, empleado, supervisor")]
        public IActionResult EliminarCliente(int id)
        {
            var oCliente = clienteDatos.ObtenerCliente(id);

            return View(oCliente);
        }


        [Authorize(Roles = "administrador, empleado, supervisor")]
        //Método para logica de eliminar 
        [HttpPost]
        public IActionResult EliminarCliente(Cliente oCliente)
        {
            var respuesta = clienteDatos.EliminarCliente(oCliente.id_cliente);

            if (respuesta) {

                TempData["MensajeError"] = "El Cliente ha sido eliminado";
                return RedirectToAction("Index");
            }

            else
            {
                return View();
            }
        }


    }


}
