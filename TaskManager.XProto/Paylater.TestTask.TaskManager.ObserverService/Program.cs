using Paylater.TestTask.TaskManager.ObserverService;
using X.Proto.Common.Endpoints.Setup.Autofac;
using X.Proto.Common.Endpoints.Setup.ConfigFiles;


var builder = WebApplication.CreateBuilder( args );

builder.AddXSetupAutofac();
builder.AddXSetupConfigFiles();


builder.AddObserverService();

var app = builder.Build();


app.Run();
