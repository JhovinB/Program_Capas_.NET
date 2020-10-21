using Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class GetDetallePedidos
    {
        public List<Pedido> GetPedidos(Pedido pedido)
        {
            SqlParameter[] parameters = null;
            string comandText = string.Empty;
            List<Pedido> pedidos = null;

            try
            {
                comandText = "usp_findByPedido";
                parameters = new SqlParameter[2];
                parameters[0] = new SqlParameter("@ID", SqlDbType.Int);
                parameters[0].Value = pedido.IdPedido;
                pedidos = new List<Pedido>();

                using (SqlDataReader reader = SqlHelper.ExecuteReader(SqlHelper.Connection, "usp_findByPedido",
                    CommandType.StoredProcedure, parameters))
                {
                    while (reader.Read())
                    {
                        pedidos.Add(new Pedido
                        {
                            IdPedido = reader["IdPedido"] != null ? Convert.ToInt32(reader["IdPedido"]) : 0,
                            IdCliente = reader["IdCliente"] != null ? Convert.ToString(reader["IdCliente"]) : string.Empty,
                            IdEmpleado = reader["IdEmpleado"] != null ? Convert.ToInt32(reader["IdEmpleado"]) : 0,
                            FechaPedido = reader["FechaPedido"] != null ? Convert.ToDateTime(reader["FechaPedido"]) : DateTime.MinValue,
                            FechaEntrega = reader["FechaEntrega"] != null ? Convert.ToDateTime(reader["FechaEntrega"]) : DateTime.MinValue,
                            FechaEnvio = reader["FechaEnvio"] != null ? Convert.ToDateTime(reader["FechaEnvio"]) : DateTime.MinValue,
                            FormaEnvio = reader["FormaEnvio"] != null ? Convert.ToInt32(reader["FormaEnvio"]) : 0,
                            Cargo = reader["Cargo"] != null ? Convert.ToInt32(reader["Cargo"]) : 0,
                            Destinatario = reader["Destinatario"] != null ? Convert.ToString(reader["Destinatario"]) : string.Empty,
                            DireccionDestinatario = reader["DireccionDestinatario"] != null ? Convert.ToString(reader["DireccionDestinatario"]) : string.Empty,
                            RegionDestinatario = reader["RegionDestinatario"] != null ? Convert.ToString(reader["RegionDestinatario"]) : string.Empty,
                            CodPostalDestinatario = reader["CodPostalDestinatario"] != null ? Convert.ToString(reader["CodPostalDestinatario"]) : string.Empty,
                            PaisDestinatario = reader["PaisDestinatario"] != null ? Convert.ToString(reader["PaisDestinatario"]) : string.Empty
                        });
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return pedidos;
        }
    }
}
