using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Conexion_a_BBDD.Models
{
    public class Promocion_producto
    {
        [Key]
        public int id_promo { get; set; }
        [Key]
        public int id_producto { get; set; }
        [Key]
        public int promo_numero { get; set; }
        public DateTime? promo_fecha_inicio { get; set; }
        public DateTime? promo_fecha_fin { get; set; }

    }
}
