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


        [Authorize(Roles = "administrador, empleado")]
        public IActionResult Index()
        {

            var oLista = clienteDatos.ListarCliente();

            return View(oLista);
        }

        public IActionResult GuardarCliente()
        {
            return View();
        }


        [HttpPost]
        public IActionResult GuardarCliente(Cliente oCliente)
        {
            var respuesta = clienteDatos.GuardarCliente(oCliente);

            if (respuesta){

                return RedirectToAction("Index");

            }

            else
            {
                return View();
            }
        }

      
        //Método para la vista
        public IActionResult EditarCliente(int id)
        {
            
            var oCliente = clienteDatos.ObtenerCliente(id);

            return View(oCliente);
        }





        [HttpPost]
        public IActionResult EditarCliente(Cliente oCliente)
        {
            var respuesta = clienteDatos.EditarCliente(oCliente);

            if (respuesta) {

                return RedirectToAction("Index");
                    }
            else
            {
                return View();
            }
        }


        //Método para vista eliminar 

        public IActionResult EliminarCliente(int id)
        {
            var oCliente = clienteDatos.ObtenerCliente(id);

            return View(oCliente);
        }

        //Método para logica de eliminar 
        [HttpPost]
        public IActionResult EliminarCliente(Cliente oCliente)
        {
            var respuesta = clienteDatos.EliminarCliente(oCliente.id_cliente);

            if (respuesta) {

                return RedirectToAction("Index");
            }

            else
            {
                return View();
            }
        }


    }


}
