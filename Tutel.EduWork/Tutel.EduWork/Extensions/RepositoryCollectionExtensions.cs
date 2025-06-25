using Tutel.EduWork.DataAccessLayer.Abstractions.Repositories;
using Tutel.EduWork.DataAccessLayer.Repositories;

namespace Tutel.EduWork.Extensions
{
    public static class RepositoryCollectionExtensions
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            Console.WriteLine("Registering repositories...");

            services.AddScoped<IProjectRepository, ProjectRepository>();
            services.AddScoped<ISickLeaveRepository, SickLeaveRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IVacationRepository, VacationRepository>();
            services.AddScoped<IWorkDayRepository, WorkDayRepository>();
            services.AddScoped<IWorkSessionRepository, WorkSessionRepository>();

            return services;
        }
    }
}
