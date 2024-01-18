using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using recenziiBack.Infrastructure;
using recenziiBack.Models;
using recenziiBack.Repositories;
using recenziiBack.Services;
using System.Data;
using System.Data.Common;
using System.Text.Json.Nodes;

namespace recenziiBack.Cotrollers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecenziiController : ControllerBase
    {
        private readonly RecenziiRepository _recenziiRepository;
        private readonly JWTservice _JWTservice;

        public RecenziiController(JWTservice jWTservice)
        {
            _recenziiRepository = new RecenziiRepository(new DBconnection().ConnectToDB());
            _JWTservice = jWTservice;
        }

        [HttpGet]
        [Route("getRecenziiRestaurant/{id}")]
        [AllowAnonymous]
        public JsonResult GetRecenzii(int id)
        {
            var recenzie = _recenziiRepository.GetRecenziiRestaurant(id);

            if(!recenzie.Any())
            {
                return new JsonResult(new { success = false , message = "Nu sunt recenzii "});
            }

            return new JsonResult(new { success = true, message = "Recenzii gasite", data = recenzie });
        }

        [HttpPost]
        [Route("addRecenzie/RestaurantId={idR}/UtilizatorId={idU}")]
        [Authorize]
        public async Task<JsonResult> AddRecenzie([FromBody] AddRecenzieRestaurant recenzie, int idR, int idU)
        {
            if(ModelState.IsValid)
            {
                if(_recenziiRepository.VerificaExistentaRecenzie(idU, idR))
                {
                    return new JsonResult(new { success = false, message = "Deja ai adaugat o recenzie la acest restaurant !" });
                }

                await _recenziiRepository.AddRecenzie(recenzie, idR, idU);

                return new JsonResult(new { success = true, message = "Recenzie adaugata cu success !" });
            }

            return new JsonResult(new {success = false , message = "Fail" , errors = ModelState.Values.SelectMany(v => v.Errors) });
        }

        [HttpPut]
        [Route("updateRecenzie/{id}")]
        [Authorize]
        public async Task<JsonResult> UpdateRecenzie([FromBody] AddRecenzieRestaurant recenzie , int id)
        {
            if(ModelState.IsValid)
            {
                await _recenziiRepository.UpdateRecenzie(recenzie , id);

                return new JsonResult(new { success = true , message = "Recenzie updatata cu success ! "});
            }

            return new JsonResult(new { success = false, message = "Fail", errors = ModelState.Values.SelectMany(v => v.Errors) });
        }

        [HttpDelete]
        [Route("deleteRecenzie/{id}")]
        [Authorize]
        public JsonResult DeleteRecenzie(int id)
        {
            if(ModelState.IsValid)
            {
                _recenziiRepository.DeleteRecenzie(id);

                return new JsonResult(new { success = true, message = "Recenzie stearsa cu success !" });
            }

            return new JsonResult(new { success = false, message = "Fail", errors = ModelState.Values.SelectMany(v => v.Errors) });
        }
    }
}
