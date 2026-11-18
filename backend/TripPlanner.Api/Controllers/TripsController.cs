using Microsoft.AspNetCore.Mvc;
using TripPlanner.Api.Models;
using TripPlanner.Api.Services;
using TripPlanner.Api.DTOs;

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
    public ActionResult<Trip> AddTrip(CreateTripDto createTripDto)
    {
        var trip = new Trip
        {
            Name = createTripDto.Name,
            Destination = createTripDto.Destination,
            Description = createTripDto.Description,
            StartDate = createTripDto.StartDate!.Value,
            EndDate = createTripDto.EndDate!.Value
        };

        var createdTrip = _tripService.AddTrip(trip);

        return CreatedAtAction(
            nameof(GetTripById), 
            new { id = createdTrip.Id }, 
            createdTrip);
    }

    [HttpGet("{id}")]
    public ActionResult<Trip> GetTripById(int id)
    {
        var trip = _tripService.GetTripById(id);
        if (trip == null)
        {
            return NotFound();
        }
        return Ok(trip);
    }

    [HttpPut("{id}")]
    public ActionResult<Trip> UpdateTrip(int id, UpdateTripDto updateTripDto)
    {
        var trip = new Trip
        {
            Name = updateTripDto.Name,
            Destination = updateTripDto.Destination,
            Description = updateTripDto.Description,
            StartDate = updateTripDto.StartDate!.Value,
            EndDate = updateTripDto.EndDate!.Value
        };

        var updatedTrip = _tripService.UpdateTrip(id, trip);
        if (updatedTrip == null)
        {
            return NotFound();
        }
        return Ok(updatedTrip);
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteTrip(int id)
    {
        var deleted = _tripService.DeleteTrip(id);
        if (!deleted)
        {
            return NotFound();
        }
        return NoContent();
    }
}