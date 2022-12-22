using Conexion_a_BBDD.Models;
using System.Data.SqlClient;
using System.Data;

namespace Conexion_a_BBDD.Datos
{
    public class UsuarioDatos
    {
        /*public List<Usuario> ListaUsuarios()
       {
          return new List<Usuario>()
           {
               new Usuario(){ usua_nombre = "Ezequiel", usua_email = "eze@gmail.com", usua_pass = "shashasha", //rolAsociado = new Rol {1, "Admin"},
               new Usuario(){ usua_nombre = "Lorena", usua_email = "alfa@gmail.com", usua_pass = "sha123456", //rolAsociado = new string[] { "SuperAdmin" } },
               new Usuario(){ usua_nombre = "Fernando", usua_email = "Fer@gmail.com", usua_pass = "shas978", //rolAsociado = new string[] { "User" } },
               new Usuario(){ usua_nombre = "Mateo", usua_email = "mate@gmail.com", usua_pass = "shas456" //rolAsociado = new string[] { "Admin" } }
           };
       }
       public Usuario ValidarUsuario(string correo, string contrasenia)
       {
           return ListaUsuarios().Where(item => item.usua_email == correo && item.usua_pass == contrasenia).FirstOrDefault();
       }*/
        public List<Usuario> ListarUsuarios()
        {
            //Esta variable recibe la informacion
            var oLista = new List<Usuario>();
            //Instancia de la conexion
            var conexion = new Conexion();
            //Usando using definimos el tiempo de vida de la conexion
            using (var conexionTemp = new SqlConnection(conexion.getCadenaSQL()))
            {
                //Aca abro la conexion
                conexionTemp.Open();
                //Aca instancio un objeto para las query y la relaciono con el sp
                SqlCommand cmd = new SqlCommand("ListarUsuario", conexionTemp);
                cmd.CommandType = CommandType.StoredProcedure;
                //Comienzo la lectura de datos
                using (var lector = cmd.ExecuteReader())
                {
                    //mientras haya registros van a almacenarse en el oLista
                    while (lector.Read())
                    {
                        //Añadiendo por cada vuelta un registro
                        oLista.Add(new Usuario()
                        {
                            usua_nombre = Convert.ToString(lector["usua_nombre"]),
                            usua_pass = Convert.ToString(lector["usua_pass"]),
                            usua_correo = Convert.ToString(lector["usua_correo"]),
                            id_Rol = Convert.ToInt32(lector["id_Rol"]),
                            rolAsociado = new Rol()
                            {
                                id_rol = Convert.ToInt32(lector["id_rol"]),
                                rol_detalle = Convert.ToString(lector["rol_detalle"])
                            }
                        });
                    }//Aca ya no existe la variable lector, se destruyo
                }//Aca ya no existe la variable conexionTemp, se destruyo
            }
            return oLista;
        }
        public List<Usuario> ListarUsuarioRol()
        {
            var oLista = new List<Usuario>();
            //Instancia de la conexion
            var conexion = new Conexion();
            //Usando using definimos el tiempo de vida de la conexion
            using (var conexionTemp = new SqlConnection(conexion.getCadenaSQL()))
            {
                //Aca abro la conexion
                conexionTemp.Open();
                //Aca instancio un objeto para las query y la relaciono con el sp
                SqlCommand cmd = new SqlCommand("ListarUsuarioRol", conexionTemp);
                cmd.CommandType = CommandType.StoredProcedure;
                //Comienzo la lectura de datos
                using (var lector = cmd.ExecuteReader())
                {
                    //mientras haya registros van a almacenarse en el oLista
                    while (lector.Read())
                    {
                        //Añadiendo por cada vuelta un registro
                        oLista.Add(new Usuario()
                        {
                            id_usuario = Convert.ToInt32(lector["id_usuario"]),
                            usua_nombre = Convert.ToString(lector["Nombre"]),
                            usua_correo = Convert.ToString(lector["Correo"]),
                            usua_pass = Convert.ToString(lector["Clave"]),
                            id_Rol = Convert.ToInt32(lector["usuario_rol"]),
                            rolAsociado = new Rol()
                            {
                                id_rol = Convert.ToInt32(lector["id_rol"]),
                                rol_detalle = Convert.ToString(lector["rol_detalle"]),
                            }
                        });
                    }
                }
            }
            return oLista;
        }
        public Usuario ObtenerUsuario(int id_usuario)
        {
            var oUsuario = new Usuario();
            try
            {
                var conexion = new Conexion();
                using (var conexionTemp = new SqlConnection(conexion.getCadenaSQL()))
                {
                    conexionTemp.Open();
                    SqlCommand cmd = new SqlCommand("ObtenerUsuario", conexionTemp);

                    cmd.Parameters.AddWithValue("id_usuario", id_usuario);
                    cmd.CommandType = CommandType.StoredProcedure;

                    using (var lector = cmd.ExecuteReader())
                    {
                        while (lector.Read())
                        {
                            oUsuario.id_usuario = Convert.ToInt32(lector["id_usuario"]);
                            oUsuario.usua_nombre = Convert.ToString(lector["Nombre"]);
                            oUsuario.usua_correo = Convert.ToString(lector["Correo"]);
                            oUsuario.usua_pass = Convert.ToString(lector["Clave"]);
                            oUsuario.id_Rol = Convert.ToInt32(lector["usuario_rol"]);
                        }
                    }
                }
            }
            catch (Exception e)
            {
                string error = e.Message;
                return oUsuario;
            }
            return oUsuario;
        }
        public bool GuardarUsuario(Usuario oUsuario)
        {
            bool respuesta;
            try
            {
                var conexion = new Conexion();
                using (var conexionTemp = new SqlConnection(conexion.getCadenaSQL()))
                {
                    conexionTemp.Open();
                    SqlCommand cmd = new SqlCommand("GuardarUsuario", conexionTemp);

                    cmd.Parameters.AddWithValue("Nombre", oUsuario.usua_nombre);
                    cmd.Parameters.AddWithValue("Correo", oUsuario.usua_correo);
                    cmd.Parameters.AddWithValue("Clave", oUsuario.usua_pass);
                    cmd.Parameters.AddWithValue("usuario_rol", oUsuario.id_Rol);

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
        public bool EditarUsuario(Usuario oUsuario)
        {
            bool respuesta;
            try
            {
                var conexion = new Conexion();
                using (var conexionTemp = new SqlConnection(conexion.getCadenaSQL()))
                {
                    conexionTemp.Open();

                    SqlCommand cmd = new SqlCommand("EditarUsuario", conexionTemp);

                    cmd.Parameters.AddWithValue("id_usuario", oUsuario.id_usuario);
                    cmd.Parameters.AddWithValue("Nombre", oUsuario.usua_nombre);
                    cmd.Parameters.AddWithValue("Correo", oUsuario.usua_correo);
                    cmd.Parameters.AddWithValue("Clave", oUsuario.usua_pass);
                    cmd.Parameters.AddWithValue("usuario_rol", oUsuario.id_Rol);

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
        public bool EliminarUsuario(int id_usuario)
        {
            bool respuesta;
            try
            {
                var conexion = new Conexion();
                using (var conexionTemp = new SqlConnection(conexion.getCadenaSQL()))
                {
                    conexionTemp.Open();
                    SqlCommand cmd = new SqlCommand("EliminarUsuario", conexionTemp);
                    cmd.Parameters.AddWithValue("id_usuario", id_usuario);
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
        public Usuario ValidarUsuario(string usua_correo, string usua_pass)
        {
            return ListarUsuarios().Where(item => item.usua_nombre == usua_correo && item.usua_pass == usua_pass).FirstOrDefault();
        }
        public Usuario Autenticar(string usua_correo, string usua_pass)
        {
            //Esta variable recibe la informacion
            var usuario = new Usuario();
            //Instancia de la conexion
            var conexion = new Conexion();
            try
            {
                //Usando using definimos el tiempo de vida de la conexion
                using (var conexionTemp = new SqlConnection(conexion.getCadenaSQL()))
                {
                    //Aca abro la conexion
                    conexionTemp.Open();
                    //Aca instancio un objeto para las query y la relaciono con el sp
                    SqlCommand cmd = new SqlCommand("AutenticarUsuarios", conexionTemp);
                    
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("usua_correo", usua_correo);
                    cmd.Parameters.AddWithValue("usua_pass", usua_pass);
                    cmd.ExecuteNonQuery();
                    //Comienzo la lectura de datos
                    using (var lector = cmd.ExecuteReader())
                    {
                        //mientras haya registros van a almacenarse en el oLista
                        while (lector.Read())
                        {
                            usuario.id_usuario = Convert.ToInt32(lector["id_usuario"]);
                            usuario.usua_nombre = Convert.ToString(lector["usua_nombre"]);
                            usuario.usua_pass = Convert.ToString(lector["usua_pass"]);
                            usuario.usua_correo = Convert.ToString(lector["usua_correo"]);
                            usuario.id_Rol = Convert.ToInt32(lector["id_Rol"]);
                            usuario.rolAsociado = new Rol()
                            {
                                id_rol = Convert.ToInt32(lector["id_rol"]),
                                rol_detalle = Convert.ToString(lector["rol_detalle"])
                            };
                        }
                    }
                }
                return usuario;
            }
            catch
            {
                return null;
            }
        }
    }
}
