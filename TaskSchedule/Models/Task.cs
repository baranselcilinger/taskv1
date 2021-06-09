using System;
using System.Collections.Generic;

namespace TaskSchedule.Models
{
    public class Task
    {
        public Task()
        {
            TaskUsers = new List<TaskUser>();
            TaskTodos = new List<TaskTodos>();
        }


        public int Id { get; set; }

        public string Description { get; set; }

        public DateTime? DateStart { get; set; }

        public DateTime? DateFinish { get; set; }

        public int AddedBy { get; set; }


       

     

        public ICollection<TaskUser> TaskUsers { get; set; }

        public ICollection<TaskTodos> TaskTodos { get; set; }

        public ICollection<Task> Tasks { get; set; }
    }
}