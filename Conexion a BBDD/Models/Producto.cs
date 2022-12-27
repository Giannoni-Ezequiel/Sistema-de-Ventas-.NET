using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Conexion_a_BBDD.Models
{
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
    }
}
