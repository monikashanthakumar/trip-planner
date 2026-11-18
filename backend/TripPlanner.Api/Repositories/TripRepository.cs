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

    public Trip? GetTripById(int id)
    {
        return _dbContext.Trips.Find(id);
    }

    public Trip? UpdateTrip(int id, Trip trip)
    {
        var existingTrip = _dbContext.Trips.Find(id);

        if (existingTrip == null)
        {
            return null;
        }

        existingTrip.Name = trip.Name;
        existingTrip.Description = trip.Description;
        existingTrip.StartDate = trip.StartDate;
        existingTrip.EndDate = trip.EndDate;

        _dbContext.SaveChanges();
        return existingTrip;    
    }

    public bool DeleteTrip(int id)
    {
        var trip = _dbContext.Trips.Find(id);
        if (trip == null)
        {
            return false;
        }

        _dbContext.Trips.Remove(trip);
        _dbContext.SaveChanges();
        return true;
    }
}
