using AutoMapper;
using jap_task.Dtos.User;
using jap_task.Models;

namespace server.MapperProfiles
{
    public class UserMapperProfile : Profile
    {
        public UserMapperProfile()
        {
            CreateMap<UserInsertRequest, User>();
        }
    }
}
