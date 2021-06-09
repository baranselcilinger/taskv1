using System;
using System.Collections.Generic;

namespace TaskSchedule.Models
{
    public class ToDo
    {
        public ToDo()
        {
            TaskTodos = new List<TaskTodos>();
        }
      
        public int Id { get; set; }

        public string Name { get; set; }

        public ICollection<TaskTodos> TaskTodos { get; set; }
    }
}