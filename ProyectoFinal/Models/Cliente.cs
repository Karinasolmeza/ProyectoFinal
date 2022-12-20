using System.ComponentModel.DataAnnotations.Schema;

namespace ProyectoFinal.Models
{
    public class Cliente
    {
        public int id_cliente { get; set; }

        public string? clie_nombre { get; set; }

        public string? clie_apellido { get; set; } 

        public string? clie_dni { get; set; }

        public string?  clie_cuit { get; set; }

        public string? clie_razon_social { get; set; }

        public string? clie_tipo { get; set; }

        [ForeignKey("Usuario")]
        public int? clie_id_usuario { get; set; }


    }
}
