interface IDAL
{
    public abstract MySql.Data.MySqlClient.MySqlConnection Connect();

    public abstract User Login(string login, int pin);
}
