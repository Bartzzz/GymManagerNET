using GymManagerNET.Core.Enums;
using GymManagerNET.Core.Models.DTOs.Rooms;
using GymManagerNET.Core.Models.DTOs.RoomsBooking;
using GymManagerNET.Core.Services.RoomBookings;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GymManagerNET.Controllers
{
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme,
       Roles = $"{UserType.Manager}")]
    [Route("[controller]")]
    public class RoomBookingController : ControllerBase
    {
        private readonly IRoomBookingService _roomBookingService;

        public RoomBookingController(IRoomBookingService roomBookingService)
        {
            _roomBookingService = roomBookingService;
        }

        [HttpGet("getAll")]
        public async Task<IActionResult> GetRoomBookings()
        {
            var bookings = await _roomBookingService.GetRoomBookings();

            if (bookings == null)
            {
                return NotFound();
            }

            return Ok(bookings);
        }


        [HttpGet("getBooking")]
        public async Task<IActionResult> GetRoomBooking(int roomId)
        {
            var client = await _roomBookingService.GetRoomBooking(roomId);

            if (client == null)
            {
                return NotFound();
            }

            return Ok(client);
        }

        [HttpPost("addBooking")]
        public async Task<IActionResult> AddRoomBooking(RoomBookingDto booking)
        {
            var addedBooking = await _roomBookingService.AddRoomBooking(booking);

            if (addedBooking == null)
            {
                return NotFound();
            }

            return Ok(addedBooking);
        }

        [HttpPut("updateBooking")]
        public async Task<IActionResult> UpdateBooking(RoomBookingDto booking)
        {
            var updatedBooking = await _roomBookingService.UpdateRoomBooking(booking);

            if (updatedBooking == null)
            {
                return NotFound();
            }

            return Ok(updatedBooking);
        }


        [HttpDelete("removeBooking")]
        public async Task<IActionResult> RemoveBooking(int bookingId)
        {
            var removedBooking = await _roomBookingService.RemoveRoomBooking(bookingId);

            if (removedBooking == null)
            {
                return NotFound();
            }

            return Ok(removedBooking);
        }
    }
}
