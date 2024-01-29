using Apartment_Tracking_System.Application.Constants;
using Apartment_Tracking_System.Application.Dto.ApartmentsDto;
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
    public class ApartmentsController : ControllerBase
    {
        private readonly IApartmentService _apartmentService;
        private readonly IMapper _mapper;

        public ApartmentsController(IApartmentService apartmentService, IMapper mapper)
        {
            _apartmentService = apartmentService;
            _mapper = mapper;
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAllApartment()
        {
            var getAllApartment = await _apartmentService.GetAllAsync();
            if(getAllApartment != null)
            {
                var getAll = _mapper.Map<List<Apartment>, List<ApartmentListDto>>(getAllApartment);
                return Ok(getAll);
            }
            return BadRequest(Messages.ApartmentGetAllFailed);

        }

        [HttpGet("Get")]
        public async Task<IActionResult> GetApartment(int id)
        {
            var getApartment = await _apartmentService.GetByIdAsync(id);
            if(getApartment != null)
            {
                var get = _mapper.Map<Apartment, ApartmentListDto>(getApartment);
                return Ok(get);
            }
            return BadRequest(Messages.ApartmentGetFailed);
        }
        [HttpPost("Post")]
        public async Task<IActionResult> PostApartment(CreateApartmentDto createApartmentDto)
        {
            var apartment = _mapper.Map<CreateApartmentDto, Apartment>(createApartmentDto);
            await _apartmentService.AddAsync(apartment);
            return Ok(Messages.ApartmentAdded);

        }
        [HttpDelete("Delete")]
        public async Task<IActionResult> RemoveApartment(RemoveApartmentDto removeApartmentDto)
        {
            var removeApartment = await _apartmentService.GetByIdAsync(removeApartmentDto.Id);
            if (removeApartment != null)
            {
                await _apartmentService.RemoveAsync(removeApartment);
                return Ok(Messages.ApartmentRemove);
            }
            return BadRequest(Messages.ApartmentRemoveFailed);
        }
        [HttpPut("Update")]
        public async Task<IActionResult> UpdateApartment(UpdateApartmentDto updateApartmentDto)
        {
            var apartment = _mapper.Map<UpdateApartmentDto, Apartment>(updateApartmentDto);
            await _apartmentService.UpdateAsync(apartment);
            return Ok(Messages.ApartmentUpdated);

        }
    }
}
