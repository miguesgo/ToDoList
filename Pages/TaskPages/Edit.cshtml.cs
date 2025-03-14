using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ToDoList.Data;
using ToDoList.Model;

namespace ToDoList.Pages.TaskPages
{
    [BindProperties] //Avoid redundant property of this type in OnPost Method
    public class EditModel : PageModel
    {
        private readonly ApplicationDbContext _db;

        public ToDoTask ToDoTask { get; set; }

        public EditModel(ApplicationDbContext db)
        {
            _db = db;
        }

        public void OnGet(int id)
        {
            ToDoTask = _db.ToDoTask.Find(id)!;
        }

        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                _db.ToDoTask.Update(ToDoTask);
                await _db.SaveChangesAsync();
                return RedirectToPage("Index");
            }
            return Page();
        }
    }
}
