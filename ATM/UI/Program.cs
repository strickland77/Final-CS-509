using System.Diagnostics.CodeAnalysis;


namespace ATM
{
    class Program
    {
        [ExcludeFromCodeCoverage]
        private static void Main()
        {
            Console.WriteLine("Welcome to the ATM");
            var login = "";
            var input_pin = "";
            int pin;
            User user = null;
            while (user == null)
            {
                Console.Write("Input login: ");
                login = Console.ReadLine();
                Console.Write("Input pin: ");
                input_pin = Console.ReadLine();
                if (!Int32.TryParse(input_pin, out pin))
                {
                    Console.WriteLine("Input pin was not a number...");
                }
                else if (input_pin.Length != 5)
                {
                    Console.WriteLine("Pin is not 5 digits and is invalid...");
                }
                else
                {
                    user = DAL.Login(login, pin);
                }
            }

            while (true)
            {
                IUserInput userInput = new Input();
                var input = UI.HandleInput(userInput);
                user.DisplayMenu(input);
            }
        }
    }
}
