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
using WebEpione.Models;

namespace WebEpione.Controllers
{
    public class HomeController : Controller
    {
        private Contexte db = new Contexte();
        UserService us = new UserService();
        IServicePatient sp = new ServicePatient();
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
            int currentUserId = 0;
            if (User.Identity.GetUserId()!="")
            {
                 currentUserId = Int32.Parse(User.Identity.GetUserId());
            }
           
                var cuser = new Patient();
            if (sp.GetById(currentUserId) != null) { cuser = sp.GetById(currentUserId); }
            PatientViewModel pvm = new PatientViewModel();
            pvm.LastName = cuser.LastName;
            pvm.FirstName = cuser.FirstName;
            pvm.City = cuser.City;
            pvm.BirthDate = cuser.BirthDate;
            pvm.CivilStatus = cuser.CivilStatus;
            pvm.Gender = cuser.Gender;
            pvm.HomeAddress = cuser.HomeAddress;
            pvm.Profession = cuser.Profession;
            pvm.RegistrationDate = cuser.RegistrationDate;
            pvm.Allergies = cuser.Allergies;
            pvm.SpecialReq = cuser.SpecialReq;
            pvm.PhoneNumber = cuser.PhoneNumber;
            List<PatientViewModel> listuser = new List<PatientViewModel>();
            listuser.Add(pvm);
        int nb= st.nbTotalTreatment(currentUserId);
            ViewBag.nbtreat = nb;


            return PartialView(listuser);
        }

    }
}