using Microsoft.EntityFrameworkCore;
using MinimalApi.Configuration;
using MinimalApi.Data;
using MinimalApi.Extensions;

//Builder & Services
var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;
// builder.Services.AddEndpointsApiExplorer();
var minimalApiConfiguration = ConfigurationFactory.Create(builder.Configuration);
services.AddSingleton(minimalApiConfiguration.SqlConfiguration);
services.AddDbContext<AppDataContext>(options =>
    options.UseSqlServer(minimalApiConfiguration.SqlConfiguration.ConnectionString));

//WebApplication 
var app = builder.Build();
app.UseAutomaticMigration();
app.UseHttpsRedirection();
app.Run();