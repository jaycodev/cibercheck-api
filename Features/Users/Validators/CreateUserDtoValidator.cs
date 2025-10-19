using FluentValidation;
using CiberCheck.Features.Users.Dtos;

namespace CiberCheck.Features.Users.Validators
{
    public class CreateUserDtoValidator : AbstractValidator<CreateUserDto>
    {
        private static readonly string[] AllowedRoles = new[] { "teacher", "student" };

        public CreateUserDtoValidator()
        {
            RuleFor(x => x.FullName)
                .NotEmpty()
                .MaximumLength(100);

            RuleFor(x => x.Email)
                .NotEmpty()
                .EmailAddress();

            RuleFor(x => x.Role)
                .NotEmpty()
                .MaximumLength(20)
                .Must(r => AllowedRoles.Contains(r))
                .WithMessage($"Role must be one of: {string.Join(", ", AllowedRoles)}");

            RuleFor(x => x.Password)
                .NotEmpty();
        }
    }
}
