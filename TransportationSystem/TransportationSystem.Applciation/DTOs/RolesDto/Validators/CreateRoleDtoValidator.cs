using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransportationSystem.Applciation.DTOs.RolesDto.Validators
{
    public class CreateRoleDtoValidator:AbstractValidator<CreateRoleDto>
    {
        public CreateRoleDtoValidator()
        {
            Include(new RoleDtoValidator());
        }
    }
}
