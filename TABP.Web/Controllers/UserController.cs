using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using MediatR;
using TABP.Application.Users.Register;
using TABP.Domain.Entities;
using TABP.Web.Requests.Users;

namespace TABP.Web.Controllers
{
    [ApiController]
    [Route("api/users")]
    public class UserController : ControllerBase
    {
        private readonly ISender _sender;
        private readonly IMapper _mapper;

        public UserController(ISender sender, IMapper mapper)
        {
            _sender = sender;
            _mapper = mapper;
        }

        [HttpPost("register")]
        public async Task<IActionResult> SignUp(UserRequest request, CancellationToken cancellationToken)
        {
            var rigesterCommand = _mapper.Map<UserRequest, UserCommand>(request);

            await _sender.Send(rigesterCommand, cancellationToken);

            return NoContent();
        }
    }
}