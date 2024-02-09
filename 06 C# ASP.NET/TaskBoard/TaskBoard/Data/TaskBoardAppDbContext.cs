using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TaskBoard.Data.Models;
using Task = TaskBoard.Data.Models.Task;

namespace TaskBoard.Data
{
	public class TaskBoardAppDbContext : IdentityDbContext
	{
		public TaskBoardAppDbContext(DbContextOptions<TaskBoardAppDbContext> options)
			: base(options)
		{
			//we use Migrate in order for the changes to be applied to the DB directly
			Database.Migrate();
		}

		public DbSet<Board> Boards { get; set; } = null!;
		public DbSet<Task> Tasks { get; set; } = null!;

		private IdentityUser TestUser { get; set; }

		private Board OpenBoard { get; set; } = null!;

		private Board InProgressBoard { get; set; } = null!;

		private Board DoneBoard { get; set; } = null!;
		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder
				.Entity<Task>()
				.HasOne(x => x.Board)
				.WithMany(x => x.Tasks)
				.HasForeignKey(x => x.BoardId)
				.OnDelete(DeleteBehavior.Restrict);

			SeedUsers();
			modelBuilder
				.Entity<IdentityUser>()
				.HasData(TestUser);

			SeedBoards();
			modelBuilder
				.Entity<Board>()
				.HasData(OpenBoard, InProgressBoard, DoneBoard);


			modelBuilder
				.Entity<Task>()
				.HasData(new Task()
				{
					Id = 1,
					Title = "Improve CSS styles",
					Description = "Implement better styling for all public pages",
					CreatedOn = DateTime.Now.AddDays(-200),
					OwnerId = TestUser.Id,
					BoardId = OpenBoard.Id
				},
				new Task()
				{
					Id = 2,
					Title = "Android Client App",
					Description = "Create Android client App for the RESTful TaskBoard service",
					CreatedOn = DateTime.Now.AddMonths(-5),
					OwnerId = TestUser.Id,
					BoardId = OpenBoard.Id
				},
				new Task()
				{
					Id = 3,
					Title = "Desktop Client App",
					Description = "Create Desktop client App for the RESTful TaskBoard service",
					CreatedOn = DateTime.Now.AddMonths(-1),
					OwnerId = TestUser.Id,
					BoardId = InProgressBoard.Id
				},
				new Task()
				{
					Id = 4,
					Title = "Create Tasks",
					Description = "Implement [Create Task] page for adding tasks",
					CreatedOn = DateTime.Now.AddYears(-1),
					OwnerId = TestUser.Id,
					BoardId = DoneBoard.Id
				});


			base.OnModelCreating(modelBuilder);

		}

		private void SeedBoards()
		{
			OpenBoard = new Board()
			{
				Id = 1,
				Name = "Open"
			};

			InProgressBoard = new Board()
			{
				Id = 2,
				Name = "In Progress"
			};

			DoneBoard = new Board()
			{
				Id = 3,
				Name = "Done"
			};


		}

		private void SeedUsers()
		{
			var hasher = new PasswordHasher<IdentityUser>();

			TestUser = new IdentityUser()
			{
				UserName = "test@softuni.bg",
				NormalizedUserName = "TEST@SOFTUNI.BG",
			};

			TestUser.PasswordHash = hasher.HashPassword(TestUser, "softuni");
		}
	}
}
