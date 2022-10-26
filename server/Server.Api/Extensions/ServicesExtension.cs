using Server.Core.Interfaces;
using Server.Database.Data;
using Server.Services;

namespace Server.Api.Extensions
{
    public static class ServicesExtension
    {
        public static void Services(this IServiceCollection service)
        {
            service.AddTransient<ISelectionService, SelectionService>();
            service.AddTransient<IMailService, SendGridMailService>();
            service.AddScoped<IProgramService, ProgramService>();
            service.AddScoped<IStudentService, StudentService>();
            service.AddScoped<ICommentService, CommentService>();
            service.AddScoped<IAuthRepository, AuthRepository>();
            service.AddScoped<ILectureEventService, LectureEventService>();
            service.AddScoped<IStudentLectureEventsService, StudentLectureEventsService>();
        }
    }
}
