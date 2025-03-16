using Authentication.API;
using Authentication.API.DAL;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services
	.AddApplicationServices()
	.AddInfrastructure(builder.Configuration);

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
