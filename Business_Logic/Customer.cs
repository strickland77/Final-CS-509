using System.Data;

class Customer : User
{
    public Customer(string input_login, int input_pin, string input_name, double input_balance, int input_account_number, string input_status) :
    base(input_login, input_pin, input_name, input_balance, input_account_number, input_status)
    { }
    public override void DisplayMenu()
    {
        Console.WriteLine("1----Withdraw Cash");
        Console.WriteLine("2----Deposit Cash");
        Console.WriteLine("3----Display Balance");
        Console.WriteLine("4----Exit");

        var input = Console.ReadLine();
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
    }

    private void WithdrawCash()
    {
        Console.Write("Enter the amount you would like to withdraw: ");
        var withdraw_amount = Convert.ToDouble(Console.ReadLine());

        if (this.GetAccountBalance() - withdraw_amount >= 0)
        {

            var conn = DAL.Connect();

            var cmd = new MySql.Data.MySqlClient.MySqlCommand();
            cmd.Connection = conn;
            cmd.CommandType = CommandType.Text;

            cmd.CommandText = "update atm.users set balance = @balance where account_number = @account_number";
            cmd.Parameters.AddWithValue("@balance", this.GetAccountBalance() - withdraw_amount);
            cmd.Parameters.AddWithValue("@account_number", this.GetAccountNumber());
            cmd.ExecuteNonQuery();

            SetAccountBalance(this.GetAccountBalance() - withdraw_amount);

            Console.WriteLine("Cash Successfully Withdrawn!");
            Console.WriteLine("Account #  " + this.GetAccountNumber());
            Console.WriteLine("Date:      " + DateTime.Now.ToString("MM/dd/yyyy"));
            Console.WriteLine("Withdrawn: " + withdraw_amount);
            Console.WriteLine("Balance:   " + this.GetAccountBalance());
        }
        else
        {
            Console.WriteLine("Invalid withdraw of " + withdraw_amount + ", your balance is " +
                this.GetAccountBalance());
        }
    }

    private void DepositCash()
    {
        Console.Write("Enter the amount you would like to deposit: ");
        var deposit_amount = Convert.ToDouble(Console.ReadLine());

        var conn = DAL.Connect();

        var cmd = new MySql.Data.MySqlClient.MySqlCommand();
        cmd.Connection = conn;
        cmd.CommandType = CommandType.Text;

        cmd.CommandText = "update atm.users set balance = @balance where account_number = @account_number";
        cmd.Parameters.AddWithValue("@balance", this.GetAccountBalance() + deposit_amount);
        cmd.Parameters.AddWithValue("@account_number", this.GetAccountNumber());
        cmd.ExecuteNonQuery();

        SetAccountBalance(this.GetAccountBalance() + deposit_amount);

        Console.WriteLine("Cash Successfully Deposited!");
        Console.WriteLine("Account #  " + this.GetAccountNumber());
        Console.WriteLine("Date:      " + DateTime.Now.ToString("MM/dd/yyyy"));
        Console.WriteLine("Withdrawn: " + deposit_amount);
        Console.WriteLine("Balance:   " + this.GetAccountBalance());
    }

    private void DisplayBalance()
    {
        Console.WriteLine("Account #  " + this.GetAccountNumber());
        Console.WriteLine("Date:      " + DateTime.Now.ToString("MM/dd/yyyy"));
        Console.WriteLine("Balance:   " + this.GetAccountBalance());
    }
}