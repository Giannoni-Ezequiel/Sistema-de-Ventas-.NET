using Conexion_a_BBDD.Models;
using System.Data.SqlClient;
using System.Data;

namespace Conexion_a_BBDD.Datos
{
    public class OrdenDatos
    {
        public List<Orden> ListarOrden()
        {
            //Esta variable recibe la informacion
            var objetoLista = new List<Orden>();
            //Instancia de la conexion
            var conexion = new Conexion();
            //Definimos el tiempo de duracion de la conexion
            using (var conexionTemp = new SqlConnection(conexion.getCadenaSQL()))
            {
                conexionTemp.Open();
                //Instacio un objeto para las query y relaciono con el storedprocedure
                SqlCommand cmd = new SqlCommand("ListarOrden", conexionTemp);
                cmd.CommandType = CommandType.StoredProcedure;
                using (var lector = cmd.ExecuteReader())
                {
                    while (lector.Read())
                    {
                        //Añadiendo por cada vuelta un registro
                        objetoLista.Add(new Orden()
                        {
                            id_orden = Convert.ToInt32(lector["id_orden"]),
                            ord_cliente = Convert.ToInt32(lector["ord_cliente"]),
                            ord_vendedor = Convert.ToInt32(lector["ord_vendedor"]),
                            ord_fecha_de_generacion = Convert.ToDateTime(lector["ord_fecha_de_generacion"]),
                            ord_id_cliente = Convert.ToInt32(lector["ord_id_cliente"]),
                            ord_id_empleado = Convert.ToInt32(lector["ord_id_empleado"])
                        });
                    }//Aca ya no existe la variable lector, se destruyo
                }//Aca ya no existe la variable conexionTemp, se destruyo
            }
            return objetoLista;
        }
        public Orden ObtenerOrden(int id_orden)
        {
            var objetoOrden = new Orden();
            try
            {
                var conexion = new Conexion();

                using (var conexionTemp = new SqlConnection(conexion.getCadenaSQL()))
                {
                    conexionTemp.Open();
                    SqlCommand cmd = new SqlCommand("ObtenerOrden", conexionTemp);
                    cmd.Parameters.AddWithValue("id_orden", id_orden); //id es de nuestra tabla, id_contacto es el generado ASº
                    cmd.CommandType = CommandType.StoredProcedure;

                    using (var lector = cmd.ExecuteReader())
                    {
                        while (lector.Read())
                        {
                            objetoOrden.id_orden = Convert.ToInt32(lector["id_orden"]);
                            objetoOrden.ord_cliente = Convert.ToInt32(lector["ord_cliente"]);
                            objetoOrden.ord_vendedor = Convert.ToInt32(lector["ord_vendedor"]);
                            objetoOrden.ord_fecha_de_generacion = Convert.ToDateTime(lector["ord_fecha_de_generacion"]);
                            objetoOrden.ord_id_cliente = Convert.ToInt32(lector["ord_id_cliente"]);
                            objetoOrden.ord_id_empleado = Convert.ToInt32(lector["ord_id_empleado"]);
                        }
                    }
                }
            }
            catch (Exception e)
            {
                string error = e.Message;
                return objetoOrden;
            }
            return objetoOrden;
        }
        public bool GuardarOrden(Orden objetoOrden)
        {
            bool respuesta;
            try
            {
                var conexion = new Conexion();
                using (var conexionTemp = new SqlConnection(conexion.getCadenaSQL()))
                {
                    conexionTemp.Open();
                    SqlCommand cmd = new SqlCommand("GuardarOrden", conexionTemp);
                    cmd.Parameters.AddWithValue("cliente", objetoOrden.ord_cliente);
                    cmd.Parameters.AddWithValue("vendedor", objetoOrden.ord_vendedor);
                    cmd.Parameters.AddWithValue("fecha_de_generacion", objetoOrden.ord_fecha_de_generacion);
                    cmd.Parameters.AddWithValue("id_cliente", objetoOrden.ord_id_cliente);
                    cmd.Parameters.AddWithValue("id_empleado", objetoOrden.ord_id_empleado);
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
        public bool EditarOrden(Orden objetoOrden)
        {
            bool respuesta;
            try
            {
                var conexion = new Conexion();
                using (var conexionTemp = new SqlConnection(conexion.getCadenaSQL()))
                {
                    conexionTemp.Open();
                    SqlCommand cmd = new SqlCommand("EditarOrden", conexionTemp);
                    cmd.Parameters.AddWithValue("id_orden", objetoOrden.id_orden);
                    cmd.Parameters.AddWithValue("cliente", objetoOrden.ord_cliente);
                    cmd.Parameters.AddWithValue("vendedor", objetoOrden.ord_vendedor);
                    cmd.Parameters.AddWithValue("fecha_de_generacion", objetoOrden.ord_fecha_de_generacion);
                    cmd.Parameters.AddWithValue("id_cliente", objetoOrden.ord_id_cliente);
                    cmd.Parameters.AddWithValue("id_empleado", objetoOrden.ord_id_empleado);

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
        public bool EliminarOrden(int id_orden)
        {
            bool respuesta;
            try
            {
                var conexion = new Conexion();
                using (var conexionTemp = new SqlConnection(conexion.getCadenaSQL()))
                {
                    conexionTemp.Open();
                    SqlCommand cmd = new SqlCommand("EliminarOrden", conexionTemp);
                    cmd.Parameters.AddWithValue("id_orden", id_orden);
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
