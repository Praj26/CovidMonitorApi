using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CovidMonitorApi.Models
{
    public class Patient
    {
        public int Id { get; set; }
        public String Name { get; set; }
        public String Address { get; set; }
        public String City { get; set; }
        public int Age { get; set; }
        public int Status { get; set; }
        public int Num_Of_Fam { get; set; }
        public String Month { get; set; }

        public int total_number_cases { get; set; }

        public int total_number_deceased { get; set; }

        public int total_number_recovered { get; set; }

        public int cityCount { get; set; }

        public string cityGroup { get; set; }

        public int monthCount { get; set; }

        public string monthGroup { get; set; }

        public int ageCount { get; set; }

        public string ageGroup { get; set; }
    }
}