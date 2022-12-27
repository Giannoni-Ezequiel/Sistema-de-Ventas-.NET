using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Conexion_a_BBDD.Models
{
    public class Categoria
    {
        [Key]
        public int id_categoria { get; set; }
        public string? categ_detalle { get; set; }
        
    }
}
