namespace TripPlanner.Api.Models;
public class Trip
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public string Destination { get; set; } = string.Empty;
    public string? Description { get; set; }
    public ICollection<Activity> Activities { get; set; } = new List<Activity>();
}
