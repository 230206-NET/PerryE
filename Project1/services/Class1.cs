using Models;
using DataAccess;
namespace services;
public class Service
{
    public static List<Employee> filterForEmployees(){
        List<Employee> Employees = new List<Employee>();
        List<IUser> users = FileStorage.getUser();
        foreach (IUser user in users){
            if (user.Role == "Employee"){
                Employee newEmployee = new Employee(user.UserId, user.UserName, user.HashedPassword, user.FirstName, user.LastName, user.CellNumber, user.Role);
                Employees.Add(newEmployee);
            }
        }
        return Employees;
    }
    public List<Manager> filterForManagers(){
        var Managers = new List<Manager>();
        List<IUser> users = FileStorage.getUser();
        foreach (IUser user in users){
            if (user.Role == "Manager"){
                Managers.Add(new Manager(user.UserId, user.UserName, user.HashedPassword, user.FirstName, user.LastName, user.CellNumber, user.Role));
            }
        }
        return Managers;
    }
    public static void makeEmployeeManager(int id){
        List<IUser> users = FileStorage.getUser();
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
