using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace Figaro.Models
{
    public class Pedido
    {
        
        public int Id { get; set; }
        public string NPedido { get; set; }
        public string NombreApellidos { get; set; }
        public string Direccion { get; set; }
        public string CP { get; set; }
        public string Estado { get; set; }
        public Usuario Usuario { get; set; }
        public int UsuarioId { get; set; }
        public Zona Zona { get; set; }
        public int ZonaId { get; set; }
        public decimal PrecioTotal { get; set; }
        public string Comentario { get; set; }
        public DateTime FechaPedido { get; set; }
        public string NombreChef { get; set; }
        public string TipoCocina { get; set; }

    }
}