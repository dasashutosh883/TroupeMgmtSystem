using Event.Application.Commands;
using FluentValidation;

namespace Event.Application.Validators;
public class CreateEventValidator : AbstractValidator<CreateEventCommand>
{
    public CreateEventValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Name is required.")
            .Length(2, 50).WithMessage("Name must be between 2 and 50 characters.");

        RuleFor(x => x.Description)
            .NotEmpty().WithMessage("Description is required.")
            .Length(10, 200).WithMessage("Description must be between 10 and 200 characters.");

        RuleFor(x => x.StartDate)
            .NotEmpty().WithMessage("Start date is required.")
            .GreaterThan(DateTime.Now).WithMessage("Start date must be in the future.");

        RuleFor(x => x.EndDate)
            .NotEmpty().WithMessage("End date is required.")
            .GreaterThan(x => x.StartDate).WithMessage("End date must be after start date.");
        RuleFor(x => x.Location)
            .NotEmpty().WithMessage("Location is required.")
            .Length(2, 100).WithMessage("Location must be between 2 and 100 characters.");
    }
}