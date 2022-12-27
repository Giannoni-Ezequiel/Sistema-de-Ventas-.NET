using System.ComponentModel.DataAnnotations.Schema;

namespace Conexion_a_BBDD.Models
{
    public class categoria_proveedor
    {
        [ForeignKey("Proveedor")]
        public int? id_proveedor { get; set; }

        [ForeignKey("Categoria")]
        public int? id_categoria { get; set; }
    }
}
