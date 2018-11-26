using Domain.entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Web.Models;

namespace Web.Controllers
{
    public class PatternController : Controller
    {
        // GET: Pattern
        public ActionResult Index()
        {
            return View();
            
        }
        // GET: Pattern
        public ActionResult IndexDisabled()
        {
            return View();

        }
        public ActionResult GetPatterns()
        {
            List<PatternModel> listPatterns = new List<PatternModel>();

            //PatternModel PatternModels = new PatternModel();
            HttpClient listPattern = new HttpClient();
            listPattern.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            var response = listPattern.GetAsync("http://localhost:18080/Epione_JEE-web/epione/doctor/getListPatternByDoctor/" + Session["id"]).Result;
            if (response.IsSuccessStatusCode)
            /* {

                 foreach (var pattern in response.Content.ReadAsAsync<IEnumerable<PatternModel>>().Result)
                 {
                     PatternModel PatternModel = new PatternModel();
                     PatternModel.id = pattern.id;
                     PatternModel.idDoctor = pattern.idDoctor;
                     PatternModel.price = pattern.price;
                     PatternModel.periode = pattern.periode;
                     PatternModel.label = pattern.label;
                     listPatterns.Add(PatternModel);
                 }

                 Session["alertMessageSucc"] = null;
                 Session["alertMessageError"] = null;
             }*/
            {
                foreach (var pattern in response.Content.ReadAsAsync<IEnumerable<PatternModel>>().Result)
                {

                    PatternModel PatternModel = new PatternModel { id = pattern.id , label = pattern.label, periode = pattern.periode, price = pattern.price };

                    listPatterns.Add(PatternModel);
                }
                return Json  ( new { data = listPatterns } , JsonRequestBehavior.AllowGet);
            }
            else
            {
                ViewBag.result = "error";
                return ViewBag.result;
            }
            // PatternModels.patternModels = listPatterns;
            // return View(PatternModels);
            // ViewBag.result = response.Content.ReadAsAsync<IEnumerable<PatternModel>>().Result;
        }

        // GET: Pattern/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Pattern/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Pattern/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(PatternModel pattmodel)
        {



            pattmodel.idDoctor = Convert.ToInt32(Session["id"]) ;

            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://127.0.0.1:18080");
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            var response = client.PostAsJsonAsync<PatternModel>("Epione_JEE-web/epione/doctor/addPattern", pattmodel).Result;
            if (response.StatusCode == HttpStatusCode.OK)
            {
                Session["alertMessageSucc"] = "Pattern added successfully";
                Session["alertMessageError"] = null;
                return RedirectToAction("Index", "Pattern");
            }
            if (response.StatusCode == HttpStatusCode.OK) //

            {
                Session["alertMessageSucc"] = null;
                Session["alertMessageError"] = "Pattern not added";
                return View();

            }
            ViewBag.response = client.PostAsJsonAsync<PatternModel>("Epione_JEE-web/epione/doctor/addPattern", pattmodel).Result;
            return View();

        }

        // GET: Pattern/Edit/5
        public JsonResult Edit(int id)
        {
            HttpClient pattern = new HttpClient();
            pattern.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            var response = pattern.GetAsync("http://localhost:18080/Epione_JEE-web/epione/doctor/getPatternById/" + id).Result;

            if (response.IsSuccessStatusCode)
            {
                ViewBag.result = response.Content.ReadAsAsync<PatternModel>().Result;
            }
            else
            {
                ViewBag.result = "error";
            }
            return new JsonResult { Data = ViewBag.result, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }

        // POST: Pattern/Edit/5
        public ActionResult Edits(int id, string label,int periode,int price)
        {
            PatternEditModel patternmodel = new PatternEditModel();
            patternmodel.id = id;
            patternmodel.label = label;
            patternmodel.periode =periode;
            patternmodel.price = price;
            
            //patternmodel.idDoctor = 2;
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://127.0.0.1:18080");
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            var response = client.PostAsJsonAsync<PatternEditModel>("Epione_JEE-web/epione/doctor/updatePattern", patternmodel).Result;
            if (response.StatusCode == HttpStatusCode.OK)
            {
                Session["alertMessageSucc"] = "Pattern added successfully";
                Session["alertMessageError"] = null;
                return RedirectToAction("Index", "Pattern");
            }

            return RedirectToAction("Index", "Pattern");
        }

        // GET: Pattern/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Pattern/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            
            PatternEditModel patternModel = new PatternEditModel();
            HttpClient pattern = new HttpClient();
            pattern.BaseAddress = new Uri("http://127.0.0.1:18080");
            pattern.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            var response = pattern.GetAsync("Epione_JEE-web/epione/doctor/getPatternById/"+id).Result;
            var user = response.Content.ReadAsAsync<PatternModel>().Result;

            if (user != null)
            {
                 {
                    patternModel.id = user.id;
                   // patternModel.idDoctor = user.idDoctor;
                    patternModel.label = user.label;
                    patternModel.periode = Convert.ToInt32(user.periode);
                    patternModel.price = Convert.ToInt32(user.price);
                }
                pattern.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var response2 = pattern.PostAsJsonAsync<PatternEditModel>("Epione_JEE-web/epione/doctor/deletePattern", patternModel).Result;
                if (response2.StatusCode == HttpStatusCode.OK)
                {
                    return Json(new { success = true, message = "pattern deleted successfully" }, JsonRequestBehavior.AllowGet);
                }

            }
            return View();
            
        }


