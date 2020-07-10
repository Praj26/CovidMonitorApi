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

namespace CovidMonitorApi.Controllers
{
    public class ValuesController : ApiController
    {
        // GET api/values
        [HttpGet]
        public List<Patient> GetCount()

        {
            //return listEmp.First(e => e.ID == id);  
            List<Patient> patient = new List<Patient>();
            string connectionstring = "Server = DESKTOP-HKSUM9R; initial catalog = CovidMonitor; Integrated Security = True; ";
            SqlConnection con = new SqlConnection(connectionstring);
            string sqlquery = "Select Count(*) as total_number_cases from Patient";
            con.Open();
            SqlCommand sqlCommand = new SqlCommand(sqlquery, con);
            SqlDataReader reader = sqlCommand.ExecuteReader();
            while (reader.Read())
            {
                patient.Add(new Patient
                {
                    total_number_cases = Convert.ToInt32(reader.GetValue(0)),
                    total_number_deceased = Convert.ToInt32(reader.GetValue(1)),
                    total_number_recovered = Convert.ToInt32(reader.GetValue(2)),
                    
                });
            }
            return patient;
     }
    

    // GET api/values/5
    public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
