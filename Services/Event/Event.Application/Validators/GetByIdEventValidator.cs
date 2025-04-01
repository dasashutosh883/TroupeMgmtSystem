using Event.Application.Queries;
using FluentValidation;

namespace Event.Application.Validators;
public class GetByIdEventValidator : AbstractValidator<GetByIdEventQuery>
{
    public GetByIdEventValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty().WithMessage("Id is required.")
            .GreaterThan(0).WithMessage("Id must be greater than 0.");
    }
}