using Models;
using DataAccess;
namespace services;
public class LogInHelper
{
    public static IUser? LogIn(string username, string password){
        if (PasswordHelper.Login(username, password)){
            return DBAccess.GetUserByUsername(username);
        } else{
            return null;
        }
    }

}
