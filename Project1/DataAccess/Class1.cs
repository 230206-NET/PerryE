using System.Text.Json;
using Models;
using System.Data.SqlClient;
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
    public static User GetUserByUsername(string username)
{
    User user = null;
    string connectionString = "Server=tcp:ticket-reimbursement.database.windows.net,1433;Initial Catalog=ticketsDB;Persist Security Info=False;User ID=ticket-admin;Password=Password1;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";

    using (SqlConnection connection = new SqlConnection(connectionString))
    {
        connection.Open();
        string query = "SELECT User_ID, User_Name, Hashed_Password, Full_Name, Phone_Number, User_Position FROM Users WHERE User_Name = @username";
        using (SqlCommand command = new SqlCommand(query, connection))
        {
            command.Parameters.AddWithValue("@username", username);

            using (SqlDataReader reader = command.ExecuteReader())
            {
                if (reader.Read())
                {
                    int userId = reader.GetInt32(0);
                    string userName = reader.GetString(1);
                    string hashedPassword = reader.GetString(2);
                    string fullName = reader.GetString(3);
                    string phoneNumber = reader.GetString(4);
                    string userPosition = reader.GetString(5);
                    string[] name = fullName.Split(' ').Select(word => word.Trim()).ToArray();

                    user = new User(userId, userName, hashedPassword, name[0], name[1], phoneNumber, userPosition);
                }
            }
        }
    }

    return user;
}
}
