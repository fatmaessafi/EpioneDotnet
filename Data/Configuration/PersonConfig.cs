using Domain;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Configuration
{
    public class PersonConfig : EntityTypeConfiguration<Person>
    {
        
       public PersonConfig()
        {
            Map<Doctor>(c => c.Requires("type").HasValue(0));
            Map<Patient>(c => c.Requires("type").HasValue(1));
        }
    }
}
