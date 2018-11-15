using Domain;
using Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebEpione.Controllers
{
   
    public class WSFirasController : ApiController
    {
        IServiceRapport rs = new ServiceRapport();
        [System.Web.Http.HttpGet]
        public IEnumerable<Report> GetAllReports()
        {
            return rs.GetAll().ToList();
           
        }
        [System.Web.Http.HttpGet]
        public IEnumerable<Report> GetTreatmentById(int id)
        {

            return rs.GetAll().Where(a => a.ReportId == id);
            // st.GetAll().Where(a=>a.PatientId==idUser).ToList():
            // return st.GetListTreatmentOrdered(idUser);
        }

    }
}
