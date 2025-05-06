using System.Diagnostics.CodeAnalysis;

/// <summary>
/// Program class for executing the Main function for the program.
/// </summary>
class Program
{
    [ExcludeFromCodeCoverage]
    private static void Main()
    {
        Console.WriteLine("Welcome to the ATM");
        int pin;
        IUser user = null;
        while (user == null)
        {
            Console.Write("Input login: ");
            string? login = Console.ReadLine();
            Console.Write("Input pin: ");
            string? input_pin = Console.ReadLine();
            if (!int.TryParse(input_pin, out pin))
            {
                Console.WriteLine("Input pin was not a number...");
            }
            else if (input_pin.Length != 5)
            {
                Console.WriteLine("Pin is not 5 digits and is invalid...");
            }
            else
            {
                IDAL dal = new DAL();
                user = DBHandling.LoginHandling(dal, login, pin);
            }
        }

        while (true)
        {
            UI.Menu(user);
            IUserInput userInput = new Input();
            UI.Input(user, userInput);
        }
    }
}
