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
        Assert.Equal(newUser.get_UserId(), 1);
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
    }
}