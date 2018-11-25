using Domain.entities;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Mvc;
using Web.Models;

namespace Web.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        public ActionResult Index()
        {
            if (Session["firstname"] != null)
                return RedirectToAction("Index", "Home");
            else
                return View("Index");
        }

        // GET: Account/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Account/Create
        public ActionResult Create()
        {
            if (Session["firstname"] != null)
                return RedirectToAction("Index", "Home");
            else
                return View("Index");
        }

        // POST: Account/Create
        [HttpPost]
        public ActionResult Create(user us)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://127.0.0.1:18080");
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            var response = client.PostAsJsonAsync<user>("Epione_JEE-web/epione/user/login", us).Result;
            if (response.StatusCode == HttpStatusCode.OK)
            {

                string rsp = response.Content.ReadAsStringAsync().Result;
                JObject json = JObject.Parse(rsp);
                Session["token"] = json["token"];
                Session["type"] = json["type"];
                Session["user_id"] = json["user_id"];
                Session["username"] = us.username;

                var responseUser = client.GetAsync("Epione_JEE-web/epione/user/getUser/" + us.username).Result;

                var user = responseUser.Content.ReadAsAsync<user>().Result;

                if (responseUser.StatusCode == HttpStatusCode.OK)
                {
                    Session["id"] = user.id;
                    Session["firstname"] = user.firstname;
                    Session["lastname"] = user.lastname;
                    Session["email"] = user.email;
                    Session["picture"] = user.picture;
                    //najmou nzidou les donnes li nist7a9ohom kima birthday ...
                }
                return RedirectToAction("Index", "Home");
            }
            else
            {
                TempData["errormsg"] = "Usernemae or password is insorrect.";
                return RedirectToAction("Index");
            }


        }
        public ActionResult Logout()
        {

            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://127.0.0.1:18080");
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Session["token"].ToString());

            string id = Session["user_id"].ToString();
            var responseUser = client.GetAsync("Epione_JEE-web/epione/user/logout/" + id).Result;

            if (responseUser.StatusCode == HttpStatusCode.OK)
            {

                //remove the cache 
                Response.Cache.SetCacheability(HttpCacheability.NoCache);
                Response.Cache.SetExpires(DateTime.UtcNow.AddHours(-1));
                Response.Cache.SetNoStore();
                //remove the session
                Session.Clear();
                Response.Cookies.Clear();
                Session.RemoveAll();
                Session.Abandon();
                return RedirectToAction("Index", "Home");
            }
            else
                return RedirectToAction("Index", "Home");
        }
    }
}