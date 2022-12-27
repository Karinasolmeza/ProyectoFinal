using ProyectoFinal.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProyectoFinal.Models
{
    public class Orden
    {
        public int id_orden { get; set; }

        public DateTime? ord_fecha_de_generacion { get; set; }

        public DateTime? ord_fecha_entrega { get; set; }


        [ForeignKey("Cliente")]
        public int? ord_id_cliente { get; set; }

        [ForeignKey("Empleado")]
        public int? ord_id_empleado { get; set; }

        //public virtual Detalle_orden detalleAsociado { get; set; }
        public List<Detalle_orden> Detalles { get; set; }
     

    }
}
