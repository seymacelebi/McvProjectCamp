using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace McvPrpjectKampi.Models
{
    public class HeadingClasses
    {
        public int id { get; set; }
        public string title { get; set; }
        public DateTime start { get; set; }
        public DateTime end { get; set; }
        public bool allDay { get; set; }
    }
}