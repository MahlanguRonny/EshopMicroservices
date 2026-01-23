using Ordering.API;
using Ordering.Application;
using Ordering.Infrustructure;
using Ordering.Infrustructure.Data.Extentions;

var builder = WebApplication.CreateBuilder(args);

//Add services to the container

builder.Services
  .AddApplicationServices(builder.Configuration)
  .AddInfrastructureServices(builder.Configuration)
  .AddApiServices(builder.Configuration);
//--------------------------------
var app = builder.Build();

// configure the HTTP request pipleline
app.UseApiServices();

if(app.Environment.IsDevelopment())
{
    await app.InitialiseDatabaseAsync();
}
app.Run();
