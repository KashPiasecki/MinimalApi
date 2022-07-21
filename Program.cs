using Microsoft.EntityFrameworkCore;
using MinimalApi.Configuration;
using MinimalApi.Data;
using MinimalApi.DataTransferObjects;
using MinimalApi.Extensions;
using MinimalApi.Repositories;

// WebApplicationBuilder
var builder = WebApplication.CreateBuilder(args);
// ServiceCollection
var services = builder.Services;
var minimalApiConfiguration = ConfigurationFactory.Create(builder.Configuration);
services.AddSingleton(minimalApiConfiguration.SqlConfiguration);
services.AddScoped<ICommandRepository, CommandRepository>();
services.AddDbContext<AppDataContext>(options =>
    options.UseSqlServer(minimalApiConfiguration.SqlConfiguration.ConnectionString));
// WebApplication 
var app = builder.Build();  
app.UseAutomaticDatabaseUpdate();
app.UseHttpsRedirection();

// Api
app.MapGet("api/v1/commands", async (ICommandRepository repository) =>
    await repository.GetAsync());
app.MapGet("api/v1/commands/{id:int}", async (ICommandRepository repository, int id) =>
{
    var command = await repository.GetAsync(id);
    return command.IsSomething() ? Results.Ok(command) : Results.NotFound();

});
app.MapPost("api/v1/commands", async (ICommandRepository repository, CommandDto command) =>
{
    var created = await repository.AddAsync(command);
    return Results.Created($"api/v1/commands/{created.Id}", created);
});
    
app.MapDelete("api/v1/commands/{id:int}", async (ICommandRepository repository, int id) =>
{
    var result = await repository.DeleteAsync(id);
    return result ? Results.NoContent() : Results.NotFound();
});
app.Run();

public class ModelState
{
}