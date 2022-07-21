using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using MinimalApi.DataTransferObjects;

namespace MinimalApi.Models;

public record Command
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; init; }

    [Required]
    public string? HowTo { get; init; } 

    [Required]
    [MaxLength(5)]
    public string? Platform { get; init; }

    [Required]
    public string? CommandLine { get; init; }

    public Command()
    {
    }
    
    public Command(CommandDto commandDto)
    {
        HowTo = commandDto.HowTo;
        Platform = commandDto.Platform;
        CommandLine = commandDto.CommandLine;
    }
}