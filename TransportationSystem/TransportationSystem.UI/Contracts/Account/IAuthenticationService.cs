using TransportationSystem.UI.ViewModels.Account;

namespace TransportationSystem.UI.Contracts.Account
{
    public interface IAuthenticationService
    {
        Task<bool> Authenticate(LoginViewModel loginVM);
        Task<bool> Register(RegistrationView registerVM,int role=0);
        Task LogOut();
    }
}
