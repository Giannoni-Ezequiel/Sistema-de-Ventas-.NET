using Conexion_a_BBDD.Models;
using System.Data.SqlClient;
using System.Data;

namespace Conexion_a_BBDD.Datos
{
    public class Promocion_productoDatos
    {
        public List<Promocion_producto> ListarPromocion_producto()
        {
            var oLista = new List<Promocion_producto>();
            var conexion = new Conexion();
            using (var conexionTemp = new SqlConnection(conexion.getCadenaSQL()))
            {
                conexionTemp.Open();
                SqlCommand cmd = new SqlCommand("ListarPromocion_producto", conexionTemp);
                cmd.CommandType = CommandType.StoredProcedure;
                using (var lector = cmd.ExecuteReader())
                {
                    while (lector.Read())
                    {
                        oLista.Add(new Promocion_producto()
                        {
                            id_promo = Convert.ToInt32(lector["id_promo"]),
                            id_producto = Convert.ToInt32(lector["id_producto"]),
                            promo_numero = Convert.ToInt32(lector["promo_numero"]),
                            promo_fecha_inicio = Convert.ToDateTime(lector["promo_fecha_inicio"]),
                            promo_fecha_fin = Convert.ToDateTime(lector["promo_fecha_fin"])
                        });
                    }
                }
            }
            return oLista;
        }
        public Promocion_producto ObtenerPromocion_producto(int promo_numero)
        {
            var oPromocion_producto = new Promocion_producto();
            try
            {
                var conexion = new Conexion();
                using (var conexionTemp = new SqlConnection(conexion.getCadenaSQL()))
                {
                    conexionTemp.Open();
                    SqlCommand cmd = new SqlCommand("ObtenerPromocion_producto", conexionTemp);
                    cmd.Parameters.AddWithValue("promo_numero", promo_numero);
                    cmd.CommandType = CommandType.StoredProcedure;
                    using (var lector = cmd.ExecuteReader())
                    {
                        while (lector.Read())
                        {
                            oPromocion_producto.id_promo = Convert.ToInt32(lector["id_promo"]);
                            oPromocion_producto.id_producto = Convert.ToInt32(lector["id_producto"]);
                            oPromocion_producto.promo_numero = Convert.ToInt32(lector["promo_numero"]);
                            oPromocion_producto.promo_fecha_inicio = Convert.ToDateTime(lector["promo_fecha_inicio"]);
                            oPromocion_producto.promo_fecha_fin = Convert.ToDateTime(lector["promo_fecha_fin"]);
                        }
                    }
                }
            }
            catch (Exception e)
            {
                string error = e.Message;
                return oPromocion_producto;
            }
            return oPromocion_producto;
        }
        public bool GuardarPromocion_producto(Promocion_producto oPromocion_producto)
        {
            bool respuesta;
            try
            {
                var conexion = new Conexion();
                using (var conexionTemp = new SqlConnection(conexion.getCadenaSQL()))
                {
                    conexionTemp.Open();
                    SqlCommand cmd = new SqlCommand("GuardarPromocion_producto", conexionTemp);
                    cmd.Parameters.AddWithValue("promo_fecha_inicio", oPromocion_producto.promo_fecha_inicio);
                    cmd.Parameters.AddWithValue("promo_fecha_fin", oPromocion_producto.promo_fecha_fin);
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
        public bool EditarPromocion_producto(Promocion_producto oPromocion_producto)
        {
            bool respuesta;
            try
            {
                var conexion = new Conexion();
                using (var conexionTemp = new SqlConnection(conexion.getCadenaSQL()))
                {
                    conexionTemp.Open();
                    SqlCommand cmd = new SqlCommand("EditarPromocion_producto", conexionTemp);
                    cmd.Parameters.AddWithValue("id_promo", oPromocion_producto.id_promo);
                    cmd.Parameters.AddWithValue("id_producto", oPromocion_producto.id_producto);
                    cmd.Parameters.AddWithValue("promo_numero", oPromocion_producto.promo_numero);
                    cmd.Parameters.AddWithValue("promo_fecha_inicio", oPromocion_producto.promo_fecha_inicio);
                    cmd.Parameters.AddWithValue("promo_fecha_fin", oPromocion_producto.promo_fecha_fin);
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
        public bool EliminarPromocion_producto(int promo_numero)
        {
            bool respuesta;
            try
            {
                var conexion = new Conexion();
                using (var conexionTemp = new SqlConnection(conexion.getCadenaSQL()))
                {
                    conexionTemp.Open();
                    SqlCommand cmd = new SqlCommand("EliminarPromocion_producto", conexionTemp);
                    cmd.Parameters.AddWithValue("promo_numero", promo_numero);
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
