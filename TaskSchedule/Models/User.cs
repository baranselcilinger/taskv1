using System.Collections.Generic;

namespace TaskSchedule.Models
{
    public class User
    {
        public User()
        {
            TaskUsers = new List<TaskUser>();
        }


        public int Id { get; set; }

        public string UserName { get; set; }

        public string Name { get; set; }

        public bool Islocked { get; set; }

        public int DepartmentId { get; set; }

        public string Position { get; set; }

        public int RoleId { get; set; }




        public Department Department { get; set; }

        public ICollection<TaskUser> TaskUsers { get; set; }


    }

}