/// <summary>
/// DAL interface defining core required functionality for a DAL.
/// </summary>
interface IDAL
{
    /// <summary>
    /// Connects to the SQL database for the ATM.
    /// </summary>
    /// <returns>
    /// MySql.Data.MySqlClient.MySqlConnection for the created connection or null if the connection failed.
    /// </returns>
    public abstract MySql.Data.MySqlClient.MySqlConnection Connect();

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
    public abstract User Login(string login, int pin);
}
