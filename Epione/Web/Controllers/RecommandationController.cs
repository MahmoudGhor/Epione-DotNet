using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.tool.xml;
using Newtonsoft.Json.Linq;
using Service;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using Web.Models;

namespace Web.Controllers
{
    public class RecommandationController : Controller
    {
        // GET: Recommandation/index
        public ActionResult Index()
        {
            HttpClient Client = new HttpClient();
            Client.BaseAddress = new Uri("http://localhost:18080/Epione_JEE-web/epione/");
            Client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = Client.GetAsync("recommandation/getRecommandationsByPatient?patient=2").Result;
            if (response.IsSuccessStatusCode)
            {
                ViewBag.result = response.Content.ReadAsAsync<IEnumerable<recommandation>>().Result;



            }

            else
            {


                ViewBag.result = "error";
            }


            HttpClient Client2 = new HttpClient();
            Client2.BaseAddress = new Uri("http://localhost:18080/Epione_JEE-web/epione/");
            Client2.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response2 = Client.GetAsync("recommandation/countNotifications?user=2").Result;
            ViewBag.nbNotif = response2.Content.ReadAsAsync<long>().Result;



            ViewBag.adresseSpecialist = TempData["adresseSpecialist"];
            ViewBag.adresseDoctor = TempData["adresseDoctor"];
            ViewBag.doctor = TempData["doctor"];
            ViewBag.recommandeddoctor = TempData["recommandeddoctor"];

            return View();
        }


        // GET: Recommandation/index
        public ActionResult DisplayPatient(int recommandation)
        {
            HttpClient Client = new HttpClient();
            Client.BaseAddress = new Uri("http://localhost:18080/Epione_JEE-web/epione/");
            Client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = Client.GetAsync("recommandation/getDoctorFromRecommandation?recommandation="+recommandation).Result;
            if (response.IsSuccessStatusCode)
            {
                TempData["doctor"] = response.Content.ReadAsAsync<user>().Result;
                string rsp = response.Content.ReadAsStringAsync().Result;
                JObject json = JObject.Parse(rsp);
                TempData["adresseDoctor"] = json["adresse"];

            }


            HttpClient Client2 = new HttpClient();
            Client2.BaseAddress = new Uri("http://localhost:18080/Epione_JEE-web/epione/");
            Client2.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response2 = Client.GetAsync("recommandation/getRecommandedDoctorFromRecommandation?recommandation=" + recommandation).Result;
            if (response2.IsSuccessStatusCode)
            {
                TempData["recommandeddoctor"] = response2.Content.ReadAsAsync<user>().Result;
                string rsp = response.Content.ReadAsStringAsync().Result;
                JObject json = JObject.Parse(rsp);
                TempData["adresseSpecialist"] = json["adresse"];

            }

            else
            {


                ViewBag.patient = "NO";
            }

            return RedirectToAction("Index");
        }



        // GET: Recommandation/RecommandedPatients
        public ActionResult RecommandedPatients()
        {
            HttpClient Client = new HttpClient();
            Client.BaseAddress = new Uri("http://localhost:18080/Epione_JEE-web/epione/");
            Client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = Client.GetAsync("recommandation/ListAllPatientsForSpecialist?specialist=3").Result;
            if (response.IsSuccessStatusCode)
            {

                ViewBag.patients = response.Content.ReadAsAsync<IEnumerable<user>>().Result;
              


            }


            else
            {


                ViewBag.patients = "NO";
            }

            ViewBag.no = TempData["no"];
            ViewBag.succes = TempData["succes"];
            ViewBag.mg = TempData["msg"];

            ViewBag.path = TempData["path"];
            return View();
        }


        // GET: Recommandation/RecommandedPatient
        public ActionResult DisplayPathOfPatient(int patient)
        {
            HttpClient Client = new HttpClient();
            Client.BaseAddress = new Uri("http://localhost:18080/Epione_JEE-web/epione/");
            Client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = Client.GetAsync("recommandation/getRecommandationsByPatient?patient=" + patient).Result;
            if (response.IsSuccessStatusCode)
            {
                TempData["path"] = response.Content.ReadAsAsync < IEnumerable < recommandation >> ().Result;


            }

         


            return RedirectToAction("RecommandedPatients");
        }


