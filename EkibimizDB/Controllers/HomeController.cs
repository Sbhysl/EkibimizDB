using EkibimizDB.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace EkibimizDB.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult SaveuserName(string userName)
        {
            //session yazdık
            //HttpContext.Session.SetString("userName", userName);
            //cookie yazdık
            //cookie optionsları tanımlayabiliriz
            CookieOptions options = new CookieOptions();
            options.Expires = new DateTimeOffset(DateTime.Now.AddDays(5));//5 gün boyunca sistemde kalmasına izin verdik
            options.Domain = ".bilgeadam.com";//. dediğimizde sadece bilgeadamın altındaki sayfalar için sadece demek
            options.Path = "/home/";//cookie sadece home sayfası içerisinde işlevsellik göstersin diye
            if (!HttpContext.Request.Cookies.ContainsKey("userName")|| HttpContext.Request.Cookies["userName"]=="")//içeride bi kullanıcı varsa kayıt etme demek için
            {
              HttpContext.Response.Cookies.Append("userName",userName,options);//options yaptıysak buraya da yazmak zorundayız
            }
            if (!HttpContext.Request.Cookies.ContainsKey("FirstLoginTİme")|| HttpContext.Request.Cookies["FirstLoginTime"]=="")
            {
                HttpContext.Response.Cookies.Append("FirstLoginTime",DateTime.Now.ToLongDateString()+" "+DateTime.Now.ToLongTimeString());
            }
            return RedirectToAction("Index");
        }

        public IActionResult Logout()
        {
            //session sıfıladık
            HttpContext.Session.SetString("userName", "");
            //cookie sıfırladık
            HttpContext.Response.Cookies.Delete("userName");
            HttpContext.Response.Cookies.Delete("FirstLoginTime");
            return RedirectToAction("Index");
        }
    }
}
