using FluentValidation;

namespace TABP.Application.Users.Register
{
    public class UserCommandValidator : AbstractValidator<UserCommand>
    {
        public UserCommandValidator()
        {
            RuleFor(user => user.FirstName).NotEmpty();

            RuleFor(user => user.LastName).NotEmpty();

            RuleFor(email => email.Email).NotEmpty().EmailAddress();

            RuleFor(password => password.Password).NotEmpty()
            .Matches("[A-Z]").WithMessage("At least one uppercase letter is required.")
            .Matches("[a-z]").WithMessage("At least one lowercase letter is required.")
            .Matches("[0-9]").WithMessage("At least one number is required.");

            RuleFor(password => password.ConfirmPassword).NotEmpty().Equal(x => x.Password)
            .WithMessage("Passwords do not match.");
        }
    }
}