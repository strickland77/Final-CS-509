public class UI
{
    public static string HandleInput(IUserInput input)
    {
        return input.GetInput();
    }

    public static string Menu(IUser user, string input)
    {
        return user.DisplayMenu(input);
    }
}
