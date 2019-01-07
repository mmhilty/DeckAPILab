using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.IO;
using Newtonsoft.Json.Linq;

namespace DeckAPILab28.Controllers
{
    public class APIController : Controller
    {
        const string userAgent = "Mozilla/5.0 (Windows NT 6.1; Win64; x64; rv:47.0) Gecko/20100101 Firefox/47.0";


        // GET: API

        //public ActionResult DeckPull()
        //{
        //    return View();
        //}

        //[HttpPost]
        public ActionResult DeckPull()
        {
            //if(ViewBag.DeckID == null)
            //{
            //    HttpWebRequest request1 = WebRequest.CreateHttp("https://deckofcardsapi.com/api/deck/new/shuffle/?deck_count=1");

            //    request1.UserAgent = userAgent;

            //    HttpWebResponse response1 = (HttpWebResponse)request1.GetResponse();
            //    if (response1.StatusCode == HttpStatusCode.OK)
            //    {
            //        StreamReader data = new StreamReader(response1.GetResponseStream());
            //        JObject dataObject = JObject.Parse(data.ReadToEnd());
            //        ViewBag.DeckID = dataObject["deck_id"];
            //    }
            //}

           

            HttpWebRequest request = WebRequest.CreateHttp($"https://deckofcardsapi.com/api/deck/{ViewBag.DeckID}/draw/?count=5");
            request.UserAgent = userAgent;

            HttpWebResponse response = (HttpWebResponse)request.GetResponse();

            if(response.StatusCode == HttpStatusCode.OK)
            {
                StreamReader data = new StreamReader(response.GetResponseStream());
                JObject dataObject = JObject.Parse(data.ReadToEnd());


                ViewBag.Cards = dataObject["cards"];
            }


            return View();
        }
    }
}