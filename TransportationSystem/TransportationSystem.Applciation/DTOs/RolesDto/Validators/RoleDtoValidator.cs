using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransportationSystem.Applciation.DTOs.RolesDto.Validators
{
    public class RoleDtoValidator:AbstractValidator<IRoleDto>
    {
        public RoleDtoValidator()
        {

            RuleFor(p => p.Role_Name)
              .NotEmpty()
              .WithMessage("{PropertyName} must be filled out.");
        }
    }
}
