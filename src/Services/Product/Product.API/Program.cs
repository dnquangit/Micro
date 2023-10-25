using Common.Logging;
using Product.API.Extensions;
using Product.API.Persistence;
using Serilog;

var builder = WebApplication.CreateBuilder(args);
builder.Host.UseSerilog(Seriloger.Configure);
builder.AddAppConfigurations();
builder.Services.AddInfrastructure(builder.Configuration);

var app = builder.Build();
app.UseInferastructure();

app.MigrateDatabase<ProductContext>((context, _) =>
{
    ProductContextSeed.SeedProductAsync(context, Log.Logger).Wait();
});

app.Run();
