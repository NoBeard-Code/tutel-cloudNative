using Tutel.EduWork.BusinessLayer.Abstractions;
using Tutel.EduWork.BusinessLayer.Services;

namespace Tutel.EduWork.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            Console.WriteLine("Registering services...");

            services.AddScoped<IProjectService, ProjectService>();
            services.AddScoped<ISickLeaveService, SickLeaveService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IWorkSessionService, WorkSessionService>();
            services.AddScoped<IWorkDayService, WorkDayService>();
            services.AddScoped<IVacationService, VacationService>();

            return services;
        }
    }
}
