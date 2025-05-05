using System.Diagnostics.CodeAnalysis;

/// <summary>
/// Input class to handle getting user input from the console.
/// </summary>
class Input : IUserInput
{
    /// <summary>
    /// Gets the input from reading the console.
    /// </summary>
    /// <returns>
    /// String input from the console.
    /// </returns>
    [ExcludeFromCodeCoverage]
    public string GetInput()
    {
        return Console.ReadLine();
    }
}
