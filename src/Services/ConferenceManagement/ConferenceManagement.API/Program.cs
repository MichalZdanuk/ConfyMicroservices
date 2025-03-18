using ConferenceManagement.API;
using ConferenceManagement.Application;
using ConferenceManagement.Infrastructure;
using Shared.Context;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services
	.AddApplication(builder.Configuration)
	.AddInfrastructure(builder.Configuration)
	.AddApiServices(builder.Configuration)
	.AddConfyAuthentication(builder.Configuration);

builder.Services.AddControllers();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
	await app.InitialiseDatabaseAsync();
}

// Configure the HTTP request pipeline.
app.UseAuthentication();
app.UseAuthorization();
app.UseApiServices();

app.MapControllers();

app.Run();
