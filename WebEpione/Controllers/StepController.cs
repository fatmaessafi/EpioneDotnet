using Domain;
using Domain.Entities;
using Microsoft.AspNet.Identity;
using Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;
using WebEpione.Models;

namespace WebEpione.Controllers
{
    
    public class StepController : Controller
    {
        
        UserService us = new UserService();
        IServiceStep ss = new ServiceStep();
        IServiceTreatment st = new ServiceTreatment();
        IServiceStepRequest ssr = new ServiceStepRequest();
        // GET: Step
        public ActionResult Index()
        {
            return View();
        }

        // GET: Step/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Step/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Step/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Step/Edit/5
        public ActionResult Edit(int id)
        {
            var s = ss.GetById(id);
            StepViewModel svm = new StepViewModel();
            svm.StepId = s.StepId;
            svm.StepSpeciality = s.StepSpeciality;
            svm.NewStepSpeciality = s.StepSpeciality;
            svm.StepDescription = s.StepDescription;
            svm.NewStepDescription = s.StepDescription;
            svm.StepDate = s.StepDate;
            svm.NewStepDate = s.StepDate;

            if (s.Validation == true)
            {
                svm.Validation = "Valid";
                svm.NewValidation = "Valid";
            }
            else
            {
                svm.Validation = "NotValid";
                svm.NewValidation = "NotValid";
            }
            svm.TreatmentId = s.TreatmentId;
            svm.LastModificationBy = us.GetUserById(s.LastModificationBy).FirstName+" "+us.GetUserById(s.LastModificationBy).LastName;
            svm.NewLastModificationBy = Int32.Parse(User.Identity.GetUserId());
            svm.LastModificationDate = s.LastModificationDate.ToString();
            svm.NewLastModificationDate = DateTime.UtcNow.Date;
            svm.ModificationReason = s.ModificationReason;
            svm.NewValidation = "NotValid";
            svm.TreatmentIllness = st.GetById(s.TreatmentId).Illness;
            svm.NewModificationReason = "";

            ViewBag.illness = svm.TreatmentIllness;
            
            if (s.Appointment != null)
            {
                svm.AppointmentId = s.Appointment.AppointmentId;
                svm.Appointment = "Taken";
            }
            else
            {
                svm.AppointmentId = 0;
                svm.Appointment = "Not taken";
            }

            return View(svm);

        }

        // POST: Step/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, StepViewModel collection)
        {
            StepRequest sr = new StepRequest();
            try
            {
                var s = ss.GetById(id);
                sr.NewLastModificationBy = Int32.Parse(User.Identity.GetUserId());
                sr.NewLastModificationDate = DateTime.UtcNow.Date;
                sr.NewModificationReason = collection.NewModificationReason;
                sr.NewTreatmentId = s.TreatmentId;
                sr.NewStepDate = collection.NewStepDate;
                sr.NewStepDescription = collection.NewStepDescription;
                sr.NewStepSpeciality = collection.NewStepSpeciality;
                if (collection.NewValidation == "Valid")
                {
                    sr.NewValidation = true;
                }
                else
                {
                    sr.NewValidation = false;
                }
                var maildocteur= us.GetUserById(st.GetById(s.TreatmentId).DoctorId).Email;
                var mailpatient= us.GetUserById(st.GetById(s.TreatmentId).PatientId).Email;
                var lastmodifbyname = us.GetUserById(s.LastModificationBy).FirstName + " " + us.GetUserById(s.LastModificationBy).LastName;
                var illness = st.GetById(s.TreatmentId).Illness;
                var patient = us.GetUserById(st.GetById(s.TreatmentId).PatientId).FirstName + " " + us.GetUserById(st.GetById(s.TreatmentId).PatientId).LastName;
                //MAIL
                MailMessage mail = new MailMessage("EpionePidev@esprit.tn", maildocteur, "Modification request", "The doctor '" +lastmodifbyname+"' sent a request to modify the treatment of '"+illness+"' of the patient '"+patient+"'");
                 //MailMessage mail = new MailMessage();
                mail.IsBodyHtml = true;
                SmtpClient smtpClient = new SmtpClient("Smtp.gmail.com", 587);
                smtpClient.EnableSsl = true;

               smtpClient.Credentials = new System.Net.NetworkCredential("EpionePidev@gmail.com", "epionepidev123");
                smtpClient.Send(mail);
                ssr.Add(sr);
                ssr.Commit();

                return RedirectToAction("Details", "Treatment", new {id=s.TreatmentId});
            }
            catch
            {
                return View();
            }
        }

        // GET: Step/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Step/Delete/5
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
