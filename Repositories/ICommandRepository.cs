using MinimalApi.DataTransferObjects;
using MinimalApi.Models;

namespace MinimalApi.Repositories;

public interface ICommandRepository
{
    Task<IEnumerable<Command>> GetAsync();
    Task<Command> GetAsync(int id);
    Task<Command> AddAsync(CommandDto model);
    Task<bool> DeleteAsync(int id);
}