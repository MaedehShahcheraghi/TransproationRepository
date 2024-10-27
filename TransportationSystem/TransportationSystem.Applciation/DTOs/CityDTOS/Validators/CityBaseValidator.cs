using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransportationSystem.Applciation.DTOs.CityDTOS.Validators
{
    public class CityBaseValidator:AbstractValidator<ICityDto>
    {
        public CityBaseValidator() { 
        
            RuleFor(c=> c.City_Name).NotEmpty().WithMessage("{PropertyName} Is Requierd")
                .MaximumLength(200).WithMessage("{PropertyName} Should be less than 200");
            RuleFor(c => c.City_Code).NotEmpty().WithMessage("{PropertyName} Is Requierd");
        
        }
    }
}
