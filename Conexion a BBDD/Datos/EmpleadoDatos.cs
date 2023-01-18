using Conexion_a_BBDD.Models;
using System.Data.SqlClient;
using System.Data;

namespace Conexion_a_BBDD.Datos
{
    public class EmpleadoDatos
    {
        /*
        El paso a paso es, 
        BBDD: tiene la info que son los registros
        >> Conexion: Atraves de la conexion (puente/tunel)
        >> Modelos: La info se almacena en Modelos en forma de objeto
        >> Controladores: Reciben el objeto del modelo y lo envian a las vistas
        >> Vistas: muestra la informacion
         
         */
        //Aca pasamos a definir los metodos del CRUD (ABML)
        public List<Empleado> ListarEmpleado()
        {
            var oLista = new List<Empleado>();
            //Instancia de la conexion
            var conexion = new Conexion();
            //Usando using definimos el tiempo de vida de la conexion
            using (var conexionTemp = new SqlConnection(conexion.getCadenaSQL()))
            {
                //Aca abro la conexion
                conexionTemp.Open();
                //Aca instancio un objeto para las query y la relaciono con el sp
                SqlCommand cmd = new SqlCommand("ListarEmpleado", conexionTemp);
                cmd.CommandType = CommandType.StoredProcedure;
                //Comienzo la lectura de datos
                using (var lector = cmd.ExecuteReader())
                {
                    //mientras haya registros van a almacenarse en el oLista
                    while (lector.Read())
                    {
                        //Añadiendo por cada vuelta un registro
                        oLista.Add(new Empleado()
                        {
                            id_empleado = Convert.ToInt32(lector["id_empleado"]),
                            emple_nombre = Convert.ToString(lector["emple_nombre"]),
                            emple_apellido = Convert.ToString(lector["emple_apellido"]),
                            emple_id_supervisor = Convert.ToInt32(lector["emple_id_supervisor"]),
                            emple_id_usuario = Convert.ToInt32(lector["emple_id_usuario"])
                        });
                    }
                }
            }
            return oLista;
        }
        public Empleado ObtenerEmpleado(int id_empleado)
        {
            var oEmpleado = new Empleado();
            try
            {
                var conexion = new Conexion();
                using (var conexionTemp = new SqlConnection(conexion.getCadenaSQL()))
                {
                    conexionTemp.Open();
                    SqlCommand cmd = new SqlCommand("ObtenerEmpleado", conexionTemp);

                    cmd.Parameters.AddWithValue("id_empleado", id_empleado);
                    cmd.CommandType = CommandType.StoredProcedure;

                    using (var lector = cmd.ExecuteReader())
                    {
                        while (lector.Read())
                        {
                            oEmpleado.id_empleado = Convert.ToInt32(lector["id_empleado"]);
                            oEmpleado.emple_nombre = Convert.ToString(lector["emple_nombre"]);
                            oEmpleado.emple_apellido = Convert.ToString(lector["emple_apellido"]);
                            oEmpleado.emple_id_supervisor = Convert.ToInt32(lector["emple_id_supervisor"]);
                            oEmpleado.emple_id_usuario = Convert.ToInt32(lector["emple_id_usuario"]);
                        }
                    }
                }
            }
            catch (Exception e)
            {
                string error = e.Message;
                return oEmpleado;
            }
            return oEmpleado;
        }
        public bool GuardarEmpleado(Empleado oEmpleado)
        {
            bool respuesta;
            try
            {
                var conexion = new Conexion();
                using (var conexionTemp = new SqlConnection(conexion.getCadenaSQL()))
                {
                    conexionTemp.Open();
                    SqlCommand cmd = new SqlCommand("GuardarEmpleado", conexionTemp);
                    cmd.Parameters.AddWithValue("nombre", oEmpleado.emple_nombre);
                    cmd.Parameters.AddWithValue("apellido", oEmpleado.emple_apellido);
                    cmd.Parameters.AddWithValue("id_supervisor", oEmpleado.emple_id_supervisor);
                    cmd.Parameters.AddWithValue("id_usuario", oEmpleado.emple_id_usuario);

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
        public bool EditarEmpleado(Empleado oEmpleado)
        {
            bool respuesta;
            try
            {
                var conexion = new Conexion();
                using (var conexionTemp = new SqlConnection(conexion.getCadenaSQL()))
                {
                    conexionTemp.Open();
                    SqlCommand cmd = new SqlCommand("EditarEmpleado", conexionTemp);

                    cmd.Parameters.AddWithValue("id_empleado", oEmpleado.id_empleado);
                    cmd.Parameters.AddWithValue("nombre", oEmpleado.emple_nombre);
                    cmd.Parameters.AddWithValue("apellido", oEmpleado.emple_apellido);
                    cmd.Parameters.AddWithValue("id_supervisor", oEmpleado.emple_id_supervisor);
                    cmd.Parameters.AddWithValue("id_usuario", oEmpleado.emple_id_usuario);

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
        public bool EliminarEmpleado(int id_empleado)
        {
            bool respuesta;
            try
            {
                var conexion = new Conexion();
                using (var conexionTemp = new SqlConnection(conexion.getCadenaSQL()))
                {
                    conexionTemp.Open();
                    SqlCommand cmd = new SqlCommand("EliminarEmpleado", conexionTemp);
                    cmd.Parameters.AddWithValue("id_empleado", id_empleado);
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
