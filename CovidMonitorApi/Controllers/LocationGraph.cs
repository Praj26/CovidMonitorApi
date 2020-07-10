using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using CovidMonitorApi.Models;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using System.Web.Http.Cors;

namespace CovidMonitorApi.Controllers
{
    public class LocationGraph : ApiController
    {
        string connectionstring = "Server = DESKTOP-HKSUM9R; initial catalog = CovidMonitor; Integrated Security = True; ";

        // GET api/locationgraph
        [HttpGet]
        public List<Patient> Get()
        {
            List<Patient> series = new List<Patient>();
            SqlConnection con = new SqlConnection(connectionstring);
            string sqlquery = "Select Count(*) from Patient Group By City";
            con.Open();
            SqlCommand sqlCommand = new SqlCommand(sqlquery, con);
            SqlDataReader reader = sqlCommand.ExecuteReader();
            while (reader.Read())
            {
                series.Add(new Patient
                {
                    cityCount = Convert.ToInt32(reader.GetValue(0)),
                    cityGroup = reader.GetValue(1).ToString(),
                });
            }
            con.Close();
            return series;
        }

    }
}
