namespace ATMTest;

using FluentAssertions;
using Moq;
using AutoFixture;
using ATM;

public class TestATM
{
    [Fact]
    public void Test1()
    {
        Fixture fixture = new Fixture();
        string expectedLogin = fixture.Create<string>();
        int expectedPin = fixture.Create<int>();
        string expectedName = fixture.Create<string>();
        double expectedBalance = fixture.Create<double>();
        int expectedAccountNumber = fixture.Create<int>();
        string expectedStatus = fixture.Create<string>();
        
        var mock = new Mock<IUser>();
        mock.Setup(x => x.GetAccountNumber()).Returns(expectedAccountNumber);

        Admin user = new Admin(expectedLogin, expectedPin, expectedName, expectedBalance, expectedAccountNumber, expectedStatus);

        var output = user.GetAccountNumber();

        Assert.Equal(output, mock.Object.GetAccountNumber());

    }
    
    [Fact]
    public void Test2()
    {
        Fixture fixture = new Fixture();
        string expectedLogin = fixture.Create<string>();
        int expectedPin = fixture.Create<int>();
        string expectedName = fixture.Create<string>();
        double expectedBalance = fixture.Create<double>();
        int expectedAccountNumber = fixture.Create<int>();
        string expectedStatus = fixture.Create<string>();
        
        var mock = new Mock<IUserInput>();
        mock.Setup(x => x.GetInput()).Returns("6");

        Admin user = new Admin(expectedLogin, expectedPin, expectedName, expectedBalance, expectedAccountNumber, expectedStatus);

        var input = UI.HandleInput(mock.Object);


        var output = user.DisplayMenu(input);

        Assert.Equal("6", output);

    }
}
