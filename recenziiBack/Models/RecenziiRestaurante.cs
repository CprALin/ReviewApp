using System.ComponentModel.DataAnnotations;

namespace recenziiBack.Models
{
    public class RecenziiRestaurante
    {
        public int IdRecenzie { get; }
        public int IdRestaurant { get; set; }
        public int IdUtilizator { get; set; }
        public string? TitluRecenzie { get; set; }
        public string? DescriereRecenzie { get; set; }
        public string? DataRecenzie { get; set; }
        public int ValoareRecenzie { get; set; }
    }

    public class AddRecenzieRestaurant
    {
        [Required(ErrorMessage = "Adauga un titlu recenziei !")]
        public string? TitluRecenzie { get; set; }
        [Required(ErrorMessage = "Adauga o descriere !")]
        public string? DescriereRecenzie { get; set; }
        [Required]
        [Range(1, 5, ErrorMessage = "Valoarea recenziei trebuie să fie între 1 și 5.")]
        public int ValoareRecenzie { get; set; }
    }

    public class GetRecenzieRestaurant
    {
        public int IdRecenzie { get; }
        public string? PozaProfil { get; set; }
        public string? NumeUtilizator { get; set; }
        public string? TitluRecenzie { get; set; }
        public int ValoareRecenzie { get; set; }
        public string? DescriereRecenzie { get; set; }
        public string? DataRecenzie { get; set; }
    }

}
