using TaskBoard.ViewModels.Task;

namespace TaskBoard.ViewModels.Board
{
	public class BoardViewModel
	{
        public BoardViewModel()
        {
            Tasks = new HashSet<TaskViewModel>();
        }
        public int Id { get; init; }

		public string Name { get; init; } = null!;

        public IEnumerable<TaskViewModel> Tasks { get; set; } 
    }
}
