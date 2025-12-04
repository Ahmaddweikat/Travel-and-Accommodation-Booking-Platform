using AutoMapper;
using TABP.Application.Users.Register;
using TABP.Web.Requests.Users;

namespace TABP.Web.Mapping
{
    public class UserMappingProfile : Profile
    {
        public UserMappingProfile()
        {
            CreateMap<UserRequest, UserCommand>();
        }
    }
}