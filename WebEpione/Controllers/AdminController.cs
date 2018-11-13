using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebEpione.Models;

namespace WebEpione.Controllers
{
    public class AdminController : Controller
    {
        private int reTryCounter;

        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult RecupDoc()
        {
            List<UserViewModel> lists = new List<UserViewModel>();

            UserViewModel UserViewModl = new UserViewModel();
            HtmlAgilityPack.HtmlWeb web = new HtmlAgilityPack.HtmlWeb();
            HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();


            web.PreRequest = delegate (HttpWebRequest webRequest)
            {
                webRequest.Timeout = 15000;
                return true;
            };

            try { doc = web.Load("https://www.doctolib.fr/medecin-generaliste/france"); }
            catch (WebException ex)
            {
                reTryCounter++;
                if (reTryCounter == 19) { }
            }
            catch (IOException ex2)
            {

            }

            var HeaderNames = doc.DocumentNode.SelectNodes("//a[@class='dl-search-result-name js-search-result-path']").ToList();
            var Headerspec = doc.DocumentNode.SelectNodes("//div[@class='dl-search-result-subtitle']").ToList();
            var HeaderAdd = doc.DocumentNode.SelectNodes("//div[@class='dl-text dl-text-body']").ToList();

            var alternatePairs = HeaderNames.Select(
             (item1, index1) => new
             {
                 name = item1,
                 address = HeaderAdd[index1 % 2],
                 spec = Headerspec[index1 % 3]

             });
            foreach (var item3 in alternatePairs)
            {
                UserViewModl.doctolibName = item3.name.InnerText;
                UserViewModl.doctolibAdress = item3.address.InnerText;
                UserViewModl.doctolibSpec = item3.spec.InnerText;
                lists.Add(UserViewModl);
            }


            try
            {
                // TODO: Add insert logic here
                return View(lists);
            }
            catch
            {
                return View();
            }






            return View();
        }
    }
}
