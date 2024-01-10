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
}
