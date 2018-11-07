using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    class Events
    {
        public int EventId { set; get;}
        public string Subject { set; get; }
        public string Description { set; get; }
        public DateTime Start { set; get; }
        public DateTime End { set; get; }
        public string ThemeColor { set; get; }
        public byte IsFullDay { set; get; }
    }
}
