using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net.Http;
using System.Net.Http.Headers;

namespace Web.Controllers
{
    public class AnalyticsController : Controller
    {
        // GET: Analytics
        public ActionResult Index()
        {
            
            return View();
        }


        public ActionResult PatientsByAges()
        {
            HttpClient listDoctors = new HttpClient();

            //listDoctors.BaseAddress = new Uri("http://localhost:18080/Epione_JEE-web/epione");
            listDoctors.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            var response = listDoctors.GetAsync("http://localhost:18080/Epione_JEE-web/epione/analytics/patients/age/0/10").Result;
            listDoctors.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            var range1 = listDoctors.GetAsync("http://localhost:18080/Epione_JEE-web/epione/analytics/patients/age/10/20").Result;
            listDoctors.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            var range2 = listDoctors.GetAsync("http://localhost:18080/Epione_JEE-web/epione/analytics/patients/age/20/30").Result;
            listDoctors.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            var range3 = listDoctors.GetAsync("http://localhost:18080/Epione_JEE-web/epione/analytics/patients/age/30/40").Result;
            listDoctors.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            var range4 = listDoctors.GetAsync("http://localhost:18080/Epione_JEE-web/epione/analytics/patients/age/40/60").Result;
            listDoctors.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            var range5 = listDoctors.GetAsync("http://localhost:18080/Epione_JEE-web/epione/analytics/patients/age/60/80").Result;
            listDoctors.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            var range6 = listDoctors.GetAsync("http://localhost:18080/Epione_JEE-web/epione/analytics/patients/age/80/100").Result;

            if (response.IsSuccessStatusCode && range1.IsSuccessStatusCode && range2.IsSuccessStatusCode)
            {
                var result = response.Content.ReadAsStringAsync().Result;
                var s = Newtonsoft.Json.JsonConvert.DeserializeObject(result);
                var result2 = range1.Content.ReadAsStringAsync().Result;
                var s2 = Newtonsoft.Json.JsonConvert.DeserializeObject(result2);
                var result3 = Newtonsoft.Json.JsonConvert.DeserializeObject(range2.Content.ReadAsStringAsync().Result);
                var result4 = Newtonsoft.Json.JsonConvert.DeserializeObject(range3.Content.ReadAsStringAsync().Result);
                var result5 = Newtonsoft.Json.JsonConvert.DeserializeObject(range4.Content.ReadAsStringAsync().Result);
                var result6 = Newtonsoft.Json.JsonConvert.DeserializeObject(range5.Content.ReadAsStringAsync().Result);
                var result7 = Newtonsoft.Json.JsonConvert.DeserializeObject(range6.Content.ReadAsStringAsync().Result);





                ViewBag.result1 = s;
                ViewBag.result2 = s2;
                ViewBag.result3 = result3;
                ViewBag.result4 = result4;
                ViewBag.result5 = result5;
                ViewBag.result6 = result6;
                ViewBag.result7 = result7;
                //ViewBag.result = response.Content;
            }
            else
            {
                ViewBag.result1 = "erreur";
            }
            //return View("listeResource");
            
            return PartialView("PatientsByAges");
        }

        public ActionResult YearAppointments()
        {

            HttpClient listDoctors = new HttpClient();
            //listDoctors.BaseAddress = new Uri("http://localhost:18080/Epione_JEE-web/epione");
            listDoctors.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            var response = listDoctors.GetAsync("http://localhost:18080/Epione_JEE-web/epione/analytics/doctors/yearappointments/2").Result;
            if (response.IsSuccessStatusCode )
            {
                var result = response.Content.ReadAsStringAsync().Result;

                var s = Newtonsoft.Json.JsonConvert.DeserializeObject(result);
                ViewBag.result1 = s;

                ViewBag.tab = null;               



                //ViewBag.result = response.Content;
            }
            else
            {
                ViewBag.result1 = "erreur";
            }
            return PartialView("YearAppointments");
        }


        public ActionResult DoctorCountAppointments()
        {
            HttpClient listDoctors = new HttpClient();
            //listDoctors.BaseAddress = new Uri("http://localhost:18080/Epione_JEE-web/epione");
            listDoctors.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            var response = listDoctors.GetAsync("http://localhost:18080/Epione_JEE-web/epione/analytics/appointment/bydoctor/2").Result;
            var canceled = listDoctors.GetAsync("http://localhost:18080/Epione_JEE-web/epione/analytics/appointment/countcanceled/2").Result;

            if (response.IsSuccessStatusCode && canceled.IsSuccessStatusCode)
            {
                var result = response.Content.ReadAsStringAsync().Result;
                var result1 = canceled.Content.ReadAsStringAsync().Result;
                var s = Newtonsoft.Json.JsonConvert.DeserializeObject(result);
                var s2= Newtonsoft.Json.JsonConvert.DeserializeObject(result1);
                ViewBag.result = s;
                ViewBag.canceled = s2;
            



            }
            else
            {
                ViewBag.result1 = "erreur";
            }
            return PartialView("DoctorCountAppointments");
        }

        public ActionResult DoctorCountPatients()
        {
            HttpClient listDoctors = new HttpClient();
            //listDoctors.BaseAddress = new Uri("http://localhost:18080/Epione_JEE-web/epione");
            listDoctors.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            var response = listDoctors.GetAsync("http://localhost:18080/Epione_JEE-web/epione/analytics/doctor/countpatients/2").Result;

            if (response.IsSuccessStatusCode)
            {
                var result = response.Content.ReadAsStringAsync().Result;

                var s = Newtonsoft.Json.JsonConvert.DeserializeObject(result);
                ViewBag.result = s;





            }
            else
            {
                ViewBag.result1 = "erreur";
            }
            return PartialView("DoctorCountPatients");
        }


        public ActionResult VacationsStats()
        {
            HttpClient listDoctors = new HttpClient();
            //listDoctors.BaseAddress = new Uri("http://localhost:18080/Epione_JEE-web/epione");
            listDoctors.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            var response = listDoctors.GetAsync("http://localhost:18080/Epione_JEE-web/epione/analytics/doctors/vacations/2").Result;

            if (response.IsSuccessStatusCode)
            {
                var result = response.Content.ReadAsStringAsync().Result;

                var s = Newtonsoft.Json.JsonConvert.DeserializeObject(result);
                ViewBag.result = s;





            }
            else
            {
                ViewBag.result1 = "erreur";
            }
            return PartialView("VacationsStats");
        }


        public ActionResult AppointmentsStats()
        {
            HttpClient listDoctors = new HttpClient();
            //listDoctors.BaseAddress = new Uri("http://localhost:18080/Epione_JEE-web/epione");
            listDoctors.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            var response = listDoctors.GetAsync("http://localhost:18080/Epione_JEE-web/epione/analytics/appointment/countcanceled/2").Result;
            var all = listDoctors.GetAsync("http://localhost:18080/Epione_JEE-web/epione/analytics/appointment/bydoctor/2").Result;

            if (response.IsSuccessStatusCode && all.IsSuccessStatusCode)
            {

                var result = response.Content.ReadAsStringAsync().Result;
                var result1 = all.Content.ReadAsStringAsync().Result;
                var s2 = Newtonsoft.Json.JsonConvert.DeserializeObject(result1);
                var s = Newtonsoft.Json.JsonConvert.DeserializeObject(result);
                ViewBag.canceled = s;
                ViewBag.all = s2;





            }
            else
            {
                ViewBag.result1 = "erreur";
            }
            return PartialView("AppointmentsStats");
        }

       
    }
}