using System;

namespace TaskSchedule.Models
{
    public class TaskUser
    {
        public int Id { get; set; }

        public int TaskId { get; set; }


        public int UserId { get; set; }

        public bool Active { get; set; }

        public Task Task { get; set; }

        public User User { get; set; }



    }
}