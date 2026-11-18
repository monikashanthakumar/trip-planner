using Microsoft.EntityFrameworkCore;
using TripPlanner.Api.Data;
using TripPlanner.Api.Models;

namespace TripPlanner.Api.Repositories;

public class ActivityRepository : IActivityRepository
{
    private readonly TripPlannerDbContext _dbContext;

    public ActivityRepository(TripPlannerDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<IReadOnlyList<Activity>> GetByTripIdAsync(
        int tripId,
        CancellationToken cancellationToken)
    {
        return await _dbContext.Activities
            .AsNoTracking()
            .Where(activity => activity.TripId == tripId)
            .ToListAsync(cancellationToken);
    }

    public Task<Activity?> GetByIdAsync(int id, CancellationToken cancellationToken)
    {
        return _dbContext.Activities
            .FirstOrDefaultAsync(activity => activity.Id == id, cancellationToken);
    }

    public Task<Trip?> GetTripByIdAsync(int tripId, CancellationToken cancellationToken)
    {
        return _dbContext.Trips
            .FirstOrDefaultAsync(trip => trip.Id == tripId, cancellationToken);
    }

    public async Task<Activity> AddAsync(Activity activity, CancellationToken cancellationToken)
    {
        _dbContext.Activities.Add(activity);
        await _dbContext.SaveChangesAsync(cancellationToken);
        return activity;
    }

    public async Task<Activity> UpdateAsync(Activity activity, CancellationToken cancellationToken)
    {
        _dbContext.Activities.Update(activity);
        await _dbContext.SaveChangesAsync(cancellationToken);
        return activity;
    }

    public async Task<bool> DeleteAsync(Activity activity, CancellationToken cancellationToken)
    {
        _dbContext.Activities.Remove(activity);
        await _dbContext.SaveChangesAsync(cancellationToken);
        return true;
    }
}
