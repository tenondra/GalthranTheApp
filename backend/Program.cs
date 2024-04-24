using backend;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddProjectServices()
    .AddEndpointsApiExplorer()
    .AddSwaggerGen()
    .AddHttpClients(builder.Configuration)
    .AddControllers();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();
app.UseHttpsRedirection();
app.MapControllers();
app.UseAuthorization();

app.Run();