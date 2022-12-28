using Conexion_a_BBDD.Models;
using System.Data.SqlClient;
using System.Data;

namespace Conexion_a_BBDD.Datos
{
    public class categorias_proveedorDatos
    {
        public List<categorias_proveedor> Listarcategorias_proveedor()
        {
            var oLista = new List<categorias_proveedor>();
            var conexion = new Conexion();
            using (var conexionTemp = new SqlConnection(conexion.getCadenaSQL()))
            {
                conexionTemp.Open();
                SqlCommand cmd = new SqlCommand("ListarCategorias_Proveedor", conexionTemp);
                cmd.CommandType = CommandType.StoredProcedure;
                using (var lector = cmd.ExecuteReader())
                {
                    while (lector.Read())
                    {
                        oLista.Add(new categorias_proveedor()
                        {
                            id_proveedor = Convert.ToInt32(lector["id_proveedor"]),
                            id_categoria = Convert.ToInt32(lector["id_categoria"]),
                            proveedorCategoria = new Proveedor()
                            {
                                id_proveedor = Convert.ToInt32(lector["id_proveedor"]),
                                prove_nombre = Convert.ToString(lector["prove_nombre"]),
                            },
                            categoriaProveedor = new Categoria()
                            {
                                id_categoria = Convert.ToInt32(lector["id_categoria"]),
                                categ_detalle = Convert.ToString(lector["categ_detalle"])
                            }
                        });
                    }
                }
            }
            return oLista;
        }
        public categorias_proveedor Obtenercategorias_proveedor(int id)
        {
            var ocategorias_proveedor = new categorias_proveedor();
            bool respuesta;
            try
            {
                var conexion = new Conexion();
                using (var conexionTemp = new SqlConnection(conexion.getCadenaSQL()))
                {
                    conexionTemp.Open();
                    using (var cmd = new SqlCommand("ObtenerCategorias_Proveedor", conexionTemp))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("id_proveedor", id);
                        cmd.Parameters.AddWithValue("id_categoria", id);
                        using (var lector = cmd.ExecuteReader())
                        {
                            while (lector.Read())
                            {
                                ocategorias_proveedor.id_proveedor = Convert.ToInt32(lector["id_proveedor"]);
                                ocategorias_proveedor.id_categoria = Convert.ToInt32(lector["id_categoria"]);
                            }
                        }
                    }
                }
            }
            catch (Exception e)
            {
                string error = e.Message;
                respuesta = false;
            }
            return ocategorias_proveedor;
        }
        public bool Guardarcategorias_proveedor(categorias_proveedor ocategorias_proveedor)
        {
            bool respuesta;
            try
            {
                var conexion = new Conexion();
                using (var conexionTemp = new SqlConnection(conexion.getCadenaSQL()))
                {
                    conexionTemp.Open();
                    SqlCommand cmd = new SqlCommand("GuardarCategorias_Proveedor", conexionTemp);
                    cmd.Parameters.AddWithValue("id_proveedor", ocategorias_proveedor.id_proveedor);
                    cmd.Parameters.AddWithValue("id_categoria", ocategorias_proveedor.id_categoria);
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
        public bool Editarcategorias_proveedor(categorias_proveedor ocategorias_proveedor)
        {
            bool respuesta;
            try
            {
                var conexion = new Conexion();
                using (var conexionTemp = new SqlConnection(conexion.getCadenaSQL()))
                {
                    conexionTemp.Open();
                    SqlCommand cmd = new SqlCommand("EditarCategorias_Proveedor", conexionTemp);
                    cmd.Parameters.AddWithValue("id_proveedor", ocategorias_proveedor.id_proveedor);
                    cmd.Parameters.AddWithValue("id_categoria", ocategorias_proveedor.id_categoria);
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
        public bool Eliminarcategorias_proveedor(int id_proveedor)
        {
            bool respuesta;
            try
            {
                var conexion = new Conexion();
                using (var conexionTemp = new SqlConnection(conexion.getCadenaSQL()))
                {
                    conexionTemp.Open();
                    SqlCommand cmd = new SqlCommand("EliminarCategorias_Proveedor", conexionTemp);
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
