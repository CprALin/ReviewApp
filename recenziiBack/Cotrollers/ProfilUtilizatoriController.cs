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
    public class ProfilUtilizatoriController : ControllerBase
    {
        private readonly ProfilUtilizatorRepository _profilUtilizatorRepository;
        private readonly JWTservice _JWTservice;

        public ProfilUtilizatoriController(JWTservice jWTservice)
        {
            _profilUtilizatorRepository = new ProfilUtilizatorRepository(new DBconnection().ConnectToDB());
            _JWTservice = jWTservice;
        }

        [HttpGet]
        [Route("getProfilUtilizator/{id}")]
        [Authorize(Roles = "User,Admin")]
        public JsonResult GetProfilUtilizator(int id)
        {
            var profil = _profilUtilizatorRepository.GetProfilUtilizator(id);

            if (!profil.Any())
            {
                return new JsonResult(new { success = false, message = "Profilul nu a fost gasit !" });
            }

            return new JsonResult(new { success = true, message = "Profilul a fost gasit", data = profil });
        }

        [HttpPut]
        [Route("updatePozaProfil/{id}")]
        [Authorize(Roles = "User,Admin")]
        public async Task<JsonResult> UpdatePozaProfil([FromBody] UpdatePozaProfilUtilziator profil , int id)
        {
            if(ModelState.IsValid)
            {
                await _profilUtilizatorRepository.UpdatePozaProfil(profil , id);

                return new JsonResult(new { success = true, message = "Profil updatat cu success !" });
            }


            return new JsonResult(new { success = false, message = "Fail", errors = ModelState.Values.SelectMany(v => v.Errors) });
        }

        [HttpPut]
        [Route("updateDescriereProfil/{id}")]
        [Authorize(Roles = "User,Admin")]
        public async Task<JsonResult> UpdateDescriereProfil([FromBody] UpdateDescriereProfilUtilziator profil, int id)
        {
            if (ModelState.IsValid)
            {
                await _profilUtilizatorRepository.UpdateDescriereProfil(profil, id);

                return new JsonResult(new { success = true, message = "Profil updatat cu success !" });
            }


            return new JsonResult(new { success = false, message = "Fail", errors = ModelState.Values.SelectMany(v => v.Errors) });
        }
    }
}
