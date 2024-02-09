using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TaskBoard.Data.Models
{
	using static TaskBoard.Data.DataConstants.Task;
	public class Task
	{
		[Key]
		public int Id { get; set; }

		[Required]
		[MaxLength(TitleMaxLength)]
		public string Title { get; set; } = null!;

		[Required]
		[MaxLength(DescriptionMaxLength)]
		public string Description { get; set; } = null!;

		public DateTime CreatedOn { get; set; }

		[ForeignKey(nameof(Board))]
		public int BoardId { get; set; }
		public Board? Board { get; set; }

		//this one is a string because the IdentityUser class has a string for Id!
		[Required]
		public string OwnerId { get; set; } = null!;

		public IdentityUser Owner { get; set; } = null!;
    }
}
