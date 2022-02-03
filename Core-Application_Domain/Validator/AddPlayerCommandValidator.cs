using System;
using Core_Application_Domain.CQRS.Command;
using FluentValidation;

namespace Core_Application_Domain.Validator
{
	public class AddPlayerCommandValidator:AbstractValidator<AddPlayerCommand>
	{
		public AddPlayerCommandValidator()
		{
			RuleFor(s => s.PlayerToAdd).NotNull().WithMessage("Player cannot be null");
			RuleFor(s => s.PlayerToAdd.Naam).MaximumLength(20).WithMessage("Player name must not be more than 20");
			RuleFor(s => s.PlayerToAdd.Birth).NotNull().WithMessage("Birth cannot be null").Must(b => b.Year < 2004);
			RuleFor(s => s.PlayerToAdd.Club).MaximumLength(30).WithMessage("Club name must not be more than 30");
			RuleFor(s => s.PlayerToAdd.Image).MinimumLength(5).WithMessage("Url must be more than 5");

		}
	}
}

