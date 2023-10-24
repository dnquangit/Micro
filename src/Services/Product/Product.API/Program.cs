using Common.Logging;
using Product.API.Extensions;
using Serilog;

var builder = WebApplication.CreateBuilder(args);
builder.Host.UseSerilog(Seriloger.Configure);
builder.AddAppConfigurations();
builder.Services.AddInfrastructure(builder.Configuration);

var app = builder.Build();
app.UseInferastructure();

app.Run();
