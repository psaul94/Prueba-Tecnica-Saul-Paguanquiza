namespace JuegoRuleta.Models.Validation
{
    public class Game
    {
        public static double ValdationGame(ResponseGamerDto data, ApiBetModelDto bet)
        {
            double result = 0;
            switch (bet.TypeBet)
            {
                case 0://Color
                    result = data.Color == bet.Color ? bet.Amount * 1.5 : 0;
                    break;
                case 1://Pares e Impares
                    if (bet.Odd)
                        result = data.Color == bet.Color && Odd(data.Number) ? bet.Amount * 2 : 0;
                    else
                        result = data.Color == bet.Color && !Odd(data.Number) ? bet.Amount * 2 : 0;
                    break;
                case 2://Numero y color
                    result = data.Color != bet.Color && data.Number == bet.Number ? bet.Amount * 3 : 0;
                    break;
            }
            return result;           
        }
        public static ResponseGamerDto ResultGame()
        {
            Random random = new Random();
            int numberRandom = random.Next(1, 36);
            int numberRandomColor = random.Next(2);
            return new ResponseGamerDto()
            {
                Number = numberRandom,
                Color = numberRandomColor == 0 ? "Negro" : "Rojo"
            };
        }

        public static bool Odd(int number)
        {
            return number % 2 == 0;
        }
        public static int AcumulateAmount(int amount, bool sum, int amountNew)
        {
            return sum ? amount + amountNew : amount - amountNew;
        }
    }
}
