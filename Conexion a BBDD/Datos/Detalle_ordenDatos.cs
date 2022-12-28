using Conexion_a_BBDD.Models;
using System.Data.SqlClient;
using System.Data;

namespace Conexion_a_BBDD.Datos
{
    public class Detalle_ordenDatos
    {
        public List<Detalle_orden> ListarDetalle_orden()
        {
            var oLista = new List<Detalle_orden>();
            var conexion = new Conexion();
            using (var conexionTemp = new SqlConnection(conexion.getCadenaSQL()))
            {
                conexionTemp.Open();
                SqlCommand cmd = new SqlCommand("ListarDetalle_orden", conexionTemp);
                cmd.CommandType = CommandType.StoredProcedure;
                using (var lector = cmd.ExecuteReader())
                {
                    while (lector.Read())
                    {
                        oLista.Add(new Detalle_orden()
                        {
                            id_orden = Convert.ToInt32(lector["id_orden"]),
                            id_detalle_orden = Convert.ToInt32(lector["id_detalle_orden"]),
                            det_ord_precio = Convert.ToDecimal(lector["det_ord_precio"]),
                            det_ord_cantidad = Convert.ToDecimal(lector["det_ord_cantidad"]),
                            id_producto = Convert.ToInt32(lector["id_producto"])
                        });
                    }
                }
            }
            return oLista;
        }
        public Detalle_orden ObtenerDetalle_orden(int id_detalle_orden)
        {
            var oDetalle_orden = new Detalle_orden();
            try
            {
                var conexion = new Conexion();
                using (var conexionTemp = new SqlConnection(conexion.getCadenaSQL()))
                {
                    conexionTemp.Open();
                    SqlCommand cmd = new SqlCommand("ObtenerDetalle_orden", conexionTemp);
                    cmd.Parameters.AddWithValue("id_detalle_orden", id_detalle_orden);
                    cmd.CommandType = CommandType.StoredProcedure;
                    using (var lector = cmd.ExecuteReader())
                    {
                        while (lector.Read())
                        {
                            oDetalle_orden.id_orden = Convert.ToInt32(lector["id_orden"]);
                            oDetalle_orden.id_detalle_orden = Convert.ToInt32(lector["id_detalle_orden"]);
                            oDetalle_orden.det_ord_precio = Convert.ToDecimal(lector["det_ord_precio"]);
                            oDetalle_orden.det_ord_cantidad = Convert.ToDecimal(lector["det_ord_cantidad"]);
                            oDetalle_orden.id_producto = Convert.ToInt32(lector["id_producto"]);

                        }
                    }
                }
            }
            catch (Exception e)
            {
                string error = e.Message;
                return oDetalle_orden;
            }
            return oDetalle_orden;
        }
        public bool GuardarDetalle_orden(Detalle_orden oDetalle_orden)
        {
            bool respuesta;
            try
            {
                var conexion = new Conexion();
                using (var conexionTemp = new SqlConnection(conexion.getCadenaSQL()))
                {
                    conexionTemp.Open();
                    SqlCommand cmd = new SqlCommand("GuardarDetalle_orden", conexionTemp);
                    cmd.Parameters.AddWithValue("det_ord_precio", oDetalle_orden.det_ord_precio);
                    cmd.Parameters.AddWithValue("det_ord_cantidad", oDetalle_orden.det_ord_cantidad);
                    cmd.Parameters.AddWithValue("id_producto", oDetalle_orden.id_producto);
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
        public bool EditarDetalle_orden(Detalle_orden oDetalle_orden)
        {
            bool respuesta;
            try
            {
                var conexion = new Conexion();
                using (var conexionTemp = new SqlConnection(conexion.getCadenaSQL()))
                {
                    conexionTemp.Open();
                    SqlCommand cmd = new SqlCommand("EditarDetalle_orden", conexionTemp);
                    cmd.Parameters.AddWithValue("id_orden", oDetalle_orden.id_orden);
                    cmd.Parameters.AddWithValue("id_detalle_orden", oDetalle_orden.id_detalle_orden);
                    cmd.Parameters.AddWithValue("det_ord_precio", oDetalle_orden.det_ord_precio);
                    cmd.Parameters.AddWithValue("det_ord_cantidad", oDetalle_orden.det_ord_cantidad);
                    cmd.Parameters.AddWithValue("id_producto", oDetalle_orden.id_producto);
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
        public bool EliminarDetalle_orden(int id_detalle_orden)
        {
            bool respuesta;
            try
            {
                var conexion = new Conexion();
                using (var conexionTemp = new SqlConnection(conexion.getCadenaSQL()))
                {
                    conexionTemp.Open();
                    SqlCommand cmd = new SqlCommand("EliminarDetalle_orden", conexionTemp);
                    cmd.Parameters.AddWithValue("id_detalle_orden", id_detalle_orden);
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
