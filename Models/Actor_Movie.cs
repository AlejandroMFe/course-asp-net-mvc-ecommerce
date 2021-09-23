using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace eTickets.Models
{
    public class Actor_Movie
    {
        /** 
         * Esta es una tabla pivote o join table 
         * 
         * El EF detecta automáticamente la FK, al tener una propiedad Movie y otra propiedad MovieId
         * reconoce que MovieId es la FK que referencia a Movie.
         * 
         * Para definir la FK de manera manual puedo utilizar la etiqueta [ForeignKey("ActorId")] 
         */

        public int MovieId { get; set; } //FK que referencia a Movie
        public Movie Movie { get; set; } //Actor_Movie solo tiene un Movie, 1:N

        public int ActorId { get; set; } //Fk que referencia a Actor
        [ForeignKey("ActorId")]          
        public Actor Actor { get; set; }
    }
}
