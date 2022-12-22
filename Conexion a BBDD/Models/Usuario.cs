using System.Data;

namespace Conexion_a_BBDD.Models
{
    public class Usuario
    {
        public int id_usuario { get; set; }
        public string? usua_nombre { get; set; }
        public string? usua_correo { get; set; }
        public string? usua_pass { get; set; }
 
        public int id_Rol { get; set; }
       
        public Rol? rolAsociado { get; set; }
    }
}
