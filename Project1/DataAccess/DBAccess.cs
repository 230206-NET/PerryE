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
        string query = "Update Users SET User_Position = 'Manager' WHERE User_ID = @UserId";
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


    public static void CreateNewUser(string username, string hashedPassword, string fullName, string phoneNumber){
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
    }
    public static User? GetUserByUsername(string username)
{
    User? user = null;

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
    public static void CreateNewTicket(double amount, string description, int userId, string userName){
        using (SqlConnection connection = new SqlConnection(Secrets.getConnection()))
        {
            connection.Open();
            string query = "INSERT INTO Tickets(Ticket_Category, Ticket_Amount, Ticket_User_Id, Ticket_Submitter_Name, Ticket_Date, Ticket_Status) VALUES(@Category, @Amount, @UserId, @userName, @Date, 'Pending')";
            using (SqlCommand command = new SqlCommand(query, connection)){
                command.Parameters.AddWithValue("@Category", description);
                command.Parameters.AddWithValue("@Amount", amount);
                command.Parameters.AddWithValue("@UserId", userId);
                command.Parameters.AddWithValue("@userName", userName);
                command.Parameters.AddWithValue("@Date", DateTime.Today);
                command.ExecuteNonQuery();
            }
        }
        return;
    }
    public static List<Ticket> GetUserTicketsByStatus(int userId, string status)
    {
        List<Ticket> tickets = new List<Ticket>();

        using (SqlConnection connection = new SqlConnection(Secrets.getConnection()))
        {
            connection.Open();
            string query = "SELECT * FROM Tickets WHERE Ticket_User_Id = @UserId AND Ticket_Status = @status";
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@UserId", userId);
                command.Parameters.AddWithValue("@status", status);

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int ticketNum = reader.GetInt32(0);
                        string category = reader.GetString(1);
                        double amount = (double) reader.GetDecimal(2);
                        string userName = reader.GetString(4);
                        DateTime dateOfSubmission = reader.GetDateTime(5).Date;

                         tickets.Add(new Ticket(ticketNum, amount, dateOfSubmission, userId, userName, status, category));
                    }
                }
        }
        return tickets;
    }
}
    public static List<Ticket> GetAllUnapprovedTickets()
    {
        List<Ticket> tickets = new List<Ticket>();

        using (SqlConnection connection = new SqlConnection(Secrets.getConnection()))
        {
            connection.Open();
            string query = "SELECT * FROM Tickets WHERE Ticket_Status = 'Pending'";
            using (SqlCommand command = new SqlCommand(query, connection))
            {

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while(reader.Read())
                    {
                        int ticketNum = reader.GetInt32(0);
                        string category = reader.GetString(1);
                        double amount = (double) reader.GetDecimal(2);
                        int userId = reader.GetInt32(3);
                        string userName = reader.GetString(4);
                        DateTime dateOfSubmission = reader.GetDateTime(5).Date;

                         tickets.Add(new Ticket(ticketNum, amount, dateOfSubmission, userId, userName, "Pending", category));
                    }
                }
        }
        return tickets;
    }
}
    public static void DecideOnTicket(int ticketId, string newStatus)
    {
        List<Ticket> tickets = new List<Ticket>();

        using (SqlConnection connection = new SqlConnection(Secrets.getConnection()))
        {
            connection.Open();
            string query = "Update Tickets SET Ticket_Status = @newStatus WHERE Ticket_Num = @ticketId";
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@newStatus", newStatus);
                command.Parameters.AddWithValue("@ticketId", ticketId);

                command.ExecuteNonQuery();
        }
    }
}
    public static List<Ticket> GetAllTicketsFromCategory(string category)
    {
        List<Ticket> tickets = new List<Ticket>();

        using (SqlConnection connection = new SqlConnection(Secrets.getConnection()))
        {
            connection.Open();
            string query = "SELECT * FROM Tickets WHERE Ticket_Category LIKE @category";
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@category", "%" + category + "%");

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while(reader.Read())
                    {
                        int ticketNum = reader.GetInt32(0);
                        string fullCategory = reader.GetString(1);
                        double amount = (double) reader.GetDecimal(2);
                        int userId = reader.GetInt32(3);
                        string userName = reader.GetString(4);
                        DateTime dateOfSubmission = reader.GetDateTime(5).Date;
                        string status = reader.GetString(6);

                         tickets.Add(new Ticket(ticketNum, amount, dateOfSubmission, userId, userName, status, fullCategory));
                    }
                }
        }
        return tickets;
    }
}
    public static List<Ticket> GetUserTicketsFromCategory(int userId, string category)
    {
        List<Ticket> tickets = new List<Ticket>();

        using (SqlConnection connection = new SqlConnection(Secrets.getConnection()))
        {
            connection.Open();
            string query = "SELECT * FROM Tickets WHERE Ticket_Category Like @category AND Ticket_User_Id = @userId";
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@category", "%" + category + "%");
                command.Parameters.AddWithValue("@userId", userId);

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while(reader.Read())
                    {
                        int ticketNum = reader.GetInt32(0);
                        string fullCategory = reader.GetString(1);
                        double amount = (double) reader.GetDecimal(2);
                        string userName = reader.GetString(4);
                        DateTime dateOfSubmission = reader.GetDateTime(5).Date;
                        string status = reader.GetString(6);

                         tickets.Add(new Ticket(ticketNum, amount, dateOfSubmission, userId, userName, status, fullCategory));
                    }
                }
        }
        return tickets;
    }
}
    public static List<Ticket> GetSpecifiedUserTickets(int userId)
    {
        List<Ticket> tickets = new List<Ticket>();

        using (SqlConnection connection = new SqlConnection(Secrets.getConnection()))
        {
            connection.Open();
            string query = "SELECT * FROM Tickets WHERE Ticket_User_Id = @userId";
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@userId", userId);

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while(reader.Read())
                    {
                        int ticketNum = reader.GetInt32(0);
                        string fullCategory = reader.GetString(1);
                        double amount = (double) reader.GetDecimal(2);
                        string userName = reader.GetString(4);
                        DateTime dateOfSubmission = reader.GetDateTime(5).Date;
                        string status = reader.GetString(6);

                         tickets.Add(new Ticket(ticketNum, amount, dateOfSubmission, userId, userName, status, fullCategory));
                    }
                }
        }
        return tickets;
    }
}
}