        // GET: Recommandation/Appointments
        public ActionResult Appointments()
        {
            HttpClient Client = new HttpClient();
            Client.BaseAddress = new Uri("http://localhost:18080/Epione_JEE-web/epione/");
            Client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = Client.GetAsync("recommandation/listAppointmentForDoctor?doctor=1").Result;
            if (response.IsSuccessStatusCode)
            {
                ViewBag.appointments = response.Content.ReadAsAsync<IEnumerable<appointment>>().Result;



            }

         

            else
            {


                ViewBag.result = "error";
            }


            HttpClient Client2 = new HttpClient();
            Client2.BaseAddress = new Uri("http://localhost:18080/Epione_JEE-web/epione/");
            Client2.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response2 = Client.GetAsync("recommandation/countNotifications?user=3").Result;
            ViewBag.nbNotif = response2.Content.ReadAsAsync<long>().Result;


            //  ViewBag.doctor = TempData["doctor"];
            ViewBag.path = TempData["path"];
            ViewBag.appointment = TempData["appointment"];

            return View();

        }



        // GET: Recommandation/Appointment/Path
        public ActionResult DisplayPathFromAppointment(int appointment)
        {
            HttpClient Client = new HttpClient();
            Client.BaseAddress = new Uri("http://localhost:18080/Epione_JEE-web/epione/");
            Client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = Client.GetAsync("recommandation/listallrecommandations?appointment=" + appointment).Result;
            if (response.IsSuccessStatusCode)
            {
                TempData["path"] = response.Content.ReadAsAsync<IEnumerable<recommandation>>().Result;

                TempData["appointment"] = appointment;
                    

            }




            return RedirectToAction("Appointments");
        }


        public ActionResult AddRecommandation(int appointment)
        {
            ViewBag.appointment  = appointment;
            HttpClient Client = new HttpClient();
            Client.BaseAddress = new Uri("http://localhost:18080/Epione_JEE-web/epione/");
            Client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = Client.GetAsync("doctor/getListDoctors").Result;
            if (response.IsSuccessStatusCode)
            {
                ViewBag.doctors = response.Content.ReadAsAsync<IEnumerable<user>>().Result;

            }

            return View();
        }

        [HttpGet]
        public ActionResult Create()
        {

           
            return View("Create");


        }

        [HttpPost]
        public ActionResult AddRecommandation(string speciality,int appointment,int doctor)
        {

            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:18080/Epione_JEE-web/epione/");
           var response =client.PostAsync("recommandation/addRecommandation?a=" + appointment + "&d="+doctor+"&type=" + speciality, null).ContinueWith((postTask) => postTask.Result.EnsureSuccessStatusCode()).Result;




            string rsp = response.Content.ReadAsStringAsync().Result;
            //  JObject json = JObject.Parse(rsp);
            //  string json = new JavaScriptSerializer().Serialize(response);
            JObject json = JObject.Parse(rsp);
            var no = json.First;

            //TempData["no"] = json["NO"]; 
            //TempData["succes"] = json["succes"];
            TempData["msg"] = "<script>alert('" + no + "');</script>";

            return RedirectToAction("Appointments");
        }


        public ActionResult DeleteRecommandation(int recommandation)
        {

   
            RecommandationService rs = new RecommandationService();
            rs.SupprimerRecommandation(recommandation);


            return RedirectToAction("Appointments");
        }






        // GET: Recommandation/ValidateRecommandation
        [HttpPost]
        public ActionResult RecommandedPatients(int recommandation)
        {

            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:18080/Epione_JEE-web/epione/");
           var response= client.PostAsync("recommandation/validateRecommandation?recommandation=" + recommandation + "&doctor=3", null).ContinueWith((postTask) => postTask.Result.EnsureSuccessStatusCode()).Result;

            var t2 = response.Content.ReadAsStringAsync();
            t2.Wait();

            string rsp = response.Content.ReadAsStringAsync().Result;
          //  JObject json = JObject.Parse(rsp);
          //  string json = new JavaScriptSerializer().Serialize(response);
            JObject json = JObject.Parse(rsp);
            var no = json.First;

            //TempData["no"] = json["NO"]; 
            //TempData["succes"] = json["succes"];
            TempData["msg"] = "<script>alert('"+no+"');</script>";


     //"<script src='https://unpkg.com/sweetalert/dist/sweetalert.min.js'> swal('" + no + "');</script>";

            //  ViewBag.msg = json.First;



            //TempData["msg"] = no;



            return RedirectToAction("RecommandedPatients");
        }



