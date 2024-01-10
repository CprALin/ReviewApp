using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using recenziiBack.Infrastructure;
using recenziiBack.Repositories;

namespace recenziiBack.Cotrollers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RestauranteController : ControllerBase
    {
        private readonly RestauranteRepository _repository;

        public RestauranteController()
        {
            _repository = new RestauranteRepository(new DBconnection().ConnectToDB());
        }

        [HttpGet]
        [Route("getRestaurante")]
        public JsonResult GetRestaurante()
        {
            var restaurante = _repository.GetAllRestaurante();

            return new JsonResult(new { success = true , message = "Lista de restaurante" , data = restaurante });
        }
    }
}
