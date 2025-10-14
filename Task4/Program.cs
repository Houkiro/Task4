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

builder.Services.AddAutoMapper(typeof(Program));

builder.Services.ConfigureRepositoryManager();
builder.Services.ConfigureServiceManager();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

var logger = app.Services.GetRequiredService<ILoggerManager>();

app.ConfigureExceptionHandler(logger);

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
