
using Microsoft.EntityFrameworkCore;
using TestN5.Core.Interface;
using TestN5.Data.Data;
using TestN5.Data.Repositories;

var builder = WebApplication.CreateBuilder(args);

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
