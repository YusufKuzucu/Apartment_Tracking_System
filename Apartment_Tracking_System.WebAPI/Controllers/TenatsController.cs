using Apartment_Tracking_System.Application.Constants;
using Apartment_Tracking_System.Application.Dto.ManagersDto;
using Apartment_Tracking_System.Application.Dto.TenantsDto;
using Apartment_Tracking_System.Application.Interfaces.Repositories;
using Apartment_Tracking_System.Domain.Entities;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Apartment_Tracking_System.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TenatsController : ControllerBase
    {
        private readonly ITenantService _tenantService;
        private readonly IMapper _mapper;
        private readonly ILogger<TenatsController> _logger;

        public TenatsController(ITenantService tenantService, IMapper mapper, ILogger<TenatsController> logger)
        {
            _tenantService = tenantService;
            _mapper = mapper;
            _logger = logger;
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAllTenant()
        {
            var getAllTenant = await _tenantService.GetAllAsync();
            if (getAllTenant !=null)
            {
                var getAll = _mapper.Map<List<Tenant>, List<TenantListDto>>(getAllTenant);
                return Ok(getAll);
            }
            return BadRequest(Messages.TenantGetAllFailed);
        }

        [HttpGet("Get")]
        public async Task<IActionResult> GetTenant(int id)
        {
            var getTenant = await _tenantService.GetByIdAsync(id);
            if (getTenant !=null)
            {
                var get = _mapper.Map<Tenant, TenantListDto>(getTenant);
                return Ok(get);
            }
            return BadRequest(Messages.TenantGetFailed);
        }
        [HttpPost("Post")]
        public async Task<IActionResult> PostTenant(CreateTenantDto createTenantDto)
        {
            var tenant = _mapper.Map<CreateTenantDto, Tenant>(createTenantDto);
            await _tenantService.AddAsync(tenant);
            return Ok(Messages.TenantAdded);

        }
        [HttpDelete("Delete")]
        public async Task<IActionResult> RemoveTenant(RemoveTenantDto removeTenantDto)
        {
            var removeTenant = await _tenantService.GetByIdAsync(removeTenantDto.Id);
            if (removeTenant != null)
            {
                await _tenantService.RemoveAsync(removeTenant);
                return Ok(Messages.TenantRemove);
            }
            return BadRequest(Messages.TenantRemoveFailed);


        }
        [HttpPut("Update")]
        public async Task<IActionResult> UpdateTenant(UpdateTenantDto updateTenantDto)
        {
            var tenant = _mapper.Map<UpdateTenantDto, Tenant>(updateTenantDto);
            await _tenantService.UpdateAsync(tenant);
            return Ok(Messages.TenantUpdated);
        }
    }
}
