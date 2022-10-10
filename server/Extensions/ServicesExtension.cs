using jap_task.Data;
using jap_task.Services.ProgramService;
using jap_task.Services.SelectionService;
using server.Services.CommentService;
using server.Services.MailService;
using server.Services.StudentService;

namespace server.Extensions
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
        }
    }
}
