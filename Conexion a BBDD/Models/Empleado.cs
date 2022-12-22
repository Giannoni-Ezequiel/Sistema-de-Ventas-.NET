using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Conexion_a_BBDD.Models
{
    public class Empleado
    {
        [Key]
        public int id_empleado { get; set; }
        public string? emple_nombre { get; set; }
        public string? emple_apellido { get; set; }
        [ForeignKey("Empleado")]
        public int? emple_id_supervisor { get; set; }

        [ForeignKey("Usuario")]
        public int? emple_id_usuario { get; set; }
    }
}
