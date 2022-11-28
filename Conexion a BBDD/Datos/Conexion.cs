using System.Data.SqlClient;

namespace Conexion_a_BBDD.Datos
{
   
    public class Conexion
    {
        private string cadenaSQL = string.Empty;
       
        //Constructor de la conexion
        public Conexion(string cadenaSQL)
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).
                AddJsonFile("appsettings.json").Build();
            cadenaSQL = builder.GetSection("ConnectionStrings:CadenaSQL").Value;
        }
        //Getter de la cadena de SQL
        public string getCadenaSQL() { return cadenaSQL; }
    }
}
