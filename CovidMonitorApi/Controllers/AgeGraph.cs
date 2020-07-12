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
    public class AgeGraphController : ApiController
    {
        string connectionstring = ConfigurationManager.ConnectionStrings["connectionString"].ToString();

        // GET api/agegraph
        [HttpGet]
        public List<AgeGraph> Get()
        {
            List<AgeGraph> series = new List<AgeGraph>();
            SqlConnection con = new SqlConnection(connectionstring);
            string sqlquery = "Select Count(*) , Age from Patient Group By Age";
            con.Open();
            SqlCommand sqlCommand = new SqlCommand(sqlquery, con);
            SqlDataReader reader = sqlCommand.ExecuteReader();
            while (reader.Read())
            {
                series.Add(new AgeGraph
                {
                    caseCount = Convert.ToInt32(reader.GetValue(0)),
                    age = reader.GetValue(1).ToString(),
                });
            }
            con.Close();
            return series;
        }
    }
}
