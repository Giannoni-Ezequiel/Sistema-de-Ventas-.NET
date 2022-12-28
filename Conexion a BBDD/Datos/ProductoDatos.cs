using Conexion_a_BBDD.Models;
using System.Data.SqlClient;
using System.Data;

namespace Conexion_a_BBDD.Datos
{
    public class ProductoDatos
    {
        public List<Producto> ListarProductos()
        {
            //Esta variable recibe la informacion
            var oLista = new List<Producto>();
            //Instancia de la conexion
            var conexion = new Conexion();
            //Usando using definimos el tiempo de vida de la conexion
            using (var conexionTemp = new SqlConnection(conexion.getCadenaSQL()))
            {
                //Aca abro la conexion
                conexionTemp.Open();
                //Aca instancio un objeto para las query y la relaciono con el sp
                SqlCommand cmd = new SqlCommand("ListarProductos", conexionTemp);
                cmd.CommandType = CommandType.StoredProcedure;
                //Comienzo la lectura de datos
                using (var lector = cmd.ExecuteReader())
                {
                    //mientras haya registros van a almacenarse en el oLista
                    while (lector.Read())
                    {
                        //Añadiendo por cada vuelta un registro
                        oLista.Add(new Producto()
                        {
                            prod_nombre = Convert.ToString(lector["prod_nombre"]),
                            prod_precio = Convert.ToDecimal(lector["prod_precio"]),
                            prod_stock = Convert.ToDecimal(lector["prod_stock"]),
                            prod_detalle = Convert.ToString(lector["prod_detalle"]),
                            prod_img = Convert.ToString(lector["prod_img"]),
                            prod_proveedor = Convert.ToInt32(lector["prod_proveedor"]),
                            proveedorAsociado = new Proveedor()
                            {
                                id_proveedor = Convert.ToInt32(lector["id_proveedor"]),
                                prove_nombre = Convert.ToString(lector["prove_nombre"]),
                                prove_apellido = Convert.ToString(lector["prove_apellido"]),
                                prove_direccion = Convert.ToString(lector["prove_direccion"]),
                                prove_cuit = Convert.ToString(lector["prove_cuit"])
                            }
                        });
                    }//Aca ya no existe la variable lector, se destruyo
                }//Aca ya no existe la variable conexionTemp, se destruyo
            }
            return oLista;
        }
        /*public List<Producto> MostrarProductos()
        {
            var oLista = new List<Producto>();
            //Instancia de la conexion

            var conexion = new Conexion();
            //Usando using definimos el tiempo de vida de la conexion
            using (var conexionTemp = new SqlConnection(conexion.getCadenaSQL()))
            {
                //Aca abro la conexion
                conexionTemp.Open();
                SqlCommand cmd = new SqlCommand("MostrarProductos", conexionTemp);
                cmd.CommandType = CommandType.StoredProcedure;
                //Comienzo la lectura de datos
                using (var lector = cmd.ExecuteReader())
                {
                    //mientras haya registros van a almacenarse en el oLista
                    while (lector.Read())
                    {
                        //Añadiendo por cada vuelta un registro
                        oLista.Add(new Producto()
                        {
                            prod_nombre = Convert.ToString(lector["prod_nombre"]),
                            prod_precio = Convert.ToDecimal(lector["prod_precio"]),
                            prod_stock = Convert.ToDecimal(lector["prod_stock"]),
                            prod_detalle = Convert.ToString(lector["prod_detalle"]),
                            prod_img = Convert.ToString(lector["prod_img"]),
                        });
                    }
                }
            }
            return oLista;
        }*/
        public Producto ObtenerProductos(int id_producto)
        {
            var oProducto = new Producto();
            try
            {
                var conexion = new Conexion();
                using (var conexionTemp = new SqlConnection(conexion.getCadenaSQL()))
                {
                    conexionTemp.Open();
                    SqlCommand cmd = new SqlCommand("ObtenerProductos", conexionTemp);
                    cmd.Parameters.AddWithValue("id_producto", id_producto);
                    cmd.CommandType = CommandType.StoredProcedure;
                    using (var lector = cmd.ExecuteReader())
                    {
                        while (lector.Read())
                        {
                            oProducto.id_producto = Convert.ToInt32(lector["id_producto"]);
                            oProducto.prod_nombre = Convert.ToString(lector["prod_nombre"]);
                            oProducto.prod_precio = Convert.ToDecimal(lector["prod_precio"]);
                            oProducto.prod_stock = Convert.ToDecimal(lector["prod_stock"]);
                            oProducto.prod_detalle = Convert.ToString(lector["prod_detalle"]);
                            oProducto.prod_img = Convert.ToString(lector["prod_img"]);
                            oProducto.prod_proveedor = Convert.ToInt32(lector["prod_proveedor"]);
                        }
                    }
                }
            }
            catch (Exception e)
            {
                string error = e.Message;
                return oProducto;
            }
            return oProducto;
        }
        public bool GuardarProductos(Producto oProducto)
        {
            bool respuesta;
            try
            {
                var conexion = new Conexion();
                using (var conexionTemp = new SqlConnection(conexion.getCadenaSQL()))
                {
                    conexionTemp.Open();
                    SqlCommand cmd = new SqlCommand("GuardarProductos", conexionTemp);
                    cmd.Parameters.AddWithValue("prod_nombre", oProducto.prod_nombre);
                    cmd.Parameters.AddWithValue("prod_precio", oProducto.prod_precio);
                    cmd.Parameters.AddWithValue("prod_stock", oProducto.prod_stock);
                    cmd.Parameters.AddWithValue("prod_detalle", oProducto.prod_detalle);
                    cmd.Parameters.AddWithValue("prod_img", oProducto.prod_img);
                    cmd.Parameters.AddWithValue("prod_proveedor", oProducto.prod_proveedor);
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
        public bool EditarProductos(Producto oProducto)
        {
            bool respuesta;
            try
            {
                var conexion = new Conexion();
                using (var conexionTemp = new SqlConnection(conexion.getCadenaSQL()))
                {
                    conexionTemp.Open();
                    SqlCommand cmd = new SqlCommand("EditarProductos", conexionTemp);
                    cmd.Parameters.AddWithValue("id_producto", oProducto.id_producto);
                    cmd.Parameters.AddWithValue("prod_nombre", oProducto.prod_nombre);
                    cmd.Parameters.AddWithValue("prod_precio", oProducto.prod_precio);
                    cmd.Parameters.AddWithValue("prod_stock", oProducto.prod_stock);
                    cmd.Parameters.AddWithValue("prod_detalle", oProducto.prod_detalle);
                    cmd.Parameters.AddWithValue("prod_img", oProducto.prod_img);
                    cmd.Parameters.AddWithValue("prod_proveedor", oProducto.prod_proveedor);
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
        public bool EliminarProductos(int id_producto)
        {
            bool respuesta;
            try
            {
                var conexion = new Conexion();
                using (var conexionTemp = new SqlConnection(conexion.getCadenaSQL()))
                {
                    conexionTemp.Open();
                    SqlCommand cmd = new SqlCommand("EliminarProductos", conexionTemp);
                    cmd.Parameters.AddWithValue("id_producto", id_producto);
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
