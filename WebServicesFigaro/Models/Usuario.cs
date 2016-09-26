using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebServicesFigaro.Models
{
    public class Usuario
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public string Nombre { get; set; }
        [Required]
        public string Apellidos { get; set; }
        [DisplayName("Correo electrónico")]
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        public string Imagen { get; set; }
        [Required]
        [DisplayName("Contraseña")]
        [PasswordPropertyText(true)]
        public string Password { get; set; }
        [DisplayName("Zona")]
        [ForeignKey("Zona")]
        public int ZonaId { get; set; }
        public string Ciudad { get; set; }
        [DisplayName("Dirección")]
        public string Direccion { get; set; }
        public string Estado { get; set; }
        [DisplayName("Fecha de registro")]
        public DateTime FechaRegistro { get; set; }
        [DisplayName("Género")]
        public string genero { get; set; }
        [DisplayName("ChefSeleccionado")]
        [ForeignKey("ChefSeleccionado")]
        public int ChefSeleccionadoId { get; set; }

        public Chef ChefSeleccionado { get; set; }
        public Zona Zona { get; set; }
    }
}