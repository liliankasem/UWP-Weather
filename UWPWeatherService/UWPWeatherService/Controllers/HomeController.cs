using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace UWPWeatherService.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public async Task<ActionResult> Index(string lat, string lon)
        {
            //Trim lat and lon
            var latitude = double.Parse(lat.Substring(0, 5));
            var longitude = double.Parse(lon.Substring(0, 5));

            var weather = await Models.OpenWeatherMapProxy.GetWeather(latitude, longitude);

            ViewBag.Temp = ((int)weather.main.temp).ToString() + "°C";
            ViewBag.Desc = weather.weather[0].description;
            ViewBag.Name = weather.name;

            return View();
        }
    }
}