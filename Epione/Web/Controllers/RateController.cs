using Domain.entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Mvc;

namespace Web.Controllers
{
    public class RateController : Controller
    {

        public ActionResult AddRate()
        {
            return View();
        }

        public ActionResult AddRateAjax(int rate, string message)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://127.0.0.1:18080");
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            rating r = new rating();
            r.rate = rate;
            r.comment = message;
            appointment a = new appointment();

            var app = (appointment)Session["app"];
            r.appointment = app;

            var response = client.PostAsJsonAsync<rating>("Epione_JEE-web/epione/rate/add/" + app.id, r).Result;

            if (response.StatusCode == HttpStatusCode.OK)
                ViewBag.result = response.Content.ReadAsAsync<rating>().Result;
            else
                ViewBag.result = "error";

            return View();
        }

        public ActionResult GetAll()
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://127.0.0.1:18080");
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            var response = client.GetAsync("Epione_JEE-web/epione/rate/get").Result;

            if (response.StatusCode == HttpStatusCode.OK)
                ViewBag.result = response.Content.ReadAsAsync < IEnumerable<rating>> ().Result;
            else
                ViewBag.result = "error";

            return View();
        }

        public ActionResult GetRateByAppointement(appointment app)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://127.0.0.1:18080");
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            var response = client.GetAsync("Epione_JEE-web/epione/rate/get/"+app.id).Result;

            if (response.StatusCode == HttpStatusCode.OK)
                ViewBag.result = response.Content.ReadAsAsync<IEnumerable<rating>>().Result;
            else
                ViewBag.result = "error";

            return View();
        }

        public ActionResult EditRate(rating rate)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://127.0.0.1:18080");
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            var response = client.PutAsJsonAsync<rating>("Epione_JEE-web/epione/rate/edit", rate).Result;

            if (response.StatusCode == HttpStatusCode.OK)
                ViewBag.result = response.Content.ReadAsAsync<rating>().Result;
            else
                ViewBag.result = "error";

            return View();
        }

        public ActionResult deleteRate(rating rate)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://127.0.0.1:18080");
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            var response = client.DeleteAsync("Epione_JEE-web/epione/rate/"+ rate.id).Result;

            if (response.StatusCode == HttpStatusCode.OK)
                ViewBag.result = response.Content.ReadAsAsync<rating>().Result;
            else
                ViewBag.result = "error";

            return View();
        }

        public ActionResult GetRatesByPatientUserName(String paientUserName)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://127.0.0.1:18080");
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            var response = client.GetAsync("Epione_JEE-web/epione/rate/patient/"+ paientUserName).Result;

            if (response.StatusCode == HttpStatusCode.OK)
                ViewBag.result = response.Content.ReadAsAsync<IEnumerable<rating>>().Result;
            else
                ViewBag.result = "error";

            return View();
        }

        public ActionResult GetRatesByDoctorUserName(String doctorUserName)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://127.0.0.1:18080");
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            var response = client.GetAsync("Epione_JEE-web/epione/rate/doctor/"+ doctorUserName).Result;

            if (response.StatusCode == HttpStatusCode.OK)
                ViewBag.result = response.Content.ReadAsAsync<IEnumerable<rating>>().Result;
            else
                ViewBag.result = "error";

            return View();
        }

        public ActionResult DoctorRate(int doctorId)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://127.0.0.1:18080");
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            var response = client.GetAsync("Epione_JEE-web/epione/rate/doctorRate/"+ doctorId).Result;

            if (response.StatusCode == HttpStatusCode.OK)
                ViewBag.result = response.Content.ReadAsAsync<IEnumerable<rating>>().Result;
            else
                ViewBag.result = "error";

            return View();
        }
    }
}