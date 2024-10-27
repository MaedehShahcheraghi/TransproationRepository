using TransportationSystem.UI.Response;

namespace TransportationSystem.UI.Contracts.UserServices
{
    public interface IUserService
    {
        Task<Response<List<long>>> GetRolesForPermission(long userId);
    }
}
