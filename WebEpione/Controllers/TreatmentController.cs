﻿using Domain;
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
   
    public class TreatmentController : Controller
    {
      
        IServiceTreatment st = new ServiceTreatment();
        UserService us = new UserService();
        ServiceStep ss = new ServiceStep(); 
        // GET: Treatment
        public ActionResult Index()
        {
            List<TreatmentViewModel> list = new List<TreatmentViewModel>();
            foreach (var item in st.GetListTreatmentOrdered(1))
            {
                TreatmentViewModel tvm = new TreatmentViewModel();
                tvm.TreatmentId = item.TreatmentId;
                tvm.Illness = item.Illness;
                if (item.Validation == true) { tvm.Validation = "Valid"; }
                else if(item.Validation==false) { tvm.Validation = "Not valid"; }
                tvm.Doctor = us.GetUserById(item.DoctorId).FirstName + " " + us.GetUserById(item.DoctorId).LastName;
                tvm.Patient = us.GetUserById(item.PatientId).FirstName + " " + us.GetUserById(item.PatientId).LastName;


                list.Add(tvm);

            
            }
            return View(list);
        }

        // GET: Treatment/Details/id
        public ActionResult Details(int id)
        {
            List<StepViewModel> liststeps = new List<StepViewModel>();
            if (id!=0) { ViewBag.illness = st.GetById(id).Illness; }
            foreach (var item2 in ss.GetListStepOrdered(id))
            {
                StepViewModel svm = new StepViewModel();
                svm.StepId = item2.StepId;
                svm.StepSpeciality = item2.StepSpeciality;
                svm.StepDescription = item2.StepDescription;
                svm.StepDate = item2.StepDate;
                svm.LastModificationBy = us.GetUserById(item2.LastModificationBy).FirstName + " " + us.GetUserById(item2.LastModificationBy).LastName;
                svm.ModificationReason = item2.ModificationReason;
                svm.LastModificationDate = item2.LastModificationDate.ToString("dd-MM-yyyy");
                if (item2.Validation == true) svm.Validation = "Valid";
                else if (item2.Validation == false) svm.Validation = "Not valid";
                svm.NbModifications = item2.NbModifications;
                svm.TreatmentId = item2.TreatmentId;
                svm.TreatmentIllness = st.GetById(item2.TreatmentId).Illness;

                if (item2.Appointment !=null)
                {
                    svm.AppointmentId = item2.Appointment.AppointmentId;
                    svm.Appointment = "Taken";
                }
                else
                {
                    svm.AppointmentId = 0;
                    svm.Appointment = "Not taken";
                }

                liststeps.Add(svm);
            }
            return View(liststeps);
        }

        // GET: Treatment/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Treatment/Create
        [HttpPost]
        public ActionResult Create(TreatmentViewModel collection)
        {
            try
            {
                Treatment treat = new Treatment();
                treat.TreatmentId = collection.TreatmentId;
                treat.Illness = collection.Illness;
                treat.DoctorId= int.Parse(User.Identity.GetUserId());
                treat.Validation = false;
                st.Add(treat);
                st.Commit();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Treatment/Edit/5
        public ActionResult Edit(int id)
        {

            var t = st.GetById(id);
            TreatmentViewModel tvm = new TreatmentViewModel();
            tvm.Illness = t.Illness;
            if (t.Validation == true)
            {
                tvm.Validation = "Valid";
            }
            else
            {
                tvm.Validation = "Not valid";
            }
            tvm.Doctor = us.GetUserById(t.DoctorId).FirstName + " " + us.GetUserById(t.DoctorId).LastName;

            List<SelectListItem> list = new List<SelectListItem>
            {
            new SelectListItem {  Text = "Not valid", Value = "Not valid"},
            new SelectListItem { Text = "Valid", Value = "Valid"},
          
            };

            ViewBag.DDLItems = new SelectList(list, "Value", "Text", "Not valid");
            return View(tvm);
        }

        // POST: Treatment/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, TreatmentViewModel collection)
        {

            // TODO: Add update logic here
           
                Treatment t = st.GetById(id);
            
                try
                {
                    t.Illness = collection.Illness;
                    if (collection.Validation == "Validate")
                    { t.Validation = true;
                    }
                    else
                    {
                        t.Validation = false;
                    }
                    st.Update(t);
                    st.Commit();

                    return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Treatment/Delete/5
        public ActionResult Delete(int id)
        {
            var t = st.GetById(id);
            TreatmentViewModel tvm = new TreatmentViewModel();
            tvm.Illness = t.Illness;
            if (t.Validation == true)
            {
                tvm.Validation = "Validate";
            }
            else
            {
                tvm.Validation = "Not validate";
            }
            tvm.Doctor = us.GetUserById(t.DoctorId).FirstName+" "+us.GetUserById(t.DoctorId).LastName;
            return View(tvm);
        }

        // POST: Treatment/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, TreatmentViewModel collection)
        {
              Treatment t = st.GetById(id);
            
            try
            {   
                t.Illness = collection.Illness;
                if (collection.Validation == "Validate")
                { t.Validation = true; }
                else
                {
                    t.Validation = false;
                }
                st.Delete(t);
                st.Commit();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
