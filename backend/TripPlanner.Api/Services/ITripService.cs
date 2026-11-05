using TripPlanner.Api.Models;

namespace TripPlanner.Api.Services;

public interface ITripService
{
    IEnumerable<Trip> GetTrips();
}