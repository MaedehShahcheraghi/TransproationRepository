using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransportationSystem.Applciation.Contracts.Persistence.RoleRepository;
using TransportationSystem.Applciation.Contracts.Persistence.UserRepository;

namespace TransportationSystem.Applciation.DTOs.UserDtos.Validators
{
    public class AddUserRoleDtoValidator:AbstractValidator<AddUserRoleDto>  
    {
        private readonly IUserRepository _userRepository;
        private readonly IRoleRepositories _roleRepositories;

        public AddUserRoleDtoValidator(IUserRepository userRepository,IRoleRepositories roleRepositories)
        {
            _userRepository = userRepository;
            _roleRepositories = roleRepositories;
            RuleFor(p => p.User_Id)
          .NotEmpty()
          .WithMessage("{PropertyName} must be filled out.")
            .MustAsync(async (User_Id, token) =>
            {
              var userExists = await _userRepository.ExistAsync(User_Id);
              return userExists; // Returns true if the user does  exist
          })
          .WithMessage("The user with id {PropertyValue} not found");

            RuleFor(p => p.Role_Id)
         .NotEmpty()
         .WithMessage("{PropertyName} must be filled out.")
           .MustAsync(async (Role_Id, token) =>
           {
               var userExists = await _roleRepositories.ExistAsync(Role_Id);
               return userExists; // Returns true if the user does  exist
           })
         .WithMessage("The Role with id {PropertyValue} not found");
        }
    }
}
