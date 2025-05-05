using System.Diagnostics.CodeAnalysis;

public class Input : IUserInput
{
    [ExcludeFromCodeCoverage]
    public string GetInput()
    {
        return Console.ReadLine();
    }
}
