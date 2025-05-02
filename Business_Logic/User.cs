abstract class User
{
    private readonly string login;
    private readonly int pin;
    private readonly string name;
    private double balance;
    private readonly int account_number;

    private string status;

    public User(string input_login, int input_pin, string input_name, double input_balance, int input_account_number, string input_status)
    {
        this.login = input_login;
        this.pin = input_pin;
        this.name = input_name;
        this.balance = input_balance;
        this.account_number = input_account_number;
        this.status = input_status;
    }

    public abstract void DisplayMenu();

    public void Exit()
    {
        Console.WriteLine("Exiting ATM...");
        Environment.Exit(0);
    }

    public int GetAccountNumber()
    {
        return this.account_number;
    }

    public string GetAccountName()
    {
        return this.name;
    }

    public double GetAccountBalance()
    {
        return this.balance;
    }

    public string GetAccountStatus()
    {
        return this.status;
    }

    public string GetAccountLogin()
    {
        return this.login;
    }

    public int GetAccountPin()
    {
        return this.pin;
    }

    public void SetAccountBalance(double input_balance)
    {
        this.balance = input_balance;
    }
}