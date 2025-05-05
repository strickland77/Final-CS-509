class DBHandling
{
    public static MySql.Data.MySqlClient.MySqlConnection ConnectHandling(IDAL dal)
    {
        return dal.Connect();
    }

    public static User LoginHandling(IDAL dal, string login, int pin)
    {
        return dal.Login(login, pin);
    }
}
