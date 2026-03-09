using Microsoft.AspNetCore.Mvc;

namespace EsemkaJatiHotelAPI
{
    public class Helper
    {
        public static BadRequestObjectResult badReq(string msg)
        {
            return new BadRequestObjectResult(new { message = msg });
        }
    }
}
