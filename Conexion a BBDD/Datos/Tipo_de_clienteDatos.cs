using Conexion_a_BBDD.Models;
using System.Data.SqlClient;
using System.Data;

namespace Conexion_a_BBDD.Datos
{
    public class Tipo_de_clienteDatos
    {
        public List<Tipo_de_cliente> ListarTipo_De_Cliente()
        {
            var oLista = new List<Tipo_de_cliente>();
            var conexion = new Conexion();
            using (var conexionTemp = new SqlConnection(conexion.getCadenaSQL()))
            {
                conexionTemp.Open();
                SqlCommand cmd = new SqlCommand("ListarTipo_De_Cliente", conexionTemp);
                cmd.CommandType = CommandType.StoredProcedure;
                using (var lector = cmd.ExecuteReader())
                {
                    while (lector.Read())
                    {
                        oLista.Add(new Tipo_de_cliente()
                        {
                            id_tipo_cliente = Convert.ToInt32(lector["id_tipo_cliente"]),
                            clie_tipo_descripcion = Convert.ToString(lector["clie_tipo_descripcion"])
                        });
                    }
                }
            }
            return oLista;
        }
        public Tipo_de_cliente ObtenerTipo_De_Cliente(int id_tipo_cliente)
        {
            var oTipo_de_cliente = new Tipo_de_cliente();
            try
            {
                var conexion = new Conexion();
                using (var conexionTemp = new SqlConnection(conexion.getCadenaSQL()))
                {
                    conexionTemp.Open();
                    SqlCommand cmd = new SqlCommand("ObtenerTipo_De_Cliente", conexionTemp);
                    cmd.Parameters.AddWithValue("id_tipo_cliente", id_tipo_cliente);
                    cmd.CommandType = CommandType.StoredProcedure;
                    using (var lector = cmd.ExecuteReader())
                    {
                        while (lector.Read())
                        {
                            oTipo_de_cliente.id_tipo_cliente = Convert.ToInt32(lector["id_tipo_cliente"]);
                            oTipo_de_cliente.clie_tipo_descripcion = Convert.ToString(lector["clie_tipo_descripcion"]);
                        }
                    }
                }
            }
            catch (Exception e)
            {
                string error = e.Message;
                return oTipo_de_cliente;
            }
            return oTipo_de_cliente;
        }
        public bool GuardarTipo_De_Cliente(Tipo_de_cliente oTipo_de_cliente)
        {
            bool respuesta;
            try
            {
                var conexion = new Conexion();
                using (var conexionTemp = new SqlConnection(conexion.getCadenaSQL()))
                {
                    conexionTemp.Open();
                    SqlCommand cmd = new SqlCommand("GuardarTipo_De_Cliente", conexionTemp);
                    cmd.Parameters.AddWithValue("clie_tipo_descripcion", oTipo_de_cliente.clie_tipo_descripcion);
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
        public bool EditarTipo_De_Cliente(Tipo_de_cliente oTipo_de_cliente)
        {
            bool respuesta;
            try
            {
                var conexion = new Conexion();
                using (var conexionTemp = new SqlConnection(conexion.getCadenaSQL()))
                {
                    conexionTemp.Open();
                    SqlCommand cmd = new SqlCommand("EditarTipo_De_Cliente", conexionTemp);
                    cmd.Parameters.AddWithValue("id_tipo_cliente", oTipo_de_cliente.id_tipo_cliente);
                    cmd.Parameters.AddWithValue("clie_tipo_descripcion", oTipo_de_cliente.clie_tipo_descripcion);
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
        public bool EliminarTipo_De_Cliente(int id_tipo_cliente)
        {
            bool respuesta;
            try
            {
                var conexion = new Conexion();
                using (var conexionTemp = new SqlConnection(conexion.getCadenaSQL()))
                {
                    conexionTemp.Open();
                    SqlCommand cmd = new SqlCommand("EliminarTipo_De_Cliente", conexionTemp);
                    cmd.Parameters.AddWithValue("id_tipo_cliente", id_tipo_cliente);
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
