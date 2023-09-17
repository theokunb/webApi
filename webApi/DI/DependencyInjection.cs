using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using webApi.Commands.CreateTask;
using webApi.Commands.DeleteTask;
using webApi.Commands.GetTask;
using webApi.Commands.GetTaskList;
using webApi.Commands.UpdateTask;
using webApi.Mapper;

namespace webApi.DI
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddDbConnection(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration["DbConnection"];

            services.AddDbContext<TaskDbContext>(options =>
            {
                options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
            });
            services.AddScoped<ITaskDbContext>(provider =>
            {
                var dbContext = provider.GetService<TaskDbContext>();
                DbInitializer.Initialize(dbContext);

                return dbContext;
            });

            return services;
        }

        public static IServiceCollection AddMediator(this IServiceCollection services)
        {
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));

            return services;
        }

        public static IServiceCollection AddMapper(this IServiceCollection services)
        {
            services.AddAutoMapper(conf =>
            {
                conf.AddProfile(new AssemblyMappingProfile(Assembly.GetExecutingAssembly()));
            });

            return services;
        }

        public static IServiceCollection AddValidator(this IServiceCollection services)
        {
            services.AddScoped(typeof(CreateTaskValidator), typeof(CreateTaskValidator));
            services.AddScoped(typeof(UpdateTaskValidator), typeof(UpdateTaskValidator));
            services.AddScoped(typeof(DeleteTaskValidator), typeof(DeleteTaskValidator));
            services.AddScoped(typeof(GetTaskValidator), typeof(GetTaskValidator));
            services.AddScoped(typeof(GetTaskListValidator), typeof(GetTaskListValidator));

            return services;
        }
    }
}
