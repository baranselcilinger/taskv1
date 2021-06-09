using PagedList;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using TaskSchedule.Areas.Admin.Models;
using TaskSchedule.Models;
using System;

namespace TaskSchedule.Areas.Admin.Controllers
{
    public class AdminTaskController : Controller
    {
        private readonly TaskEntity db;

        public AdminTaskController()
        {
            db = new TaskEntity();
        }

        //public ActionResult Index(int page = 1)
        //{
        //    List<TaskViewModel> liste = new List<TaskViewModel>();
        //    var tasks = db.Task.Where(x => x.DateFinish == null).ToList();
        //    foreach (var item in tasks)
        //    {
        //        TaskViewModel tvm = new TaskViewModel();
        //        tvm.AssignedDate = item.DateStart.ToString();
        //        tvm.Description = item.Description;
        //        tvm.Id = item.Id;
        //        var todos = db.TaskTodos.Where(x => x.TaskId == item.Id).Include(x => x.ToDo).Select(x => x.ToDo).ToList();
        //        tvm.Todos = todos;
        //        var users = db.TaskUser.Where(x => x.TaskId == item.Id).Include(x => x.User).Select(x => x.User).ToList();
        //        tvm.Users = users;
        //        liste.Add(tvm);
        //    }
        //    ViewBag.personal = db.User.Where(x => x.RoleId == 2).ToList();
        //    return View(liste.OrderByDescending(x => x.AssignedDate).ToPagedList(page, 5));
        //}

        public ActionResult Index()
        {
            List<TaskViewModel> liste = new List<TaskViewModel>();

            var tasks = db.Task.Where(x => x.DateFinish == null).ToList();

            var User = Session["User"];

            foreach (var item in tasks)
            {
                TaskViewModel tvm = new TaskViewModel();
                tvm.AssignedDate = item.DateStart.ToString();
                tvm.Description = item.Description;
                tvm.Id = item.Id;
                var todos = db.TaskTodos.Where(x => x.TaskId == item.Id).Include(x => x.ToDo).Select(x => x.ToDo).ToList();
                tvm.Todos = todos;
                var users = db.TaskUser.Where(x => x.TaskId == item.Id).Include(x => x.User).Select(x => x.User).ToList();
                tvm.Users = users;
                liste.Add(tvm);
            }

            ViewBag.personal = db.User.Where(x => x.RoleId == 2).ToList();

            return View(liste.OrderBy(x => x.AssignedDate));
        }

        public ActionResult Create()
        {

            TaskAddViewModel model = new TaskAddViewModel();

            model.Todos = db.ToDo.ToList();
            model.Users = db.User.ToList();

            return View(model);
        }


        [HttpPost]
        public ActionResult Create(TaskAddViewModel model)
        {
            Task t = new Task();

            t.Description = model.Description;
            t.DateStart = DateTime.Now;
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

            foreach (var item in model.UserIds)
            {
                TaskUser tu = new TaskUser
                {
                    Active = true,
                    TaskId = t.Id,
                    UserId = item
                };
                db.TaskUser.Add(tu);
                db.SaveChanges();
            }

            if (t.Id > 0)
                model = new TaskAddViewModel();
            model.Todos = db.ToDo.ToList();
            model.Users = db.User.ToList();
            model.Description = string.Empty;
            ViewBag.Message = "Görev ekleme işlemi başarıyla tamamlandı.";


            return View(model);
        }

        public JsonResult personalAta(AssignPersonnelViewModel model)
        {
            foreach (var item in model.personnelId)
            {
                TaskUser tu = new TaskUser
                {
                    Active = true,
                    TaskId = model.IsId,
                    UserId = item
                };
                db.TaskUser.Add(tu);
                db.SaveChanges();
            }
            return Json(1);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var task = db.Task.FirstOrDefault(x => x.Id == id);
            TaskViewModel tm = new TaskViewModel();
            tm.Id = task.Id;
            tm.Description = task.Description;
            tm.SelectedTodos = db.TaskTodos.Where(x => x.TaskId == id).Include(x => x.ToDo).Select(x => x.ToDo).ToList();
            tm.SelectedUsers = db.TaskUser.Where(a => a.TaskId == id).Include(a => a.User).Select(a => a.User).ToList();
            tm.Todos = db.ToDo.ToList();
            tm.Users = db.User.ToList();
            return View(tm);
        }

        [HttpPost]
        public ActionResult Edit(TaskViewModel model)
        {
            try
            {
                var task = db.Task.FirstOrDefault(x => x.Id == model.Id);
                task.Description = model.Description;
                task.DateStart = DateTime.Now;
                var taskEntry = db.Entry(task);
                taskEntry.State = EntityState.Modified;
                db.TaskTodos.RemoveRange(db.TaskTodos.Where(a => a.TaskId == model.Id).ToList());
                db.TaskUser.RemoveRange(db.TaskUser.Where(a => a.TaskId == model.Id).ToList());
                db.SaveChanges();
                foreach (var item in model.TodoIds)
                {
                    TaskTodos td = new TaskTodos()
                    {
                        TaskId = model.Id,
                        TodoId = item
                    };
                    db.TaskTodos.Add(td);
                    db.SaveChanges();
                }
                foreach (var item in model.UserIds)
                {
                    TaskUser tu = new TaskUser
                    {
                        Active = true,
                        TaskId = model.Id,
                        UserId = item
                    };
                    db.TaskUser.Add(tu);
                    db.SaveChanges();
                }
                TaskViewModel tm = new TaskViewModel();
                tm.Id = task.Id;
                tm.Description = task.Description;
                tm.SelectedTodos = db.TaskTodos.Where(x => x.TaskId == model.Id).Include(x => x.ToDo).Select(x => x.ToDo).ToList();
                tm.SelectedUsers = db.TaskUser.Where(a => a.TaskId == model.Id).Include(a => a.User).Select(a => a.User).ToList();
                tm.Todos = db.ToDo.ToList();
                tm.Users = db.User.ToList();
                ViewBag.Message = "Görev güncelleme işlemi başarıyla tamamlandı.";
                return View(tm);
            }
            catch
            {
                TaskViewModel tm = new TaskViewModel();
                tm.Id = model.Id;
                tm.Description = model.Description;
                tm.SelectedTodos = db.TaskTodos.Where(x => x.TaskId == model.Id).Include(x => x.ToDo).Select(x => x.ToDo).ToList();
                tm.SelectedUsers = db.TaskUser.Where(a => a.TaskId == model.Id).Include(a => a.User).Select(a => a.User).ToList();
                tm.Todos = db.ToDo.ToList();
                tm.Users = db.User.ToList();
                ViewBag.Message = "Görev güncelleme işlemi sırasında bir hata oluştu.";
                return View(tm);
            }
        }

        public ActionResult Delete(int id)
        {
            var task = db.Task.FirstOrDefault(a => a.Id == id);
            db.Task.Remove(task);
            db.TaskTodos.RemoveRange(db.TaskTodos.Where(a => a.TaskId == id).ToList());
            db.TaskUser.RemoveRange(db.TaskUser.Where(a => a.TaskId == id).ToList());
            db.SaveChanges();
            TempData["Message"] = "Kayıt başarıyla silinmiştir.";
            return Redirect("/Admin/AdminTask");
        }
    }
}