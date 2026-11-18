using TripPlanner.Api.Models;

namespace TripPlanner.Api.Repositories;

public interface IActivityRepository
{
    Task<IReadOnlyList<Activity>> GetByTripIdAsync(int tripId, CancellationToken cancellationToken);
    Task<Activity?> GetByIdAsync(int id, CancellationToken cancellationToken);
    Task<Trip?> GetTripByIdAsync(int tripId, CancellationToken cancellationToken);
    Task<Activity> AddAsync(Activity activity, CancellationToken cancellationToken);
    Task<Activity> UpdateAsync(Activity activity, CancellationToken cancellationToken);
    Task<bool> DeleteAsync(Activity activity, CancellationToken cancellationToken);
}
