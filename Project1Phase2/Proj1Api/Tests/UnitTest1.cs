using services;
using Models;
namespace Tests;

public class UnitTest1
{
    [Fact]
    public void passwordTest(){
        string password = "password1!";
        string hashedPassword = PasswordHelper.HashAndSaltPassword(password);
        Assert.True(PasswordHelper.VerifyPassword(password, hashedPassword));
    }
    [Fact]
    public void IUserCon1Test(){
        IUser newUser = new IUser(1, "testing", "testdata", "Tester", "Testing", "3942857", "Employee");

        Assert.Equal(newUser.UserId, 1);
        Assert.Equal(newUser.UserName, "testing");
        Assert.Equal(newUser.HashedPassword, "testdata");
        Assert.Equal(newUser.FirstName, "Tester");
        Assert.Equal(newUser.LastName, "Testing");
        Assert.Equal(newUser.Role, "Employee");
    }
    [Fact]
    public void IUserCon2Test(){
        IUser newUser;
        newUser = new IUser(2, "testing", "Tester", "Testing", "3942857", "Employee");
        Assert.Equal(newUser.UserId, 2);
        Assert.Equal(newUser.UserName, "testing");
        Assert.Equal(newUser.FirstName, "Tester");
        Assert.Equal(newUser.LastName, "Testing");
        Assert.Equal(newUser.Role, "Employee");
    }
    [Fact]
    public void IUserCon3Test(){
        IUser newUser;
        newUser = new IUser();
        Assert.NotEqual(newUser, null);
    }
    [Fact]
    public void TicketConstructorTest(){
        Ticket newTick1 = new Ticket(1, 150.5, DateTime.Today, 2, "something", "Pending", "N/A");
        Ticket newTick2 = new Ticket(15.50, 2, "something", "N/A");
        Ticket newTick3 = new Ticket();
        Assert.Equal(newTick1.TicketNum, 1);
        Assert.Equal(newTick2.Amount, 15.50);
        Assert.NotEqual(newTick3, null);
    }
}