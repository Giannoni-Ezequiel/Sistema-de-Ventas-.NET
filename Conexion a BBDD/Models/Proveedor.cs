namespace Conexion_a_BBDD.Models
{
    public class Proveedor
    {
        public int id_proveedor { get; set; }

        public string? provee_nombre { get; set; }

        public string? provee_apellido { get; set; }

        public string? provee_direccion { get; set; }

        public string? provee_cuit { get; set; }
    }
}
