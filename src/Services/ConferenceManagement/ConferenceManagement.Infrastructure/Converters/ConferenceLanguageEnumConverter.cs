using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Shared.Enums;

namespace ConferenceManagement.Infrastructure.Converters;
public class ConferenceLanguageEnumConverter
	: ValueConverter<ConferenceLanguage, string>
{
	public ConferenceLanguageEnumConverter() : base(
			v => v.ToString(),
			v => (ConferenceLanguage)Enum.Parse(typeof(ConferenceLanguage), v))
	{ }
}
