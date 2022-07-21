using System.ComponentModel.DataAnnotations;

namespace MinimalApi.DataTransferObjects;

public record CommandDto
{
    [Required]
    public string? HowTo { get; set; }
    [Required]
    [MaxLength(5)]
    public string? Platform { get; set; }
    [Required]
    public string? CommandLine { get; set; }
}