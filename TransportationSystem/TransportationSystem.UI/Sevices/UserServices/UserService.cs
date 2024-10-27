using System.IdentityModel.Tokens.Jwt;
using TransportationSystem.UI.Contracts.LocalStorage;
using TransportationSystem.UI.Contracts.UserServices;
using TransportationSystem.UI.Response;
using TransportationSystem.UI.Sevices.Base;

namespace TransportationSystem.UI.Sevices.UserServices
{
    public class UserService : BaseHttpService, IUserService
    {

        private readonly IHttpContextAccessor _httpContextAccessor;
        private JwtSecurityTokenHandler _jwtSecurityTokenHandler;

        public UserService(ILocalStorageService localStorage, IClient client, IHttpContextAccessor httpContextAccessor
            ) : base(client, localStorage)
        {
            this._httpContextAccessor = httpContextAccessor;
            _jwtSecurityTokenHandler = new JwtSecurityTokenHandler();
        }
        public Task<Response<List<long>>> GetRolesForPermission(long userId)
        {
            throw new NotImplementedException();
        }
    }
}
