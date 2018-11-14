using Domain.entities;
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
        public ActionResult Create(UserViewModel us)
        {
            HttpClient client = new HttpClient();
           client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            
           var response =  client.PostAsJsonAsync<UserViewModel>("http://localhost:18080/Epione_JEE-web/epione/user/login", us).Result;
            if (response.StatusCode == HttpStatusCode.OK)
            {
                Session["token"] = response.Content.ReadAsAsync<TokenModel>().Result.token;
                Session["username"] = us.username;
                Session["type"] = response.Content.ReadAsAsync<TokenModel>().Result.type;
                return RedirectToAction("Index");

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
