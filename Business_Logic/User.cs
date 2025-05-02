abstract class User
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

    internal abstract void DisplayMenu();

    protected void Exit()
    {
        Console.WriteLine("Exiting ATM...");
        Environment.Exit(0);
    }

    internal int GetAccountNumber()
    {
        return account_number;
    }

    internal string GetAccountName()
    {
        return name;
    }

    internal double GetAccountBalance()
    {
        return balance;
    }

    internal string GetAccountStatus()
    {
        return status;
    }

    internal string GetAccountLogin()
    {
        return login;
    }

    internal int GetAccountPin()
    {
        return pin;
    }

    protected void SetAccountBalance(double input_balance)
    {
        this.balance = input_balance;
    }
}