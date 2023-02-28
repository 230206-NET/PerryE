using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Models;
using DataAccess;
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
app.MapGet("/ticket", ([FromQuery] int? empId) => {
    if (empId != null){
        return DBAccess.GetSpecifiedUserTickets((int) empId);
    }
    return DBAccess.GetAllUnapprovedTickets();
}
);
app.MapPost("/newTicket", ([FromBody] Ticket ticket) =>{
    Results.Created("/newTicket", DBAccess.CreateNewTicket(ticket));
});
app.MapPost("/newUser", ([FromBody] IUser user) =>{
    Results.Created("/newUser", DBAccess.CreateNewUser(user.UserName, user.HashedPassword, user.FirstName + " " + user.LastName, user.CellNumber));
});
app.Run();
