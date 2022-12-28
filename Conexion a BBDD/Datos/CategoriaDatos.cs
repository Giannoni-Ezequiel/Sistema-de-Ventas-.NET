using System.Data.SqlClient;
using System.Data;
using Conexion_a_BBDD.Models;

namespace Conexion_a_BBDD.Datos
{
    public class CategoriaDatos
    {
        public List<Categoria> ListarCategoria()
        {
            var oLista = new List<Categoria>();
            var conexion = new Conexion();
            using (var conexionTemp = new SqlConnection(conexion.getCadenaSQL()))
            {
                conexionTemp.Open();
                SqlCommand cmd = new SqlCommand("ListarCategoria", conexionTemp);
                cmd.CommandType = CommandType.StoredProcedure;
                using (var lector = cmd.ExecuteReader())
                {
                    while (lector.Read())
                    {
                        oLista.Add(new Categoria()
                        {
                            id_categoria = Convert.ToInt32(lector["id_categoria"]),
                            categ_detalle = Convert.ToString(lector["categ_detalle"])
                        });
                    }
                }
            }
            return oLista;
        }
        public Categoria ObtenerCategoria(int id_categoria)
        {
            var oCategoria = new Categoria();
            try
            {
                var conexion = new Conexion();
                using (var conexionTemp = new SqlConnection(conexion.getCadenaSQL()))
                {
                    conexionTemp.Open();
                    SqlCommand cmd = new SqlCommand("ObtenerCategoria", conexionTemp);
                    cmd.Parameters.AddWithValue("id_categoria", id_categoria);
                    cmd.CommandType = CommandType.StoredProcedure;
                    using (var lector = cmd.ExecuteReader())
                    {
                        while (lector.Read())
                        {
                            oCategoria.id_categoria = Convert.ToInt32(lector["id_categoria"]);
                            oCategoria.categ_detalle = Convert.ToString(lector["categ_detalle"]);
                        }
                    }
                }
            }
            catch (Exception e)
            {
                string error = e.Message;
                return oCategoria;
            }
            return oCategoria;
        }
        public bool GuardarCategoria(Categoria oCategoria)
        {
            bool respuesta;
            try
            {
                var conexion = new Conexion();
                using (var conexionTemp = new SqlConnection(conexion.getCadenaSQL()))
                {
                    conexionTemp.Open();
                    SqlCommand cmd = new SqlCommand("GuardarCategoria", conexionTemp);
                    cmd.Parameters.AddWithValue("categ_detalle", oCategoria.categ_detalle);
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
        public bool EditarCategoria(Categoria oCategoria)
        {
            bool respuesta;
            try
            {
                var conexion = new Conexion();
                using (var conexionTemp = new SqlConnection(conexion.getCadenaSQL()))
                {
                    conexionTemp.Open();
                    SqlCommand cmd = new SqlCommand("EditarCategoria", conexionTemp);
                    cmd.Parameters.AddWithValue("id_categoria", oCategoria.id_categoria);
                    cmd.Parameters.AddWithValue("categ_detalle", oCategoria.categ_detalle);
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
        public bool EliminarCategoria(int id_categoria)
        {
            bool respuesta;
            try
            {
                var conexion = new Conexion();
                using (var conexionTemp = new SqlConnection(conexion.getCadenaSQL()))
                {
                    conexionTemp.Open();
                    SqlCommand cmd = new SqlCommand("ELiminarCategoria", conexionTemp);
                    cmd.Parameters.AddWithValue("id_categoria", id_categoria);
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
