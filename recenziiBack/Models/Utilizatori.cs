using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace recenziiBack.Models
{
    public class Utilizatori
    {
        public int IdUtilizator { get; }
        [Required(ErrorMessage = "Intordu Numele !")]
        [StringLength(100 , MinimumLength = 6)]
        public string? NumeUtilizator { get; set; }
        [Required(ErrorMessage = "Introdu adresa de email !")]
        [EmailAddress(ErrorMessage = "Verifica daca adresa de email este valida !")]
        public string? EmailUtilizator { get; set; }
        [Required(ErrorMessage = "Introdu parola !")]
        [StringLength(100 , MinimumLength = 6 , ErrorMessage = "Parola nu este sigura !")]
        public string? ParolaUtilizator { get; set; }
        [JsonIgnore]
        public string? RolUtilizator { get; set; }

    }
}
