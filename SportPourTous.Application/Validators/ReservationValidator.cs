using FluentValidation;
using Microsoft.EntityFrameworkCore.Diagnostics;
using SportPourTous.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SportPourTous.Application.Services
{
    public class ReservationValidator : AbstractValidator<Reservation>
    {
        public ReservationValidator() 
        { 
            RuleFor(x => x.ReservationDate).NotEmpty().GreaterThanOrEqualTo(DateTime.Now.Date).WithMessage("Invalid reservation date");
            RuleFor(x => x.BeginningHour).NotEmpty().GreaterThanOrEqualTo(DateTime.Now.Date);
            RuleFor(x => x.EndingHour).NotEmpty().GreaterThanOrEqualTo(DateTime.Now.Date);
        }
    }
}
