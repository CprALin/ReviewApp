using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;

namespace recenziiBack.Models
{
    public class ProfilUtilizatori
    {
        public int IdProfil { get; }
        public int IdUtilizator { get; set; }
        public string? PozaProfil { get; set; }
        public string? DescriereProfil { get; set; }
    }

    public class GetProfilUtilizator
    {
        public string? PozaProfil { get; }
        public string? DescriereProfil { get; }
    }

    public class UpdatePozaProfilUtilziator
    {
        public string? PozaProfil { get; set;}
    }

    public class UpdateDescriereProfilUtilziator
    {
        public string? DescriereProfil { get; set; }
    }

}
