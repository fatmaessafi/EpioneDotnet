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
        private Contexte db=new Contexte();
        
        
        public ActionResult Index()
        {   
            int currentUserId = Int32.Parse(User.Identity.GetUserId());
            

            UserService su = new UserService();
            User user = new User();
            ViewBag.id = currentUserId;
            
            string userstring=su.GetUserById(currentUserId).ToString();
            ViewBag.userstring = userstring;
            
            if(userstring.Contains("Doctor")==true)
            
            {
                TempData["role"]= "Doctor";
            }
            else if(userstring.Contains("Patient") == true)
            {
                TempData["role"] = "Patient";
            }
            else
            {
                TempData["role"] = "No type";
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
    }
}