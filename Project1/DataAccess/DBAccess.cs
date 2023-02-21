using System.Text.Json;
using Models;
using System.Data.SqlClient;
using System.Data;
namespace DataAccess;
public class DBAccess
{
    public static void MakeEmployeeManager(int id){
        List<User> userList = new List<User>();
        using (SqlConnection connection = new SqlConnection(Secrets.getConnection()))
    {
        connection.Open();
        string query = "Update Users SET User_Role = 'Manager' WHERE User_ID = @UserId";
        using (SqlCommand command = new SqlCommand(query, connection))
        {
            command.Parameters.AddWithValue("@UserId", id);
            command.ExecuteNonQuery();
        }
    }
    }
    public static void ChangeName(int id, string name){
        using (SqlConnection connection = new SqlConnection(Secrets.getConnection()))
    {
        connection.Open();
        string query = "Update Users SET Full_Name = @Name WHERE User_ID = @UserId";
        using (SqlCommand command = new SqlCommand(query, connection))
        {
            command.Parameters.AddWithValue("@Name", name);
            command.Parameters.AddWithValue("@UserId", id);
            command.ExecuteNonQuery();
        }
    }
    }
        public static void ChangeUserName(int id, string newUserName){
        using (SqlConnection connection = new SqlConnection(Secrets.getConnection()))
    {
        connection.Open();
        string query = "Update Users SET User_Name = @Name WHERE User_ID = @UserId";
        using (SqlCommand command = new SqlCommand(query, connection))
        {
            command.Parameters.AddWithValue("@Name", newUserName);
            command.Parameters.AddWithValue("@UserId", id);
            command.ExecuteNonQuery();
        }
    }
    }
    public static void ChangePhoneNumber(int id, string phoneNumber){
        using (SqlConnection connection = new SqlConnection(Secrets.getConnection()))
    {
        connection.Open();
        string query = "Update Users SET Phone_Number = @phoneNumber WHERE User_ID = @UserId";
        using (SqlCommand command = new SqlCommand(query, connection))
        {
            command.Parameters.AddWithValue("@phoneNumber", phoneNumber);
            command.Parameters.AddWithValue("@UserId", id);
            command.ExecuteNonQuery();
        }
    }
    }

    public static List<User> getEmployees(){
        List<User> userList = new List<User>();
        using (SqlConnection connection = new SqlConnection(Secrets.getConnection()))
    {
        connection.Open();
        string query = "SELECT User_ID, User_Name, Hashed_Password, Full_Name, Phone_Number, User_Position FROM Users WHERE User_Position = 'Employee'";
        using (SqlCommand command = new SqlCommand(query, connection))
        {

            using (SqlDataReader reader = command.ExecuteReader())
            {
                while(reader.Read())
                {
                    int userId = reader.GetInt32(0);
                    string userName = reader.GetString(1);
                    string hashedPassword = reader.GetString(2);
                    string fullName = reader.GetString(3);
                    string phoneNumber = reader.GetString(4);
                    string userPosition = reader.GetString(5);
                    string[] name = fullName.Split(' ').Select(word => word.Trim()).ToArray();

                    userList.Add(new User(userId, userName, hashedPassword, name[0], name[1], phoneNumber, userPosition));
                }
            }
        }
    }
    return userList;
        
    }


    public static User CreateNewUser(string username, string hashedPassword, string fullName, string phoneNumber){
        using (SqlConnection connection = new SqlConnection(Secrets.getConnection()))
        {
            connection.Open();
            string query = "INSERT INTO Users(User_Name, Hashed_Password, Full_Name, Phone_Number, User_Position) VALUES (@username, @hashedPassword, @fullName, @phoneNumber, 'Employee')";
            using (SqlCommand command = new SqlCommand(query, connection)){
                command.Parameters.AddWithValue("@username", username);
                command.Parameters.AddWithValue("@hashedPassword", hashedPassword);
                command.Parameters.AddWithValue("@fullName", fullName);
                command.Parameters.AddWithValue("@phoneNumber", phoneNumber);
                command.ExecuteNonQuery();
            }
        }
        return null;
    }
    public static User GetUserByUsername(string username)
{
    User user = null;

    using (SqlConnection connection = new SqlConnection(Secrets.getConnection()))
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
