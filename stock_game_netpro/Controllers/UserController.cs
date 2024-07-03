// Controllers/UserController.cs
using System.Linq;
using System.Web.Mvc;
using YourNamespace.Models;
using YourNamespace.Data;

public class UserController : Controller
{
    private ApplicationDbContext db = new ApplicationDbContext();

    [HttpPost]
    public ActionResult Login(int id, string name)
    {
        var user = db.Users.SingleOrDefault(u => u.Id == id && u.Name == name);
        if (user == null)
        {
            return new HttpStatusCodeResult(401, "Unauthorized");
        }
        return Json(user);
    }
}
