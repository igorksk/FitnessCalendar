using System.ComponentModel.DataAnnotations;

namespace FitnessCalendar.Models
{
    public class FitnessRecord
    {
        public int Id { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }

        [Required]
        [Range(30, 200)]
        public decimal Weight { get; set; }

        public int? FullBodyTrainingId { get; set; }
        public TrainingType? FullBodyTraining { get; set; }

        public int? StretchingId { get; set; }
        public TrainingType? Stretching { get; set; }
    }
} 