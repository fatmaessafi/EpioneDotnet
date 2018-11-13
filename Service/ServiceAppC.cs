using Data.Infrastructure;
using Domain;
using ServicePattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class ServiceAppC : Service<Analytics>, IServiceAppC
    {


        private static IDatabaseFactory databaseFactory = new DatabaseFactory();
        private static IUnitOfWork unit = new UnitOfWork(databaseFactory);
        public ServiceAppC() : base(unit)
            {

        }

        public int nbrApp()
        {
            return GetAll().Count();
        }
    }
}
