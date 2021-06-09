using System.Collections.Generic;

namespace TaskSchedule.Models
{
    public class TaskAddViewModel
    {
        public TaskAddViewModel()
        {
            TodoIds = new List<int>();
            Todos = new List<ToDo>();
            SelectedTodos = new List<ToDo>();
            Users = new List<User>();
            SelectedUsers = new List<User>();
            UserIds = new List<int>();
        }

        public string Description { get; set; }


        public List<ToDo> Todos { get; set; }
        public List<ToDo> SelectedTodos { get; set; }
        public List<int> TodoIds { get; set; }


        public List<User> Users { get; set; }
        public List<User> SelectedUsers { get; set; }
        public List<int> UserIds { get; set; }

    }
}