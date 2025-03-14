using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
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

        public async Task<IActionResult> OnGetAsync()
        {
            var query = _db.ToDoTask.AsQueryable();

            query = SortOrder switch
            {
                "name" => query.OrderBy(t => t.Name),
                "date" => query.OrderBy(t => t.DueDate),
                "status" => query.OrderBy(t => t.IsCompleted),
                _ => query.OrderBy(t => t.Name)
            };

            ToDoTasks = await query.ToListAsync();

            // If it's an AJAX request, return only the sorted table
            if (Request.Headers["X-Requested-With"] == "XMLHttpRequest")
            {
                return Partial("_SortByPartial", ToDoTasks);
            }

            return Page();
        }
    }
}