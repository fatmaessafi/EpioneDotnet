using Domain;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Configuration
{
    class MessageConfig : EntityTypeConfiguration<Message>
    {
         public MessageConfig()
        {
            //Table porteuse
            HasKey(a => new { a.MessageId, a.DoctorId, a.PatientId });
        }
   
}
 }
    

