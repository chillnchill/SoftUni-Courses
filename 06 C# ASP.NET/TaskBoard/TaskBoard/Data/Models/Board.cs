using System.ComponentModel.DataAnnotations;

namespace TaskBoard.Data.Models
{
	using static TaskBoard.Data.DataConstants.Board;
	public class Board
	{
        public Board()
        {
            Tasks = new HashSet<Task>();
        }

        [Key]
		public int Id { get; set; }

		[Required]
		[MaxLength(NameMaxLength)]
		public string Name { get; set; } = null!;

		public virtual IEnumerable<Task> Tasks { get; set; }
    }
}
