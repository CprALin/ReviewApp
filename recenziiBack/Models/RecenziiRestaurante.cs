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
}
