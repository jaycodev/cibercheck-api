using FluentValidation;
using CiberCheck.Features.Courses.Dtos;

namespace CiberCheck.Features.Courses.Validators
{
    public class CreateCourseDtoValidator : AbstractValidator<CreateCourseDto>
    {
        public CreateCourseDtoValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .MaximumLength(100);
            RuleFor(x => x.Code)
                .MaximumLength(20)
                .When(x => x.Code != null);
        }
    }
}
