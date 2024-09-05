using Web.Configuration;

var builder = WebApplication.CreateBuilder(args);

builder.SetupDatabase();
builder.SetupAuthentication();
builder.SetupDotNetServices();
builder.SetupDependencyInjection();

var app = builder.Build();

if (app.Environment.IsDevelopment())
    app.SetupDevEnvironment();

using (var scope = app.Services.CreateScope())
    await scope.InitializationRoutine();

app.SetupMiddlewares();

app.Run();
