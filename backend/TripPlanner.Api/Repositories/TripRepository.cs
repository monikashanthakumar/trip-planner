using TripPlanner.Api.Models;

namespace TripPlanner.Api.Repositories;

public class TripRepository : ITripRepository
{
    public IEnumerable<Trip> GetTrips()
    {
        return new List<Trip>
        {
            new Trip
            {
                Id = 1,
                Name = "Trip to Paris",
                StartDate = new DateTime(2024, 6, 1),
                EndDate = new DateTime(2024, 6, 10),
                Destination = "Paris, France",
                Description = "A wonderful trip to the city of lights."
            },
            new Trip
            {
                Id = 2,
                Name = "Trip to New York",
                StartDate = new DateTime(2024, 7, 15),
                EndDate = new DateTime(2024, 7, 25),
                Destination = "New York City, USA",
                Description = "Exploring the Big Apple."
            }
        };
    }
}
