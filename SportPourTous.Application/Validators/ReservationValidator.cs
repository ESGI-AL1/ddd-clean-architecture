using FluentValidation;
using SportPourTous.Domain.Entities;

namespace SportPourTous.Application.Validators
{
    public class ReservationValidator : AbstractValidator<Reservation>
    {
        public ReservationValidator() 
        { 
            RuleFor(x => x.ReservationDate).NotEmpty().GreaterThanOrEqualTo(DateTime.Now.Date)
                .WithMessage("Invalid reservation date");
            RuleFor(x => x.BeginningHour).NotEmpty().GreaterThanOrEqualTo(DateTime.Now.Date);
            RuleFor(x => x.EndingHour).NotEmpty().GreaterThanOrEqualTo(DateTime.Now.Date);
        }
    }
}
