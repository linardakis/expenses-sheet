using Expenses.Server.Repositories.DB;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);

if (!File.Exists("expenses.db"))
{
    File.Create("expenses.db");
}

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddControllers();

builder.Services.AddDbContext<ExpensesDBContext>(
    options => options.UseSqlite("Data source=expenses.db"));

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
