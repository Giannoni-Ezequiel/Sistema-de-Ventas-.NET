using System.ComponentModel.DataAnnotations.Schema;

namespace Conexion_a_BBDD.Models
{
    public class categorias_proveedor
    {
        [ForeignKey("Proveedor")]
        public int? id_proveedor { get; set; }

        [ForeignKey("Categoria")]
        public int? id_categoria { get; set; }

        public Proveedor proveedorCategoria { get; set; }

        public Categoria categoriaProveedor { get; set; }
    }
}
