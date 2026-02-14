using System.ComponentModel.DataAnnotations;
namespace mission6
{
    public class Application
    {
        [Key]
        [Required]
        public int MovieId { get; set; } 
        public string Category { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public int Year { get; set; }

        [Required]
        public string Director { get; set; }

        [Required]
        public string Rating { get; set; }

        public bool? Edited { get; set; }

        public string? LentTo { get; set; } 

        [StringLength(25)]
        public string? Notes { get; set; } 
    }
}