using Microsoft.AspNetCore.Mvc.RazorPages;
using ToDoList.Data;
using ToDoList.Model;

namespace ToDoList.Pages.TaskPages
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _db;

        public IEnumerable<ToDoTask> ToDoTasks { get; set; }

        public IndexModel(ApplicationDbContext db)
        {
            _db = db;
        }

        public void OnGet()
        {
            //Retrieve all the list of tasks
            ToDoTasks = _db.ToDoTask;
        }
    }
}
