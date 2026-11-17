using Microsoft.AspNetCore.Mvc;
using TripPlanner.Api.Models;
using TripPlanner.Api.Services;

namespace TripPlanner.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TripsController : ControllerBase
{
    private readonly ITripService _tripService;

    public TripsController(ITripService tripService)
    {
        _tripService = tripService;
    }

    [HttpGet]
    public ActionResult<IEnumerable<Trip>> GetTrips()
    {
        var trips = _tripService.GetTrips();
        return Ok(trips);
    }

    [HttpPost]
    public ActionResult<Trip> AddTrip(Trip trip)
    {
        var createdTrip = _tripService.AddTrip(trip);

        return CreatedAtAction(nameof(GetTrips), new { id = createdTrip.Id }, createdTrip);
    }
}