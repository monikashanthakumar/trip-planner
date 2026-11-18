using TripPlanner.Api.Models;
using TripPlanner.Api.Repositories;

namespace TripPlanner.Api.Services;

public class ActivityService : IActivityService
{
    private readonly IActivityRepository _activityRepository;

    public ActivityService(IActivityRepository activityRepository)
    {
        _activityRepository = activityRepository;
    }

    public async Task<IReadOnlyList<Activity>?> GetByTripIdAsync(
        int tripId,
        CancellationToken cancellationToken)
    {
        var trip = await _activityRepository.GetTripByIdAsync(tripId, cancellationToken);
        if (trip == null)
        {
            return null;
        }

        return await _activityRepository.GetByTripIdAsync(tripId, cancellationToken);
    }

    public Task<Activity?> GetByIdAsync(int id, CancellationToken cancellationToken)
    {
        return _activityRepository.GetByIdAsync(id, cancellationToken);
    }

    public async Task<Activity?> AddAsync(
        int tripId,
        Activity activity,
        CancellationToken cancellationToken)
    {
        var trip = await _activityRepository.GetTripByIdAsync(tripId, cancellationToken);
        if (trip == null)
        {
            return null;
        }

        ValidateActivityDate(activity.Date, trip);
        activity.TripId = tripId;
        return await _activityRepository.AddAsync(activity, cancellationToken);
    }

    public async Task<Activity?> UpdateAsync(
        int id,
        Activity activity,
        CancellationToken cancellationToken)
    {
        var existingActivity = await _activityRepository.GetByIdAsync(id, cancellationToken);
        if (existingActivity == null)
        {
            return null;
        }

        var trip = await _activityRepository.GetTripByIdAsync(
            existingActivity.TripId,
            cancellationToken);
        if (trip == null)
        {
            return null;
        }

        ValidateActivityDate(activity.Date, trip);
        existingActivity.Name = activity.Name;
        existingActivity.Date = activity.Date;
        existingActivity.Location = activity.Location;
        existingActivity.Notes = activity.Notes;

        return await _activityRepository.UpdateAsync(existingActivity, cancellationToken);
    }

    public async Task<bool> DeleteAsync(int id, CancellationToken cancellationToken)
    {
        var activity = await _activityRepository.GetByIdAsync(id, cancellationToken);
        if (activity == null)
        {
            return false;
        }

        return await _activityRepository.DeleteAsync(activity, cancellationToken);
    }

    private static void ValidateActivityDate(DateTime activityDate, Trip trip)
    {
        if (activityDate.Date < trip.StartDate.Date || activityDate.Date > trip.EndDate.Date)
        {
            throw new ArgumentException("Activity date must be within the trip dates.");
        }
    }
}
