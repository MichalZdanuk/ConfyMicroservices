using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Registration.Domain.Enums;

namespace Registration.Infrastucture.Converters;
public class RegistrationStatusEnumConverter
	: ValueConverter<RegistrationStatus, string>
{
	public RegistrationStatusEnumConverter() : base(
			v => v.ToString(),
			v => (RegistrationStatus)Enum.Parse(typeof(RegistrationStatus), v))
	{ }
}
