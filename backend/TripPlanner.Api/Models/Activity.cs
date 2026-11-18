namespace TripPlanner.Api.Models;

public class Activity
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public DateTime Date { get; set; }
    public string? Location { get; set; } 
    public string? Notes { get; set; }
    public int TripId { get; set; }
    public Trip Trip { get; set; } = null!;
}