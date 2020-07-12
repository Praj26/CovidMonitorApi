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
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class LocationGraphController : ApiController
    {
        string connectionstring = ConfigurationManager.ConnectionStrings["connectionString"].ToString();

        // GET api/locationgraph
        [HttpGet]
        public List<LocationGraph> Get()
        {
            List<LocationGraph> series = new List<LocationGraph>();
            SqlConnection con = new SqlConnection(connectionstring);
            string sqlquery = "Select Count(*) , City from Patient Group By City";
            con.Open();
            SqlCommand sqlCommand = new SqlCommand(sqlquery, con);
            SqlDataReader reader = sqlCommand.ExecuteReader();
            while (reader.Read())
            {
                series.Add(new LocationGraph
                {
                    caseCount = Convert.ToInt32(reader.GetValue(0)),
                    city = reader.GetValue(1).ToString(),
                });
            }
            con.Close();
            return series;
        }

    }
}
