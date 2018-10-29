using DOMAIN;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DATA.configuration
{
    public class PersonConf : EntityTypeConfiguration<Person>
    {
        
       public PersonConf()
        {
            Map<Doctor>(c => c.Requires("type").HasValue(0));
            Map<Patient>(c => c.Requires("type").HasValue(1));
        }
    }
}
