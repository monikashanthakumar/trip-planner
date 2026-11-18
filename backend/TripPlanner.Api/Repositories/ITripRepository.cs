using TripPlanner.Api.Models;

namespace TripPlanner.Api.Repositories;

public interface ITripRepository
{
    IEnumerable<Trip> GetTrips();
    Trip AddTrip(Trip trip);
    Trip? GetTripById(int id);
    Trip? UpdateTrip(int id, Trip trip);
    bool DeleteTrip(int id);
}