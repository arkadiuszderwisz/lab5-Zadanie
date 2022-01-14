using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace lab5_Zadanie.Models
{
    public class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new MoviesContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<MoviesContext>>()))
            {
                if (context.MoviesItems.Any())
                {
                    return;   
                }
                context.MoviesItems.AddRange(
                    new MoviesItem
                    {
                        Id = 1,
                        Title = "Intouchables",
                        ReleaseDate = "2011",
                        NumberOfReviews = 234,
                        RuntimeInMinutes = 130
                    },
                    new MoviesItem
                    {
                        Id = 2,
                        Title = "The Godfather",
                        ReleaseDate = "1972",
                        NumberOfReviews = 214,
                        RuntimeInMinutes = 230
                    },
                    new MoviesItem
                    {
                        Id = 3,
                        Title = "Fight Club",
                        ReleaseDate = "1999",
                        NumberOfReviews = 190,
                        RuntimeInMinutes = 155
                    },
                    new MoviesItem
                    {
                        Id = 4,
                        Title = "Joker",
                        ReleaseDate = "2019",
                        NumberOfReviews = 134,
                        RuntimeInMinutes = 180
                    }
                );
                context.SaveChanges();
            }
        }
    }
}
