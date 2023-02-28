using System.Text.Json;
using Models;
using System.Data.SqlClient;
using System.Data;
namespace DataAccess;
public class DBAccess
{
    public static void MakeEmployeeManager(int id){
        List<IUser> userList = new List<IUser>();
        using (SqlConnection connection = new SqlConnection(Secrets.getConnection()))
    {
        connection.Open();
        string query = "Update IUsers SET IUser_Position = 'Manager' WHERE IUser_ID = @IUserId";
        using (SqlCommand command = new SqlCommand(query, connection))
        {
            command.Parameters.AddWithValue("@IUserId", id);
            command.ExecuteNonQuery();
        }
    }
    }

    public static List<IUser> getEmployees(){
        List<IUser> userList = new List<IUser>();
        using (SqlConnection connection = new SqlConnection(Secrets.getConnection()))
    {
        connection.Open();
        string query = "SELECT IUser_ID, IUser_Name, Hashed_Password, Full_Name, Phone_Number, IUser_Position FROM IUsers WHERE IUser_Position = 'Employee'";
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

                    userList.Add(new Employee(userId, userName, hashedPassword, name[0], name[1], phoneNumber, userPosition));
                }
            }
        }
    }
    return userList;
        
    }


    public static void CreateNewIUser(string username, string hashedPassword, string fullName, string phoneNumber){
        using (SqlConnection connection = new SqlConnection(Secrets.getConnection()))
        {
            connection.Open();
            string query = "INSERT INTO IUsers(IUser_Name, Hashed_Password, Full_Name, Phone_Number, IUser_Position) VALUES (@username, @hashedPassword, @fullName, @phoneNumber, 'Employee')";
            using (SqlCommand command = new SqlCommand(query, connection)){
                command.Parameters.AddWithValue("@username", username);
                command.Parameters.AddWithValue("@hashedPassword", hashedPassword);
                command.Parameters.AddWithValue("@fullName", fullName);
                command.Parameters.AddWithValue("@phoneNumber", phoneNumber);
                command.ExecuteNonQuery();
            }
        }
    }
    public static IUser? GetIUserByIUsername(string username)
{

        IUser user = null;
    using (SqlConnection connection = new SqlConnection(Secrets.getConnection()))
    {
        connection.Open();
        string query = "SELECT IUser_ID, IUser_Name, Hashed_Password, Full_Name, Phone_Number, IUser_Position FROM IUsers WHERE IUser_Name = @username";
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
                    if (userPosition == "Manager"){
                        user = new Manager(userId, userName, hashedPassword, name[0], name[1], phoneNumber, userPosition);
                    } else{
                        user = new Employee(userId, userName, hashedPassword, name[0], name[1], phoneNumber, userPosition);
                    }
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
            string query = "INSERT INTO Tickets(Ticket_Category, Ticket_Amount, Ticket_IUser_Id, Ticket_Submitter_Name, Ticket_Date, Ticket_Status) VALUES(@Category, @Amount, @IUserId, @userName, @Date, 'Pending')";
            using (SqlCommand command = new SqlCommand(query, connection)){
                command.Parameters.AddWithValue("@Category", description);
                command.Parameters.AddWithValue("@Amount", amount);
                command.Parameters.AddWithValue("@IUserId", userId);
                command.Parameters.AddWithValue("@userName", userName);
                command.Parameters.AddWithValue("@Date", DateTime.Today);
                command.ExecuteNonQuery();
            }
        }
        return;
    }
    public static List<Ticket> GetIUserTicketsByStatus(int userId, string status)
    {
        List<Ticket> tickets = new List<Ticket>();

        using (SqlConnection connection = new SqlConnection(Secrets.getConnection()))
        {
            connection.Open();
            string query = "SELECT * FROM Tickets WHERE Ticket_IUser_Id = @IUserId AND Ticket_Status = @status";
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@IUserId", userId);
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
    public static List<Ticket> GetIUserTicketsFromCategory(int userId, string category)
    {
        List<Ticket> tickets = new List<Ticket>();

        using (SqlConnection connection = new SqlConnection(Secrets.getConnection()))
        {
            connection.Open();
            string query = "SELECT * FROM Tickets WHERE Ticket_Category Like @category AND Ticket_IUser_Id = @userId";
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
public static void changeIUserField(string field, int id, string input){
        using (SqlConnection connection = new SqlConnection(Secrets.getConnection()))
    {
        connection.Open();
        string query = "Update IUsers SET " + field + " = @NewData WHERE IUser_ID = @IUserId";
        using (SqlCommand command = new SqlCommand(query, connection))
        {
            command.Parameters.AddWithValue("@NewData", input);
            command.Parameters.AddWithValue("@IUserId", id);
            command.ExecuteNonQuery();
        }
    }
}
    public static List<Ticket> GetSpecifiedIUserTickets(int userId)
    {
        List<Ticket> tickets = new List<Ticket>();

        using (SqlConnection connection = new SqlConnection(Secrets.getConnection()))
        {
            connection.Open();
            string query = "SELECT * FROM Tickets WHERE Ticket_IUser_Id = @userId";
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
