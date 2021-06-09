using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TaskSchedule.Models
{
    public class TaskTodos
    {



        public int Id { get; set; }

        public int TaskId { get; set; }

        public int TodoId { get; set; }

        public Task Task { get; set; }

        public ToDo ToDo { get; set; }

        public DateTime? FinishDate { get; set; }
    }
}