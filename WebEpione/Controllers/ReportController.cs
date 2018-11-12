using Domain;
using Service;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebEpione.Models;
using Rotativa;


namespace WebEpione.Controllers
{
    public class ReportController : Controller
    {
        IServiceRapport RS = new ServiceRapport();
        // GET: Report
        public ActionResult Index()
        {
            List<ReportViewModels> list = new List<ReportViewModels>();

            foreach (var item in RS.GetAll())
            {
                ReportViewModels PVM = new ReportViewModels();
                PVM.ReportId = item.ReportId;
                PVM.ReportTitle = item.ReportTitle;
                PVM.ReportDescription = item.ReportDescription;
                PVM.ReportImage = item.ReportImage;
                PVM.ReportDate = item.ReportDate;

                list.Add(PVM);
            }

            return View(list);
        }

        public ActionResult ExportPDF()
        {
            return new Rotativa.ActionAsPdf("Index") {
          FileName =Server.MapPath("~/Content/list.pdf")      };


           
        }

        // GET: Report/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Report/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Report/Create
        [HttpPost]
        public ActionResult Create(ReportViewModels RVM,HttpPostedFileBase file)
        {
           // TODO: Add insert logic here

                Report r = new Report();

                r.ReportId = 1;
                r.ReportTitle = RVM.ReportTitle;
                r.ReportDescription = RVM.ReportDescription;
                r.ReportDate = DateTime.UtcNow.Date;
            r.Step = new Step { StepId = 2,TreatmentId=2 };
                r.ReportImage = RVM.ReportImage;


            var fileName = "";
            if (file.ContentLength > 0)
            {
                fileName = Path.GetFileName(file.FileName);

                var path = Path.Combine(Server.MapPath("~/Content/Upload/"), file.FileName);
                file.SaveAs(path);
            }
            r.ReportImage = file.FileName;


            RS.Add(r);
            RS.Commit();

                return RedirectToAction("Index");
            
          
              
        }

        // GET: Report/Edit/5
        public ActionResult Edit(int id)
        {
            var bib = RS.GetById(id);

           

            ReportViewModels rvm = new ReportViewModels();
            rvm.ReportDescription = bib.ReportDescription;
            rvm.ReportTitle = bib.ReportTitle;
           

            return View(rvm);
        }

        // POST: Report/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, ReportViewModels RVM, HttpPostedFileBase file)
        {
            Report r = RS.GetById(id);

            /* var fileName = "";
             if (file.ContentLength > 0)
             {
                 fileName = Path.GetFileName(file.FileName);

                 var path = Path.Combine(Server.MapPath("~/Content/Upload/"), file.FileName);
                 file.SaveAs(path);
             }

             r.ReportImage = file.FileName;
             r.ReportImage = RVM.ReportImage; */


            r.ReportTitle = RVM.ReportTitle;
            r.ReportDescription = RVM.ReportDescription;
            RS.Update(r);
            RS.Commit();

            return RedirectToAction("index");
            
        }

        // GET: Report/Delete/5
        public ActionResult Delete(int id)
        {
            var bib = RS.GetById(id);


            ReportViewModels rvm = new ReportViewModels();
            rvm.ReportDate = bib.ReportDate;
            rvm.ReportDescription = bib.ReportDescription;
            rvm.ReportImage=bib.ReportImage;
            //rvm.Step.TreatmentId = bib.Step.TreatmentId;
            rvm.ReportTitle = bib.ReportTitle;


            return View(rvm);

           
        }

        // POST: Report/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, ReportViewModels RVM)
        {
            
                // TODO: Add delete logic here
               Report d = RS.GetById(id);
                RVM.ReportTitle = d.ReportTitle;
                RVM.ReportImage = d.ReportImage;
                RVM.ReportDescription = d.ReportDescription;
                RVM.ReportDate = d.ReportDate;
               // RVM.Step.TreatmentId = d.Step.TreatmentId;

                RS.Delete(d);
                RS.Commit();

                return RedirectToAction("Index");
            
           
        }
    }
}
