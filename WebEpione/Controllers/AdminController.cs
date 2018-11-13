﻿using System;
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

            var HeaderNames = doc.DocumentNode.SelectNodes("//a[@class='dl-search-result-name js-search-result-path']").ToArray();
            var Headerspec = doc.DocumentNode.SelectNodes("//div[@class='dl-search-result-subtitle']").ToArray();
            var HeaderAdd = doc.DocumentNode.SelectNodes("//div[@class='dl-text dl-text-body']").ToArray();


          int  i= 0;

            foreach (var item3 in HeaderNames)
            {

                UserViewModel UserViewModl = new UserViewModel();
                UserViewModl.doctolibName = item3.InnerText;
                UserViewModl.doctolibAdress = HeaderAdd[i].InnerText;
                UserViewModl.doctolibSpec = Headerspec[i].InnerText;
                i++;
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


        public ActionResult 
    }
}