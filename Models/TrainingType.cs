using System.ComponentModel.DataAnnotations;

namespace FitnessCalendar.Models
{
    public class TrainingType
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [StringLength(200)]
        public string Description { get; set; }
    }
} 