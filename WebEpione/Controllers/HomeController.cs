using Data;
using Domain;
using Domain.Entities;
using Microsoft.AspNet.Identity;
using Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebEpione.Controllers
{
    public class HomeController : Controller
    {
        private Contexte db = new Contexte();
        UserService us = new UserService();
        IServiceTreatment st = new ServiceTreatment();
        public ActionResult Index()
        {
            if (User.Identity.GetUserId() != null)
            {
                int currentUserId = Int32.Parse(User.Identity.GetUserId());
                TempData["currentid"] = currentUserId;
                UserService su = new UserService();
                User user = new User();
                ViewBag.id = currentUserId;
                string userstring = su.GetUserById(currentUserId).ToString();
                ViewBag.userstring = userstring;

                if (userstring.Contains("Doctor") == true)

                {
                    TempData["role"] = "Doctor";
                }
                else if (userstring.Contains("Patient") == true)
                {
                    TempData["role"] = "Patient";
                }
                else
                {
                    TempData["role"] = "No type";
                }

            }
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public PartialViewResult UserInformations()
        {
                int currentUserId = Int32.Parse(User.Identity.GetUserId());
                
                var cuser = new User();
               
                cuser = us.GetUserById(currentUserId);
            List<User> listuser = new List<User>();
            listuser.Add(cuser);
        int nb= st.nbTotalTreatment(currentUserId);
            ViewBag.nbtreat = nb;


            return PartialView(listuser);
        }

    }
}