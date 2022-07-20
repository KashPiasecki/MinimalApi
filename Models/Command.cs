using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MinimalApi.Models;

public class Command
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    [Required]
    public string? HowTo { get; set; }
    [Required]
    [MaxLength(5)]
    public string? Platform { get; set; }
    [Required]
    public string? CommandLine { get; set; }

    public Command(int id, string? howTo, string? platform, string? commandLine)
    {
        Id = id;
        HowTo = howTo;
        Platform = platform;
        CommandLine = commandLine;
    }
}