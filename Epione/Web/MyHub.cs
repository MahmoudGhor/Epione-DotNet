using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;
using System.Net.Http;
using System.Net.Http.Headers;
using Domain.entities;

namespace Web
{
    public class MyHub : Hub
    {
        public void Hello()
        {
            //Clients.All.hello();

        }

        public void notifRate(int t,string patient)
        {

            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://127.0.0.1:18080");
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            var response = client.GetAsync("Epione_JEE-web/epione/rate/lisappr/" + patient).Result;
            var obj = response.Content.ReadAsAsync<IEnumerable<appointment>>().Result;
            //bool b;
            //DateTime d = new DateTime();
            int i = obj.Count();
            if (i == 0)
                t = 1;
            string msg = "you have " + i + " unrated appointement";

            Clients.All.notifRate(t,msg);

        }

        public void rateDoc(int rate, string doc , string msg)
        {

            if(rate == 2 || rate == 1)
                Clients.All.rateDoc(rate, doc, "you need to perform better with your patients");
            else if(rate == 3)
                Clients.All.rateDoc(rate, doc, "your appointements rating is not bad");
            else if (rate == 4)
                Clients.All.rateDoc(rate, doc, "you have a good performing with your patients");
            else
                Clients.All.rateDoc(rate, doc, "you have excellent performing with your patients");

        }

    }
}