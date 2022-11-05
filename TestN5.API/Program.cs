
using Microsoft.EntityFrameworkCore;
using Serilog;
using TestN5.Core.Interfaces;
using TestN5.Core.Services;
using TestN5.Data.Data;
using TestN5.Data.Filters;
using TestN5.Data.Repositories;

var builder = WebApplication.CreateBuilder(args);

var logger = new LoggerConfiguration()
  .ReadFrom.Configuration(builder.Configuration)
  .Enrich.FromLogContext()
  .CreateLogger();
builder.Logging.ClearProviders();
builder.Logging.AddSerilog(logger);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<TestN5Context>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("TestN5"));
});
builder.Services.AddTransient<IPermissions, PermissionsRepository>();
builder.Services.AddTransient<IServicePermissions, ServicePermissions>();
builder.Services.AddControllers(option =>
{
    option.Filters.Add<GlobalExceptionFilter>();
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
