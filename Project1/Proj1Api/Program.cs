using Microsoft.AspNetCore.Mvc;
using Models;
using services;
using DataAccess;
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
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
app.Run();
