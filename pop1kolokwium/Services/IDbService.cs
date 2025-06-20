using pop1kolokwium.ModelsDTOs;

namespace pop1kolokwium.Services;

public interface IDbService
{
    Task<PreservationProjectDTO?> GetVisitByIdAsync(int visitId);
    Task<object> GetPreservationProject(int id);
}
