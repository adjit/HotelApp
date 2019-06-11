using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using HotelApp.Models;

namespace HotelApp.Controllers
{
    public class HotelController : ApiController
    {
        List<Hotel> hotels = new List<Hotel>();

        public HotelController() { }

        public HotelController(List<Hotel> hotels)
        {
            this.hotels = hotels;
        }

        public IEnumerable<Hotel> getAllHotels()
        {
            return hotels;
        }

        public async Task<IEnumerable<Hotel>> getAllHotelsAsync()
        {
            return await Task.FromResult(getAllHotels());
        }

        public IHttpActionResult getHotel(int id)
        {
            var hotel = hotels.FirstOrDefault((p) => p.ID == id);
            if (hotel == null)
                return NotFound();
            return Ok(hotel);
        }

        public async Task<IHttpActionResult> getHotelAsync(int id)
        {
            return await Task.FromResult(getHotel(id));
        }
    }
}
