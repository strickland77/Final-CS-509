using System.Diagnostics.CodeAnalysis;
[assembly: System.Runtime.CompilerServices.InternalsVisibleTo("DynamicProxyGenAssembly2")]

/// <summary>
/// User abstract class with core functionality for all users.
/// </summary>
abstract class User : IUser
{
    private readonly string login;
    private readonly int pin;
    private readonly string name;
    private double balance;
    private readonly int account_number;
    private string status;

    protected User(string input_login, int input_pin, string input_name, double input_balance, int input_account_number, string input_status)
    {
        login = input_login;
        pin = input_pin;
        name = input_name;
        balance = input_balance;
        account_number = input_account_number;
        status = input_status;
    }

    protected User(IUser user)
    {
        login = user.GetAccountLogin();
        pin = user.GetAccountPin();
        name = user.GetAccountName();
        balance = user.GetAccountBalance();
        account_number = user.GetAccountNumber();
        status = user.GetAccountStatus();
    }

    /// <summary>
    /// Exits the application.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public void Exit()
    {
        Console.WriteLine("Exiting ATM...");
        Environment.Exit(0);
    }

    /// <summary>
    /// Gets the account number for this user.
    /// </summary>
    /// <returns>
    /// Int account number.
    /// </returns>
    public int GetAccountNumber()
    {
        return account_number;
    }

    /// <summary>
    /// Gets the account name for this user.
    /// </summary>
    /// <returns>
    /// String account name.
    /// </returns>
    public string GetAccountName()
    {
        return name;
    }

    /// <summary>
    /// Gets the account balance for this user.
    /// </summary>
    /// <returns>
    /// Double account balance.
    /// </returns>
    public double GetAccountBalance()
    {
        return balance;
    }

    /// <summary>
    /// Gets the account status for this user.
    /// </summary>
    /// <returns>
    /// String account status.
    /// </returns>
    public string GetAccountStatus()
    {
        return status;
    }

    /// <summary>
    /// Gets the account login for this user.
    /// </summary>
    /// <returns>
    /// String account login.
    /// </returns>
    public string GetAccountLogin()
    {
        return login;
    }

    /// <summary>
    /// Gets the account pin for this user.
    /// </summary>
    /// <returns>
    /// Int account pin.
    /// </returns>
    public int GetAccountPin()
    {
        return pin;
    }

    /// <summary>
    /// Sets the account balance for this user.
    /// </summary>
    /// <param name="input_balance">
    /// Double to set the balance to.
    /// </param>
    public void SetAccountBalance(double input_balance)
    {
        balance = input_balance;
    }

    public abstract void DisplayMenu();

    public abstract string MenuInput(string input);

    /// <summary>
    /// Displays the menu for a user and handles the user input to select an action.
    /// </summary>
    /// <param name="input">
    /// String number to select an action from the menu.
    /// </param>
    /// <returns>
    /// String that was input.
    /// </returns>
    [ExcludeFromCodeCoverage]
    protected abstract string HandleMenuInput(string input);
}