        [HttpPost]
        [ValidateInput(false)]
        public FileResult Export(string GridHtml)
        {
            using (MemoryStream stream = new System.IO.MemoryStream())
            {
                StringReader sr = new StringReader(GridHtml);
                Document pdfDoc = new Document(PageSize.A4, 10f, 10f, 100f, 0f);
                PdfWriter writer = PdfWriter.GetInstance(pdfDoc, stream);
                pdfDoc.Open();
                XMLWorkerHelper.GetInstance().ParseXHtml(writer, pdfDoc, sr);
                pdfDoc.Close();
                return File(stream.ToArray(), "application/pdf", "MyPath.pdf");
            }
        }



        // GET: Recommandation/Notification
        public ActionResult Notification()
        {
            HttpClient Client = new HttpClient();
            Client.BaseAddress = new Uri("http://localhost:18080/Epione_JEE-web/epione/");
            Client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = Client.GetAsync("recommandation/listNotifications?patient=2").Result;
            if (response.IsSuccessStatusCode)
            {
               ViewBag.notif = response.Content.ReadAsAsync<IEnumerable<notification>>().Result;

              


            }




            return View();
        }



        // GET: Recommandation/NotificationDoctor
        public ActionResult NotificationDoctor()
        {
            HttpClient Client = new HttpClient();
            Client.BaseAddress = new Uri("http://localhost:18080/Epione_JEE-web/epione/");
            Client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = Client.GetAsync("recommandation/listNotificationsSpecialist?specialist=3").Result;
            if (response.IsSuccessStatusCode)
            {
                ViewBag.notif = response.Content.ReadAsAsync<IEnumerable<notification>>().Result;




            }




            return View();
        }


        // POST: Recommandation/OpenNotification
        public ActionResult OpenNotification(int notification)
        {

            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:18080/Epione_JEE-web/epione/");
            client.PostAsync("recommandation/openNotification?notification="+notification+"&user=2", null).ContinueWith((postTask) => postTask.Result.EnsureSuccessStatusCode());



            return RedirectToAction("Notification");
        }

        // POST: Recommandation/OpenNotification
        public ActionResult OpenNotificationDoctor(int notification)
        {

            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:18080/Epione_JEE-web/epione/");
            client.PostAsync("recommandation/openNotification?notification=" + notification + "&user=3", null).ContinueWith((postTask) => postTask.Result.EnsureSuccessStatusCode());



            return RedirectToAction("NotificationDoctor");
        }


        public ActionResult UpdateRecommandation(int recommandation)
        {
            ViewBag.recommandation = recommandation;
            HttpClient Client = new HttpClient();
            Client.BaseAddress = new Uri("http://localhost:18080/Epione_JEE-web/epione/");
            Client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = Client.GetAsync("doctor/getListDoctors").Result;
            if (response.IsSuccessStatusCode)
            {
                ViewBag.doctors = response.Content.ReadAsAsync<IEnumerable<user>>().Result;

            }

            return View();
        }


        [HttpPost]
        public ActionResult UpdateRecommandation(string speciality,string justification,int recommandation, int doctor)
        {

            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:18080/Epione_JEE-web/epione/");
            var response = client.PostAsync("recommandation/updateRecommandation?recommandation="+recommandation+"&specialist=3&type="+speciality+"&justification="+justification+"&newspecialist="+doctor, null).ContinueWith((postTask) => postTask.Result.EnsureSuccessStatusCode()).Result;




            string rsp = response.Content.ReadAsStringAsync().Result;
            //  JObject json = JObject.Parse(rsp);
            //  string json = new JavaScriptSerializer().Serialize(response);
            JObject json = JObject.Parse(rsp);
            var no = json.First;

            //TempData["no"] = json["NO"]; 
            //TempData["succes"] = json["succes"];
            TempData["msg"] = "<script>alert('" + no + "');</script>";

            return RedirectToAction("Appointments");
        }

    }   
}