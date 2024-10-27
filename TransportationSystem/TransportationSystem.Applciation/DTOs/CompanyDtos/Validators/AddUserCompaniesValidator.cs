using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransportationSystem.Applciation.Contracts.Persistence.CompanyRepository;
using TransportationSystem.Applciation.Contracts.Persistence.RoleRepository;
using TransportationSystem.Applciation.Contracts.Persistence.UserRepository;

namespace TransportationSystem.Applciation.DTOs.CompanyDtos.Validators
{
    public class AddUserCompaniesValidator:AbstractValidator<AddUserCompaniesDto>
    {
        private readonly IUserRepository _userRepository;
        private readonly ICompanyRepository _companyRepository;

        public AddUserCompaniesValidator(IUserRepository userRepository,ICompanyRepository companyRepository)
        {
           _userRepository = userRepository;
           _companyRepository = companyRepository;

            RuleFor(p => p.UserId)
         .NotEmpty()
         .WithMessage("{PropertyName} must be filled out.")
            .MustAsync(async (userId, token) =>
            {
               var userExists = await _userRepository.ExistAsync(userId);
               return userExists; // Returns true if the user does  exist
           })
         .WithMessage("The Role with id {PropertyValue} not found");

            RuleFor(p => p.CompanyId)
         .NotEmpty()
         .WithMessage("{PropertyName} must be filled out.")
           .MustAsync(async (companyId, token) =>
           {
               var CompanyExist = await _companyRepository.ExistAsync(companyId);
               return CompanyExist; // Returns true if the user does  exist
           })
         .WithMessage("The Role with id {PropertyValue} not found");
        }
    }
}
