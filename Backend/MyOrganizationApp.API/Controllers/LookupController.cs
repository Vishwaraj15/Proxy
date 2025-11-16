using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyOrganizationApp.Application.Services.Interface;
using MyOrganizationApp.Domain.Entities;
using System.Threading.Tasks;

namespace MyOrganizationApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LookupController : ControllerBase
    {
        private readonly ILogger<LookupController> _logger;
        private readonly ILookupService _lookupService;
        public LookupController(ILookupService lookupService, ILogger<LookupController> logger)
        {
            _lookupService = lookupService;
            _logger = logger;
        }

        [HttpGet]
        [Route("GetAllEmployeeDepartmentDetails")]
        public async Task<IEnumerable<VwEmployeeDepartmentDetail>> GetAllEmployeeDepartmentDetailsAsync()
        {
           return await _lookupService.GetAllEmployeeDepartmentDetailsAsync();
        }
    }
}
