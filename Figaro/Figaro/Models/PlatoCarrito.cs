using Figaro.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace Figaro.Models
{
    public class PlatoCarrito
    {
        
        public int Id { get; set; }
        public Plato Plato { get; set; }
        public int PlatoId { get; set; }
        public Usuario Usuario { get; set; }
        public int UsuarioId { get; set; }
        public int Cantidad { get; set; }

    }
}
