using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using recenziiBack.Infrastructure;
using recenziiBack.Models;
using recenziiBack.Repositories;

namespace recenziiBack.Cotrollers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UtilizatoriController : ControllerBase
    {
        private readonly UtilizatoriRepository _utilizatoriRepository;

        public UtilizatoriController()
        {
            _utilizatoriRepository = new UtilizatoriRepository(new DBconnection().ConnectToDB());
        }

        //POST : api/utilizatori/inregistrare
        [HttpPost]
        [Route("inregistrare")]
        public JsonResult Inregistrare([FromBody] Utilizatori utilizator)
        {
            if(ModelState.IsValid)
            {
                _utilizatoriRepository.InregistreazaUtilizator(utilizator);

                return new JsonResult(new {success = true , message = "Utilizator inregistrat cu success . "});
            }

            return new JsonResult(new { success = false , message = "Fail" , errors = ModelState.Values.SelectMany(v => v.Errors)});
        }
    }
}
