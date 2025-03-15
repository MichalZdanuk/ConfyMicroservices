using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Shared.Domain;
public abstract class Entity : IEntity
{
	[Column(Order = 0)]
	[Key]
	[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
	public Guid Id { get; set; }

	[Column(Order = 1)]
	public DateTime CreationDate { get; set; }
	
	[Column(Order = 2)]
	public DateTime UpdateDate { get; set; }
}
