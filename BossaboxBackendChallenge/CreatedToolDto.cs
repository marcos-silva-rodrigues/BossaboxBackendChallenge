using System.ComponentModel.DataAnnotations;

namespace BossaboxBackendChallenge
{
    public class CreatedToolDto
    {
        [Required]
        public string Title { get; set; }

        [Required]
        public string Link { get; set; }

        [Required]
        [MaxLength(120)]
        public string Description { get; set; }

        [Required]
        [MinLength(1)]
        public string[] Tags { get; set; }
    }
}
