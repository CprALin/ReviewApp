using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using recenziiBack.Infrastructure;
using recenziiBack.Models;
using recenziiBack.Repositories;
using recenziiBack.Services;

namespace recenziiBack.Cotrollers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RestauranteController : ControllerBase
    {
        private readonly RestauranteRepository _restaurantRepository;
        private readonly JWTservice _jwtService;

        public RestauranteController(JWTservice jwtService)
        {
            _restaurantRepository = new RestauranteRepository(new DBconnection().ConnectToDB());
            _jwtService = jwtService;
        }

        [HttpGet]
        [Route("getRestaurante")]
        [AllowAnonymous]
        public JsonResult GetRestaurante()
        {
            var restaurante = _restaurantRepository.GetAllRestaurante();

            return new JsonResult(new { success = true , message = "Lista de restaurante" , data = restaurante });
        }

        [HttpGet]
        [Route("getRestaurant/{id}")]
        [AllowAnonymous]
        public JsonResult GetRestaurant(int id)
        {
            var restaurant = _restaurantRepository.GetByIdRestaurant(id);

            if(!restaurant.Any())
            {
                return new JsonResult(new { success = false , message = "Restaurantul nu a fost gasit !"});
            }

            return new JsonResult(new { success = true , message = "Restaurantul a fost gasit" ,  data = restaurant });
        }

        [HttpPost]
        [Route("addRestaurant")]
        [Authorize(Roles = "Admin")]
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
        [Authorize(Roles = "Admin")]
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
        [Authorize(Roles = "Admin")]
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
