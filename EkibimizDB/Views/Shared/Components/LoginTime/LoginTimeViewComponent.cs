using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EkibimizDB.Views.Shared.Components.LoginTime
{
    public class LoginTimeViewComponent:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            string loginTime="";
            DateTime time = DateTime.Now;
            if (HttpContext.Request.Cookies.ContainsKey("FirstLoginTime"))
            {
                loginTime = HttpContext.Request.Cookies["FirstLoginTime"];
                HttpContext.Response.Cookies.Append("LoginTime",DateTime.Now.ToUniversalTime().ToString());//her seferinde yapılan giriş için
            }
            else
            {
                
            }
            return View(model: loginTime);

        }
    }
}
