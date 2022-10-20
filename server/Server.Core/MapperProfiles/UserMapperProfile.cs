using AutoMapper;
using Server.Core.Entities;
using Server.Core.Requests.User;

namespace Server.Core.MapperProfiles
{
    public class UserMapperProfile : Profile
    {
        public UserMapperProfile()
        {
            CreateMap<UserInsertRequest, User>();
        }
    }
}
