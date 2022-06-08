using GymManagerNET.Core.Enums;
using GymManagerNET.Core.Models.DTOs.Rooms;
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
    public class ClubController : ControllerBase
    {
        private readonly IRoomService _roomService;

        public ClubController(IRoomService roomService)
        {
            _roomService = roomService;
        }

        [HttpGet("getAll")]
        public async Task<IActionResult> GetUsers()
        {
            var rooms = await _roomService.GetRooms();

            if (rooms == null)
            {
                return NotFound();
            }

            return Ok(rooms);
        }


        [HttpGet("getRoom")]
        public async Task<IActionResult> GetClient(int roomId)
        {
            var client = await _roomService.GetRoom(roomId);

            if (client == null)
            {
                return NotFound();
            }

            return Ok(client);
        }

        [HttpPost("addRoom")]
        public async Task<IActionResult> Addclient(RoomDto room)
        {
            var addedRoom = await _roomService.AddRoom(room);

            if (addedRoom == null)
            {
                return NotFound();
            }

            return Ok(addedRoom);
        }

        [HttpPut("updateRoom")]
        public async Task<IActionResult> Updateclient(RoomDto room)
        {
            var updatedRoom = await _roomService.UpdateRoom(room);

            if (updatedRoom == null)
            {
                return NotFound();
            }

            return Ok(updatedRoom);
        }


        [HttpDelete("removeRoom")]
        public async Task<IActionResult> RemoveClient(int roomId)
        {
            var removedRoom = await _roomService.RemoveRoom(roomId);

            if (removedRoom == null)
            {
                return NotFound();
            }

            return Ok(removedRoom);
        }
    }
}
