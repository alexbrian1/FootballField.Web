using System;
using System.ComponentModel.DataAnnotations;

namespace FootballField.Web.Models
{
    public class Cancha : EntityBase
    {
        // [Required]
        // public Guid ID { get; set; }
        [Required]
        public string nombreCliente { get; set; }
        [Required]
        public string Hora { get; set; }

    }
}