namespace ATM;

public interface IUserInput
{
    string GetInput();
}

public class Input : IUserInput
{
    public string GetInput()
    {
        return Console.ReadLine();
    }
}

public class UI
{
    public static string HandleInput(IUserInput input)
    {
        return input.GetInput();
    }
}
