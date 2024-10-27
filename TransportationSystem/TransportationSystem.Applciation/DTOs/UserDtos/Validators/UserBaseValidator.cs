using FluentValidation;
using TransportationSystem.Applciation.Contracts.Persistence.UserRepository;

namespace TransportationSystem.Applciation.DTOs.UserDtos.Validators
{
    public class UserBaseValidator : AbstractValidator<IUserDto>
    {
        private readonly IUserRepository _userRepository;

        public UserBaseValidator(IUserRepository userRepository)
        {
            _userRepository = userRepository;


            #region UserNameValidation
            RuleFor(p => p.UserName)
               .NotEmpty()
               .WithMessage("{PropertyName} must be filled out.")
               .MustAsync(async (userName, token) =>
               {
                   var userExists = await _userRepository.UserExistByUserNameAsync(userName);
                   return !userExists; // Returns true if the user does not exist
               })
               .WithMessage("The username '{PropertyValue}' already exists. Please choose another username.");
            #endregion
            #region EmailValidation
            RuleFor(p => p.Email)
        .NotEmpty()
        .WithMessage("{PropertyName} must be filled out.")
        .MustAsync(async (Email, token) =>
        {
            var userExists = await _userRepository.UserExistByUserNameAsync(Email);
            return !userExists; // Returns true if the user does not exist
        })
        .WithMessage("The username '{PropertyValue}' already exists. Please choose another Eamil.");

            #endregion
            #region PhoneValidation

            RuleFor(p => p.Phone)
       .NotEmpty()
       .WithMessage("{PropertyName} must be filled out.")
       .MustAsync(async (Phone, token) =>
       {
           var userExists = await _userRepository.UserExistByUserNameAsync(Phone);
           return !userExists; // Returns true if the user does not exist
       })
       .WithMessage("The username '{PropertyValue}' already exists. Please choose another Phone.");
            #endregion
            #region PasswordValidation


            RuleFor(p => p.Password)
                .NotEmpty()
                .WithMessage("{PropertyName} must be filled out.")
                .MinimumLength(8)
                .WithMessage("{PropertyName} must be at least {MinLength} characters long.")
                .Matches(@"[A-Z]")
                .WithMessage("{PropertyName} must contain at least one uppercase letter.")
                .Matches(@"[a-z]")
                .WithMessage("{PropertyName} must contain at least one lowercase letter.")
                .Matches(@"[0-9]")
                .WithMessage("{PropertyName} must contain at least one number.")
                .Matches(@"[\W_]")
                .WithMessage("{PropertyName} must contain at least one special character.");

            #endregion
            #region NationalCodeValidator



            RuleFor(p => p.National_Code)
                .Matches(@"^\d{10}$")
                .WithMessage("National ID must be exactly 10 digits.")
                .When(x => !string.IsNullOrEmpty(x.National_Code)); // Only validate if NationalId is provided



            #endregion


        }
    }
}
