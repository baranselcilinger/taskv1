using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace TaskSchedule.Models
{
    public class TaskEntity : DbContext
    {


        public TaskEntity() : base("TaskScheduleConnection")
        {

        }


        public DbSet<Department> Department { get; set; }

        public DbSet<Task> Task { get; set; }

        public DbSet<ToDo> ToDo { get; set; }

        public DbSet<TaskUser> TaskUser { get; set; }

        public DbSet<User> User { get; set; }

        public DbSet<TaskTodos> TaskTodos { get; set; }




        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            //modelBuilder.Entity<Task>()
            // .HasRequired<JobsOfDepartmant>(s => s.JobsOfDepartmant)
            // .WithMany()
            // .WillCascadeOnDelete(false);
        }
    }
}