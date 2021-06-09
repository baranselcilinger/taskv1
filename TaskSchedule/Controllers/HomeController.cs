using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using TaskSchedule.Models;

namespace TaskSchedule.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            using (TaskEntity db = new TaskEntity())
            {
                List<TaskViewModel> Liste = new List<TaskViewModel>();

                if (Session["User"] != null)
                {
                    var user = (User)Session["User"];
                    var tasks = db.TaskUser.Where(x => x.UserId == user.Id).Include(x => x.Task).Select(x => x.Task).ToList();

                    foreach (var tas in tasks)
                    {
                        TaskViewModel tvm = new TaskViewModel();
                        tvm.AssignedDate = tas.DateStart != null ? tas.DateStart.ToString() : "";
                        tvm.Description = tas.Description;
                        tvm.Id = tas.Id;
                        var tasktodos = db.TaskTodos.Where(x => x.TaskId == tas.Id).Select(x => x.ToDo).ToList();
                        tvm.Todos = tasktodos.ToList();
                        Liste.Add(tvm);
                    }
                }
                return View(Liste);
            }
        }

        public ActionResult Add()
        {
            TaskEntity db = new TaskEntity();
            TaskAddViewModel model = new TaskAddViewModel();
            model.Todos = db.ToDo.ToList();
            return View(model);
        }

        [HttpPost]
        public ActionResult Add(TaskAddViewModel model)
        {

            using (TaskEntity db = new TaskEntity())
            {
                if (Session["User"] != null)
                {
                    var user = (User)Session["User"];
                    Task t = new Task();
                    t.DateStart = DateTime.Now;
                    t.Description = model.Description;
                    db.Task.Add(t);
                    db.SaveChanges();

                    foreach (var item in model.TodoIds)
                    {
                        TaskTodos td = new TaskTodos()
                        {
                            TaskId = t.Id,
                            TodoId = item
                        };
                        db.TaskTodos.Add(td);
                        db.SaveChanges();
                    }

                    if (t.Id > 0)
                        model = new TaskAddViewModel();
                    model.Todos = db.ToDo.ToList();

                    model.Description = string.Empty;
                    ViewBag.Message = "Görev ekleme işlemi başarıyla tamamlandı.";
                }

                return View(model);

            }
        }

        [HttpPost]
        public void TaskComplete(string Id)
        {
            using (TaskEntity db = new TaskEntity())
            {
                var taskId = Convert.ToInt32(Id.Split('-')[0]);
                var todoId = Convert.ToInt32(Id.Split('-')[1]);
                var _taskTodo = db.TaskTodos.FirstOrDefault(a => a.TaskId == taskId && a.TodoId == todoId);
                if (_taskTodo != null)
                {
                    _taskTodo.FinishDate = DateTime.Now;
                    var taskTodoEntry = db.Entry(_taskTodo);
                    taskTodoEntry.State = EntityState.Modified;
                    db.SaveChanges();
                }
            }
        }
    }

}


