using TripPlanner.Api.Models;

namespace TripPlanner.Api.Repositories;

public interface ITripRepository
{
    IEnumerable<Trip> GetTrips();
}