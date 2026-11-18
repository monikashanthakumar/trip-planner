using Microsoft.EntityFrameworkCore;
using TripPlanner.Api.Models;

namespace TripPlanner.Api.Data;

public class TripPlannerDbContext : DbContext
{
    public TripPlannerDbContext(DbContextOptions<TripPlannerDbContext> options) : base(options)
    {
    }

    public DbSet<Trip> Trips { get; set; }
    public DbSet<Activity> Activities { get; set; }
}