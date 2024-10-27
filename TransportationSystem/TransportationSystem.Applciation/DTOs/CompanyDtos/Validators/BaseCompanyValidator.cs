using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransportationSystem.Applciation.Contracts.Persistence.CompanyRepository;
using TransportationSystem.Applciation.Contracts.Persistence.UserRepository;

namespace TransportationSystem.Applciation.DTOs.CompanyDtos.Validators
{
    public class BaseCompanyValidator : AbstractValidator<ICompanyDto>
    {
        private readonly ICompanyRepository _companyRepository;

        public BaseCompanyValidator(ICompanyRepository companyRepository)
        {
            _companyRepository = companyRepository;

            RuleFor(p => p.RegisterationNumber)
                   .NotEmpty()
                   .WithMessage("{PropertyName} must be filled out.")
                   .MustAsync(async (registerNumber, token) =>
                   {
                       var userExists = await _companyRepository.CompanyExistByRegisterationNumberAsync(registerNumber);
                       return !userExists; // Returns true if the user does not exist
                   })
                   .WithMessage("The Company '{PropertyValue}' already exists. Please choose another Company.");


        }
    }
}
