using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Conexion_a_BBDD.Models
{
    public class Orden
    {
        [Key]
        public int id_orden { get; set; }

        public DateTime? ord_fecha_de_generacion { get; set; }

        [ForeignKey("Cliente")]
        public int? ord_id_cliente { get; set; }
        [ForeignKey("Empleado")]
        public int? ord_id_empleado { get; set; }
    }
}
