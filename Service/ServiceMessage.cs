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
   public class ServiceMessage : Service<Message>, IServiceMessage
    {
            private static IDatabaseFactory databaseFactory = new DatabaseFactory();
            private static IUnitOfWork unit = new UnitOfWork(databaseFactory);
            public ServiceMessage() : base(unit)
            {

            }

            public int nbrApp()
            {
                return GetAll().Count();
            }
        }
    
}
