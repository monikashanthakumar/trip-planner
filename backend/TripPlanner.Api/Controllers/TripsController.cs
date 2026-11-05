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
}