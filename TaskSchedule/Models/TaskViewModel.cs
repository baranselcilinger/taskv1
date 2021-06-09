using System.Collections.Generic;
using System.Web.Mvc;

namespace TaskSchedule.Models
{
    public class TaskViewModel
    {
        public TaskViewModel()
        {
            TodoIds = new List<int>();
         
            SelectedTodos = new List<ToDo>();
            Todos = new List<ToDo>();
            Users = new List<User>();
            SelectedUsers = new List<User>();
            UserIds = new List<int>();
        }

        public int Id { get; set; }

        public string Description { get; set; }

        public string AssignedDate { get; set; }

    

        public List<ToDo> Todos { get; set; } 
        public List<ToDo> SelectedTodos { get; set; }
        public List<int> TodoIds { get; set; }



        public List<User> SelectedUsers { get; set; }
        public List<User> Users { get; set; }
        public List<int> UserIds { get; set; }


    }
}