using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransportationSystem.Applciation.DTOs.RolesDto.Validators
{
    public class EidtRoleDtoValidator:AbstractValidator<EditRoleDto>
    {
        public EidtRoleDtoValidator()
        {
            Include(new RoleDtoValidator());
            RuleFor(p => p.Id).NotNull()
                 .WithMessage("{PropertyName} is required.");
        }
    }
}
