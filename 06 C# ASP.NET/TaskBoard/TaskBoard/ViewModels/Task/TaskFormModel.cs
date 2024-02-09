using System.ComponentModel.DataAnnotations;

namespace TaskBoard.ViewModels.Task
{
    using static TaskBoard.Data.DataConstants.Task;
    public class TaskFormModel
    {
        public TaskFormModel()
        {
          Boards = new HashSet<TaskBoardModel>();   
        }

        [Required]
        [StringLength(TitleMaxLength, MinimumLength = TitleMinLength,
            ErrorMessage = "Title should be at least {2} chars long")]
        public string Title { get; set; } = null!;

		[Required]
		[StringLength(DescriptionMaxLength, MinimumLength = DescriptionMinLength,
            ErrorMessage = "Description should be between {2} and {1} characters long")]
		public string Description { get; set; } = null!;

		[Display(Name = "Board")]
        public int BoardId { get; set; }

        public IEnumerable<TaskBoardModel> Boards { get; set; } = null!;
    }
}
