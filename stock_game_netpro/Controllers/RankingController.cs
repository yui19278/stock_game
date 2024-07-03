// Controllers/RankingController.cs
using System.Linq;
using System.Web.Mvc;
using YourNamespace.Models;
using YourNamespace.Data;

public class RankingController : Controller
{
    private ApplicationDbContext db = new ApplicationDbContext();

    [HttpGet]
    public ActionResult GetRanking()
    {
        var ranking = db.Currencies
            .Join(db.Users, c => c.Id, u => u.Id, (c, u) => new { u.Name, TotalAssets = c.CurrencyA + c.CurrencyB }) //仮のランク
            .OrderByDescending(x => x.TotalAssets)
            .ToList();

        return Json(ranking, JsonRequestBehavior.AllowGet);
    }
}
