using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CovidMonitorApi.Models
{
    public class AgeGraph
    {
        public string age { get; set; }
        public int caseCount { get; set; }
    }
    public class MonthGraph
    {
        public string month { get; set; }
        public int caseCount { get; set; }
    }

    public class LocationGraph
    {
        public string city { get; set; }
        public int caseCount { get; set; }
    }
}