using System.Data;

class Admin : User
{
    internal Admin(string input_login, int input_pin, string input_name, double input_balance, int input_account_number, string input_status) :
    base(input_login, input_pin, input_name, input_balance, input_account_number, input_status)
    { }
    internal override void DisplayMenu()
    {
        Console.WriteLine("1----Create New Account");
        Console.WriteLine("2----Delete Existing Account");
        Console.WriteLine("3----Update Account Information");
        Console.WriteLine("4----Search for Account");
        Console.WriteLine("5----Exit");

        var input = Console.ReadLine();
        switch (input)
        {
            case "1":
                CreateAccount();
                break;
            case "2":
                DeleteAccount();
                break;
            case "3":
                UpdateAccount();
                break;
            case "4":
                SearchAccount();
                break;
            case "5":
                Exit();
                break;
            default:
                Console.WriteLine("Invalid input...");
                break;
        }
    }

    private void CreateAccount()
    {
        Console.Write("Input new account login: ");
        var input_login = Console.ReadLine();
        Console.Write("Input new account pin: ");
        var input_pin = Console.ReadLine();
        Console.Write("Input new account name: ");
        var input_name = Console.ReadLine();
        Console.Write("Input new account balance: ");
        var input_balance = Console.ReadLine();
        Console.Write("Input new account status: ");
        var input_status = Console.ReadLine();

        if (input_pin.Length != 5)
        {
            Console.WriteLine("Pin is not 5 digits and is invalid...");
        }
        else
        {
            var conn = DAL.Connect();

            var cmd = new MySql.Data.MySqlClient.MySqlCommand();
            cmd.Connection = conn;
            cmd.CommandType = CommandType.Text;

            cmd.CommandText = "insert into atm.users(login, pin, name, balance, status) values(@login, @pin, @name, @balance, @status)";
            cmd.Parameters.AddWithValue("@login", input_login);
            cmd.Parameters.AddWithValue("@pin", input_pin);
            cmd.Parameters.AddWithValue("@name", input_name);
            cmd.Parameters.AddWithValue("@balance", input_balance);
            cmd.Parameters.AddWithValue("@status", input_status);

            var rows = cmd.ExecuteNonQuery();
            if (rows > 0)
            {
                User new_account = RetrieveAccountByLogin(input_login, Convert.ToInt32(input_pin));
                Console.WriteLine("Account Successfully Created - the account number assigned is: " + new_account.GetAccountNumber());
            }
            else
            {
                Console.WriteLine("New account creation failed...");
            }
        }
    }

    private void DeleteAccount()
    {
        Console.Write("Enter the account number to which you want to delete: ");
        var input_account_number = Convert.ToInt32(Console.ReadLine());
        User user = RetrieveAccountByNumber(input_account_number);

        if (user == null)
        {
            Console.WriteLine("Account with that number not found...");
        }
        else
        {
            Console.Write("You wish to delete the account held by " + user.GetAccountName() +
                ". If this information is correct, please re-enter the account number: ");
            var confirmed_account_number = Convert.ToInt32(Console.ReadLine());

            if (confirmed_account_number == input_account_number)
            {
                var conn = DAL.Connect();

                var cmd = new MySql.Data.MySqlClient.MySqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = CommandType.Text;

                cmd.CommandText = "delete from atm.users where account_number = @account_number";
                cmd.Parameters.AddWithValue("@account_number", confirmed_account_number);

                var rows = cmd.ExecuteNonQuery();
                Console.WriteLine("Account Deleted Successfully");
            }
            else
            {
                Console.WriteLine("Re-entered account number did not match...");
            }
        }
    }

