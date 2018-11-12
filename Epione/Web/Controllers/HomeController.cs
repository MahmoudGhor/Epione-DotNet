using Domain.entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Mvc;

namespace Web.Controllers
{
    public class HomeController : Controller
    {
        public static DateTime JavaTimeStampDateTime (long javaTimeStamp)
        {
            System.DateTime dtDateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Utc);
            dtDateTime = dtDateTime.AddMilliseconds(javaTimeStamp).ToLocalTime();
            return dtDateTime;

        }
        public ActionResult Index()
        {
            HttpClient listDoctors = new HttpClient();
            //listDoctors.BaseAddress = new Uri("http://localhost:18080/Epione_JEE-web/epione");
            listDoctors.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            var response = listDoctors.GetAsync("http://localhost:18080/Epione_JEE-web/epione/doctor/getListDoctors").Result;
          
            if (response.IsSuccessStatusCode)
            {
                ViewBag.result = response.Content.ReadAsAsync<IEnumerable<user>>().Result;
            }
            else
            {
                ViewBag.result = "error";
            }
            
            
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}