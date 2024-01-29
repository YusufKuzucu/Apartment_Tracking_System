using Apartment_Tracking_System.Application.Constants;
using Apartment_Tracking_System.Application.Dto.FlatDto;
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
    public class FlatsController : ControllerBase
    {
        private readonly IFlatService _flatService;
        private readonly IApartmentService _apartmentService;
        private readonly IMapper _mapper;
        private readonly ILogger<FlatsController> _logger;

        public FlatsController(IFlatService flatService, IApartmentService apartmentService, IMapper mapper, ILogger<FlatsController> logger)
        {
            _flatService = flatService;
            _apartmentService = apartmentService;
            _mapper = mapper;
            _logger = logger;
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAllFlat()
        {
            var getAllFlat = await _flatService.GetAllAsync();
            if (getAllFlat !=null)
            {
                var getAll = _mapper.Map<List<Flat>, List<FlatListDto>>(getAllFlat);
                return Ok(getAll);
            }
            return BadRequest(Messages.FlatGetAllFailed);
        }

        [HttpGet("Get")]
        public async Task<IActionResult> GetFlat(int id)
        {
            var getFlat = await _flatService.GetByIdAsync(id);
            if (getFlat != null) 
            {
                var get = _mapper.Map<Flat, FlatListDto>(getFlat);
                return Ok( get);
            }
            return BadRequest(Messages.FlatGetFailed);

        }
        [HttpPost("Post")]
        public async Task<IActionResult> PostFlat(CreateFlatDto createFlatDto)
        {
            var flat = _mapper.Map<CreateFlatDto, Flat>(createFlatDto);
            var existingFlat = await _flatService.FlatExistByFlatNoAsync(flat.FlatNo);

            if (existingFlat)
            {
                return BadRequest(Messages.FlatAddedFlatFailed);
            }


            var apartment = await _apartmentService.GetByIdAsync(flat.ApartmentId);

            var flatCountInApartment = await _flatService.GetFlatCountByApartmentIdAsync(flat.ApartmentId);

            if (flatCountInApartment <= apartment.FlatNumber)
            {
                await _flatService.AddAsync(flat);
                return Ok(Messages.FlatAdded);
            }
            return BadRequest(Messages.FlatAddedApartmentFailed);
        }
        [HttpDelete("Delete")]
        public async Task<IActionResult> RemoveFlat(RemoveFlatDto removeFlatDto)
        {
            var removeFlat= await _flatService.GetByIdAsync(removeFlatDto.Id);
            if (removeFlat != null)
            {
                await _flatService.RemoveAsync(removeFlat);
                return Ok(Messages.FlatRemove);
            }
            return BadRequest(Messages.FlatRemoveFailed);


        }
        [HttpPut("Update")]
        public async Task<IActionResult> UpdateFlat(UpdateFlatDto updateFlatDto)
        {
            var flat = _mapper.Map<UpdateFlatDto, Flat>(updateFlatDto);
            await _flatService.UpdateAsync(flat);
            return Ok(Messages.FlatUpdated);
        }
        [HttpGet("IsVacant")]
        public async Task<IActionResult> GetVacant()
        {
            var vacantFlats = await _flatService.GetAllAsync(x => x.IsVacant == false);
            var flats = _mapper.Map<List<Flat>,List <FlatListDto>>(vacantFlats);
            return Ok(flats);
        }

    }
}
