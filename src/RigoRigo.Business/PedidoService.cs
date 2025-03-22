using RigoRigo.Entities;
using RigoRogo.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RigoRigo.Business
{
    public class PedidoService
    {
        private readonly PedidoRepository _pedidoRepository;

        public PedidoService(PedidoRepository pedidoRepository)
        {
            _pedidoRepository = pedidoRepository;
        }

        public int CrearPedido(Pedido pedido)
        {
            // Calcular el valor total en base a los productos seleccionados.
            pedido.ValorTotal = pedido.Productos.Sum(p => p.Precio * p.Cantidad);

            // Llamar al repositorio para insertar el pedido.
            return _pedidoRepository.InsertPedido(pedido);
        }
    }
}
