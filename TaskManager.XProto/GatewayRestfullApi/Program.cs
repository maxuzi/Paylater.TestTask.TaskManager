

using Microsoft.AspNetCore.Builder;
using Microsoft.OpenApi.Models;
using X.Proto.Common.Endpoints.Setup.Autofac;
using X.Proto.Common.Endpoints.Setup.ConfigFiles;

var builder = WebApplication.CreateBuilder( args );

// Add services to the container.

builder.Services.AddControllers();

builder.AddXSetupAutofac();
builder.AddXSetupConfigFiles();


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

//app.UseAuthentication();
//app.UseAuthorization();

app.MapControllers();

app.Run();
