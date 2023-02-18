using Models;
using DataAccess;
namespace services;
public class Service
{
    public static List<User> filterForEmployees(){
        return (List<User>) FileStorage.getUser().Where(u => u.Role == "Employee").ToList();
    }
    public List<User> filterForManagers(){
        return (List<User>) FileStorage.getUser().Where(u => u.Role == "Manager").ToList();
    }
    public static void makeEmployeeManager(int id){
        List<User> users = FileStorage.getUser();
        for (int i = 0; i < users.Count; i++){
            if (users[i].UserId == id){
                users[i].Role = "Manager";
                FileStorage.updateUsersFromList(users);
                return;
            }
        }
    Console.WriteLine("Failed operation. Please try again");
        
    }
}
