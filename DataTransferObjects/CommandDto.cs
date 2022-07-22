using System.ComponentModel.DataAnnotations;
using FluentValidation;

namespace MinimalApi.DataTransferObjects;

public record CommandDto 
{
    [Required]
    public string? HowTo { get; init; }
    [Required]
    [MaxLength(5)]
    public string? Platform { get; init; }
    [Required]
    public string? CommandLine { get; init; }
}

public class CommandValidator : AbstractValidator<CommandDto>
{
    public CommandValidator()
    {
        RuleFor(m => m.HowTo).NotEmpty();
        RuleFor(m => m.Platform).NotEmpty().MaximumLength(5);
        RuleFor(m => m.CommandLine).NotEmpty();
    }
}