using Microsoft.EntityFrameworkCore;
using MinimalApi.Data;
using MinimalApi.DataTransferObjects;
using MinimalApi.Extensions;
using MinimalApi.Models;

namespace MinimalApi.Repositories;

public class CommandRepository : ICommandRepository
{
    private readonly AppDataContext _appDataContext;

    public CommandRepository(AppDataContext appDataContext)
    {
        _appDataContext = appDataContext;
    }
    
    public async Task<IEnumerable<Command>> GetAsync() =>
        await _appDataContext.Commands.ToListAsync();

    public async Task<Command> GetAsync(int id) =>
        (await _appDataContext.Commands.FirstOrDefaultAsync(e => e.Id == id))!;

    public async Task<Command> AddAsync(CommandDto commandDto)
    {
        ArgumentNullException.ThrowIfNull(commandDto);
        var result = await _appDataContext.Commands.AddAsync(new Command(commandDto));
        await _appDataContext.SaveChangesAsync();
        return result.Entity;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var command = await _appDataContext.Commands.FirstOrDefaultAsync(e => e.Id == id);
        if (command.IsSomething())
        {
            _appDataContext.Commands.Remove(command);
            await _appDataContext.SaveChangesAsync();
            return true;
        }

        return false;
    }
}