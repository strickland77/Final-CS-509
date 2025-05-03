[assembly: System.Runtime.CompilerServices.InternalsVisibleTo("DynamicProxyGenAssembly2")]
namespace ATM;

public interface IUser
{
    internal abstract void DisplayMenu();

    protected void Exit();

    internal int GetAccountNumber();

    internal string GetAccountName();

    internal double GetAccountBalance();

    internal string GetAccountStatus();

    internal string GetAccountLogin();

    internal int GetAccountPin();

    protected void SetAccountBalance(double input_balance);
}

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

    public abstract void DisplayMenu();

    public void Exit()
    {
        Console.WriteLine("Exiting ATM...");
        Environment.Exit(0);
    }

    public int GetAccountNumber()
    {
        return account_number;
    }

    public string GetAccountName()
    {
        return name;
    }

    public double GetAccountBalance()
    {
        return balance;
    }

    public string GetAccountStatus()
    {
        return status;
    }

    public string GetAccountLogin()
    {
        return login;
    }

    public int GetAccountPin()
    {
        return pin;
    }

    public void SetAccountBalance(double input_balance)
    {
        balance = input_balance;
    }
}