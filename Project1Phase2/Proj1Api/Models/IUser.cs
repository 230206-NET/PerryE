namespace Models;
public class IUser
{
        public IUser(int userId, string userName, string hashedPassword, string firstName, string lastName, string cellNumber, string role)
    {
        UserId = userId;
        UserName = userName;
        HashedPassword = hashedPassword;
        FirstName = firstName;
        LastName = lastName;
        CellNumber = cellNumber;
        Role = role;
    }
        public IUser(int userId, string userName, string firstName, string lastName, string cellNumber, string role)
    {
        UserId = userId;
        UserName = userName;
        FirstName = firstName;
        LastName = lastName;
        CellNumber = cellNumber;
        Role = role;
    }
    public IUser(){}
    public int UserId{get; set;}
    public string UserName{get;set;}
    public string HashedPassword{get; set;}
    public string FirstName{get; set;}
    public string LastName{get; set;}
    public string CellNumber{get; set;}
    public string Role {get; set;}


    
}
