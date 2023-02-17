using System.Text.Json;
using Models;
namespace DataAccess;
public class FileStorage
{
    static string filePath = "C:\\Users\\eperr\\Documents\\Users.docx";

    public static bool createNewUser(IUser newUser){
        List<IUser> UserList = getUser();
        UserList.Add(newUser);
        string serialized = JsonSerializer.Serialize(UserList);
        File.WriteAllText(filePath, serialized);
        return true;
    }
    public static List<IUser> getUser(){
        string fileContent = File.ReadAllText(filePath);
        return JsonSerializer.Deserialize<List<IUser>>(fileContent);
        
    }
    public static void updateUsersFromList(List<IUser> users){
        string serialized = JsonSerializer.Serialize(users);
        File.WriteAllText(filePath, serialized);
    }
    public static IUser getSpecifiedUser(string username, string password){
        List<IUser> userList = getUser();
        foreach (IUser user in userList){
            if (user.UserName == username && user.HashedPassword == password){
                return user;
            }
        }
        return null;
        
    }
}
