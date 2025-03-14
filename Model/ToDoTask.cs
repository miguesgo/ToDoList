using System.ComponentModel.DataAnnotations;

namespace ToDoList.Model
{
    public class ToDoTask
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public string Description { get; set; }

        public bool IsCompleted { get; set; }

        public DateTime DueDate { get; set; }
    }
}
