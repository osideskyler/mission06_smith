using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using mission6.Models;

namespace mission6
{
    public class Movie
    {
        [Key]
        [Required]
        public int MovieId { get; set; } 
        [ForeignKey("CategoryId")]
        public int? CategoryId { get; set; }
        public Category? Category { get; set; }
        [Required(ErrorMessage = "Movie title is required")]
        
        public string Title { get; set; }
        

        [Required]
        [Range(1888, 2026, ErrorMessage = "You must enter a valid movie year")]
        public int Year { get; set; }
        
        public string? Director { get; set; }

        
        public string? Rating { get; set; }

        public bool Edited { get; set; }

        public string? LentTo { get; set; } 
        
        public bool CopiedToPlex { get; set; }

        [StringLength(25)]
        public string? Notes { get; set; } 
    }
}