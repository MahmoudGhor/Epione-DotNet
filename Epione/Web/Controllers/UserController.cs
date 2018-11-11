using Domain;
using Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web.Models;

namespace Web.Controllers
{
    
    public class UserController : Controller
    {
        IUserService userService = new UserService();
        // GET: User
        public ActionResult Index()
        {
            List<UserViewModel> liste = new List<UserViewModel>();
            var listeUser = userService.GetAll();
            foreach(var i in listeUser)
            {
                UserViewModel userView = new UserViewModel();
                userView.firstname = i.firstname;
                userView.username = i.username;
                liste.Add(userView);
            }
            return View(liste);
        }

        // GET: User/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: User/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: User/Create
        [HttpPost]
        public ActionResult Create(UserViewModel user)
        {
            User u = new User();
            u.id = user.id;
            u.username = user.username;
            u.firstname = user.firstname;
            userService.Add(u);
            userService.Commit();
            return RedirectToAction("Index");

            //try
            //{
            //    // TODO: Add insert logic here

            //    return RedirectToAction("Index");
            //}
            //catch
            //{
            //    return View();
            //}
        }

        // GET: User/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: User/Edit/5
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

        // GET: User/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: User/Delete/5
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
