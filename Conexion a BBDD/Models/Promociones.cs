using System.ComponentModel.DataAnnotations;

namespace Conexion_a_BBDD.Models
{
    public class Promociones
    {
        [Key]
        public int id_promo { get; set; }
        public char nombre_promo { get; set; }
        public decimal descuento { get; set; }

    }
}
