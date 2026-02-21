using Microsoft.EntityFrameworkCore;
using mission6;
using mission6.Models;

namespace Mission06_LastName.Models
{
    public class MovieCollectionContext : DbContext
    {
        public MovieCollectionContext(DbContextOptions<MovieCollectionContext> options) : base(options) 
        { 
        }

        public DbSet<Movie> Movies { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Seed data: Add your 3 favorite movies here
            modelBuilder.Entity<Movie>().HasData(
                new Movie 
                { 
                    MovieId = 1, 
                    CategoryId = 1, 
                    Title = "Inception", 
                    Year = 2010, 
                    Director = "Christopher Nolan", 
                    Rating = "PG-13", 
                    Edited = false, 
                    LentTo = "",
                    CopiedToPlex = true,
                    Notes = "Mind blowing" 
                },
                new Movie 
                { 
                    MovieId = 2, 
                    CategoryId = 3, 
                    Title = "The Dark Knight", 
                    Year = 2008, 
                    Director = "Christopher Nolan", 
                    Rating = "PG-13", 
                    Edited = false, 
                    LentTo = "",
                    CopiedToPlex = true,
                    Notes = "Best Joker" 
                },
                new Movie 
                { 
                    MovieId = 3, 
                    CategoryId = 2, 
                    Title = "Napoleon Dynamite", 
                    Year = 2004, 
                    Director = "Jared Hess", 
                    Rating = "PG", 
                    Edited = true, 
                    LentTo = "Joel",
                    CopiedToPlex = false,
                    Notes = "Gosh!" 
                }
            );
        }
    }
}