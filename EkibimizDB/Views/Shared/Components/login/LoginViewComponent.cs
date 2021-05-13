using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EkibimizDB.Views.Shared.Components.login
{
    public class LoginViewComponent:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            string userName;
            //session olarak okuduk
            //userName = HttpContext.Session.GetString("userName");//kullanıcı adı olarak da yazılabilir değişkenle aynı anda olmasına gerek yok
            //cookie olarak okuduk
            if (HttpContext.Request.Cookies.ContainsKey("userName"))//hata vermesin diye böyle bir key var mı diye kontrol ettirdik
            {
                userName = HttpContext.Request.Cookies["userName"];
            }
            else
            {
                userName = "";
            }
            //if (String.IsNullOrEmpty(userName))//login olduktan sonra çıkış butonu oluşması için kontrol yaptık
            //{
            //    userName = "";
            //} 

            return View(model:userName);
        }
    }
}
