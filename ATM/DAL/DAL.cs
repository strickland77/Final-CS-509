using System.Data;
namespace ATM;

class DAL
{
    internal static MySql.Data.MySqlClient.MySqlConnection Connect()
    {
        MySql.Data.MySqlClient.MySqlConnection conn;
        string myConnectionString;

        myConnectionString = "server=127.0.0.1;port=3306;uid=root;pwd=password;database=ATM";

        conn = new MySql.Data.MySqlClient.MySqlConnection();
        conn.ConnectionString = myConnectionString;
        conn.Open();

        return conn;
    }

    internal static User Login(string login, int pin)
    {
        var conn = Connect();

        var cmd = new MySql.Data.MySqlClient.MySqlCommand();
        cmd.Connection = conn;
        cmd.CommandType = CommandType.Text;
        cmd.CommandText = "select * from atm.users where login = @login and pin = @pin";
        cmd.Parameters.AddWithValue("@login", login);
        cmd.Parameters.AddWithValue("@pin", pin);

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
        }

        Console.WriteLine("Found no account matching those credentials...");
        return null;
    }
}