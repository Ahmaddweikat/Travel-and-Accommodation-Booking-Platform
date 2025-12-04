using MediatR;

namespace TABP.Application.Users.Register
{
    public record UserCommand : IRequest<Guid>
    {
        public required string FirstName { get; init; }
        public required string LastName { get; init; }
        public required string Email { get; init; }
        public required string Password { get; init; }
        public required string ConfirmPassword { get; init; }
    }
}
