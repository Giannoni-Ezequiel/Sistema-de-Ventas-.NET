using Conexion_a_BBDD.Models;
using System.Data.SqlClient;
using System.Data;

namespace Conexion_a_BBDD.Datos
{
    public class ProveedorDatos
    {
        public List<Proveedor> ListarProveedor()
        {
            var oLista = new List<Proveedor>();
            var conexion = new Conexion();
            using (var conexionTemp = new SqlConnection(conexion.getCadenaSQL()))
            {
                conexionTemp.Open();
                SqlCommand cmd = new SqlCommand("ListarProveedor", conexionTemp);
                cmd.CommandType = CommandType.StoredProcedure;
                using (var lector = cmd.ExecuteReader())
                {
                    while (lector.Read())
                    {
                        oLista.Add(new Proveedor()
                        {
                            id_proveedor = Convert.ToInt32(lector["id_proveedor"]),
                            provee_nombre = Convert.ToString(lector["provee_nombre"]),
                            provee_apellido = Convert.ToString(lector["provee_apellido"]),
                            provee_direccion = Convert.ToString(lector["provee_direccion"]),
                            provee_cuit = Convert.ToString(lector["provee_cuit"])
                        });
                    }
                }
            }
            return oLista;
        }
        public Proveedor ObtenerProveedor(int id_proveedor)
        {
            var oProveedor = new Proveedor();
            try
            {
                var conexion = new Conexion();
                using (var conexionTemp = new SqlConnection(conexion.getCadenaSQL()))
                {

                    conexionTemp.Open();
                    SqlCommand cmd = new SqlCommand("ObtenerProveedor", conexionTemp);

                    cmd.Parameters.AddWithValue("id_proveedor", id_proveedor);
                    cmd.CommandType = CommandType.StoredProcedure;

                    using (var lector = cmd.ExecuteReader())
                    {
                        while (lector.Read())
                        {
                            oProveedor.id_proveedor = Convert.ToInt32(lector["id_proveedor"]);
                            oProveedor.provee_nombre = Convert.ToString(lector["provee_nombre"]);
                            oProveedor.provee_apellido = Convert.ToString(lector["provee_apellido"]);
                            oProveedor.provee_direccion = Convert.ToString(lector["provee_direccion"]);
                            oProveedor.provee_cuit = Convert.ToString(lector["provee_cuit"]);
                        }
                    }
                }
            }
            catch (Exception e)
            {
                string error = e.Message;
                return oProveedor;
            }
            return oProveedor;
        }
        public bool GuardarProveedor(Proveedor oProveedor)
        {
            bool respuesta;
            try
            {
                var conexion = new Conexion();
                using (var conexionTemp = new SqlConnection(conexion.getCadenaSQL()))
                {
                    conexionTemp.Open();
                    SqlCommand cmd = new SqlCommand("GuardarProveedor", conexionTemp);

                    cmd.Parameters.AddWithValue("nombre", oProveedor.provee_nombre);
                    cmd.Parameters.AddWithValue("apellido", oProveedor.provee_apellido);
                    cmd.Parameters.AddWithValue("direccion", oProveedor.provee_direccion);
                    cmd.Parameters.AddWithValue("cuit", oProveedor.provee_cuit);
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
        public bool EditarProveedor(Proveedor oProveedor)
        {
            bool respuesta;
            try
            {
                var conexion = new Conexion();
                using (var conexionTemp = new SqlConnection(conexion.getCadenaSQL()))
                {
                    conexionTemp.Open();
                    SqlCommand cmd = new SqlCommand("EditarProveedor", conexionTemp);
                    cmd.Parameters.AddWithValue("id_proveedor", oProveedor.id_proveedor);
                    cmd.Parameters.AddWithValue("nombre", oProveedor.provee_nombre);
                    cmd.Parameters.AddWithValue("apellido", oProveedor.provee_apellido);
                    cmd.Parameters.AddWithValue("direccion", oProveedor.provee_direccion);
                    cmd.Parameters.AddWithValue("cuit", oProveedor.provee_cuit);
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
        public bool EliminarProveedor(int id_proveedor)
        {
            bool respuesta;
            try
            {
                var conexion = new Conexion();
                using (var conexionTemp = new SqlConnection(conexion.getCadenaSQL()))
                {
                    conexionTemp.Open();
                    SqlCommand cmd = new SqlCommand("EliminarProveedor", conexionTemp);
                    cmd.Parameters.AddWithValue("id_proveedor", id_proveedor);
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
