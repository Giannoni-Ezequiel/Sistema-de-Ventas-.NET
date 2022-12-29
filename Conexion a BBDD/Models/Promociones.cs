using System.ComponentModel.DataAnnotations;

namespace Conexion_a_BBDD.Models
{
    public class Promociones
    {
        [Key]
        public int id_promo { get; set; }
        public string? promo_nombre { get; set; }
        public decimal? descuento { get; set; }

    }
}
