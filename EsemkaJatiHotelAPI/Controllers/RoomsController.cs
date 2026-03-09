using EsemkaJatiHotelAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EsemkaJatiHotelAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoomsController : ControllerBase
    {
        private readonly EsemkaJatiHotelContext dbc;
        public RoomsController(EsemkaJatiHotelContext ctx) { dbc = ctx; }

        [HttpGet]
        async public Task<IActionResult> GetAll()
        {
            var rooms = await dbc.ReservationRooms.Where(rr => rr.CheckOutDateTime == null).Select(rr => new { id = rr.RoomId, name = rr.Room.RoomNumber }).ToListAsync();
            return Ok(rooms);
        }
    }
}
