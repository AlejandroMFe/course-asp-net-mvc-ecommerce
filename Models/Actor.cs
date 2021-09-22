using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace eTickets.Models
{
    public class Actor
    {
        [Key]                       //Esta etiquieta identifica cual va a ser la clave de la clase en la base de datos.
        public int Id { get; set; } //El entity framework (EF) automáticamente toma la propiedad Id de la clase como clave primaria.
        public string ProfilePictureURL { get; set; }
        public string FullName { get; set; }
        public string Bio { get; set; }

        //Relaciones

        public List<Actor_Movie> Actors_Movies { get; set; }

    }
}
