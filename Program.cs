using System.Reflection;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using MinimalApi.Configuration;
using MinimalApi.Data;
using MinimalApi.DataTransferObjects;
using MinimalApi.Extensions;
using MinimalApi.Repositories;
using MinimalApi.Validation;
using static Microsoft.AspNetCore.Http.Results;

// WebApplicationBuilder
var builder = WebApplication.CreateBuilder(args);
// ServiceCollection
var services = builder.Services;
var minimalApiConfiguration = ConfigurationFactory.Create(builder.Configuration);
services.AddSingleton(minimalApiConfiguration.SqlConfiguration);
services.AddScoped<ICommandRepository, CommandRepository>();
services.AddDbContext<AppDataContext>(options =>
    options.UseSqlServer(minimalApiConfiguration.SqlConfiguration.ConnectionString));
services.AddValidatorsFromAssembly(Assembly.GetAssembly(typeof(Program)));
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
    return command.IsSomething() ? Ok(command) : NotFound();
});
app.MapPost("api/v1/commands", async (ICommandRepository repository, Validated<CommandDto> command) =>
{
    var (isValid, value) = command;
    var created = await repository.AddAsync(value);
    return isValid ? Created($"api/v1/commands/{created.Id}", created) : ValidationProblem(command.Errors);
});
app.MapDelete("api/v1/commands/{id:int}", async (ICommandRepository repository, int id) =>
{
    var result = await repository.DeleteAsync(id);
    return result ? NoContent() : NotFound();
});
app.Run();