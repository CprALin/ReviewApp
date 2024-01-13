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
        public async Task<JsonResult> Inregistrare([FromBody] UtilizatoriInregistrare utilizator)
        {
            if(ModelState.IsValid)
            {
                await _utilizatoriRepository.InregistreazaUtilizator(utilizator);

                return new JsonResult(new {success = true , message = "Utilizator inregistrat cu success . "});
            }

            return new JsonResult(new { success = false , message = "Fail" , errors = ModelState.Values.SelectMany(v => v.Errors)});
        }

        [HttpPost]
        [Route("autentificare")]
        public async Task<JsonResult> Autentificare([FromBody] UtilizatorAutentificare utilizator)
        {
            if (ModelState.IsValid)
            {
                int idProfil = await _utilizatoriRepository.AutentificareUtilizator(utilizator);

                //Console.WriteLine(idProfil);
                
                if(idProfil != -1)
                {
                    return new JsonResult(new { success = true, message = "Autentificare reusita !", data = idProfil });
                }
                else
                {
                    return new JsonResult(new { success = false, message = "Email sau parola gresita !" });
                }
            }

            return new JsonResult(new { success = false, message = "Fail", errors = ModelState.Values.SelectMany(v => v.Errors) });
        }

        [HttpDelete]
        [Route("deleteUtilizator/{id}")]
        public JsonResult DeleteUtilizator(int id)
        {
            if(ModelState.IsValid)
            {
                _utilizatoriRepository.DeleteUtilizator(id);

                return new JsonResult(new { success = true , message = "Utilizatorul a fost sters !" });
            }

            return new JsonResult(new { success = false , message = "Fail", errors = ModelState.Values.SelectMany(v => v.Errors) });
        }
    }
}
