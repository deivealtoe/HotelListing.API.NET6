using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HotelListing.API.Data;
using HotelListing.API.Models;
using AutoMapper;
using HotelListing.API.Dto.Hotel;
using HotelListing.API.Dto.Country;
using HotelListing.API.Contracts;

namespace HotelListing.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HotelsController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IHotelsRepository _hotelsRepository;

        public HotelsController(IMapper mapper, IHotelsRepository hotelsRepository)
        {
            this._mapper = mapper;
            this._hotelsRepository = hotelsRepository;
        }

        // GET: api/Hotels
        [HttpGet]
        public async Task<ActionResult<IEnumerable<HotelDto>>> GetHotels()
        {
            List<Hotel> hotels = await _hotelsRepository.GetAllAsync();

            List<HotelDto> hotelsDto = _mapper.Map<List<HotelDto>>(hotels);

            return Ok(hotelsDto);
        }

        // GET: api/Hotels/5
        [HttpGet("{id}")]
        public async Task<ActionResult<HotelDetailsDto>> GetHotel(int id)
        {
            var hotel = await _hotelsRepository.GetDetails(id);

            if (hotel == null)
            {
                return NotFound();
            }

            var hotelDto = _mapper.Map<HotelDetailsDto>(hotel);

            return Ok(hotelDto);
        }

        // PUT: api/Hotels/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutHotel(int id, PutHotelDto putHotelDto)
        {
            if (id != putHotelDto.Id)
            {
                return BadRequest();
            }

            //_context.Entry(putHotelDto).State = EntityState.Modified;
            var hotel = await _hotelsRepository.GetAsync(id);

            if (hotel == null)
            {
                return NotFound();
            }

            _mapper.Map(putHotelDto, hotel);

            try
            {
                await _hotelsRepository.UpdateAsync(hotel);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await _hotelsRepository.Exists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Hotels
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Hotel>> PostHotel(CreateHotelDto createHotelDto)
        {
            if (_hotelsRepository == null)
            {
                return Problem("Entity set 'HotelListingDbContext.Hotels'  is null.");
            }

            var hotel = _mapper.Map<Hotel>(createHotelDto);

            await _hotelsRepository.AddAsync(hotel);

            return CreatedAtAction("GetHotel", new { id = hotel.Id }, hotel);
        }

        // DELETE: api/Hotels/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<HotelDto>> DeleteHotel(int id)
        {
            var hotel = await _hotelsRepository.GetAsync(id);
            
            if (hotel == null)
            {
                return NotFound();
            }

            var hotelDto = _mapper.Map<HotelDto>(hotel);

            await _hotelsRepository.DeleteAsync(id);

            return Ok(hotelDto);
        }
    }
}
