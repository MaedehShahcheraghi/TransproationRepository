using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransportationSystem.Applciation.DTOs.CityDTOS.Validators
{
    public class CreateCityValidator:AbstractValidator<CreateCityDto>
    {
        public CreateCityValidator()
        {
                Include(new CityBaseValidator());
                
        }
    }
}
