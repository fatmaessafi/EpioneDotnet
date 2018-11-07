using Domain;
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
        public static int idPatient = 1;
        IServiceTreatment st = new ServiceTreatment();
        UserService us = new UserService();
        ServiceStep ss = new ServiceStep();
        // GET: Treatment
        public ActionResult Index()
        {
            List<TreatmentViewModel> list = new List<TreatmentViewModel>();
            foreach (var item in st.GetListTreatmentOrdered(idPatient))
            {
                TreatmentViewModel tvm = new TreatmentViewModel();
                tvm.TreatmentId = item.TreatmentId;
                tvm.Illness = item.Illness;
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
                svm.StepDescription = item2.StepDescription;
                svm.StepDate = item2.StepDate;
                svm.LastModificationBy = us.GetUserById(item2.LastModificationBy.Id).FirstName+" "+ us.GetUserById(item2.LastModificationBy.Id).LastName;
                svm.ModificationReason = item2.ModificationReason;
                svm.LastModificationDate = item2.LastModificationDate.Date;
                if (item2.Validation == true) svm.Validation = "Validate";
                else if (item2.Validation == false) svm.Validation = "Not validate";
                svm.NbModifications = item2.NbModifications;
                svm.TreatmentId = item2.TreatmentId;
                svm.TreatmentIllness = st.GetById(item2.TreatmentId).Illness;


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
                treat.PatientId = idPatient;
                treat.DoctorId= int.Parse(User.Identity.GetUserId());
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
            return View();
        }

        // POST: Treatment/Edit/5
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

        // GET: Treatment/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Treatment/Delete/5
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
