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
}