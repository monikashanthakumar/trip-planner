using System.ComponentModel.DataAnnotations;

namespace TripPlanner.Api.DTOs;

public class UpdateActivityDto
{
    [Required]
    public string Name { get; set; } = string.Empty;

    [Required]
    public DateTime? Date { get; set; }

    public string? Location { get; set; }

    public string? Notes { get; set; }
}
