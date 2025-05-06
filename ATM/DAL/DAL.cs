using System.Data;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.InteropServices;

/// <summary>
/// DAL (Data Abstraction Layer) class to hand direct interaction with the database.
/// </summary>
class DAL : IDAL
{
    /// <summary>
    /// Connects to the SQL database for the ATM.
    /// </summary>
    /// <returns>
    /// MySql.Data.MySqlClient.MySqlConnection for the created connection or null if the connection failed.
    /// </returns>
    public MySql.Data.MySqlClient.MySqlConnection Connect()
    {
        MySql.Data.MySqlClient.MySqlConnection conn;
        string myConnectionString;

        myConnectionString = Environment.GetEnvironmentVariable("CONNECTION");

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

        return conn;
    }

    /// <summary>
    /// Logs in a user to the database.
    /// </summary>
    /// <param name="login">
    /// String login for the user attempting access.
    /// </param>
    /// <param name="pin">
    /// Int pin for the user attempting access.
    /// </param>
    /// <returns>
    /// User if found or null if the login failed.
    /// </returns>
    public User Login(string login, int pin)
    {
        var conn = Connect();

        if (conn == null)
        {
            Console.WriteLine("Login failed...");
            return null;
        }
        else
        {
            return LoadUser(conn, login, pin);
        }
    }

    [ExcludeFromCodeCoverage]
    private User LoadUser(MySql.Data.MySqlClient.MySqlConnection conn, string login, int pin)
    {
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
