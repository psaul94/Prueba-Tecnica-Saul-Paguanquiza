namespace JuegoRuleta.Models
{
    public class ApiModelDto
    {
        public string? Name { get; set; }
        public int Amount { get; set; }
    }
    public class ApiBetModelDto
    {
        public int Number { get; set; }
        public string Color { get; set; }
        public int Amount { get; set; }
        public int TypeBet { get; set; }
        public bool Odd { get; set; }
    }
    public class ResponseGamerDto
    {
        public int Number { get; set; }

        public string Color { get; set; }
    }
}
