using Microsoft.AspNetCore.Mvc;
using TripPlanner.Api.DTOs;
using TripPlanner.Api.Models;
using TripPlanner.Api.Services;

namespace TripPlanner.Api.Controllers;

[ApiController]
[Route("api")]
public class ActivitiesController : ControllerBase
{
    private readonly IActivityService _activityService;

    public ActivitiesController(IActivityService activityService)
    {
        _activityService = activityService;
    }

    [HttpGet("trips/{tripId}/activities")]
    public async Task<ActionResult<IEnumerable<Activity>>> GetActivitiesByTripId(
        int tripId,
        CancellationToken cancellationToken)
    {
        var activities = await _activityService.GetByTripIdAsync(tripId, cancellationToken);
        if (activities == null)
        {
            return NotFound();
        }

        return Ok(activities);
    }

    [HttpPost("trips/{tripId}/activities")]
    public async Task<ActionResult<Activity>> AddActivity(
        int tripId,
        CreateActivityDto createActivityDto,
        CancellationToken cancellationToken)
    {
        var activity = new Activity
        {
            Name = createActivityDto.Name,
            Date = createActivityDto.Date!.Value,
            Location = createActivityDto.Location,
            Notes = createActivityDto.Notes,
            TripId = tripId
        };

        var createdActivity = await _activityService.AddAsync(
            tripId,
            activity,
            cancellationToken);
        if (createdActivity == null)
        {
            return NotFound();
        }

        return CreatedAtAction(
            nameof(GetActivityById),
            new { id = createdActivity.Id },
            createdActivity);
    }

    [HttpGet("activities/{id}")]
    public async Task<ActionResult<Activity>> GetActivityById(
        int id,
        CancellationToken cancellationToken)
    {
        var activity = await _activityService.GetByIdAsync(id, cancellationToken);
        if (activity == null)
        {
            return NotFound();
        }

        return Ok(activity);
    }

    [HttpPut("activities/{id}")]
    public async Task<ActionResult<Activity>> UpdateActivity(
        int id,
        UpdateActivityDto updateActivityDto,
        CancellationToken cancellationToken)
    {
        var activity = new Activity
        {
            Name = updateActivityDto.Name,
            Date = updateActivityDto.Date!.Value,
            Location = updateActivityDto.Location,
            Notes = updateActivityDto.Notes
        };

        var updatedActivity = await _activityService.UpdateAsync(id, activity, cancellationToken);
        if (updatedActivity == null)
        {
            return NotFound();
        }

        return Ok(updatedActivity);
    }

    [HttpDelete("activities/{id}")]
    public async Task<IActionResult> DeleteActivity(
        int id,
        CancellationToken cancellationToken)
    {
        var deleted = await _activityService.DeleteAsync(id, cancellationToken);
        if (!deleted)
        {
            return NotFound();
        }

        return NoContent();
    }
}
