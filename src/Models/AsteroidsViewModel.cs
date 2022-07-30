using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using NasaConsumer.Clients.Models;

namespace NasaConsumer.Models
{
    public class AsteroidsViewModel : IValidatableObject
    {
        [DataType(DataType.Date)]
        public DateTime StartDate { get; set; } = DateTime.UtcNow;

        [DataType(DataType.Date)]
        public DateTime? EndDate { get; set; }

        [BindNever]
        public AsteroidsResponse? Asteroids { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (StartDate > DateTime.Now)
            {
                yield return new ValidationResult(
                    $"Start Date cannot be set to a date in the future.");
            }

            if (EndDate != null && EndDate > DateTime.Now)
            {
                yield return new ValidationResult(
                    $"End Date cannot be set to a date in the future.");
            }

            if (EndDate != null && StartDate > EndDate)
            {
                yield return new ValidationResult(
                    $"Start Date cannot be greater than End Date.");
            }

            if (EndDate != null && (EndDate.Value - StartDate).TotalDays > 7)
            {
                yield return new ValidationResult(
                    $"Not valid range. The range must be max 7 days.");
            }
        }
    }
}