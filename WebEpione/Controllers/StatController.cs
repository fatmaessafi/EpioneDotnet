using Service;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using WebEpione.Models;

namespace WebEpione.Controllers
{
    public class StatController : Controller
    {
       
        // GET: Stat
        public ActionResult Index()
        {
            StatService ss = new StatService();
            ServiceMessage msg = new ServiceMessage();
            ServiceAppC apc = new ServiceAppC();
            int c = ss.nbrApp();
            int d = msg.nbrApp();
            int e = apc.nbrApp();
            var x = (float)e / (float)c;
            var y = (float)d / (float)c;
            float taux = x*100;
            float tauxmsg = y*100;

            StatViewModels s = new StatViewModels();
            s.var = c;
            s.varp = d;
            s.app = e;
            s.vart = taux;
            s.varm = tauxmsg;
                     
            return View(s);       
    }
        public ActionResult BillChart()
        {
            StatService ss = new StatService();
            ServiceMessage msg = new ServiceMessage();
            ServiceAppC apc = new ServiceAppC();
            int c = ss.nbrApp();
            int d = msg.nbrApp();
            int e = apc.nbrApp();
            StatViewModels s = new StatViewModels();
            s.var = c;
            s.varp = d;
            s.app = e;

            decimal Appointments = c;
            decimal AppointmentsC = e;

            string myTheme =
                @"<Chart BackColor=""Transparent"">
                     <ChartAreas>
                                <ChartArea Name=""Default"" BackColor=""Transparent""> 
                                </ChartArea>
                     </ChartAreas>
                   </Chart>";
            new Chart(width: 350, height: 350, theme: myTheme)
               .AddSeries(
              chartType: "pie",
               xValue: new[] { "Appointments", "Appointments Cancelled" },
               yValues: new[] { Appointments, AppointmentsC })
               .Write("png");
            return null;
        }

        public ActionResult MyChart()
        {
            StatService ss = new StatService();
            ServiceMessage msg = new ServiceMessage();
            ServiceAppC apc = new ServiceAppC();
            int c = ss.nbrApp();
            int d = msg.nbrApp();
            int e = apc.nbrApp();
            StatViewModels s = new StatViewModels();
            s.var = c;
            s.varp = d;
            s.app = e;



            decimal Appointments = d;
            decimal AppointmentsC = e;

            new Chart(width: 800, height: 500)
                .AddSeries(
               chartType: "Column",
                xValue: new[] { "Appointments", "Appointments Cancelled"},
                yValues: new[] { Appointments, AppointmentsC})
                .Write("png");
            return null;
        }

       
        public class Type
        {
            public int employe { get; set; }
            public int pigiste { get; set; }
        }


        // GET: Stat/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Stat/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Stat/Create
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

        // GET: Stat/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        public ActionResult Index1()
        {
            return View();
        }

        // POST: Stat/Edit/5
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

        // GET: Stat/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Stat/Delete/5
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
