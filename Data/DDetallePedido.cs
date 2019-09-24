using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Entity;

namespace Data
{
    public class DDetallePedido
    {
        public List<DetallePedido> GetDetallePedidos (DetallePedido detallePedido)
        {
            SqlParameter[] parameters = null;
            string commandText = string.Empty;
            List<DetallePedido> detallepedidos = null;

            try
            {
                commandText = "USP_Detalle";
                parameters = new SqlParameter[1];
                parameters[0] = new SqlParameter("@IdPedido", SqlDbType.Int);
                parameters[0].Value = detallePedido.Pedido.IdPedido;
                detallepedidos = new List<DetallePedido>();

                using (SqlDataReader reader = SqlHelper.ExecuteReader(SqlHelper.Connection, "usp_detalle", CommandType.StoredProcedure, parameters))
                {
                    while (reader.Read())
                    {
                        detallepedidos.Add(new DetallePedido
                        {
                            Pedido = new Pedido { IdPedido = reader["IdPedido"] != null ? Convert.ToInt32(reader["IdPedido"]) : 0 },
                            IdProducto = reader["idproducto"] != null ? Convert.ToInt32(reader["idproducto"]) : 0,
                            NombreProducto = reader["nombreProducto"] != null ? Convert.ToString(reader["nombreProducto"]) : string.Empty,
                            PrecioUnidad = reader["preciounidad"] != null ? Convert.ToDecimal(reader["preciounidad"]) : 0,
                            Cantidad = reader["cantidad"] != null ? Convert.ToInt32(reader["cantidad"]) : 0,
                            Descuento = reader["descuento"] != null ? Convert.ToDecimal(reader["descuento"]) : 0,
                        });
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return detallepedidos;
        }
    }
}
