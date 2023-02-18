using System.Text.Json;
using Models;
namespace DataAccess;
public class FileStorage
{
    static string filePath = "C:\\Users\\eperr\\Documents\\Users.docx";

    public static bool createUser(User newUser){
        List<User> UserList = getUser();
        UserList.Add(newUser);
        string serialized = JsonSerializer.Serialize(UserList);
        File.WriteAllText(filePath, serialized);
        return true;
    }
    public static List<User> getUser(){
        string fileContent = File.ReadAllText(filePath);
        return JsonSerializer.Deserialize<List<User>>(fileContent);
        
    }
    public static void updateUsersFromList(List<User> users){
        string serialized = JsonSerializer.Serialize(users);
        File.WriteAllText(filePath, serialized);
    }
    public static User getSpecifiedUser(string username){
        List<User> userList = getUser();
        foreach (User user in userList){
            if (user.UserName == username){
                return user;
            }
        }
        return null;
        
    }
}
