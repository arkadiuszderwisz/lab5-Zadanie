using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace lab5_Zadanie.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MoviesController : ControllerBase
    {
        private static readonly string[] Titles = new[]
        {
            "Intouchables", "The Green Mile", "The Godfather", "Forrest Gump", "Fight Club", "Joker", "The Pianist"
        };
        private static readonly string[] Dates = new[]
        {
            "2011", "1999", "1972", "1994", "1999", "2019", "2002"
        };

        private readonly ILogger<MoviesController> _logger;

        public MoviesController(ILogger<MoviesController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<Movies> Get()
        {
            var rng = new Random();
            return Enumerable.Range(0, 7).Select(index => new Movies
            {
                Title = Titles[index],
                ReleaseDate = Dates[index],
                NumberOfReviews = rng.Next(1, 300),
                RuntimeInMinutes = rng.Next(120, 200)
            })
            .ToArray();
        }
        public class Movies
        {
            public string ReleaseDate { get; set; }
            public int NumberOfReviews { get; set; }
            public int RuntimeInMinutes { get; set; }
            public string Title { get; set; }
        }
    }
}
