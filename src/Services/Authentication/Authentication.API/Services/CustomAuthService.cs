using Authentication.API.Authentication.Register;
using Authentication.API.Exceptions;
using Authentication.API.ValueObjects;
using Microsoft.IdentityModel.Tokens;
using Shared.Enums;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Authentication.API.Services;

public class CustomAuthService(AuthenticationDbContext dbContext,
	IConfiguration configuration)
	: ICustomAuthService
{
	public async Task<User> Register(string FirstName, string LastName, string Email, string Password, UserRole UserRole)
	{
		if (await dbContext.Users.AnyAsync(u => u.Email == Email))
		{
			throw new EmailAlreadyTakenException(Email);
		}

		var user = User.Create(Email,
			BCrypt.Net.BCrypt.HashPassword(Password),
			FullName.Of(FirstName, LastName),
			UserRole);

		dbContext.Users.Add(user);
		await dbContext.SaveChangesAsync();

		return user;
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
