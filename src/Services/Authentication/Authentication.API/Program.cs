using Shared.Context;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services
	.AddApiServices(builder.Configuration)
	.AddApplicationServices()
	.AddInfrastructure(builder.Configuration)
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
