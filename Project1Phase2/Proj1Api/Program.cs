using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Models;
using DataAccess;
using services;
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddScoped<DBAccess>(ctx => new DBAccess());
builder.Services.Configure<Microsoft.AspNetCore.Http.Json.JsonOptions>(options =>
{
    options.SerializerOptions.PropertyNamingPolicy = null;
});
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();
app.UseSwagger();
app.UseSwaggerUI();
app.MapGet("/username", ([FromQuery] string username) =>{
    return DBAccess.GetUserByUsername(username);
});
app.MapGet("/ticket", ([FromQuery] int? empId) => {
    if (empId != null){
        return DBAccess.GetSpecifiedUserTickets((int) empId);
    }
    return DBAccess.GetAllUnapprovedTickets();
}
);
app.MapGet("/ticket/{category}", (string category) => {
    return DBAccess.GetAllTicketsFromCategory(category);
    
}
);
app.MapGet("/ticket/{userId}", (int userId) => {
    return DBAccess.GetSpecifiedUserTickets(userId);
    
}
);
app.MapPost("/ticket/{ticketId}/{decision}", (int ticketId, string decision) => {
    DBAccess.DecideOnTicket(ticketId, decision);
});
app.MapGet("/users", () => {return DBAccess.getEmployees();});
app.MapGet("/users/Login", ([FromQuery] string username, [FromQuery] string password) =>{
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
    DBAccess.CreateNewTicket(ticket);
});
app.Run();
