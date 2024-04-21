using backend;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddProjectServices();

var app = builder.Build();

app.UseHttpsRedirection();

app.Run();
