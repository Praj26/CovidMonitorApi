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
    public class MonthGraphController : ApiController
    {
        string connectionstring = ConfigurationManager.ConnectionStrings["connectionString"].ToString();

        // GET api/monthgraph
        [HttpGet]
        public List<MonthGraph> GetAll()
        {  
            List<MonthGraph> series = new List<MonthGraph>();
            SqlConnection con = new SqlConnection(connectionstring);
            string sqlquery = "Select Count(*),month from Patient Group By month";
            con.Open();
            SqlCommand sqlCommand = new SqlCommand(sqlquery, con);
            SqlDataReader reader = sqlCommand.ExecuteReader();
            while (reader.Read())
            {
                series.Add(new MonthGraph
                {
                    caseCount = Convert.ToInt32(reader.GetValue(0)),
                    month = reader.GetValue(1).ToString(),
                });
            }
            con.Close();
            return series;
        }  
    }
}
