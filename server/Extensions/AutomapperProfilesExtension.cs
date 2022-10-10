﻿using server.MapperProfiles;

namespace server.Extensions
{
    public static class AutomapperProfilesExtension
    {
        public static void AutomapperProfiles(this IServiceCollection service)
        {
            service.AddAutoMapper(typeof(UserMapperProfile));
            service.AddAutoMapper(typeof(ProgramMapperProfile));
            service.AddAutoMapper(typeof(CommentMapperProfile));
            service.AddAutoMapper(typeof(SelectionMapperProfile));
            service.AddAutoMapper(typeof(StudentMapperProfile));
        }
    }
}
