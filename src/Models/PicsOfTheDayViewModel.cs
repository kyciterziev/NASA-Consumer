using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace NasaConsumer.Models
{
    public class PicsOfTheDayViewModel : IValidatableObject
    {
        public PicsOfTheDayViewModel()
        {
            PicsOfTheDayViewModels = new List<PicOfTheDayViewModel>();
        }

        [DataType(DataType.Date)]
        public DateTime StartDate { get; set; } = DateTime.UtcNow;

        [DataType(DataType.Date)]
        public DateTime EndDate { get; set; } = DateTime.UtcNow;

        [BindNever]
        public IEnumerable<PicOfTheDayViewModel> PicsOfTheDayViewModels { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (StartDate > DateTime.Now)
            {
                yield return new ValidationResult(
                    $"Start Date cannot be set to a date in the future.");
            }

            if (EndDate > DateTime.Now)
            {
                yield return new ValidationResult(
                    $"End Date cannot be set to a date in the future.");
            }

            if (StartDate > EndDate)
            {
                yield return new ValidationResult(
                    $"Start Date cannot be greater than End Date.");
            }
        }
    }
}