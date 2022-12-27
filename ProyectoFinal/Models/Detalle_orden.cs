using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Cryptography.Xml;

namespace ProyectoFinal.Models
{
	public class Detalle_orden
	{
        public int id_detalle_orden { get; set; }

        [ForeignKey("Orden")]
        public int? det_id_orden { get; set; }

        [ForeignKey("Producto")]
        public int? det_id_producto { get; set; }
       
        public decimal? det_ord_precio { get; set; }

        public decimal? det_ord_cantidad { get; set; }

        public decimal? det_ord_total { get; set; }
    }
}

