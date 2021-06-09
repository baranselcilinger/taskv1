using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using TaskSchedule.Models;

namespace TaskSchedule.Areas.Admin.Controllers
{
    public class DashboardController : Controller
    {
        private readonly TaskEntity db;

        public DashboardController()
        {
            db = new TaskEntity();
        }
        // GET: Admin/Dashboard
        public ActionResult Index()
        {
            var users = db.User.ToList();

            List<UserVithTask> Liste = new List<UserVithTask>();

            foreach (var item in users)
            {

                var tasks = db.TaskUser.Where(x => x.UserId == item.Id).Include(x => x.Task).Select(x => x.Task).ToList();
                UserVithTask uvt = new UserVithTask();
                uvt.UserName = item.Name;
                foreach (var tas in tasks)
                {

                    TaskViewModel tvm = new TaskViewModel();
                    tvm.AssignedDate = tas.DateStart != null ? tas.DateStart.ToString() : "";
                    tvm.Description = tas.Description;


                    var tasktodos = db.TaskTodos.Where(x => x.TaskId == tas.Id).Select(x => x.ToDo).ToList();

                    tvm.Todos = tasktodos.ToList();

                    uvt.TaskList.Add(tvm);

                }

                Liste.Add(uvt);

            }


            return View(Liste);
        }
    }
}