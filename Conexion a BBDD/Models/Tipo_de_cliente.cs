using System.ComponentModel.DataAnnotations;

namespace Conexion_a_BBDD.Models
{
    public class Tipo_de_cliente
    {
        [Key]
        public int id_tipo_cliente { get; set; }

        public string? clie_tipo_descripcion { get; set; }
    }
}
