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
}