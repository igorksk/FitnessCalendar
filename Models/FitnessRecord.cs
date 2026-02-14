using System.ComponentModel.DataAnnotations;

namespace FitnessCalendar.Models
{
    public class FitnessRecord
    {
        public int Id { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Date")]
        public DateTime Date { get; set; }

        [Required]
        [Range(30, 200)]
        [RegularExpression(@"^\d+([,\.]\d{1})?$", ErrorMessage = "Weight must be a number with one decimal place")]
        [Display(Name = "Weight (kg)")]
        [DisplayFormat(DataFormatString = "{0:N1}", ApplyFormatInEditMode = true)]
        public decimal Weight { get; set; }

        [Display(Name = "Full Body")]
        public int? FullBodyTrainingId { get; set; }
        [Display(Name = "Full Body")]
        public TrainingType? FullBodyTraining { get; set; }

        [Display(Name = "Stretching")]
        public int? StretchingId { get; set; }
        [Display(Name = "Stretching")]
        public TrainingType? Stretching { get; set; }
    }
} 