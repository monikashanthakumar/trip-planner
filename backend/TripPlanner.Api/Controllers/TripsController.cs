using Microsoft.AspNetCore.Mvc;
using TripPlanner.Api.Models;

namespace TripPlanner.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TripsController : ControllerBase
{
    [HttpGet]
    public ActionResult<IEnumerable<Trip>> GetTrips()
    {
        var trips = new List<Trip>
        {
            new Trip
            {
                Id = 1,
                Name = "Beach Vacation",
                StartDate = new DateTime(2024, 6, 15),
                EndDate = new DateTime(2024, 6, 22),
                Destination = "Hawaii",
                Description = "A relaxing beach vacation in Hawaii."
            },
            new Trip
            {
                Id = 2,
                Name = "Mountain Adventure",
                StartDate = new DateTime(2024, 7, 10),
                EndDate = new DateTime(2024, 7, 20),
                Destination = "Colorado",
                Description = "An adventurous trip to the mountains of Colorado."
            }
        };

        return Ok(trips);
    }
}