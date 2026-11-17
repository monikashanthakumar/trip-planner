using TripPlanner.Api.Models;
using TripPlanner.Api.Data;

namespace TripPlanner.Api.Repositories;

public class TripRepository : ITripRepository
{
    private readonly TripPlannerDbContext _dbContext;

    public TripRepository(TripPlannerDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    public IEnumerable<Trip> GetTrips()
    {
        return _dbContext.Trips.ToList();
    }

    public Trip AddTrip(Trip trip)
    {
        _dbContext.Trips.Add(trip);
        _dbContext.SaveChanges();
        return trip;
    }
}
