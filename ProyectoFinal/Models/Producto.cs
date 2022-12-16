using MessagePack;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using KeyAttribute = System.ComponentModel.DataAnnotations.KeyAttribute;

namespace ProyectoFinal.Models
{
    //public class Producto
    //{
    //    [Key]
    //    public int id_producto { get; set; }

    //    public string? prod_nombre { get; set; }

    //    public decimal? prod_precio { get; set; }

    //    public decimal? prod_stock { get; set; }

    //    public string? prod_detalle { get; set; }

    //    public string? prod_img { get; set; }

    //    [ForeignKey("Proveedor")]
    //    public int? id_proveedor { get; set; }

    //    public virtual Proveedor proveedorAsociado { get; set; }




    //}


    public class Producto
    {
        [Key]
        public int id_producto { get; set; }

        public string? prod_nombre { get; set; }

        public decimal? prod_precio { get; set; }

        public decimal? prod_stock { get; set; }

        public string? prod_detalle { get; set; }

        public string? prod_img { get; set; }

        [ForeignKey("Proveedor")]
        public int? prod_proveedor { get; set; }

        public virtual Proveedor proveedorAsociado { get; set; }




    }
}
