using InnoClinic.ServicesAPI.Extensions;
using Serilog;

LoggingExtensions.CongigureLogger();

try
{
    Log.Information("Starting web host");

    var builder = WebApplication.CreateBuilder(args);

    builder.Host.UseSerilog((ctx, lc) => lc
        .WriteTo.Console());

    builder.Services.ConfigureControllers();
    builder.Services.ConfigureSwagger();
    builder.Services.ConfigureDapper(builder.Configuration);
    builder.Services.ConfigureEntityServices();
    builder.Services.ConfigureFluentValidation();
    builder.Services.ConfigureAutomapper();
    builder.Services.ConfigureCQRSServices();
    builder.Services.CofigureAuthorization(builder.Configuration);
    builder.Services.CofigureExceptionHandlerMiddleware();
    builder.Services.CofigureRabbitMQ();
    builder.Services.CofigureMassTransit();
    builder.Services.ConfigureCORS(builder.Configuration);

    var app = builder.Build();

    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }

    app.UseExceptionHandlerMiddleware();

    app.UseSerilogRequestLogging();

    app.MigrateDatabase();

    app.UseHttpsRedirection();

    app.UseAuthorization();

    app.MapControllers();

    app.Run();
}
catch (Exception ex)
{
    Log.Fatal(ex, "Host terminated unexpectedly");
}
finally
{
    Log.CloseAndFlush();
}