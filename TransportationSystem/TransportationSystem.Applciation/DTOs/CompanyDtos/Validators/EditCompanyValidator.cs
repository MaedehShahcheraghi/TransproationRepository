using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransportationSystem.Applciation.Contracts.Persistence.CompanyRepository;

namespace TransportationSystem.Applciation.DTOs.CompanyDtos.Validators
{
    public class EditCompanyValidator:AbstractValidator<EditCompanyDto>
    {
        private readonly ICompanyRepository _companyRepository;

        public EditCompanyValidator(ICompanyRepository companyRepository)
        {

            _companyRepository = companyRepository;
            Include(new BaseCompanyValidator(_companyRepository));
            RuleFor(c => c.Id).NotEmpty().WithMessage("{PropertyName} Is Requierd.");

        }
    }
}
