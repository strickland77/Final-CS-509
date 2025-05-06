/// <summary>
/// User interface defining core required functionality for a User.
/// </summary>
interface IUser
{
    protected void Exit();

    internal int GetAccountNumber();

    internal string GetAccountName();

    internal double GetAccountBalance();

    internal string GetAccountStatus();

    internal string GetAccountLogin();

    internal int GetAccountPin();

    protected void SetAccountBalance(double input_balance);

    internal void DisplayMenu();

    internal string MenuInput(string input);
}
