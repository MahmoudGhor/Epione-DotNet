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
    public class ChatController : Controller
    {
        // GET: Chat
        public ActionResult send(string key, string message)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://127.0.0.1:18080");
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            chatMessage msg = new chatMessage();
            msg.content = message;
            msg.doctorName = Session["username"].ToString();
            msg.isPatient = "";
            msg.patientName = "";

            var response = client.PostAsJsonAsync<chatMessage>("Epione_JEE-web/epione/messages/ques/send/"+key, msg);

            return Json(new { result = "ok"}, JsonRequestBehavior.AllowGet);
        }
    }
}