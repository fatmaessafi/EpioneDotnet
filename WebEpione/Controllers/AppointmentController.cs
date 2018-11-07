using Domain;
using Service;
using ServicePattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebEpione.Models;

namespace WebEpione.Controllers
{
    public class AppointmentController : Controller
    {
    
        IserviceAppointment AS = new ServiceAppointment();
        // GET: Appointment
        public ActionResult Index()
        {
            List<AppointmentViewModel> list = new List<AppointmentViewModel>();

            foreach (var item in AS.GetAll())
            {
                AppointmentViewModel PVM = new AppointmentViewModel();

                PVM.AppDate = item.AppDate;
                PVM.VisitReason = item.VisitReason;
                PVM.AppointmentId = item.AppointmentId;
                PVM.AppRate= item.AppRate;
                PVM.DoctorId = item.DoctorId;
                PVM.ReportId=item.ReportId;
                PVM.PatientId = item.PatientId;

                list.Add(PVM);
            }

            return View(list);

        }

        // GET: Appointment/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Appointment/Create
        public ActionResult Create()
        {
            return View();
        }
        // GET: Appointment/CreateAppointment
        public ActionResult CreateAppointment()
        {
            return View();
        }


        // POST: Appointment/Create
        [HttpPost]
        public ActionResult Create(AppointmentViewModel collection)
        {
            Appointment a = new Appointment() ;


            a.AppDate = collection.AppDate;


            a.AppointmentId = collection.AppointmentId;
            a.AppRate= collection.AppRate;
            a.VisitReason = collection.VisitReason;
            a.DoctorId = collection.DoctorId;
            a.PatientId = collection.PatientId;
            a.ReportId = collection.ReportId;

            AS.Add(a);
            AS.Commit();
            return RedirectToAction("Index");

        }

        // GET: Appointment/Edit/5
        public ActionResult Edit(int id)
        {
            var app = AS.GetById(id);
            AppointmentViewModel bvm = new AppointmentViewModel();
            bvm.AppDate = app.AppDate;
            bvm.AppRate = app.AppRate;
            bvm.DoctorId = app.DoctorId;
            bvm.VisitReason = app.VisitReason;
            bvm.ReportId = app.ReportId;

            //var bib1 = AS.GetAll();

            //List<AppointmentViewModel> lbvm = new List<AppointmentViewModel>();
            //foreach (var item in bib1)
            //{
            //    AppointmentViewModel bvm1 = new AppointmentViewModel();
            //    bvm1.AppDate = item.AppDate;
            //    bvm1.AppRate = item.AppRate;
            //    bvm1.VisitReason = app.VisitReason;
            //    bvm1.ReportId = app.ReportId;
            //    lbvm.Add(bvm1);

            //}
            //ViewData["app"] = new SelectList(lbvm, "Code", "Code");

            return View(bvm);
        }


        // POST: Appointment/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, AppointmentViewModel collection)
        {
            Appointment a = AS.GetById(id);


            a.AppDate = collection.AppDate;


         
            a.AppRate = collection.AppRate;
            a.DoctorId = collection.DoctorId;
            a.PatientId = collection.PatientId;
            a.ReportId = collection.ReportId;

            AS.Update(a);
            AS.Commit();
            return RedirectToAction("Index");
        }

        // GET: Appointment/Delete/5
        public ActionResult Delete(int id)
        {
            var app = AS.GetById(id);


            AppointmentViewModel bvm = new AppointmentViewModel();
            bvm.AppDate = app.AppDate;
            bvm.AppRate = app.AppRate;
            bvm.DoctorId = app.DoctorId;
            bvm.VisitReason = app.VisitReason;
            bvm.ReportId = app.ReportId;

            return View(bvm);

        }

        // POST: Appointment/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, AppointmentViewModel collection)
        {
            Appointment a = AS.GetById(id);


            //  a.AppointmentId = collection.AppointmentId;
            a.AppDate = collection.AppDate;
            a.AppRate = collection.AppRate;
            a.VisitReason = collection.VisitReason;
            a.DoctorId = collection.DoctorId;
            a.PatientId = collection.PatientId;
            a.ReportId = collection.ReportId;

            AS.Delete(a);
            AS.Commit();

            return RedirectToAction("Index");
        }
       





    }
}
