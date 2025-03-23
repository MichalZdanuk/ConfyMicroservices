var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services
	.AddApiServices(builder.Configuration)
	.AddConfyAuthentication(builder.Configuration);

builder.Services.AddControllers();

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseAuthentication();
app.UseAuthorization();
app.UseApiServices();

app.MapControllers();

app.Run();
