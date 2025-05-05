public interface IUser
{
    protected void Exit();

    internal int GetAccountNumber();

    internal string GetAccountName();

    internal double GetAccountBalance();

    internal string GetAccountStatus();

    internal string GetAccountLogin();

    internal int GetAccountPin();

    protected void SetAccountBalance(double input_balance);

    internal string DisplayMenu(string input);
}
