using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using Travellness.WebApi.Core.Implementation;
using Travellness.WebApi.Core;
using Travellness.WebApi.DaraAccess.Database.Implementation;
using Travellness.WebApi.DaraAccess.Store;
using Travellness.WebApi.DaraAccess.Store.Implementation;
using Travellness.WebApi.DaraAccess.Database;
using Microsoft.Extensions.Configuration;
using System;

var builder = WebApplication.CreateBuilder(args);

// Add configuration
builder.Configuration.AddJsonFile("appsettings.json", optional: false);

builder.Services.AddControllers();

// Configure DbContext with the connection string from appsettings.json
builder.Services.AddDbContext<RegisterDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"), sqlServerOptionsAction: sqlOptions =>
    {
        sqlOptions.MigrationsAssembly(typeof(Program).Assembly.FullName);
        sqlOptions.EnableRetryOnFailure(maxRetryCount: 5, maxRetryDelay: TimeSpan.FromSeconds(30), errorNumbersToAdd: null);
    });
});
// Register your store and manager
builder.Services.AddScoped<IRegisterDbContext, RegisterDbContext>();
builder.Services.AddScoped<IRegisterStore, RegisterStore>();
builder.Services.AddScoped<IRegisterManager, RegisterManager>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();

app.MapControllers();

app.Run();
