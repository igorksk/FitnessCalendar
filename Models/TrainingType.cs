using System.ComponentModel.DataAnnotations;

namespace FitnessCalendar.Models
{
    public class TrainingType
    {
        public int Id { get; set; }

        public const int FullBodyTrainingId = 1;
        public const int StretchingId = 2;

        [Required]
        [StringLength(50)]
        public required string Name { get; set; }

        [StringLength(200)]
        public string? Description { get; set; }
    }
} 