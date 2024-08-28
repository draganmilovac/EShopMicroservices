using BuildingBlocks.Behaviours;
using Carter;
using FluentValidation;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCarter();
builder.Services.AddMediatR(config =>
{
    config.RegisterServicesFromAssemblies(typeof(Program).Assembly);
    config.AddOpenBehavior(typeof(ValidationBehaviour<,>));
});
builder.Services.AddMarten(opts =>
{
    opts.Connection(builder.Configuration.GetConnectionString("Database")!);
}).UseLightweightSessions();
builder.Services.AddValidatorsFromAssembly(typeof(Program).Assembly);


var app = builder.Build();

app.MapCarter();

app.Run();
