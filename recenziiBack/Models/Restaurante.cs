using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace recenziiBack.Models
{
    public class Restaurante
    {
        public int IdRestaurant { get; set; }
        public string? NumeRestaurant { get; set;}
        public string? AdresaRestaurant { get; set;}
        public string? DescriereRestaurant { get; set;}
        public string? PozaRestaurant { get; set;}
    }

    public class AdaugaRestaurant
    {
        [Required(ErrorMessage = "Introdu numele restaurantului !")]
        [StringLength(100)]
        public string? NumeRestaurant { get; set; }
        [Required(ErrorMessage = "Restaurantul trebuie sa aibe o adresa !")]
        [StringLength(100)]
        public string? AdresaRestaurant { get; set; }
        [Required(ErrorMessage = "Adauga descrierea !")]
        [StringLength(500)]
        public string? DescriereRestaurant { get; set; }
        [Required(ErrorMessage = "Adauga o poza !")]
        [StringLength(200)]
        public string? PozaRestaurant { get; set; }
    }
}
