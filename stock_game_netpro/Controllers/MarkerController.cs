// Controllers/MarketController.cs
using System;
using System.Timers;
using System.Web.Mvc;

public class MarketController : Controller
{
    private static double currencyARate = 100.0;
    private static double currencyBRate = 100.0;
    private static Timer timer;

    static MarketController()
    {
        timer = new Timer(1000); // 毎秒更新
        timer.Elapsed += OnTimedEvent;
        timer.AutoReset = true;
        timer.Enabled = true;
    }

    private static void OnTimedEvent(Object source, ElapsedEventArgs e)
    {
        Random rand = new Random();
        currencyARate += currencyARate * (rand.NextDouble() * 0.01 - 0.005);
        currencyBRate += currencyBRate * (rand.NextDouble() * 0.01 - 0.005);
    }

    [HttpGet]
    public ActionResult GetRates()
    {
        return Json(new { CurrencyA = currencyARate, CurrencyB = currencyBRate }, JsonRequestBehavior.AllowGet);
    }
}
