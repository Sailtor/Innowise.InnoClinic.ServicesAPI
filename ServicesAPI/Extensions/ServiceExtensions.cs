using Core.RepositoryInterfaces;
using FluentMigrator.Runner;
using FluentValidation;
using Infrastructure.MessageBus;
using Infrastructure.Persistence;
using Infrastructure.Persistence.Migrations;
using InnoClinic.ServicesAPI.Middleware;
using MassTransit;
using MediatR;
using UseCases.Interfaces;
using UseCases.PipelineBehaviors;

namespace InnoClinic.ServicesAPI.Extensions
{
    public static class ServiceExtensions
    {
        public static void ConfigureControllers(this IServiceCollection services)
        {
            services.AddControllers();
        }

        public static void ConfigureSwagger(this IServiceCollection services)
        {
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();
        }
        public static void ConfigureEntityServices(this IServiceCollection services)
        {
            services.AddScoped<IRepositoryManager, RepositoryManager>();
        }
        public static void ConfigureFluentValidation(this IServiceCollection services)
        {
            services.AddValidatorsFromAssembly(typeof(UseCases.AssemblyReference).Assembly);
        }
        public static void ConfigureCQRSServices(this IServiceCollection services)
        {
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));

            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(UseCases.AssemblyReference).Assembly));
        }
        public static void ConfigureDapper(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton<DapperContext>();
            services.AddSingleton<Database>();
            services.AddLogging(c => c.AddFluentMigratorConsole())
                .AddFluentMigratorCore()
                .ConfigureRunner(c => c.AddSqlServer2016()
                    .WithGlobalConnectionString(configuration.GetConnectionString("ServicesDb"))
                    .ScanIn(typeof(Infrastructure.Persistence.AssemblyReference).Assembly).For.Migrations());
        }

        public static void ConfigureAutomapper(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(UseCases.AssemblyReference).Assembly);
        }

        public static void CofigureAuthorization(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddAuthentication("Bearer")
               .AddJwtBearer("Bearer", opt =>
               {
                   opt.RequireHttpsMetadata = false;
                   opt.Authority = configuration.GetSection("IdentityServerAuthority").Value;
                   opt.Audience = "services";
               });
        }

        public static void CofigureExceptionHandlerMiddleware(this IServiceCollection services)
        {
            services.AddTransient<ExceptionHandlingMiddleware>();
        }

        public static void CofigureRabbitMQ(this IServiceCollection services)
        {
            services.AddTransient<IMessageProducer, RabbitMQServicesProducer>();
        }

        public static void CofigureMassTransit(this IServiceCollection services)
        {
            services.AddMassTransit(x =>
            {
                x.UsingRabbitMq();
            });
        }

        /* --- CUSTOM MIDDLEWARE --- */
        public static void UseExceptionHandlerMiddleware(this IApplicationBuilder app)
        {
            app.UseMiddleware<ExceptionHandlingMiddleware>();
        }

    }
}
