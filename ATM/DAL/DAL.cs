using System.Data;
using System.Diagnostics.CodeAnalysis;


class DAL : IDAL
{
    public MySql.Data.MySqlClient.MySqlConnection Connect()
    {
        MySql.Data.MySqlClient.MySqlConnection conn;
        string myConnectionString;

        myConnectionString = "server=127.0.0.1;port=3306;uid=root;pwd=password;database=ATM";

        conn = new MySql.Data.MySqlClient.MySqlConnection();
        conn.ConnectionString = myConnectionString;

        try
        {
            conn.Open();
        }
        catch
        {
            Console.WriteLine("Unable to connect to database...");
            return null;
        }
        conn.Open();

        return conn;
    }

    public User Login(string login, int pin)
    {
        var conn = Connect();

        if (conn == null)
        {
            Console.WriteLine("Login failed...");
            return null;
        }

        var cmd = new MySql.Data.MySqlClient.MySqlCommand();
        cmd.Connection = conn;
        cmd.CommandType = CommandType.Text;
        cmd.CommandText = "select * from atm.users where login = @login and pin = @pin";
        cmd.Parameters.AddWithValue("@login", login);
        cmd.Parameters.AddWithValue("@pin", pin);

        var reader = cmd.ExecuteReader();
        var user = LoadUser(reader);

        if (user == null)
        {
            Console.WriteLine("Found no account matching those credentials...");
        }

        return user;
    }

    [ExcludeFromCodeCoverage]
    private User LoadUser(MySql.Data.MySqlClient.MySqlDataReader reader)
    {
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
        }

        return null;
    }
}
