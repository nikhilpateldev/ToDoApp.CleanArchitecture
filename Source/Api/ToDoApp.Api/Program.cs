using Microsoft.OpenApi.Models;
using ToDoApp.Infrastructure;
using ToDoApp.Application;
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddToDoAppApplication();
builder.Services.AddToDoAppInfrastructure(builder.Configuration);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "ToDo API",
        Version = "v1"
    });
});

var app = builder.Build();

app.UseMiddleware<ToDoApp.Api.Middleware.GlobalExceptionMiddleware>();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();