using Conexion_a_BBDD.Models;
using System.Data.SqlClient;
using System.Data;
using System.Reflection.Metadata.Ecma335;

namespace Conexion_a_BBDD.Datos
{
    /*
     El paso a paso es,
    BBDD: tiene la info que son los registros
    >>Conexion: Atraves de la conexion (puente/tunel)
    >>Modelos: La info se almacena en Modelos en forma de objeto
    >>Controladores: Reciben el objeto del modelo y lo envian a las vistas
    >>Vistas: 
    */
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
                            id = Convert.ToInt32(lector["id"]),
                            nombre = lector["nombre"].ToString(),
                            telefono = lector["telefono"].ToString(),
                            email = lector["email"].ToString()

                        }); 
                    }//Aca ya no existe la variable lector, se destruyo
                }//Aca ya no existe la variable conexionTemp, se destruyo
            }
            return objetoLista;
        }

        public Cliente Obtener(int id)
        {
            var objetoCliente = new Cliente();
            try { 
            var conexion = new Conexion();

            using (var conexionTemp = new SqlConnection(conexion.getCadenaSQL()))
            {
                conexionTemp.Open();
                SqlCommand cmd = new SqlCommand("Obtener", conexionTemp);
                cmd.Parameters.AddWithValue("id", id);
                cmd.CommandType = CommandType.StoredProcedure;

                using (var lector = cmd.ExecuteReader())
                {
                    while (lector.Read())
                    {
                        objetoCliente.id = Convert.ToInt32(lector["id"]);
                        objetoCliente.nombre = Convert.ToString(lector["nombre"]);
                        objetoCliente.telefono = Convert.ToString(lector["telefono"]);
                        objetoCliente.email = Convert.ToString(lector["email"]);
                    }
                }
            }
            }
            catch(Exception e)
            {
                string error = e.Message;
                return objetoCliente;
            }
            return objetoCliente;
        }


        public bool Guardar(Cliente objetoCliente)
        {
            bool respuesta;

            try
            {
                var conexion = new Conexion();
                using (var conexionTemp = new SqlConnection(conexion.getCadenaSQL()))
                {
                    conexionTemp.Open();
                    SqlCommand cmd = new SqlCommand("Guardar", conexionTemp);
                    cmd.Parameters.AddWithValue("nombre", objetoCliente.nombre);
                    cmd.Parameters.AddWithValue("telefono", objetoCliente.telefono);
                    cmd.Parameters.AddWithValue("email", objetoCliente.email);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.ExecuteNonQuery();
                }
                respuesta = true;
            }
            catch (Exception e)
            {
                string error = e.Message;
                respuesta = false;
            }
            return respuesta;
        } 

        public bool Editar(Cliente objetoCliente)
        {
            bool respuesta;
            try
            {
                var conexion = new Conexion();
                using(var conexionTemp = new SqlConnection(conexion.getCadenaSQL()))
                {
                    conexionTemp.Open();
                    SqlCommand cmd=new SqlCommand("Editar", conexionTemp);
                    cmd.Parameters.AddWithValue("id", objetoCliente.id);
                    cmd.Parameters.AddWithValue("nombre", objetoCliente.nombre);
                    cmd.Parameters.AddWithValue("telefono", objetoCliente.telefono);
                    cmd.Parameters.AddWithValue("email", objetoCliente.email);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.ExecuteNonQuery();
                }
                respuesta = true;
            }
            catch (Exception e)
            {
                string error = e.Message;
                respuesta = false;
            }
            return respuesta;
        }
        
        public bool Eliminar(int id)
        {
            bool respuesta;

            try
            {
                var conexion = new Conexion();
                using(var conexionTemp = new SqlConnection(conexion.getCadenaSQL()))
                {
                    conexionTemp.Open();
                    SqlCommand cmd = new SqlCommand("Eliminar", conexionTemp);
                    cmd.Parameters.AddWithValue("id", id);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.ExecuteNonQuery();
                }
                respuesta = true;
            }
            catch (Exception e)
            {
                string error = e.Message;
                respuesta = false;
            }
            return respuesta;
        }
    }
}
