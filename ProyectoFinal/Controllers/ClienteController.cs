using Microsoft.AspNetCore.Mvc;
using ProyectoFinal.Datos;
using ProyectoFinal.Models;


namespace ProyectoFinal.Controllers

{
    public class ClienteController : Controller
    {

        ClienteDatos clienteDatos = new ClienteDatos();



        public IActionResult Index()
        {

            var oLista = clienteDatos.Listar();

            return View(oLista);
        }

        public IActionResult Guardar()
        {
            return View();
        }


        [HttpPost]
        public IActionResult Guardar(Cliente oCliente)
        {
            var respuesta = clienteDatos.Guardar(oCliente);

            if (respuesta){

                return RedirectToAction("Index");

            }

            else
            {
                return View();
            }
        }

      
        //Método para la vista
        public IActionResult Editar(int id)
        {
            
            var oCliente = clienteDatos.Obtener(id);

            return View(oCliente);
        }





        [HttpPost]
        public IActionResult Editar(Cliente oCliente)
        {
            var respuesta = clienteDatos.Editar(oCliente);

            if (respuesta) {

                return RedirectToAction("Index");
                    }
            else
            {
                return View();
            }
        }


        //Método para vista eliminar 

        public IActionResult Eliminar(int id)
        {
            var oCliente = clienteDatos.Obtener(id);

            return View(oCliente);
        }

        //Método para logica de eliminar 
        [HttpPost]
        public IActionResult Eliminar(Cliente oCliente)
        {
            var respuesta = clienteDatos.Eliminar(oCliente.id_cliente);

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
