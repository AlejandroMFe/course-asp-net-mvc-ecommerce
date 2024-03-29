﻿using eTickets.Data.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace eTickets.Models
{
    public class Actor : IEntityBase
    {
        [Key]                       //Esta etiquieta identifica cual va a ser la clave de la clase en la base de datos.
        public int Id { get; set; } //El entity framework (EF) automáticamente toma la propiedad Id de la clase como clave primaria.
       
        [Display(Name = "Profile Picture")]
        [Required(ErrorMessage = "Profile Picture is required")]
        public string ProfilePictureURL { get; set; }
        
        [Display(Name = "Full Name")]
        [Required(ErrorMessage = "Full Name is required")]
        [StringLength(67,MinimumLength = 3, ErrorMessage = "Full Name must be between 3 and 67 chars")]
        public string FullName { get; set; }

        [Display(Name = "Biography")]
        [Required(ErrorMessage = "Biography is required")]
        public string Bio { get; set; }

        //Relaciones
        public List<Actor_Movie> Actors_Movies { get; set; }

    }
}
