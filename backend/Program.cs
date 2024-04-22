using backend;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddProjectServices()
    .AddControllers();

var app = builder.Build();

app.UseHttpsRedirection();
app.MapControllers();
app.UseAuthorization();

app.Run();
