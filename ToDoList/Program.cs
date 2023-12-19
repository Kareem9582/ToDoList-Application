using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Serilog;
using System.Net;
using System.Text.Json;
using ToDoList.Api.Contracts;
using ToDoList.Api.Middleware;
using ToDoList.Api.Services;
using ToDoList.Context;
using ToDoList.Domain;
using ToDoList.Persistence.Entities;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAuthentication().AddBearerToken(IdentityConstants.BearerScheme);
builder.Services.AddAuthorizationBuilder();
builder.Services.AddAutoMapper(typeof(Program));
builder.Services.AddProblemDetails();
builder.Services.AddDbContext<AppDbContext>(x => x.UseSqlite(@"DataSource=Data/app.sqlite"));
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(DomainEntryPoint).Assembly));
builder.Services.AddIdentityCore<User>()
    .AddEntityFrameworkStores<AppDbContext>()
    .AddApiEndpoints();

#region Add Services
builder.Services.AddTransient<IToDoListService , ToDoListService>();
#endregion

#region Logging

Log.Logger = new LoggerConfiguration()
    .MinimumLevel.Information()
    .WriteTo.Console()
    .WriteTo.File("logs/log-.txt", rollingInterval: RollingInterval.Hour)
    .CreateLogger();

#endregion

#region CROS
builder.Services.AddCors(p => p.AddPolicy("corsapp", builder =>
{
    builder.WithOrigins("*").AllowAnyMethod().AllowAnyHeader();
}));

#endregion
var app = builder.Build();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseExceptionHandler("/error");
    app.Map("/error", appBuilder =>
    {
        appBuilder.Run(async context =>
        {
            var exceptionHandlerPathFeature = context.Features.Get<IExceptionHandlerPathFeature>();
            var exception = exceptionHandlerPathFeature.Error;

            Log.Error(exception, exception.Message);

            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

            var result = JsonSerializer.Serialize(new ProblemDetail
            {
                Message = exception.Message,
                ExceptionType = exception.GetType().Name,
                Status = 500
            });
            await context.Response.WriteAsync(result);
        });
    });
}

app.UseHttpsRedirection();
app.UseCors("corsapp");
app.UseAuthorization();

app.MapControllers();

app.MapIdentityApi<User>();

app.Run();