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
            return View();
        }

        // GET: Account/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Account/Create
        public ActionResult Create()
        {
            return View("Index");
        }

        // POST: Account/Create
        [HttpPost]
        public ActionResult Create(user us)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://127.0.0.1:18080");
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            var response =  client.PostAsJsonAsync<user>("Epione_JEE-web/epione/user/login", us).Result;
            if (response.StatusCode == HttpStatusCode.OK)
            {

                string rsp = response.Content.ReadAsStringAsync().Result;
                JObject json = JObject.Parse(rsp);
                Session["token"] = json["token"];
                Session["type"] = json["type"];
                Session["user_id"] = json["user_id"];
                Session["username"] = us.username;

                var responseUser = client.GetAsync("Epione_JEE-web/epione/user/getUser/"+us.username).Result;

                var user = responseUser.Content.ReadAsAsync<user>().Result;

                if (response.StatusCode == HttpStatusCode.OK)
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
                return RedirectToAction("Index","Home");
            }
            

        }

        // GET: Account/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Account/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Account/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Account/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
