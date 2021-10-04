using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;
namespace TestingAround2.Models
{
    public class Bet
    {
        public Guid Id { get; set; }

        public decimal Amount { get; set; }

        public DateTime? LastUpdated { get; set; }


    }
    
    public class BetValidator : AbstractValidator<Bet>
    {
        public BetValidator()
        {
            RuleFor(t => t.Amount).GreaterThanOrEqualTo(0).WithMessage("Bet cannot be equal to or less than zero.");
        }
    }
}
