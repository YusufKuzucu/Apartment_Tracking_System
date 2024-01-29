using Apartment_Tracking_System.Application.Constants;
using Apartment_Tracking_System.Application.Dto.ManagersDto;
using Apartment_Tracking_System.Application.Interfaces.Repositories;
using Apartment_Tracking_System.Domain.Entities;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Apartment_Tracking_System.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ManagersController : ControllerBase
    {
        private readonly IManagerService _managerService;
        private readonly IMapper _mapper;
        private readonly ILogger<ManagersController> _logger;

        public ManagersController(IManagerService managerService, IMapper mapper, ILogger<ManagersController> logger)
        {
            _managerService = managerService;
            _mapper = mapper;
            _logger = logger;
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAllManager()
        {
            var getAllManager = await _managerService.GetAllAsync();
            if (getAllManager != null)
            {
                var getAll = _mapper.Map<List<Manager>, List<ManagerListDto>>(getAllManager);
                return Ok(getAll);
            }
            return BadRequest(Messages.ManagerGetAllFailed);
        }

        [HttpGet("Get")]
        public async Task<IActionResult> GetManager(int id)
        {
            var getManager = await _managerService.GetByIdAsync(id);
            if (getManager != null)
            {
                var get = _mapper.Map<Manager, ManagerListDto>(getManager);
              
                return Ok(get);
          
            }
            return BadRequest(Messages.ManagerGetFailed);
        }
        [HttpPost("Post")]
        public async Task<IActionResult> PostManager(CreateManagerDto createManagerDto)
        {
            var manager = _mapper.Map<CreateManagerDto, Manager>(createManagerDto);
            await _managerService.AddAsync(manager);
            _logger.LogInformation("Manager Added.");
            return Ok(Messages.ManagerAdded);

        }
        [HttpDelete("Delete")]
        public async Task<IActionResult> RemoveManager(RemoveManagerDto removeManagerDto)
        {
            var removeManager = await _managerService.GetByIdAsync(removeManagerDto.Id);
            if (removeManager != null)
            {
                await _managerService.RemoveAsync(removeManager);
                return Ok(Messages.ManagerRemove);
            }
            return BadRequest(Messages.ManagerRemoveFailed);
        }
        [HttpPut("Update")]
        public async Task<IActionResult> UpdateManager(UpdateManagerDto updateManagerDto)
        {
            var manager = _mapper.Map<UpdateManagerDto, Manager>(updateManagerDto);
            await _managerService.UpdateAsync(manager);
            return Ok(Messages.ManagerUpdated);
        }
    }
}
