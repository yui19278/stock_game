// Controllers/TradeController.cs
using System.Linq;
using System.Web.Mvc;
using YourNamespace.Models;
using YourNamespace.Data;

public class TradeController : Controller
{
    private ApplicationDbContext db = new ApplicationDbContext();

    [HttpPost]
    public ActionResult Buy(int userId, string currency, double amount, double leverage)
    {
        var userCurrency = db.Currencies.SingleOrDefault(c => c.Id == userId);
        if (userCurrency == null)
        {
            return HttpNotFound();
        }

        double rate = currency == "A" ? MarketController.currencyARate : MarketController.currencyBRate;
        double totalCost = amount * leverage * rate;

        if (currency == "A" && userCurrency.CurrencyA >= totalCost)
        {
            userCurrency.CurrencyA -= totalCost;
        }
        else if (currency == "B" && userCurrency.CurrencyB >= totalCost)
        {
            userCurrency.CurrencyB -= totalCost;
        }
        else
        {
            return new HttpStatusCodeResult(400, "Insufficient funds.");
        }

        db.SaveChanges();
        return Json(userCurrency);
    }
}
