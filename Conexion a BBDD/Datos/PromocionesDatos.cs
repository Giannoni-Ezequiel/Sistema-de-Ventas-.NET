using Conexion_a_BBDD.Models;
using System.Data.SqlClient;
using System.Data;

namespace Conexion_a_BBDD.Datos
{
    public class PromocionesDatos
    {
        public List<Promociones> ListarPromociones()
        {
            var oLista = new List<Promociones>();
            var conexion = new Conexion();
            using (var conexionTemp = new SqlConnection(conexion.getCadenaSQL()))
            {
                conexionTemp.Open();
                SqlCommand cmd = new SqlCommand("ListarPromociones", conexionTemp);
                cmd.CommandType = CommandType.StoredProcedure;
                using (var lector = cmd.ExecuteReader())
                {
                    while (lector.Read())
                    {
                        oLista.Add(new Promociones()
                        {
                            id_promo = Convert.ToInt32(lector["id_promo"]),
                            promo_nombre = Convert.ToString(lector["promo_nombre"]),
                            descuento = Convert.ToDecimal(lector["descuento"])
                        });
                    }
                }
            }
            return oLista;
        }
        public Promociones ObtenerPromociones(int id_promo)
        {
            var oPromociones = new Promociones();
            try
            {
                var conexion = new Conexion();
                using (var conexionTemp = new SqlConnection(conexion.getCadenaSQL()))
                {
                    conexionTemp.Open();
                    SqlCommand cmd = new SqlCommand("ObtenerPromociones", conexionTemp);
                    cmd.Parameters.AddWithValue("id_promo", id_promo);
                    cmd.CommandType = CommandType.StoredProcedure;
                    using (var lector = cmd.ExecuteReader())
                    {
                        while (lector.Read())
                        {
                            oPromociones.id_promo = Convert.ToInt32(lector["id_promo"]);
                            oPromociones.promo_nombre = Convert.ToString(lector["promo_nombre"]);
                            oPromociones.descuento = Convert.ToDecimal(lector["descuento"]);
                        }
                    }
                }
            }
            catch (Exception e)
            {
                string error = e.Message;
                return oPromociones;
            }
            return oPromociones;
        }
        public bool GuardarPromociones(Promociones oPromociones)
        {
            bool respuesta;
            try
            {
                var conexion = new Conexion();
                using (var conexionTemp = new SqlConnection(conexion.getCadenaSQL()))
                {
                    conexionTemp.Open();
                    SqlCommand cmd = new SqlCommand("GuardarPromociones", conexionTemp);
                    cmd.Parameters.AddWithValue("nombre", oPromociones.promo_nombre);
                    cmd.Parameters.AddWithValue("descuento", oPromociones.descuento);
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
        public bool EditarPromociones(Promociones oPromociones)
        {
            bool respuesta;
            try
            {
                var conexion = new Conexion();
                using (var conexionTemp = new SqlConnection(conexion.getCadenaSQL()))
                {
                    conexionTemp.Open();
                    SqlCommand cmd = new SqlCommand("EditarPromociones", conexionTemp);
                    cmd.Parameters.AddWithValue("id_promo", oPromociones.id_promo);
                    cmd.Parameters.AddWithValue("nombre", oPromociones.promo_nombre);
                    cmd.Parameters.AddWithValue("descuento", oPromociones.descuento);
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
        public bool EliminarPromociones(int id_promo)
        {
            bool respuesta;
            try
            {
                var conexion = new Conexion();
                using (var conexionTemp = new SqlConnection(conexion.getCadenaSQL()))
                {
                    conexionTemp.Open();
                    SqlCommand cmd = new SqlCommand("EliminarPromociones", conexionTemp);
                    cmd.Parameters.AddWithValue("id_promo", id_promo);
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
