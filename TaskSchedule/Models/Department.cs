using System.Collections.Generic;

namespace TaskSchedule.Models
{
    public class Department
    {
        public Department()
        {
            Users = new List<User>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

    

        public ICollection<User> Users { get; set; }
    }
}