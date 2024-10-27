using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransportationSystem.Applciation.Contracts.Persistence.CompanyRepository;

namespace TransportationSystem.Applciation.DTOs.CompanyDtos.Validators
{
    public class CreateCompanyValidator:AbstractValidator<CreateCompanyDto>
    {
        private readonly ICompanyRepository _companyRepository;

        public CreateCompanyValidator(ICompanyRepository companyRepository) { 
        
            _companyRepository = companyRepository;
            Include(new BaseCompanyValidator(_companyRepository));

            
        }
    }
}
