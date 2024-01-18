using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using recenziiBack.Infrastructure;
using recenziiBack.Models;
using recenziiBack.Repositories;
using recenziiBack.Services;
using System.Linq.Expressions;

namespace recenziiBack.Cotrollers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UtilizatoriController : ControllerBase
    {
        private readonly UtilizatoriRepository _utilizatoriRepository;
        private readonly JWTservice _jwtService;

        public UtilizatoriController(JWTservice jwtService)
        {
            _utilizatoriRepository = new UtilizatoriRepository(new DBconnection().ConnectToDB());
            _jwtService = jwtService;
        }

        //POST : api/utilizatori/inregistrare
        [HttpPost]
        [Route("inregistrare")]
        [AllowAnonymous]
        public async Task<JsonResult> Inregistrare([FromBody] UtilizatoriInregistrare utilizator)
        {
            if(ModelState.IsValid)
            {
                try { 
                  await _utilizatoriRepository.InregistreazaUtilizator(utilizator);
                }catch(Exception ex)
                {
                    if(ex is Exception)
                    {
                        return new JsonResult(new {success = false , message = "Numele utilizatorului sau email-ul este deja utilizat !"});
                    }
                }    

                var token = _jwtService.GenerateToken(utilizator.EmailUtilizator);

                return new JsonResult(new {success = true , message = "Utilizator inregistrat cu success . " , data = token});
            }

            return new JsonResult(new { success = false , message = "Fail" , errors = ModelState.Values.SelectMany(v => v.Errors)});
        }

        [HttpPost]
        [Route("autentificare")]
        [AllowAnonymous]
        public async Task<JsonResult> Autentificare([FromBody] UtilizatorAutentificare utilizator)
        {
            if (ModelState.IsValid)
            {
                int idProfil = await _utilizatoriRepository.AutentificareUtilizator(utilizator);

                //Console.WriteLine(idProfil);
                
                if(idProfil != -1)
                {
                    var token = _jwtService.GenerateToken(utilizator.EmailUtilizator);

                    return new JsonResult(new { success = true, message = "Autentificare reusita !", data = new { IdProfil = idProfil, Token = token } });
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
        [Authorize]
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
