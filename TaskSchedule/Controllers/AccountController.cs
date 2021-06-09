using System.DirectoryServices.AccountManagement;
using System.Linq;
using System.Web.Mvc;
using TaskSchedule.Models;

namespace TaskSchedule.Controllers
{
    public class AccountController : Controller
    {

        private readonly TaskEntity db;

        public AccountController()
        {
            db = new TaskEntity();
        }
        // GET: Account
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(LoginViewModel model)
        {
            if (!ModelState.IsValid)
                return View();
            //PrincipalContext pc = new PrincipalContext(ContextType.Domain, "aysa.corp");

            //var user = pc.ValidateCredentials(model.UserName, model.Password);

            //if (user == true)
            //{
                var kul = db.User.Where(x => x.UserName == model.UserName).FirstOrDefault();

                Session["User"] = kul;

                if(kul!=null)
                {
                    switch (kul.RoleId)
                    {
                        case 1: return RedirectToAction("index", "Dashboard", new { area = "Admin" });
                        case 2: return RedirectToAction("index", "Home");
                        default: return RedirectToAction("Login", "Account");
                    }
                }
            //}
            //else
            //{
            //    ModelState.AddModelError("validation", "Kullanıcı adı yada parola hatalı!");
            //}
            return View();
        }
        public ActionResult LogOff()
        {
            
            return RedirectToAction("Login", "Account");
        }
    }
}