using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using recenziiBack.Infrastructure;
using recenziiBack.Models;
using recenziiBack.Repositories;

namespace recenziiBack.Cotrollers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RestauranteController : ControllerBase
    {
        private readonly RestauranteRepository _restaurantRepository;

        public RestauranteController()
        {
            _restaurantRepository = new RestauranteRepository(new DBconnection().ConnectToDB());
        }

        [HttpGet]
        [Route("getRestaurante")]
        public JsonResult GetRestaurante()
        {
            var restaurante = _restaurantRepository.GetAllRestaurante();

            return new JsonResult(new { success = true , message = "Lista de restaurante" , data = restaurante });
        }

        [HttpGet]
        [Route("getRestaurant/{id}")]
        public JsonResult GetRestaurant(int id)
        {
            var restaurant = _restaurantRepository.GetByIdRestaurant(id);

            if(!restaurant.Any())
            {
                return new JsonResult(new { success = false , message = "Restaurant Not Found"});
            }

            return new JsonResult(new { success = true , message = "Restaurant Found" ,  data = restaurant });
        }

        [HttpPost]
        [Route("addRestaurant")]
        public async Task<JsonResult> AddRestaurant([FromBody] AdaugaRestaurant restaurant)
        {
            if(ModelState.IsValid)
            {
                await _restaurantRepository.AddRestaurant(restaurant);

                return new JsonResult(new { success = true , message = "Restaurant adaugat cu success !"});
            }

            return new JsonResult(new { success = false, message = "Fail", errors = ModelState.Values.SelectMany(v => v.Errors) });
        }

        [HttpPut]
        [Route("updateRestaurant/{id}")]
        public async Task<JsonResult> UpdateRestaurant([FromBody] AdaugaRestaurant restaurant , int id)
        {
            if(ModelState.IsValid)
            {
                await _restaurantRepository.UpdateRestaurant(restaurant , id);

                return new JsonResult(new { success = true, message = "Restaurant updatat cu success !" });
            }

            return new JsonResult(new { success = false, message = "Fail", errors = ModelState.Values.SelectMany(v => v.Errors) });
        }

        [HttpDelete]
        [Route("deleteRestaurant/{id}")]
        public JsonResult DeleteRestaurant(int id)
        {
            if (ModelState.IsValid)
            {
                _restaurantRepository.DeleteRestaurant(id);

                return new JsonResult(new { success = true, message = "Restaurantul a fost sters !" });
            }

            return new JsonResult(new { success = false  ,  message = "Fail" , errors = ModelState.Values.SelectMany(v => v.Errors) });
        }
    }
}
