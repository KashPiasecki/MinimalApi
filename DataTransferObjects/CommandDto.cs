using System.ComponentModel.DataAnnotations;

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