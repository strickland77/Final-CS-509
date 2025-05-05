using Moq;
using FluentAssertions;
using AutoFixture;

public class AllOtherTest
{
    [Fact]
    public void test_customer_displayMenu()
    {
        Fixture fixture = new Fixture();
        
        string login = fixture.Create<string>();
        int pin = fixture.Create<int>();
        string name = fixture.Create<string>();
        double balance = fixture.Create<double>();
        int accountNumber = fixture.Create<int>();
        string status = fixture.Create<string>();

        Customer user = new Customer(login, pin, name, balance, accountNumber, status);

        StringWriter sw = new StringWriter();
        Console.SetOut(sw);

        var testInput = "0";
        var expectedOutput = user.DisplayMenu(testInput);
        Assert.Equal(expectedOutput, testInput);

        var nl = Environment.NewLine;
        string expected = $"1----Withdraw Cash{nl}" +
                          $"2----Deposit Cash{nl}" +
                          $"3----Display Balance{nl}" +
                          $"4----Exit{nl}" +
                          $"Invalid input...{nl}";

        Assert.Equal(expected, sw.ToString());
        
        var standardOutput = new StreamWriter(Console.OpenStandardOutput());
        standardOutput.AutoFlush = true;
        Console.SetOut(standardOutput);
    }

    [Fact]
    public void test_admin_displayMenu()
    {
        Fixture fixture = new Fixture();

        string login = fixture.Create<string>();
        int pin = fixture.Create<int>();
        string name = fixture.Create<string>();
        double balance = fixture.Create<double>();
        int accountNumber = fixture.Create<int>();
        string status = fixture.Create<string>();

        Admin user = new Admin(login, pin, name, balance, accountNumber, status);

        StringWriter sw = new StringWriter();
        Console.SetOut(sw);

        var testInput = "0";
        var expectedOutput = user.DisplayMenu(testInput);
        Assert.Equal(expectedOutput, testInput);

        var nl = Environment.NewLine;
        string expected = $"1----Create New Account{nl}" +
                          $"2----Delete Existing Account{nl}" +
                          $"3----Update Account Information{nl}" +
                          $"4----Search for Account{nl}" +
                          $"5----Exit{nl}" +
                          $"Invalid input...{nl}";

        Assert.Equal(expected, sw.ToString());
        
        var standardOutput = new StreamWriter(Console.OpenStandardOutput());
        standardOutput.AutoFlush = true;
        Console.SetOut(standardOutput);
    }

    [Fact]
    public void test_connectHandling()
    {
        var mock = new Mock<IDAL>();
        MySql.Data.MySqlClient.MySqlConnection conn = new MySql.Data.MySqlClient.MySqlConnection();
        mock.Setup(x => x.Connect()).Returns(conn);

        DBHandling.ConnectHandling(mock.Object).Should().Be(conn);
    }

    [Fact]
    public void test_loginHandling()
    {
        Fixture fixture = new Fixture();
        string login = fixture.Create<string>();
        int pin = fixture.Create<int>();

        var mockDAL = new Mock<IDAL>();
        var mockUser = new Mock<IUser>();

        mockUser.Setup(x => x.GetAccountLogin()).Returns(login);
        mockUser.Setup(x => x.GetAccountPin()).Returns(pin);

        User user = new Customer(mockUser.Object);
        mockDAL.Setup(x => x.Login(login, pin)).Returns(user);

        User outputUser = DBHandling.LoginHandling(mockDAL.Object, login, pin);
        outputUser.GetAccountLogin().Should().Be(login);
        outputUser.GetAccountPin().Should().Be(pin);
    }

    [Fact]
    public void test_connect()
    {
        DAL dal = new DAL();
        dal.Connect().Should().Be(null);
    }

    [Fact]
    public void test_login()
    {
        Fixture fixture = new Fixture();
        string login = fixture.Create<string>();
        int pin = fixture.Create<int>();

        DAL dal = new DAL();
        dal.Login(login, pin).Should().Be(null);
    }

    [Fact]
    public void test_handleInput()
    {
        Fixture fixture = new Fixture();
        string input = fixture.Create<string>();

        var mock = new Mock<IUserInput>();
        mock.Setup(x => x.GetInput()).Returns(input);

        UI.HandleInput(mock.Object).Should().Be(input);
    }

    [Fact]
    public void test_menu()
    {
        Fixture fixture = new Fixture();
        string input = fixture.Create<string>();

        var mock = new Mock<IUser>();
        mock.Setup(x => x.DisplayMenu(input)).Returns(input);

        UI.Menu(mock.Object, input).Should().Be(input);
    }
}
