using YogaManagement.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.ConfigureApplicationServices(builder.Configuration);
// Add logger
builder.Host.ConfigureSeriLog(builder.Configuration);

var app = builder.Build();

// Configure the HTTP request pipeline.
app.ConfigureRequestPipeline();

app.Run();