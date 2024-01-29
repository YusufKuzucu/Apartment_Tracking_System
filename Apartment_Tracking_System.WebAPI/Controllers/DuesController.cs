using Apartment_Tracking_System.Application.Constants;
using Apartment_Tracking_System.Application.Dto.DuesDto;
using Apartment_Tracking_System.Application.Dto.ManagersDto;
using Apartment_Tracking_System.Application.Interfaces.Repositories;
using Apartment_Tracking_System.Domain.Entities;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Apartment_Tracking_System.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DuesController : ControllerBase
    {
        private readonly IDuesService _duesService;
        private readonly IMapper _mapper;
        private readonly ILogger<DuesController> _logger;

        public DuesController(IDuesService duesService, IMapper mapper, ILogger<DuesController> logger)
        {
            _duesService = duesService;
            _mapper = mapper;
            _logger = logger;
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAllDues()
        {
            var getAllDues = await _duesService.GetAllAsync();
            if (getAllDues !=null)
            {
                var getAll = _mapper.Map<List<Dues>, List<DuesListDto>>(getAllDues);
                return Ok(getAll);
            }
            return BadRequest(Messages.DuesGetAllFailed);

        }

        [HttpGet("Get")]
        public async Task<IActionResult> GetDues(int id)
        {
            var getDues = await _duesService.GetByIdAsync(id);
            if (getDues !=null)
            {
                var get = _mapper.Map<Dues, DuesListDto>(getDues);
                return Ok(get);
            }
            return BadRequest(Messages.DuesGetFailed);
        }
        [HttpPost("Post")]
        public async Task<IActionResult> PostDues(CreateDuesDto createDuesDto)
        {
            var dues = _mapper.Map<CreateDuesDto, Dues>(createDuesDto);
            await _duesService.AddAsync(dues);
            return Ok(Messages.DuesAdded);

        }
        [HttpDelete("Delete")]
        public async Task<IActionResult> RemoveDues(RemoveDuesDto removeDuesDto)
        {
            var removeDues = await _duesService.GetByIdAsync(removeDuesDto.Id);
            if (removeDues != null)
            {
                await _duesService.RemoveAsync(removeDues);
                return Ok(Messages.DuesRemove);
            }
            return BadRequest(Messages.DuesRemoveFailed);


        }
        [HttpPut("Update")]
        public async Task<IActionResult> UpdateDues(UpdateDuesDto updateDuesDto)
        {
            var dues = _mapper.Map<UpdateDuesDto, Dues>(updateDuesDto);
            await _duesService.UpdateAsync(dues);
            return Ok(Messages.DuesUpdated);

        }
    }
}
