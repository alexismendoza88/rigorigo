using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RigoRigo.Entities
{
    public class Pedido
    {
        public int Id { get; set; }
        public string Cedula { get; set; }
        public string Direccion { get; set; }
        public List<Producto> Productos { get; set; }
        public decimal ValorTotal { get; set; }
    }
}
