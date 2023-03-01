using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Models;
using DataAccess;
using services;
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<DBAccess>();

var app = builder.Build();
app.UseSwagger();
app.UseSwaggerUI();
app.MapGet("/", () => "Hello World!");
app.MapGet("/greet", ([FromQuery]string? name) => $"Hello {name}");
app.MapGet("/greet/{name}", (string? name) => $"Hello {name}");
app.MapGet("/username", ([FromQuery] string username) =>{
    return DBAccess.GetUserByUsername(username);
});
app.MapGet("/ticket", ([FromQuery] int empId) => {
    if (empId != null){
        return DBAccess.GetSpecifiedUserTickets((int) empId);
    }
    return DBAccess.GetAllUnapprovedTickets();
}
);
app.MapGet("/users", () => {return DBAccess.getEmployees();});
app.MapGet("/users/Login", ([FromBody] string username, [FromBody] string password) =>{
    if (PasswordHelper.Login(username, password)){
        IUser user = DBAccess.GetUserByUsername(username);
        return user;
    } else{
        return null;
    }
});
app.MapGet("/tickets/{userId}/Pending", (int userId) =>{
    DBAccess.GetUserTicketsByStatus(userId, "Pending");
});
app.MapGet("/tickets/{userId}/Approved", (int userId) =>{
    DBAccess.GetUserTicketsByStatus(userId, "Approved");
});
app.MapGet("/tickets/{userId}/Denied", (int userId) =>{
    DBAccess.GetUserTicketsByStatus(userId, "Denied");
});
app.MapGet("/tickets/ByCategory/{userId}/{category}", (int userId, string category) =>{
    DBAccess.GetUserTicketsFromCategory(userId, category);
});
app.MapPost("/users/MakeManager/{userId}", (int userId) =>{
    DBAccess.MakeEmployeeManager(userId);
});
app.MapPost("/users/register", ([FromBody] IUser user) =>{
    DBAccess.CreateNewUser(user.UserName, PasswordHelper.HashAndSaltPassword(user.HashedPassword), user.FirstName + " " + user.LastName, user.CellNumber);
});
app.MapPost("/newTicket", ([FromBody] Ticket ticket) =>{
    Results.Created("/newTicket", DBAccess.CreateNewTicket(ticket));
});
app.Run();
