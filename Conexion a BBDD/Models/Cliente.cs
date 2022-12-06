using System.ComponentModel.DataAnnotations;
namespace Conexion_a_BBDD.Models
{
    public class Cliente
    {
        public int id { get; set; }
        [Required(ErrorMessage = "Ingresar el nombre es obligatorio")]
        public string? nombre { get; set; }
        [Required(ErrorMessage = "Ingresar el telefono es obligatorio")]
        public string? telefono { get; set; }
        [Required(ErrorMessage = "Ingresar el email es obligatorio")]
        public string? email { get; set; }
    }
}
