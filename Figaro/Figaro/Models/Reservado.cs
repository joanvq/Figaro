using Figaro.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Figaro.Models
{
    public class Reservado
    {
        public int Id { get; set; }
        public DateTime Hora { get; set; }
        public int DisponibilidadId { get; set; }
        public int PedidoId { get; set; }

        public Pedido Pedido { get; set; }
        public Disponibilidad Disponibilidad { get; set; }
    }
}