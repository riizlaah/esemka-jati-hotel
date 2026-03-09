using EsemkaJatiHotelAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EsemkaJatiHotelAPI.Controllers
{
    [Route("api/items")]
    [ApiController]
    public class FoodNDrinksController : ControllerBase
    {
        private readonly EsemkaJatiHotelContext dbc;
        public FoodNDrinksController(EsemkaJatiHotelContext ctx) { dbc = ctx; }

        [HttpGet]
        async public Task<IActionResult> GetAll(string type = "F")
        {
            if (type != "F" && type != "D") return Helper.badReq("Type must be 'F' or 'D'");
            var items = await dbc.FoodAndDrinks.Where(fd => fd.Type == type).Select(fd => new {id = fd.Id, name = fd.Name, price = fd.Price}).ToListAsync();
            return Ok(items);
        }

        [HttpPost]
        async public Task<IActionResult> PurchaseItem(PurchaseFD input)
        {
            if(!dbc.ReservationRooms.Any(rr => rr.RoomId == input.roomId && rr.CheckOutDateTime == null))
            {
                return Helper.badReq("Room not found!");
            }
            var resvRoom = await dbc.ReservationRooms.Include(rr => rr.Reservation).Where(rr => rr.RoomId == input.roomId && rr.CheckOutDateTime == null).FirstAsync();
            if (!dbc.FoodAndDrinks.Any(fd => fd.Id == input.FDId))
            {
                return Helper.badReq("Item not found!");
            }
            var fd = await dbc.FoodAndDrinks.Where(fd => fd.Id == input.FDId).FirstAsync();
            await dbc.Fdcheckouts.AddAsync(new Fdcheckout
            {
                EmployeeId = resvRoom.Reservation.EmployeeId,
                Fdid = input.FDId,
                Qty = input.quantity,
                ReservationRoomId = resvRoom.Id,
                TotalPrice = input.quantity * fd.Price
            });
            await dbc.SaveChangesAsync();
            return Ok();
        }
    }
}


