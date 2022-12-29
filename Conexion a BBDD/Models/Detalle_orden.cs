using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Conexion_a_BBDD.Models
{
    public class Detalle_orden
    {
        [ForeignKey("Orden")]
        public int id_orden { get; set; }
        [Key]
        public int id_detalle_orden { get; set; }
        public decimal? det_ord_precio { get; set; }
        public decimal? det_ord_cantidad { get; set; }

        [ForeignKey("Producto")]
        public int? id_producto { get; set; }
    }
}
