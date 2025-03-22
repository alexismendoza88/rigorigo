using Microsoft.Data.SqlClient;
using RigoRigo.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RigoRogo.DataAccess
{
    public class PedidoRepository
    {
        private readonly string _connectionString;

        public PedidoRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public int InsertPedido(Pedido pedido)
        {
            int pedidoId = 0;
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("sp_InsertPedido", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Cedula", pedido.Cedula);
                    cmd.Parameters.AddWithValue("@Direccion", pedido.Direccion);
                    cmd.Parameters.AddWithValue("@ValorTotal", pedido.ValorTotal);

                    conn.Open();
                    pedidoId = Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
            return pedidoId;
        }
    }
}
