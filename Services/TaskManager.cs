using ToDoList.Model;

namespace ToDoList.Services
{
    public class TaskManager
    {
        private List<ToDoTask> tasks = new List<ToDoTask>();

        public void AddTask(string _title)
        {
            tasks.Add(new ToDoTask
            {
                Id = tasks.Count + 1,
                Description = _title,
                IsCompleted = 0
            });
        }

        public void RemoveTask(int _id)
        {
            tasks.RemoveAll(t => t.Id == _id);
        }
    }
}
