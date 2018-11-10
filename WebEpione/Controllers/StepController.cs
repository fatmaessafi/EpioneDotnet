using Service;
using System;
using System.Collections.Generic;
using System.Linq;
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
            svm.StepDescription = s.StepDescription;
            svm.StepDate = s.StepDate;
            if (s.Validation == true)
            {
                svm.Validation = "Validate";
            }
            else
            {
                svm.Validation = "Not validate";
            }
            svm.TreatmentId = s.TreatmentId;
            svm.LastModificationBy = us.GetUserById(s.LastModificationBy).FirstName+" "+us.GetUserById(s.LastModificationBy).LastName;
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
            return View(svm);

        }

        // POST: Step/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
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