        // GET: Pattern
        public ActionResult GetNotActifPatterns()
        {
            List<PatternModel> listPatterns = new List<PatternModel>();

            //PatternModel PatternModels = new PatternModel();
            HttpClient listPattern = new HttpClient();
            listPattern.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            var response = listPattern.GetAsync("http://localhost:18080/Epione_JEE-web/epione/doctor/getListDisabledPatternByDoctor/" + Session["id"]).Result;
            if (response.IsSuccessStatusCode)
            {
                foreach (var pattern in response.Content.ReadAsAsync<IEnumerable<PatternModel>>().Result)
                {

                    PatternModel PatternModel = new PatternModel { id = pattern.id, label = pattern.label, periode = pattern.periode, price = pattern.price };

                    listPatterns.Add(PatternModel);
                }
                return Json(new { data = listPatterns }, JsonRequestBehavior.AllowGet);
            }
            else
            {
                ViewBag.result = "error";
                return ViewBag.result;
            }
        }

        [HttpGet]
        public ActionResult AddOrEdit(int id =0)
        {
            if (id == 0)
            {
                return View(new PatternModel());
            }
            else
            {
                HttpClient pattern = new HttpClient();
                pattern.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var response = pattern.GetAsync("http://localhost:18080/Epione_JEE-web/epione/doctor/getPatternById/" + id).Result;

                if (response.IsSuccessStatusCode)
                {
                    ViewBag.result = response.Content.ReadAsAsync<PatternModel>().Result;
                    return View(ViewBag.result);
                }
                else return View(new PatternModel());
                //else
                //{
                //    ViewBag.result = "error";
                //}
               // return new JsonResult { Data = ViewBag.result, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
            }
            

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddOrEdit( PatternModel patt)
        {
            if (patt.id == 0) { 
            patt.idDoctor = Convert.ToInt32(Session["id"]);

            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://127.0.0.1:18080");
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            var response = client.PostAsJsonAsync<PatternModel>("Epione_JEE-web/epione/doctor/addPattern", patt).Result;
            if (response.StatusCode == HttpStatusCode.OK)
            {
                Session["alertMessageSucc"] = "Pattern added successfully";
                Session["alertMessageError"] = null;
                return Json(new { success = true, message = "save succ" }, JsonRequestBehavior.AllowGet);
            }
            else if (response.StatusCode == HttpStatusCode.OK) //

            {
                Session["alertMessageSucc"] = null;
                Session["alertMessageError"] = "Pattern not added";
                return Json(new { success = true, message = "save succ" }, JsonRequestBehavior.AllowGet);

            } 
            ViewBag.response = client.PostAsJsonAsync<PatternModel>("Epione_JEE-web/epione/doctor/addPattern", patt).Result;
            return Json(new { success = true, message = "pattern saved successfully" }, JsonRequestBehavior.AllowGet);
            }
            else
            {
                PatternEditModel pp = new PatternEditModel();
                pp.id = patt.id;
                pp.label = patt.label;
                pp.periode = Convert.ToInt32(patt.periode);
                pp.price = Convert.ToInt32(patt.price);
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri("http://127.0.0.1:18080");
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var response = client.PostAsJsonAsync<PatternEditModel>("Epione_JEE-web/epione/doctor/updatePattern", pp).Result;
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    return Json(new { success = true, message = "Updated successfully" }, JsonRequestBehavior.AllowGet);
                    
                }
                return Json(new { success = false, message = "Updated failed" }, JsonRequestBehavior.AllowGet);


            }
        }



        [HttpPost]
        public ActionResult Enable(int id, FormCollection collection)
        {

            PatternEditModel patternModel = new PatternEditModel();
            HttpClient pattern = new HttpClient();
            pattern.BaseAddress = new Uri("http://127.0.0.1:18080");
            pattern.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            var response = pattern.GetAsync("Epione_JEE-web/epione/doctor/getPatternById/" + id).Result;
            var user = response.Content.ReadAsAsync<PatternModel>().Result;

            if (user != null)
            {
                {
                    patternModel.id = user.id;
                    // patternModel.idDoctor = user.idDoctor;
                    patternModel.label = user.label;
                    patternModel.periode = Convert.ToInt32(user.periode);
                    patternModel.price = Convert.ToInt32(user.price);
                }
                pattern.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var response2 = pattern.PostAsJsonAsync<PatternEditModel>("Epione_JEE-web/epione/doctor/enablePattern", patternModel).Result;
                if (response2.StatusCode == HttpStatusCode.OK)
                {
                    return Json(new { success = true, message = "pattern enabled successfully" }, JsonRequestBehavior.AllowGet);
                }

            }
            return View();

        }

    }
}
