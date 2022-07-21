using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MinimalApi.Models;

public record Command(int Id, string? HowTo, string? Platform, string? CommandLine)
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; } = Id;

    [Required]
    public string? HowTo { get; set; } = HowTo;

    [Required]
    [MaxLength(5)]
    public string? Platform { get; set; } = Platform;

    [Required]
    public string? CommandLine { get; set; } = CommandLine;
}