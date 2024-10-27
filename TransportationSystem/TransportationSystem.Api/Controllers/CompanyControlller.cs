using MediatR;
using Microsoft.AspNetCore.Mvc;
using TransportationSystem.Applciation.DTOs.CompanyDtos;
using TransportationSystem.Applciation.Features.CityMange.Requests.Commsnds;
using TransportationSystem.Applciation.Features.CityMange.Requests.Queries;
using TransportationSystem.Applciation.Features.CompanyManage.Requests.Commands;
using TransportationSystem.Applciation.Features.CompanyManage.Requests.Queries;
using TransportationSystem.Applciation.Features.UserManage.Request.Command;
using TransportationSystem.Applciation.Features.UserManage.Request.Queries;
using TransportationSystem.Applciation.Responses.BaseResponse;

namespace TransportationSystem.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyController : Controller
    {
        private readonly IMediator _mediator;

        public CompanyController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("/Company/GetAllCompany")]
        public async Task<ActionResult<IReadOnlyList<CompanyDto>>> GetAllCompany()
        {
            var request = new GetAllCompaniesRequest();
            var result = await _mediator.Send(request);
            return Ok(result);
        }
        [HttpGet("/Company/GetCompany/{id}")]
        public async Task<ActionResult<CompanyDto>> GetCompanyById(long id)
        {
            var request = new GetCompantByIdRequest() { CompanyId = id };
            var result = await _mediator.Send(request);
            return Ok(result);
        }

        [HttpPost("/Company/CreateCompany")]
        public async Task<ActionResult<BaseCommandResponse>> CreateCompany(CreateCompanyDto createCompany)
        {
            var request = new CreateCompanyRequest() { createCompanyDto = createCompany };
            var result = await _mediator.Send(request);
            return Ok(result);
        }
        [HttpPut("/Company/EditCompany")]
        public async Task<ActionResult<BaseCommandResponse>> EditCompany(EditCompanyDto editCompany)
        {
            var request = new EditCompanyRequest() { EditCompanyDto = editCompany };
            var result = await _mediator.Send(request);
            return Ok(result);
        }
        [HttpPost("/Company/CreateUserCompany")]
        public async Task<ActionResult<BaseCommandResponse>> CreateUserCompany(UserCompanyDto userCompany)
        {
            var request = new CreateUserCompanyRequest() { UserCompanyDto = userCompany };
            var result = await _mediator.Send(request);
            return Ok(result);
        }
        [HttpGet("/Company/GetAllUserCompany")]
        public async Task<ActionResult<IReadOnlyList<UserCompanyDto>>> GetAllUserCompanies()
        {
            var request = new GetAllUserCompaniesRequest();
            var result = await _mediator.Send(request);
            return Ok(result);
        }
        [HttpGet("/Company/GetAllUsersForCompany/{companyId}")]
        public async Task<ActionResult<UserCompanyDto>> GetAllUserRole(long companyId)
        {
            var request = new GetUsersForCompanyRequest() { CompanyId = companyId };
            var result = await _mediator.Send(request);
            return Ok(result);
        }
    }
}
