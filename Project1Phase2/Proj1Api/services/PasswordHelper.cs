using System.Security.Cryptography;
using System.Text;
using System.Data.SqlClient;
namespace services;
public static class PasswordHelper
{
    public static string HashAndSaltPassword(string password)
    {
        // Generate a random salt
        byte[] salt = GenerateSalt();

        // Compute the hash of the password using the salt
        byte[] hash = ComputeHash(password, salt);

        // Convert the salt and hash to a base64-encoded string
        string saltString = Convert.ToBase64String(salt);
        string hashString = Convert.ToBase64String(hash);

        // Return the salt and hash as a combined string
        return $"{saltString}:{hashString}";
    }

    private static byte[] GenerateSalt()
    {
        // Generate a 16-byte random salt
        byte[] salt = new byte[16];
        using (var rng = new RNGCryptoServiceProvider())
        {
            rng.GetBytes(salt);
        }
        return salt;
    }

    private static byte[] ComputeHash(string password, byte[] salt)
    {
        // Compute the hash of the password using the PBKDF2 algorithm with 10000 iterations
        using (var pbkdf2 = new Rfc2898DeriveBytes(password, salt, 10000))
        {
            return pbkdf2.GetBytes(32); // Use a 32-byte hash
        }
    }

    public static bool VerifyPassword(string password, string hashedPassword)
    {
        // Split the salt and hash from the combined string
        string[] parts = hashedPassword.Split(':');
        string saltString = parts[0];
        string hashString = parts[1];

        // Convert the salt and hash from base64-encoded strings to byte arrays
        byte[] salt = Convert.FromBase64String(saltString);
        byte[] hash = Convert.FromBase64String(hashString);

        // Compute the hash of the entered password using the salt
        byte[] enteredHash = ComputeHash(password, salt);

        // Compare the computed hash with the stored hash
        return SlowEquals(hash, enteredHash);
    }

    private static bool SlowEquals(byte[] a, byte[] b)
    {
        // Compare the two byte arrays in a way that avoids timing attacks
        uint diff = (uint)a.Length ^ (uint)b.Length;
        for (int i = 0; i < a.Length && i < b.Length; i++)
        {
            diff |= (uint)(a[i] ^ b[i]);
        }
        return diff == 0;
    }
    public static bool Login(string username, string password)
{
    string connectionString = "Server=ticket-reimbursement.database.windows.net;Database=ticketsDB;User Id=ticket-admin;Password=Password1;";
    string sql = "SELECT Hashed_Password FROM Users WHERE User_Name = @Username";
    string hashedPassword = "";

    using (SqlConnection connection = new SqlConnection(connectionString))
    {
        SqlCommand command = new SqlCommand(sql, connection);
        command.Parameters.AddWithValue("@Username", username);

        connection.Open();

        using (SqlDataReader reader = command.ExecuteReader())
        {
            if (reader.Read())
            {
                hashedPassword = reader.GetString(0);
            }
        }
    }

    // Compare the hashed password from the database with the user-entered password
    if (!string.IsNullOrEmpty(hashedPassword))
    {
        if (VerifyPassword(password, hashedPassword))
        {
            Console.WriteLine("true");
            return true;
        }
    }
    Console.WriteLine("false");
    return false;
}
}