using MessagePack;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Cryptography.Xml;

namespace ProyectoFinal.Models
{
    public class Promocion_producto
    {
     
        public int promo_numero{ get; set; }

        [ForeignKey("Promociones")]
        public int? id_promo { get; set; }

        [ForeignKey("Producto")]
        public int? id_producto { get; set; }

        public DateTime? promo_fecha_inicio { get; set; }

        public DateTime? promo_fecha_fin  { get; set; }

      

    }
}



