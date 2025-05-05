/// <summary>
/// UI class to handle interaction between a user of the program and the business logic layer.
/// </summary>
class UI
{
    /// <summary>
    /// Handles getting input.
    /// </summary>
    /// <param name="input">
    /// IUserInput to execute getting input with.
    /// </param>
    /// <returns>
    /// String returned from getting input with IUserInput.
    /// </returns>
    public static string HandleInput(IUserInput input)
    {
        return input.GetInput();
    }

    /// <summary>
    /// Menu functionality for the program.
    /// </summary>
    /// <param name="user">
    /// IUser to display the menu for.
    /// </param>
    /// <param name="input">
    /// String input to select a menu option.
    /// </param>
    /// <returns>
    /// String that was provided as input.
    /// </returns>
    public static string Menu(IUser user, string input)
    {
        return user.DisplayMenu(input);
    }
}
