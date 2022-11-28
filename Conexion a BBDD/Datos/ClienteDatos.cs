using Conexion_a_BBDD.Models;
using System.Data.SqlClient;
using System.Data;

namespace Conexion_a_BBDD.Datos
{
    public class ClienteDatos
    {
        public List<Cliente> Listar()
        {
            //Esta variable recibe la informacion
            var objetoLista = new List<Cliente>();
           //Instancia de la conexion
            var conexion = new Conexion();
            //Definimos el tiempo de duracion de la conexion
            using (var conexionTemp = new SqlConnection(conexion.getCadenaSQL()))
            {
                conexionTemp.Open();
                //Instacio un objeto para las query y relaciono con el storedprocedure
                SqlCommand cmd = new SqlCommand("Listar", conexionTemp);
                cmd.CommandType = CommandType.StoredProcedure;

                using (var lector = cmd.ExecuteReader())
                {
                    while (lector.Read())
                    {
                        //Añadiendo por cada vuelta un registro
                        objetoLista.Add(new Cliente()
                        {
                            Id = Convert.ToInt32(lector["id"]),
                            nombre = Convert.ToString(lector["nombre"]),
                            telefono = Convert.ToString(lector["telfono"]),
                            email = Convert.ToString(lector["email"])

                        });
                    }//Aca ya no existe la variable lector, se destruyo
                }//Aca ya no existe la variable conexionTemp, se destruyo
            }
            return objetoLista;
        }
    }
}
