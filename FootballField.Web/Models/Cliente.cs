using System;
using System.ComponentModel.DataAnnotations;

namespace FootballField.Web.Models
{
    public class Cliente : EntityBase
    {
        [Required]
        public string Nombre { get; set; }
        [Required]
        public string Apellido { get; set; }
        

    }
}