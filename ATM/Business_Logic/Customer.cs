using System.Data;
using System.Diagnostics.CodeAnalysis;

class Customer : User
{
    IDAL dal = new DAL();

    internal Customer(string input_login, int input_pin, string input_name, double input_balance, int input_account_number, string input_status) :
    base(input_login, input_pin, input_name, input_balance, input_account_number, input_status){}

    internal Customer(IUser user) : base(user){}

    override public string DisplayMenu(string input)
    {
        Console.WriteLine("1----Withdraw Cash");
        Console.WriteLine("2----Deposit Cash");
        Console.WriteLine("3----Display Balance");
        Console.WriteLine("4----Exit");

        return HandleMenuInput(input);
    }

    [ExcludeFromCodeCoverage]
    override protected string HandleMenuInput(string input)
    {
        switch (input)
        {
            case "1":
                WithdrawCash();
                break;
            case "2":
                DepositCash();
                break;
            case "3":
                DisplayBalance();
                break;
            case "4":
                Exit();
                break;
            default:
                Console.WriteLine("Invalid input...");
                break;
        }

        return input;
    }

    [ExcludeFromCodeCoverage]
    private void WithdrawCash()
    {
        Console.Write("Enter the amount you would like to withdraw: ");
        var withdraw_amount = Convert.ToDouble(Console.ReadLine());

        if (GetAccountBalance() - withdraw_amount >= 0)
        {

            var conn = DBHandling.ConnectHandling(dal);

            var cmd = new MySql.Data.MySqlClient.MySqlCommand();
            cmd.Connection = conn;
            cmd.CommandType = CommandType.Text;

            cmd.CommandText = "update atm.users set balance = @balance where account_number = @account_number";
            cmd.Parameters.AddWithValue("@balance", GetAccountBalance() - withdraw_amount);
            cmd.Parameters.AddWithValue("@account_number", GetAccountNumber());
            cmd.ExecuteNonQuery();

            SetAccountBalance(GetAccountBalance() - withdraw_amount);

            Console.WriteLine("Cash Successfully Withdrawn!");
            Console.WriteLine("Account #  " + GetAccountNumber());
            Console.WriteLine("Date:      " + DateTime.Now.ToString("MM/dd/yyyy"));
            Console.WriteLine("Withdrawn: " + withdraw_amount);
            Console.WriteLine("Balance:   " + GetAccountBalance());
        }
        else
        {
            Console.WriteLine("Invalid withdraw of " + withdraw_amount + ", your balance is " +
                GetAccountBalance());
        }
    }

    [ExcludeFromCodeCoverage]
    private void DepositCash()
    {
        Console.Write("Enter the amount you would like to deposit: ");
        var deposit_amount = Convert.ToDouble(Console.ReadLine());

        var conn = DBHandling.ConnectHandling(dal);

        var cmd = new MySql.Data.MySqlClient.MySqlCommand();
        cmd.Connection = conn;
        cmd.CommandType = CommandType.Text;

        cmd.CommandText = "update atm.users set balance = @balance where account_number = @account_number";
        cmd.Parameters.AddWithValue("@balance", GetAccountBalance() + deposit_amount);
        cmd.Parameters.AddWithValue("@account_number", GetAccountNumber());
        cmd.ExecuteNonQuery();

        SetAccountBalance(GetAccountBalance() + deposit_amount);

        Console.WriteLine("Cash Successfully Deposited!");
        Console.WriteLine("Account #  " + GetAccountNumber());
        Console.WriteLine("Date:      " + DateTime.Now.ToString("MM/dd/yyyy"));
        Console.WriteLine("Withdrawn: " + deposit_amount);
        Console.WriteLine("Balance:   " + GetAccountBalance());
    }

    [ExcludeFromCodeCoverage]
    private void DisplayBalance()
    {
        Console.WriteLine("Account #  " + GetAccountNumber());
        Console.WriteLine("Date:      " + DateTime.Now.ToString("MM/dd/yyyy"));
        Console.WriteLine("Balance:   " + GetAccountBalance());
    }
}
