using Authentication.API.DAL;
using Authentication.API.Entities;
using Authentication.API.Exceptions;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Authentication.API.Services;

public class CustomAuthService(AuthenticationDbContext dbContext,
	IConfiguration configuration)
	: ICustomAuthService
{
	public async Task Register(string email, string password)
	{
		if (await dbContext.Users.AnyAsync(u => u.Email == email))
		{
			throw new EmailAlreadyTakenException(email);
		}

		var user = User.Create(email, BCrypt.Net.BCrypt.HashPassword(password));

		dbContext.Users.Add(user);
		await dbContext.SaveChangesAsync();
	}

	public async Task<string> Login(string email, string password)
	{
		var user = await dbContext.Users.SingleOrDefaultAsync(u => u.Email == email);
		if (user is null || !BCrypt.Net.BCrypt.Verify(password, user.PasswordHash))
		{
			throw new InvalidLoginCredentials();
		}

		return GenerateJwtToken(user);
	}

	private string GenerateJwtToken(User user)
	{
		var key = Encoding.UTF8.GetBytes(configuration["Jwt:Key"]!);
		var claims = new List<Claim>
		{
			new(ClaimTypes.NameIdentifier, user.Id.ToString()),
			new(ClaimTypes.Email, user.Email),
			new(ClaimTypes.Role, user.UserRole.ToString()),
		};

		var token = new JwtSecurityToken(
			configuration["Jwt:Issuer"],
			configuration["Jwt:Audience"],
			claims,
			expires: DateTime.UtcNow.AddHours(10),
			signingCredentials: new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256)
		);

		return new JwtSecurityTokenHandler().WriteToken(token);
	}
}
