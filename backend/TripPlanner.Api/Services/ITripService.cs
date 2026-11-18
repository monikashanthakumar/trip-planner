using TripPlanner.Api.Models;

namespace TripPlanner.Api.Services;

public interface ITripService
{
    IEnumerable<Trip> GetTrips();
    Trip AddTrip(Trip trip);
    Trip? GetTripById(int id);
    Trip? UpdateTrip(int id, Trip trip);
    bool DeleteTrip(int id);
}