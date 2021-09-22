using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace eTickets.Models
{
    public class Actor_Movie
    {
                                         //El EF detecta automáticamente que es una FK por el nombre de la propiedad
        public int MovieId { get; set; } //FK para el modelo Movie
        public Movie Movie { get; set; }

        public int ActorId { get; set; } //Fk que pertenece a Actor
        [ForeignKey("ActorId")]          //Defino manualmente cual es la FK
        public Actor Actor { get; set; }
    }
}
