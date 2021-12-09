using System;

namespace FootballField.Web.Models
{
    public class Cliente
    {
        public Guid ID { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string numeroCelular { get; set; }

    }
}