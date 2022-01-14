using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.InMemory;




namespace lab5_Zadanie.Models
{

    public class MoviesItem
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
        public string ReleaseDate { get; set; }
        public int NumberOfReviews { get; set; }
        public int RuntimeInMinutes { get; set; }
        
    }

    
}
