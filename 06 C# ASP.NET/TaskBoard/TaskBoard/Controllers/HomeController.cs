using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using TaskBoard.Data;
using TaskBoard.ViewModels.Home;

namespace TaskBoard.Controllers
{
	public class HomeController : Controller
	{
		//don't forget to initialize the dbContext, you need both the readonly and the constructor
		private readonly TaskBoardAppDbContext _data;
		public HomeController(TaskBoardAppDbContext context)
		{
			_data = context;
		}

		public async Task<IActionResult> Index()
		{
			var taskBoards = _data
				 .Boards
				 .Select(b => b.Name.ToLower())
				 .ToArray();

			var tasksCount = new List<HomeBoardModel>();

			foreach (var boardName in taskBoards)
			{
				var tasksInBoard = _data.Tasks.Where(t => t.Board.Name == boardName).Count();
				tasksCount.Add(new HomeBoardModel()
				{
					BoardName = boardName,
					TaskCount = tasksInBoard
				});
			}
			var userTasksCount = -1;

			if (User.Identity.IsAuthenticated)
			{
				var currentUserId = User.FindFirst(ClaimTypes.NameIdentifier).Value;
				userTasksCount = _data.Tasks.Where(t => t.OwnerId == currentUserId).Count();
			}

			var homeModel = new HomeViewModel()
			{
				AllTasksCount = _data.Tasks.Count(),
				BoardsWithTasksCount = tasksCount,
				UserTasksCount = userTasksCount
			};

			return View(homeModel);
		}
	}
}
