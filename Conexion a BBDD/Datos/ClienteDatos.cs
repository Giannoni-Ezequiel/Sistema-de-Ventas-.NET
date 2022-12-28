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
                SqlCommand cmd = new SqlCommand("ListarClientes", conexionTemp);
                cmd.CommandType = CommandType.StoredProcedure;
                using (var lector = cmd.ExecuteReader())
                {
                    while (lector.Read())
                    {
                        //Añadiendo por cada vuelta un registro
                        objetoLista.Add(new Cliente()
                        {
                            id_cliente = Convert.ToInt32(lector["id_cliente"]),
                            clie_nombre = Convert.ToString(lector["clie_nombre"]),
                            clie_apellido = Convert.ToString(lector["clie_apellido"]),
                            clie_dni = Convert.ToString(lector["clie_dni"]),
                            clie_cuit = Convert.ToString(lector["clie_cuit"]),
                            clie_razon_social = Convert.ToString(lector["clie_razon_social"]),
                            clie_tipo = Convert.ToString(lector["clie_tipo"]),
                            clie_id_usuario = Convert.ToInt32(lector["clie_id_usuario"])
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
                SqlCommand cmd = new SqlCommand("ObtenerClientes", conexionTemp);
                cmd.Parameters.AddWithValue("IdContacto", id); //id es de nuestra tabla, id_contacto es el generado ASº
                cmd.CommandType = CommandType.StoredProcedure;

                using (var lector = cmd.ExecuteReader())
                {
                    while (lector.Read())
                    {
                            objetoCliente.id_cliente = Convert.ToInt32(lector["id_cliente"]);
                            objetoCliente.clie_nombre = Convert.ToString(lector["clie_nombre"]);
                            objetoCliente.clie_apellido = Convert.ToString(lector["clie_apellido"]);
                            objetoCliente.clie_dni = Convert.ToString(lector["clie_dni"]);
                            objetoCliente.clie_cuit = Convert.ToString(lector["clie_cuit"]);
                            objetoCliente.clie_razon_social = Convert.ToString(lector["clie_razon_social"]);
                            objetoCliente.clie_tipo = Convert.ToString(lector["clie_tipo"]);
                            objetoCliente.clie_id_usuario = Convert.ToInt32(lector["clie_id_usuario"]);

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
                    SqlCommand cmd = new SqlCommand("GuardarClientes", conexionTemp);
                    cmd.Parameters.AddWithValue("clie_nombre", objetoCliente.clie_nombre);
                    cmd.Parameters.AddWithValue("clie_apellido", objetoCliente.clie_apellido);
                    cmd.Parameters.AddWithValue("clie_dni", objetoCliente.clie_dni);
                    cmd.Parameters.AddWithValue("clie_cuit", objetoCliente.clie_cuit);
                    cmd.Parameters.AddWithValue("clie_razon_social", objetoCliente.clie_razon_social);
                    cmd.Parameters.AddWithValue("clie_tipo", objetoCliente.clie_tipo);
                    cmd.Parameters.AddWithValue("clie_id_usuario", objetoCliente.clie_id_usuario);

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
                    SqlCommand cmd=new SqlCommand("EditarClientes", conexionTemp);
                    cmd.Parameters.AddWithValue("id_cliente", objetoCliente.id_cliente);
                    cmd.Parameters.AddWithValue("clie_nombre", objetoCliente.clie_nombre);
                    cmd.Parameters.AddWithValue("clie_apellido", objetoCliente.clie_apellido);
                    cmd.Parameters.AddWithValue("clie_dni", objetoCliente.clie_dni);
                    cmd.Parameters.AddWithValue("clie_cuit", objetoCliente.clie_cuit);
                    cmd.Parameters.AddWithValue("clie_razon_social", objetoCliente.clie_razon_social);
                    cmd.Parameters.AddWithValue("clie_tipo", objetoCliente.clie_tipo);
                    cmd.Parameters.AddWithValue("clie_id_usuario", objetoCliente.clie_id_usuario);

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
        public bool Eliminar(int id_cliente)
        {
            bool respuesta;
            try
            {
                var conexion = new Conexion();
                using(var conexionTemp = new SqlConnection(conexion.getCadenaSQL()))
                {
                    conexionTemp.Open();
                    SqlCommand cmd = new SqlCommand("ELiminarClientes", conexionTemp);
                    cmd.Parameters.AddWithValue("id_cliente", id_cliente);
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
