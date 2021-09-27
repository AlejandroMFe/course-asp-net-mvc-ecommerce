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
       
        [Display(Name = "Profile Picture")]
        public string ProfilePictureURL { get; set; }
        [Display(Name = "Full Name")]
        public string FullName { get; set; }
        [Display(Name = "Biography")]
        public string Bio { get; set; }

        //Relaciones
        public List<Actor_Movie> Actors_Movies { get; set; }

    }
}
