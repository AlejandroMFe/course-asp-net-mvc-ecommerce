using eTickets.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace eTickets.Models
{
    public class Movie
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public string ImageURL { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public MovieCategory MovieCategory { get; set; }

        //Relaciones
        public List<Actor_Movie> Actors_Movies { get; set; } //1:N -> un Movie tiene muchos Actor_Movie

        //Cinema <-> Movie
        //  1     :    N
        public int CinemaId { get; set; }  //FK que referencia a Cinema
        [ForeignKey("CinemaId")]
        public Cinema Cinema { get; set; }

        //Producer
        public int ProducerId { get; set; } //FK que referencia a Producer
        public Producer Producer { get; set; }

    }
}
