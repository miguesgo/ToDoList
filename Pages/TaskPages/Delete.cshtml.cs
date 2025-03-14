using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ToDoList.Data;
using ToDoList.Model;

namespace ToDoList.Pages.TaskPages
{
    [BindProperties] //Avoid redundant property of this type in OnPost Method
    public class DeleteModel : PageModel
    {
        private readonly ApplicationDbContext _db;

        public ToDoTask ToDoTask { get; set; }

        public DeleteModel(ApplicationDbContext db)
        {
            _db = db;
        }

        public void OnGet(int id)
        {
            ToDoTask = _db.ToDoTask.Find(id)!;
        }

        public async Task<IActionResult> OnPost()
        {
            var taskFromDb = _db.ToDoTask.Find(ToDoTask.Id);
            if (taskFromDb != null)
            {
                _db.ToDoTask.Remove(taskFromDb);
                await _db.SaveChangesAsync();
                return RedirectToPage("Index");
            }
            return Page();
        }
    }
}
