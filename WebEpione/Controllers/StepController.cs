﻿using Domain;
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
        public ActionResult Create(int id)
        {
            TempData["idTreatment"] = id;

            return View();
        }

        // POST: Step/Create
        [HttpPost]
        public ActionResult Create(int id, StepViewModel collection)
        {
            try
            {
                var docteurreferant = us.GetUserById(st.GetById(id).DoctorId).Id;
                if (Int32.Parse(User.Identity.GetUserId()) == docteurreferant)
                {

                    Step s = new Step();
                    s.TreatmentId = id;

                    s.LastModificationBy = Int32.Parse(User.Identity.GetUserId());
                    s.LastModificationDate = DateTime.UtcNow.Date;
                    s.ModificationReason = "No modifications yet";
                    s.StepDate = collection.StepDate;
                    s.StepDescription = collection.StepDescription;
                    s.StepSpeciality = collection.StepSpeciality;
                    s.Appointment = null;
                    s.NbModifications = 0;
                    
                    s.Validation = false;

                    ss.Add(s);
                    ss.Commit();
                }
                else
                {
                    StepRequest sr = new StepRequest();
                    sr.NewTreatmentId = id;

                    sr.NewLastModificationBy = Int32.Parse(User.Identity.GetUserId());
                    sr.NewLastModificationDate = DateTime.UtcNow.Date;
                    sr.NewModificationReason = "No modifications yet";
                    sr.NewStepDate = collection.NewStepDate;
                    sr.NewStepDescription = collection.StepDescription;
                    sr.NewStepSpeciality = collection.StepSpeciality;

                    sr.NewValidation = false;
                    var maildocteur = us.GetUserById(st.GetById(sr.NewTreatmentId).DoctorId).Email;
                    var mailpatient = us.GetUserById(st.GetById(sr.NewTreatmentId).PatientId).Email;
                    var lastmodifbyname = us.GetUserById(sr.NewLastModificationBy).FirstName + " " + us.GetUserById(sr.NewLastModificationBy).LastName;
                    var illness = st.GetById(sr.NewTreatmentId).Illness;
                    var patient = us.GetUserById(st.GetById(sr.NewTreatmentId).PatientId).FirstName + " " + us.GetUserById(st.GetById(sr.NewTreatmentId).PatientId).LastName;
                    //MAIL
                    MailMessage mail = new MailMessage("EpionePidev@esprit.tn", maildocteur, "New step request", "The doctor '" + lastmodifbyname + "' sent a request to add a new step in the treatment of '" + illness + "' of the patient '" + patient + "'");
                    mail.IsBodyHtml = true;
                    SmtpClient smtpClient = new SmtpClient("Smtp.gmail.com", 587);
                    smtpClient.EnableSsl = true;

                    smtpClient.Credentials = new System.Net.NetworkCredential("EpionePidev@gmail.com", "epionepidev123");
                    smtpClient.Send(mail);
                    //!MAIL

                    ssr.Add(sr);
                    ssr.Commit();
                }
                return RedirectToAction("Details", "Treatment", new { id = id });
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
            svm.LastModificationBy = us.GetUserById(s.LastModificationBy).FirstName + " " + us.GetUserById(s.LastModificationBy).LastName;
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

            try
            {
                var docteurreferant = us.GetUserById(st.GetById(id).DoctorId).Id;
                if (Int32.Parse(User.Identity.GetUserId()) != docteurreferant)
                {
                    var s = ss.GetById(id);
                    StepRequest sr = new StepRequest();
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
                    sr.Type = "Update";
                    ssr.Add(sr);
                    ssr.Commit();
                    var maildocteur = us.GetUserById(st.GetById(s.TreatmentId).DoctorId).Email;
                    var mailpatient = us.GetUserById(st.GetById(s.TreatmentId).PatientId).Email;
                    var lastmodifbyname = us.GetUserById(s.LastModificationBy).FirstName + " " + us.GetUserById(s.LastModificationBy).LastName;
                    var illness = st.GetById(s.TreatmentId).Illness;
                    var patient = us.GetUserById(st.GetById(s.TreatmentId).PatientId).FirstName + " " + us.GetUserById(st.GetById(s.TreatmentId).PatientId).LastName;
                    //MAIL
                    MailMessage mail = new MailMessage("EpionePidev@esprit.tn", maildocteur, "Modification request", "The doctor '" + lastmodifbyname + "' sent a request to modify the treatment of '" + illness + "' of the patient '" + patient + "'");
                    mail.IsBodyHtml = true;
                    SmtpClient smtpClient = new SmtpClient("Smtp.gmail.com", 587);
                    smtpClient.EnableSsl = true;

                    smtpClient.Credentials = new System.Net.NetworkCredential("EpionePidev@gmail.com", "epionepidev123");
                    smtpClient.Send(mail);
                    //!MAIL
                   
                    return RedirectToAction("Details", "Treatment", new { id = s.TreatmentId });

                }
                else
                {

                    var s = ss.GetById(id);
                    s.LastModificationBy = Int32.Parse(User.Identity.GetUserId());
                    s.LastModificationDate = DateTime.UtcNow.Date;
                    s.ModificationReason = collection.NewModificationReason;

                    s.StepDate = collection.NewStepDate;
                    s.StepDescription = collection.NewStepDescription;
                    s.StepSpeciality = collection.NewStepSpeciality;
                    s.NbModifications = s.NbModifications + 1;
                    if (collection.NewValidation == "Valid")
                    {
                        s.Validation = true;
                    }
                    else
                    {
                        s.Validation = false;
                    }
                    ss.Update(s);
                    ss.Commit();
                    return RedirectToAction("Details", "Treatment", new { id = s.TreatmentId });


                }
            }
               
            catch
            {
                return View();
            }
        }

        // GET: Step/Delete/5
        public ActionResult Delete(int id)
        {
            var s = ss.GetById(id);
            StepViewModel svm = new StepViewModel();
            svm.StepId = s.StepId;
            svm.StepSpeciality = s.StepSpeciality;
            svm.StepDescription = s.StepDescription;
            svm.StepDate = s.StepDate;

            if (s.Validation == true)
            {
                svm.Validation = "Valid";
            }
            else
            {
                svm.Validation = "NotValid";
            }
            svm.TreatmentId = s.TreatmentId;
            svm.LastModificationBy = us.GetUserById(s.LastModificationBy).FirstName + " " + us.GetUserById(s.LastModificationBy).LastName;
            svm.LastModificationDate = s.LastModificationDate.ToString();
            svm.ModificationReason = s.ModificationReason;
            svm.TreatmentIllness = st.GetById(s.TreatmentId).Illness;

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
            return View();
        }

        // POST: Step/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, StepViewModel collection)
        {
            try
            {
                Step s = ss.GetById(id);

               
                    s.StepId = id;

                    var docteurreferant = us.GetUserById(st.GetById(id).DoctorId).Id;
                    if (Int32.Parse(User.Identity.GetUserId()) == docteurreferant)
                    {

                        ss.Delete(s);
                        ss.Commit();


                        return RedirectToAction("Details", "Treatment", new { id = collection.TreatmentId });
                    }
                    else
                    {
                        ViewBag.errordelete = "You can't delete this step you are not a doctor referant";
                        return View();
                    }
                }
                catch
                {
                    return View();
                }
            }
            }
    }


    

