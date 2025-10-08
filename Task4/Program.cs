using BLL.Interfaces;
using BLL.Services;
using Core.Interfaces;
using DAL.InMemoryRepository;
using NLog;
using NLog.Web;
using Task4.Extensions;

var builder = WebApplication.CreateBuilder(args);

var configPath = Path.Combine(Directory.GetCurrentDirectory(), "nlog.config");
LogManager.Setup().LoadConfigurationFromFile(configPath);

builder.Logging.ClearProviders();
builder.Host.UseNLog();
builder.Services.ConfigureLoggerService();

builder.Services.AddScoped<IAuthorRepository, InMemoryAuthorRepository>();

builder.Services.AddScoped<IAuthorService, AuthorService>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseAuthorization();

app.MapControllers();

app.Run();
