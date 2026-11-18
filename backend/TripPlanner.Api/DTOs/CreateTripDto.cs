using System.ComponentModel.DataAnnotations;

namespace TripPlanner.Api.DTOs;

public class CreateTripDto
{
    [Required]
    public string Name { get; set; } = string.Empty;

    [Required]
    public string Destination { get; set; } = string.Empty;

    public string? Description { get; set; }

    [Required]
    public DateTime? StartDate { get; set; }

    [Required]
    public DateTime? EndDate { get; set; }
}