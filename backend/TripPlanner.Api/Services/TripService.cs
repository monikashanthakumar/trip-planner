using TripPlanner.Api.Models;
using TripPlanner.Api.Repositories;

namespace TripPlanner.Api.Services;

public class TripService : ITripService
{
    private readonly ITripRepository _tripRepository;

    public TripService(ITripRepository tripRepository)
    {
        _tripRepository = tripRepository;
    }

    public IEnumerable<Trip> GetTrips()
    {
        return _tripRepository.GetTrips();
    }

    public Trip AddTrip(Trip trip)
    {
        ValidateTrip(trip);
        return _tripRepository.AddTrip(trip);
    }

    public Trip? GetTripById(int id)
    {
        return _tripRepository.GetTripById(id);
    }

    public Trip? UpdateTrip(int id, Trip trip)
    {
        ValidateTrip(trip);
        return _tripRepository.UpdateTrip(id, trip);
    }

    public bool DeleteTrip(int id)
    {
        return _tripRepository.DeleteTrip(id);
    }

    private void ValidateTrip(Trip trip)
    {
        if (trip.StartDate > trip.EndDate)
        {
            throw new ArgumentException("Start date cannot be after end date.");
        }
    }
}