using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using Paylater.TestTask.TaskManager.Core.Users.Entities;
using Paylater.TestTask.TaskManager.Core.Users.Interfaces;
using Paylater.TestTask.TaskManager.Db.EntityFramework;
using Paylater.TestTask.TaskManager.Infrastructure.Users;

var builder = WebApplication.CreateBuilder( args );


var connectionString = builder.Configuration.GetSection( "TaskManager:ConnectionString" ).Value ?? throw new ArgumentNullException( "connectionString", "ConnectionString cannot be null" );
builder.Services.AddDbContext<UserManagerDbContext>( options => options.UseSqlServer( connectionString ));

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IUserRepository, UserRepositoryEF>();

builder.Services.AddSwaggerGen();

var app = builder.Build();


if( app.Environment.IsDevelopment() )
{
    // Enable Swagger middleware
    app.UseSwagger();

    // Enable Swagger UI middleware
    app.UseSwaggerUI( options =>
    {
        options.SwaggerEndpoint( "/swagger/v1/swagger.json", "TaskManager API V1" );

        options.RoutePrefix = string.Empty; // Serve Swagger UI at the app's root
    } );
}

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();


app.MapControllers();

app.Run();
