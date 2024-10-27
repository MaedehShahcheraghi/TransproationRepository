using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransportationSystem.Applciation.DTOs.CityDTOS.Validators
{
    public class EditCityValidator:AbstractValidator<EditCityDto>
    {
        public EditCityValidator()
        {
            Include(new CityBaseValidator());
            RuleFor(c=> c.Id).NotEmpty().WithMessage("{PropertyName} Is Requierd.");
        }
    }
}
