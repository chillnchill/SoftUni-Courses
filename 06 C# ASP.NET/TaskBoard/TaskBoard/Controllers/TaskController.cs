using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using TaskBoard.Data;
using TaskBoard.Data.Models;
using TaskBoard.ViewModels.Task;

namespace TaskBoard.Controllers
{
	public class TaskController : Controller
    {
        private readonly TaskBoardAppDbContext _data;

        public TaskController(TaskBoardAppDbContext context)
        {
            _data = context;
        }

        public async Task<IActionResult> Create()
        {
            TaskFormModel taskModel = new TaskFormModel()
            {
                Boards = GetBoards()
            };

            return View(taskModel);
        }


        [HttpPost]
        public async Task<IActionResult> Create(TaskFormModel taskModel)
        {
            if (!GetBoards().Any(b => b.Id == taskModel.BoardId))
            {
                ModelState.AddModelError(nameof(taskModel.BoardId), "Board does not exist.");
            }

            string currentUserId = GetUserId();

            if (!ModelState.IsValid)
            {
                taskModel.Boards = GetBoards();
                return View(taskModel);
            }

            Data.Models.Task task = new Data.Models.Task()
            {
                Title = taskModel.Title,
                Description = taskModel.Description,
                CreatedOn = DateTime.Now,
                BoardId = taskModel.BoardId,
                OwnerId = currentUserId
            };

            await _data.Tasks.AddAsync(task);
            await _data.SaveChangesAsync();

            var boards = _data.Boards;

            return RedirectToAction("All", "Board");
        }

        public async Task<IActionResult> Details(int id)
        {
            var task = await _data
                .Tasks
                .Where(t => t.Id == id)
                .Select(t => new TaskDetailsViewModel()
                {
                    Id = t.Id,
                    Title = t.Title,
                    Description = t.Description,
                    CreatedOn = t.CreatedOn.ToString("dd/MM/yyyy HH:mm"),
                    Board = t.Board.Name,
                    Owner = t.Owner.UserName
                })
                .FirstOrDefaultAsync();

            if (task == null)
            {
                return BadRequest();
            }

            return View(task);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var task = await _data.Tasks.FindAsync(id);

            if (task == null)
            {
                return BadRequest();
            }

            string currentUserId = GetUserId();

            if (currentUserId != task.OwnerId)
            {
                return Unauthorized();
            }

            TaskFormModel taskModel = new TaskFormModel()
            {
                Title = task.Title,
                Description = task.Description,
                BoardId = task.BoardId,
                Boards = GetBoards()
            };

            return View(taskModel);
        }

        [HttpPost]

        public async Task<IActionResult> Edit(int id, TaskFormModel taskModel)
        {
            var task = await _data.Tasks.FindAsync(id);

            if (task == null)
            {
                return BadRequest();
            }

			string currentUserId = GetUserId();

			if (currentUserId != task.OwnerId)
			{
				return Unauthorized();
			}

			if (!GetBoards().Any(b => b.Id == taskModel.BoardId))
			{
				ModelState.AddModelError(nameof(taskModel.BoardId), "Board does not exist.");
			}

            if (!ModelState.IsValid)
            {
                taskModel.Boards = GetBoards();

                return View(taskModel);
            }

            task.Title = taskModel.Title;
			task.Description = taskModel.Description;
            task.BoardId = taskModel.BoardId;

            await _data.SaveChangesAsync();
            return RedirectToAction("All", "Board");
        }

        public async Task<IActionResult> Delete(int id)
        {
            var task = await _data.Tasks.FindAsync(id);

			if (task == null)
			{
				return BadRequest();
			}

            string currentUserId = GetUserId();

            if (currentUserId != task.OwnerId)
            {
                return Unauthorized();
            }

            TaskViewModel taskModel = new TaskViewModel()
            {
                Id = task.Id,
                Title = task.Title,
                Description = task.Description
            };

            return View(taskModel);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(TaskViewModel taskModel)
        {
            
            var task = await _data.Tasks.FindAsync(taskModel.Id);

            
            if (task == null)
            {
                return BadRequest();
            }

            //when we are deleting and we know the task in the view exists we don't need to check for an ID but rather if 
            //the current logged in user has the authorization to delete
            //the process goes => get current user Id
            var currentUserId = GetUserId();
            //check if it equates to the user that created the Task (not Threads)
            if (currentUserId != task.OwnerId)
            {
                return Unauthorized();
            }

            //you don't need an await on the remove, because it simply MARKS the task for deleting, the actual deleting is handled
            //when we .SaveChanges();
             _data.Tasks.Remove(task);
            await _data.SaveChangesAsync();
            return RedirectToAction("All", "Board");
        }

        //this is how we get the Id of a Task's owner! It will be in 'string' format 
        private string GetUserId() => User.FindFirstValue(ClaimTypes.NameIdentifier);

        private IEnumerable<TaskBoardModel> GetBoards() =>
			_data
				.Boards
				.Select(x => new TaskBoardModel()
				{
					Id = x.Id,
					Name = x.Name
				});
	}
}
