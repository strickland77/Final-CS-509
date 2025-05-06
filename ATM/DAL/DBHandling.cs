/// <summary>
/// DBHandling class for the rest of the program to interace with the database.
/// </summary>
class DBHandling
{
    /// <summary>
    /// Handles connecting by executing connect for the provided DAL.
    /// </summary>
    /// <param name="dal">
    /// IDAL to attempt a connection with.
    /// </param>
    /// <returns>
    /// MySql.Data.MySqlClient.MySqlConnection if the connect was successful or null if it failed.
    /// </returns>
    public static MySql.Data.MySqlClient.MySqlConnection ConnectHandling(IDAL dal)
    {
        return dal.Connect();
    }

    /// <summary>
    /// Handles logging in a user to the database.
    /// </summary>
    /// <param name="dal">
    /// IDAL to attempt a connection with.
    /// </param>
    /// <param name="login">
    /// String login for the user attempting access.
    /// </param>
    /// <param name="pin">
    /// Int pin for the user attempting access.
    /// </param>
    /// <returns>
    /// User if the login was successful or null if it failed.
    /// </returns>
    public static User LoginHandling(IDAL dal, string login, int pin)
    {
        return dal.Login(login, pin);
    }
}
