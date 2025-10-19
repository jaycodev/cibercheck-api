using FluentValidation;
using CiberCheck.Features.Users.Dtos;

namespace CiberCheck.Features.Users.Validators
{
    public class UpdateUserDtoValidator : AbstractValidator<UpdateUserDto>
    {
        private static readonly string[] AllowedRoles = new[] { "teacher", "student" };

        public UpdateUserDtoValidator()
        {
            RuleFor(x => x.FullName)
                .MaximumLength(100)
                .When(x => x.FullName != null);

            RuleFor(x => x.Role)
                .MaximumLength(20)
                .Must(r => r == null || AllowedRoles.Contains(r))
                .WithMessage($"Role must be one of: {string.Join(", ", AllowedRoles)}");
        }
    }
}
