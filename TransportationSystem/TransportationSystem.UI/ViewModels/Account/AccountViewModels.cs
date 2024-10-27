using System.ComponentModel.DataAnnotations;

namespace TransportationSystem.UI.ViewModels.Account
{
   public class LoginViewModel
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public bool RememberMe { get; set; }

    }
    public class RegisterViewModel
    {
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }
        [Compare("Password")]
        public string RePassword { get; set; }
        public string Email { get; set; }
        public string? National_Code { get; set; }
        public string Phone { get; set; }
    }
    public class CompanyViewModel {
        public int Company_Code { get; set; }
        public string Company_Name { get; set; }
        public string RegisterationNumber { get; set; }
        public string Address { get; set; }

    }
    public class  RegistrationView
    {
        public RegisterViewModel registerViewModel { get; set; }
        public CompanyViewModel? CompanyViewModel { get; set; }
    }

}
