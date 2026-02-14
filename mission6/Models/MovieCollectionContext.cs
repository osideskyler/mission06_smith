using Microsoft.EntityFrameworkCore;
using mission6;

namespace Mission06_LastName.Models
{
    public class MovieCollectionContext : DbContext
    {
        public MovieCollectionContext(DbContextOptions<MovieCollectionContext> options) : base(options) 
        { 
        }

        public DbSet<Application> Applications { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Seed data: Add your 3 favorite movies here
            modelBuilder.Entity<Application>().HasData(
                new Application 
                { 
                    MovieId = 1, 
                    Category = "Sci-Fi", 
                    Title = "Inception", 
                    Year = 2010, 
                    Director = "Christopher Nolan", 
                    Rating = "PG-13", 
                    Edited = false, 
                    LentTo = "", 
                    Notes = "Mind blowing" 
                },
                new Application 
                { 
                    MovieId = 2, 
                    Category = "Action", 
                    Title = "The Dark Knight", 
                    Year = 2008, 
                    Director = "Christopher Nolan", 
                    Rating = "PG-13", 
                    Edited = false, 
                    LentTo = "", 
                    Notes = "Best Joker" 
                },
                new Application 
                { 
                    MovieId = 3, 
                    Category = "Comedy", 
                    Title = "Napoleon Dynamite", 
                    Year = 2004, 
                    Director = "Jared Hess", 
                    Rating = "PG", 
                    Edited = true, 
                    LentTo = "Joel", 
                    Notes = "Gosh!" 
                }
            );
        }
    }
}