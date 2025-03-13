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

        public int IsCompleted { get; set; }

        public string DueDate { get; set; }
    }
}
