using InnoClinic.ServicesAPI.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.ConfigureControllers();
builder.Services.ConfigureSwagger();
builder.Services.ConfigureDapper(builder.Configuration);
builder.Services.ConfigureEntityServices();
builder.Services.ConfigureFluentValidation();
builder.Services.ConfigureAutomapper();
builder.Services.ConfigureCQRSServices();
builder.Services.CofigureAuthorization();


var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MigrateDatabase();

app.UseHttpsRedirection();

//app.UseAuthorization();

app.MapControllers();

app.Run();
