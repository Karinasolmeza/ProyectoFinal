using System.ComponentModel.DataAnnotations.Schema;

namespace ProyectoFinal.Models
{
    public class Proveedor_Categoria
    {

       
        [ForeignKey("Proveedor")]
        public int? id_proveedor { get; set; }

        [ForeignKey("Categoria")]
        public int? id_categoria { get; set; }


        public Proveedor proveedorCategoria { get; set; }

        public Categoria categoriaProveedor { get; set; }


    }
}
