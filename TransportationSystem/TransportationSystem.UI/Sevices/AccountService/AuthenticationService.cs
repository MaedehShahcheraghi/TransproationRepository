using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using System.IdentityModel.Tokens.Jwt;
using System.Linq.Expressions;
using System.Security.Claims;
using TransportationSystem.UI.Contracts.Account;
using TransportationSystem.UI.Contracts.LocalStorage;
using TransportationSystem.UI.Sevices.Base;
using TransportationSystem.UI.ViewModels.Account;
using TransportationSystem.UI.Constants;

namespace TransportationSystem.UI.Sevices.Account
{
    public class AuthenticationService : BaseHttpService, TransportationSystem.UI.Contracts.Account.IAuthenticationService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private JwtSecurityTokenHandler _jwtSecurityTokenHandler;

        public AuthenticationService(ILocalStorageService localStorage, IClient client, IHttpContextAccessor httpContextAccessor
            ) : base(client, localStorage)
        {
            this._httpContextAccessor = httpContextAccessor;
            _jwtSecurityTokenHandler = new JwtSecurityTokenHandler();
        }
        public async Task<bool> Authenticate(LoginViewModel loginVM)
        {
            try
            {
                AuthRequest authRequest = new()
                {
                    UserName = loginVM.UserName,
                    Password = loginVM.Password
                };
                var response = await client.LoginAsync(authRequest);
                if (response.Token != string.Empty)
                {
                    var content = _jwtSecurityTokenHandler.ReadJwtToken(response.Token);
                    var claims = ParseClaim(content);
                    var user = new ClaimsPrincipal(new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme));
                    var login = _httpContextAccessor.HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, user);
                    localStorage.SeTStorgeValue<string>("Token", response.Token);

                    return true;
                }
                return false;
            }
            catch
            {

                return false;
            }
        }

        public async Task LogOut()
        {
            localStorage.ClearStorage(new List<string> { "Token" });
            await _httpContextAccessor.HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
        }

        public async Task<bool> Register(RegistrationView registerVM,int role=0)
        {
            try
            {
                var registerationRequest = new RegisterationRequest()
                {
                    Email = registerVM.registerViewModel.Email,
                    FirstName = registerVM.registerViewModel.FirstName,
                    LastName = registerVM.registerViewModel.LastName,
                    UserName = registerVM.registerViewModel.UserName,
                    Password = registerVM.registerViewModel.Password,
                    National_Code = registerVM.registerViewModel.National_Code,
                    Phone = registerVM.registerViewModel.Phone,
                   
                }; 
                var response = await client.RegisterAsync(role,registerationRequest);
                if (registerVM.CompanyViewModel!=null && role==5)
                {
                    #region SaveCompany
                    var company = new CreateCompanyDto()
                    {
                        Company_Code = registerVM.CompanyViewModel.Company_Code,
                        Company_Name = registerVM.CompanyViewModel.Company_Name,
                        RegisterationNumber = registerVM.CompanyViewModel.RegisterationNumber,
                        Address = registerVM.CompanyViewModel.Address
                    };
                    var result = await client.CreateCompanyAsync(company);
                    if (!result.Success) {
                        throw new Exception("Create company failed");
                    }
                    var usercompany = new UserCompanyDto()
                    {
                        CompanyId = result.Id,
                        UsersId = new List<long> { response.UserId }
                    };
                    var resultusercompany=await client.CreateUserCompanyAsync(usercompany);
                    if (!resultusercompany.Success)
                    {
                        throw new Exception("Create Usercompany failed");
                    }
                    #endregion
                }



                if (response.Success)
                {
                    return true;
                }
                else { 
                return false;
                }
            }
            catch
            {

                return false;
            }

        }



        #region Utility
        private IList<Claim> ParseClaim(JwtSecurityToken jwtToken)
        {
            var claims = jwtToken.Claims.ToList();
            claims.Add(new Claim(CustomClaimTypes.UName, jwtToken.Claims.First(u=> u.Type==CustomClaimTypes.UName).ToString()));
            return claims;
        }
        #endregion
    }
}
