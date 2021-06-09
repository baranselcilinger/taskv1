using System.Collections.Generic;

namespace TaskSchedule.Models
{
    public class UserVithTask
    {
        public UserVithTask()
        {
            TaskList = new List<TaskViewModel>();
        }

        public string UserName { get; set; }


        public List<TaskViewModel> TaskList { get; set; }

    }
}