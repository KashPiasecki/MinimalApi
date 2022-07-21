using Microsoft.EntityFrameworkCore;
using MinimalApi.Data;

namespace MinimalApi.Extensions;

public static class StartupExtensions
{
    public static async void UseAutomaticDatabaseUpdate(this WebApplication webApplication)
    {
        await using var scope = webApplication.Services.CreateAsyncScope();
        await using var dbContext = scope.ServiceProvider.GetService<AppDataContext>();
        await dbContext?.Database.MigrateAsync()!;
    }
}