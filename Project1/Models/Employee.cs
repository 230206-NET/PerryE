﻿
namespace Models;
public class Employee : IUser
{
    public string Role{get; set;}
    public string HashedPass{get; set;}
    public double CellNumber{get; set;}
    public string FirstName{get; set;}
    public string LastName{get; set;}
    public int UserId{get; set;}
    public string UserName { get; set; }
    public string HashedPassword { get; set;}

    public Employee(int UserId){
        this.UserId = UserId;
        //code to set the fields equal to the value from the database
    }

    public List<Ticket> getTickets(){
        //Implement Code that finds all tickets with the user's UserId
        return null!;

    }
}
