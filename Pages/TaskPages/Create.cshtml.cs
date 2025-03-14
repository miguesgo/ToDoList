using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ToDoList.Data;
using ToDoList.Model;

namespace ToDoList.Pages.TaskPages
{
    [BindProperties] //Avoid redundant property of this type in OnPost Method
    public class CreateModel : PageModel
    {
        private readonly ApplicationDbContext _db;

        public ToDoTask ToDoTask { get; set; }

        public CreateModel(ApplicationDbContext db)
        {
            _db = db;
        }

        public void OnGet()
        { }

        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid) // Validation of the model ie. required values
            {
                await _db.ToDoTask.AddAsync(ToDoTask);
                await _db.SaveChangesAsync();
                return RedirectToPage("Index");
            }
            return Page();
        }
    }
}
