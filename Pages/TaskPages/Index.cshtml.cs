using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Text;
using ToDoList.Data;
using ToDoList.Model;

namespace ToDoList.Pages.TaskPages
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _db;
        public IndexModel(ApplicationDbContext db)
        {
            _db = db;
        }

        public List<ToDoTask> ToDoTasks { get; set; }

        [BindProperty(SupportsGet = true)]
        public string SortOrder { get; set; } = "date"; // Default sorting by Name

        [BindProperty(SupportsGet = true)]
        public string DownloadType { get; set; } = "txt"; //Default downloading by txt file

        public async Task<IActionResult> OnGetAsync()
        {
            ToDoTasks = await SortedList();

            // If it's an AJAX request, return only the sorted table
            if (Request.Headers["X-Requested-With"] == "XMLHttpRequest")
            {
                return Partial("_SortByPartial", ToDoTasks);
            }

            return Page();
        }

        public async Task<IActionResult> OnGetDownloadTasksAsync() //Save in file
        {
            ToDoTasks = await SortedList();
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendLine("List of tasks");
            stringBuilder.AppendLine("=======================");
            foreach (var t in ToDoTasks)
            {
                stringBuilder.AppendLine($"{t.Id}. [{(t.IsCompleted ? "✔" : " ")}] {t.Name}: {t.Description} {t.DueDate}");
            }
            var bytes = Encoding.UTF8.GetBytes(stringBuilder.ToString());
            var fileName = "To-Do-List.txt";
            return File(bytes, "text/plain", fileName);
        }

        public async Task<List<ToDoTask>> SortedList()
        {
            var query = _db.ToDoTask.AsQueryable();
            query = SortOrder switch
            {
                "name" => query.OrderBy(t => t.Name),
                "date" => query.OrderBy(t => t.DueDate),
                "status" => query.OrderBy(t => t.IsCompleted),
                _ => query.OrderBy(t => t.Name)
            };
            return await query.ToListAsync();
        }
    }
}