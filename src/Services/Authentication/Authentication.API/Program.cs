using Authentication.API;
using Authentication.API.DAL;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<AuthenticationDbContext>(options =>
	options.UseSqlServer(builder.Configuration.GetConnectionString("Database")));

builder.Services.AddControllers();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
	await app.InitialiseDatabaseAsync();
}

// Configure the HTTP request pipeline.

app.UseAuthorization();

app.MapControllers();

app.Run();
