using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using TABP.Domain.Entities;
using TABP.Domain.Interfaces;
using TABP.Domain.Exceptions;
using TABP.Domain.Messages;

namespace TABP.Application.Users.Register
{
    public class UserCommandHandler : IRequestHandler<UserCommand, Guid>
    {
        private readonly IUserRepository _userRepository;
        private readonly IPasswordHasher<User> _passwordHasher;
        private readonly IMapper _mapper;

        public UserCommandHandler(
            IUserRepository userRepository,
            IPasswordHasher<User> passwordHasher,
            IMapper mapper)
        {
            _userRepository = userRepository;
            _passwordHasher = passwordHasher;
            _mapper = mapper;
        }

        public async Task<Guid> Handle(UserCommand request, CancellationToken cancellationToken)
        {
            var exists = await _userRepository.GetByEmailAsync(request.Email);
            if (exists != null)
            {
                throw new EmailExistException(UserMessages.ExistEmail);
            }

            var user = _mapper.Map<User>(request);
            user.HashedPassword = _passwordHasher.HashPassword(user, request.Password);

            Guid newId = await _userRepository.AddAsync(user, cancellationToken);
            await _userRepository.SaveChangesAsync(cancellationToken);

            return newId;
        }
    }
}
