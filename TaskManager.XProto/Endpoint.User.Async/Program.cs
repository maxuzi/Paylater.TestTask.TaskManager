using X.Proto.Common.Endpoints.Setup.Autofac;
using X.Proto.Common.Endpoints.Setup.ConfigFiles;
using X.Proto.Common.Endpoints.Transport.MsSqlBroker;

var builder = WebApplication.CreateBuilder( args );

builder.AddXSetupAutofac();
builder.AddXSetupConfigFiles();


builder.AddXMsSqlBrokerEndpoint();

var app = builder.Build();




app.Run();
