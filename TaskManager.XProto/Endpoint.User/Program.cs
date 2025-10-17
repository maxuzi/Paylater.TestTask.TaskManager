
using X.Proto.Common.Endpoints.Setup.Autofac;
using X.Proto.Common.Endpoints.Setup.ConfigFiles;
using X.Proto.Common.Endpoints.Transport.WebApi;
using X.Proto.Common.Endpoints.Transport.Grpc;

var builder = WebApplication.CreateBuilder( args );

builder.AddXSetupAutofac();
builder.AddXSetupConfigFiles();

builder.AddXEndpointWebApi();
builder.AddXEndpointGrpc();

var app = builder.Build();

app.UseXEndpointWebApi();
app.UseXEndpointGrpc();

app.Run();