    private void UpdateAccount()
    {
        Console.Write("Enter the account number to which you want to update: ");
        var input_account_number = Convert.ToInt32(Console.ReadLine());
        User user = RetrieveAccountByNumber(input_account_number);

        Console.WriteLine("You wish to update the account held by " + user.GetAccountName() +
                ".");

        if (user == null)
        {
            Console.WriteLine("Account with that number not found...");
        }
        else
        {
            Console.WriteLine("Enter which field you would like to update: ");
            Console.WriteLine("1----Holder");
            Console.WriteLine("2----Status");
            Console.WriteLine("3----Login");
            Console.WriteLine("4----Pin");

            var input = Console.ReadLine();

            var conn = DAL.Connect();

            var cmd = new MySql.Data.MySqlClient.MySqlCommand();
            cmd.Connection = conn;
            cmd.CommandType = CommandType.Text;

            switch (input)
            {
                case "1":
                    Console.WriteLine("Enter new account holder name: ");
                    var name = Console.ReadLine();
                    cmd.CommandText = "update atm.users set name = @name where account_number = @account_number";
                    cmd.Parameters.AddWithValue("@name", name);
                    cmd.Parameters.AddWithValue("@account_number", user.GetAccountNumber());
                    cmd.ExecuteNonQuery();
                    break;
                case "2":
                    Console.WriteLine("Enter new account status: ");
                    var status = Console.ReadLine();
                    cmd.CommandText = "update atm.users set status = @status where account_number = @account_number";
                    cmd.Parameters.AddWithValue("@status", status);
                    cmd.Parameters.AddWithValue("@account_number", user.GetAccountNumber());
                    cmd.ExecuteNonQuery();
                    break;
                case "3":
                    Console.WriteLine("Enter new account login: ");
                    var login = Console.ReadLine();
                    cmd.CommandText = "update atm.users set login = @login where account_number = @account_number";
                    cmd.Parameters.AddWithValue("@login", login);
                    cmd.Parameters.AddWithValue("@account_number", user.GetAccountNumber());
                    cmd.ExecuteNonQuery();
                    break;
                case "4":
                    Console.WriteLine("Enter new account pin: ");
                    var pin = Console.ReadLine();

                    if (pin.Length != 5)
                    {
                        Console.WriteLine("Pin is not 5 digits and is invalid...");
                    }
                    else
                    {
                        cmd.CommandText = "update atm.users set pin = @pin where account_number = @account_number";
                        cmd.Parameters.AddWithValue("@pin", pin);
                        cmd.Parameters.AddWithValue("@account_number", user.GetAccountNumber());
                        cmd.ExecuteNonQuery();
                    }
                    break;
                default:
                    Console.WriteLine("Invalid input...");
                    break;
            }
        }
    }

    private void SearchAccount()
    {
        Console.Write("Enter the account number to which you want to search: ");
        var input_account_number = Convert.ToInt32(Console.ReadLine());
        User user = RetrieveAccountByNumber(input_account_number);

        if (user == null)
        {
            Console.WriteLine("Account with that number not found...");
        }
        else
        {
            Console.WriteLine("Account # " + user.GetAccountNumber());
            Console.WriteLine("Holder:   " + user.GetAccountName());
            Console.WriteLine("Balance:  " + user.GetAccountBalance());
            Console.WriteLine("Status:   " + user.GetAccountStatus());
            Console.WriteLine("Login:    " + user.GetAccountLogin());
            Console.WriteLine("Pin Code: " + user.GetAccountPin());
        }
    }

    private User RetrieveAccountByLogin(string login, int pin)
    {
        return DAL.Login(login, pin);
    }

    private User RetrieveAccountByNumber(int account_number)
    {
        var conn = DAL.Connect();

        var cmd = new MySql.Data.MySqlClient.MySqlCommand();
        cmd.Connection = conn;
        cmd.CommandType = CommandType.Text;
        cmd.CommandText = "select * from atm.users where account_number = @account_number";
        cmd.Parameters.AddWithValue("@account_number", account_number);

        var reader = cmd.ExecuteReader();
        while (reader.Read())
        {
            string db_login = reader["login"].ToString();
            int db_pin = Convert.ToInt32(reader["pin"]);
            string db_name = reader["name"].ToString();
            double db_balance = Convert.ToDouble(reader["balance"]);
            int db_account_number = Convert.ToInt32(reader["account_number"]);
            string db_status = reader["status"].ToString();

            if (db_name == "Admin")
            {
                Admin user = new Admin(db_login, db_pin, db_name, db_balance, db_account_number, db_status);
                return user;
            }
            else
            {
                Customer user = new Customer(db_login, db_pin, db_name, db_balance, db_account_number, db_status);
                return user;
            }

            Console.WriteLine(db_login);
            Console.WriteLine(db_pin);
            Console.WriteLine(db_name);
            Console.WriteLine(db_balance);
            Console.WriteLine(db_account_number);
        }

        Console.WriteLine("Found no account matching those credentials...");
        return null;
    }
}