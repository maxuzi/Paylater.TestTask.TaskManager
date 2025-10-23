

using Microsoft.AspNetCore.Builder;
using Microsoft.OpenApi.Models;
using Paylater.TestTask.TaskManager.GatewayRestfullApi.Authentication;
using X.Proto.Common.Endpoints.Setup.Autofac;
using X.Proto.Common.Endpoints.Setup.ConfigFiles;

var builder = WebApplication.CreateBuilder( args );

// Add services to the container.

builder.Services.AddControllers();

builder.AddXSetupAutofac();
builder.AddXSetupConfigFiles();

builder.Services.AddAuthentication().AddScheme<CustomAuthenticationSchemeOptions, CustomAuthenticationHandler>( "CustomAuth", null );

builder.Services.AddSwaggerGen( options =>
{
    // Define the security scheme for Swagger
    options.AddSecurityDefinition( "CustomAuth", new OpenApiSecurityScheme
    {
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        Scheme = "bearer", // Or "custom" if you have a custom scheme
        In = ParameterLocation.Header,
        Description = "Enter your custom authentication token in the format: {token}"
    } );

    // Add a global security requirement
    options.AddSecurityRequirement( new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "CustomAuth"
                }
            },
            new string[] {} // No scopes required for this example
        }
    } );
} );

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

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
