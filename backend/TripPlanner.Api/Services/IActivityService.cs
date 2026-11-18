using TripPlanner.Api.Models;

namespace TripPlanner.Api.Services;

public interface IActivityService
{
    Task<IReadOnlyList<Activity>?> GetByTripIdAsync(int tripId, CancellationToken cancellationToken);
    Task<Activity?> GetByIdAsync(int id, CancellationToken cancellationToken);
    Task<Activity?> AddAsync(int tripId, Activity activity, CancellationToken cancellationToken);
    Task<Activity?> UpdateAsync(int id, Activity activity, CancellationToken cancellationToken);
    Task<bool> DeleteAsync(int id, CancellationToken cancellationToken);
}
