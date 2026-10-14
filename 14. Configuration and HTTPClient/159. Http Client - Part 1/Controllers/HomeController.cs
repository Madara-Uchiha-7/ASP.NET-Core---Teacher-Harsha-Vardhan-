using _159._Http_Client___Part_1_2_3.Models;
using _159._Http_Client___Part_1_2_3.Services;
using Microsoft.AspNetCore.Mvc;

namespace _159._Http_Client___Part_1_2_3.Controllers
{
    public class HomeController : Controller
    {
        private readonly FinnhubService _finnhubService;
        public HomeController(FinnhubService finnhubService)
        {
            _finnhubService = finnhubService;
        }

        [Route("/")]
        public async Task<IActionResult> Index()
        {
            Dictionary<string, object>? response = await _finnhubService.GetStockPriceQuote("MSFT");

            Stock stock = new Stock()
            {
                StockSymbol = "MSFT",
                // We can not directly convert to Double from Object so first use ToString()
                CurrentPrice = Convert.ToDouble(response["c"].ToString()),
                HighestPrice = Convert.ToDouble(response["h"].ToString()),
                LowestPrice = Convert.ToDouble(response["l"].ToString()),
                OpenPrice = Convert.ToDouble(response["o"].ToString()),
            };


            return View(stock);
        }
    }
}
