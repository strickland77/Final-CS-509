using FluentAssertions;
using Moq;
using AutoFixture;

public class UserTest
{
    class TestUser : User
    {
        public TestUser(IUser user) : base(user)
        {
        }

        override public void DisplayMenu()
        {
        }

        public override string MenuInput(string input)
        {
            return input;
        }

        override protected string HandleMenuInput(string input)
        {
            return input;
        }
    }

    [Fact]
    public void test_get_account_number()
    {
        Fixture fixture = new Fixture();
        int expectedAccountNumber = fixture.Create<int>();
        
        var mock = new Mock<IUser>();
        mock.Setup(x => x.GetAccountNumber()).Returns(expectedAccountNumber);

        User user = new TestUser(mock.Object);
        user.GetAccountNumber().Should().Be(expectedAccountNumber);
    }

    [Fact]
    public void test_get_account_name()
    {
        Fixture fixture = new Fixture();
        string expectedName = fixture.Create<string>();

        var mock = new Mock<IUser>();
        mock.Setup(x => x.GetAccountName()).Returns(expectedName);

        User user = new TestUser(mock.Object);
        user.GetAccountName().Should().Be(expectedName);
    }

    [Fact]
    public void test_get_account_balance()
    {
        Fixture fixture = new Fixture();
        double expectedBalance = fixture.Create<double>();
        
        var mock = new Mock<IUser>();
        mock.Setup(x => x.GetAccountBalance()).Returns(expectedBalance);

        User user = new TestUser(mock.Object);
        user.GetAccountBalance().Should().Be(expectedBalance);
    }

    [Fact]
    public void test_get_account_status()
    {
        Fixture fixture = new Fixture();
        string expectedStatus = fixture.Create<string>();
        
        var mock = new Mock<IUser>();
        mock.Setup(x => x.GetAccountStatus()).Returns(expectedStatus);

        User user = new TestUser(mock.Object);
        user.GetAccountStatus().Should().Be(expectedStatus);
    }

    [Fact]
    public void test_get_account_login()
    {
        Fixture fixture = new Fixture();
        string expectedLogin = fixture.Create<string>();
        
        var mock = new Mock<IUser>();
        mock.Setup(x => x.GetAccountLogin()).Returns(expectedLogin);

        User user = new TestUser(mock.Object);
        user.GetAccountLogin().Should().Be(expectedLogin);
    }

    [Fact]
    public void test_get_account_pin()
    {
        Fixture fixture = new Fixture();
        int expectedPin = fixture.Create<int>();
        
        var mock = new Mock<IUser>();
        mock.Setup(x => x.GetAccountPin()).Returns(expectedPin);

        User user = new TestUser(mock.Object);
        user.GetAccountPin().Should().Be(expectedPin);
    }

    [Fact]
    public void test_set_account_balance()
    {
        Fixture fixture = new Fixture();
        double expectedBalance = fixture.Create<double>();
        
        var mock = new Mock<IUser>();
        User user = new TestUser(mock.Object);

        user.SetAccountBalance(expectedBalance);
        user.GetAccountBalance().Should().Be(expectedBalance);
    }
}
