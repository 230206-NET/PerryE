using System.Collections.Generic;
using DataAccess;
using Models;
using services;
namespace UI;
public class SubmitTicket{
    public SubmitTicket(User user){
        Console.WriteLine("Please enter the amount for your ticket");
        double ticketAmount;
        bool parseSuccess = double.TryParse(Console.ReadLine(), out ticketAmount);
        
    }
}