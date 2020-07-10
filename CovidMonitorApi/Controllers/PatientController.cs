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
    [EnableCors( origins: "http://localhost:4200", headers: "*" , methods : "*")]
    public class PatientController : ApiController
    {
        string connectionstring = "Server = DESKTOP-HKSUM9R; initial catalog = CovidMonitor; Integrated Security = True; ";
        
        // GET api/patient
        [HttpGet]
        public List<Patient> GetAll()     
        {
            //return listEmp.First(e => e.ID == id);  
            List<Patient> patientList = new List<Patient>();
            SqlConnection con = new SqlConnection(connectionstring);
            string sqlquery = "Select * from Patient";
            con.Open();
            SqlCommand sqlCommand = new SqlCommand(sqlquery, con);
            SqlDataReader reader = sqlCommand.ExecuteReader();
            while(reader.Read())
            {
                patientList.Add(new Patient
                {
                    Id = Convert.ToInt32(reader.GetValue(0)),
                    Name = reader.GetValue(1).ToString(),
                    Address = reader.GetValue(2).ToString(),
                    Age = Convert.ToInt32(reader.GetValue(3)),
                    City = reader.GetValue(4).ToString(),
                    Num_Of_Fam = Convert.ToInt32(reader.GetValue(5)),
                    Status = Convert.ToInt32(reader.GetValue(6)),
                    Month = reader.GetValue(7).ToString(),
                });
            }
            con.Close();
            return patientList;
        }

        // GET api/patient/id
        [HttpGet]
        public List<Patient> Get(int id)
        { 
            List<Patient> patient = new List<Patient>();
            SqlConnection con = new SqlConnection(connectionstring);
            string sqlquery = "Select * from Patient where Id = " + id;
            con.Open();
            SqlCommand sqlCommand = new SqlCommand(sqlquery, con);
            SqlDataReader reader = sqlCommand.ExecuteReader();
            while (reader.Read())
            {
                patient.Add(new Patient
                {
                    Id = Convert.ToInt32(reader.GetValue(0)),
                    Name = reader.GetValue(1).ToString(),
                    Address = reader.GetValue(2).ToString(),
                    Age = Convert.ToInt32(reader.GetValue(3)),
                    City = reader.GetValue(4).ToString(),
                    Num_Of_Fam = Convert.ToInt32(reader.GetValue(5)),
                    Status = Convert.ToInt32(reader.GetValue(6)),
                    Month = reader.GetValue(7).ToString(),
                });
            }
            con.Close();
            return patient;
        }

        // POST api/patient
        public void Post(Patient patient)
        {
            List<Patient> patientList = new List<Patient>();
            SqlConnection con = new SqlConnection(connectionstring);
            con.Open();
            string sqlquery = "INSERT INTO Patient (Name,Address,Age,City,Num_Of_Families,Status,Month)" +
                               "VALUES(@param1,@param2,@param3,@param4,@param5,@param6,@param7)";

            SqlCommand sqlCommand = new SqlCommand(sqlquery, con);
            sqlCommand.Parameters.AddWithValue("@param1", patient.Name);
            sqlCommand.Parameters.AddWithValue("@param2", patient.Address);
            sqlCommand.Parameters.AddWithValue("@param4", patient.Age);
            sqlCommand.Parameters.AddWithValue("@param3", patient.City);
            sqlCommand.Parameters.AddWithValue("@param5", patient.Num_Of_Fam);
            sqlCommand.Parameters.AddWithValue("@param6", patient.Status);
            sqlCommand.Parameters.AddWithValue("@param7", patient.Month);

            sqlCommand.ExecuteNonQuery();
        }

        // PUT api/patient/id
        public void Put(int id, Patient patient)
        {
            SqlConnection con = new SqlConnection(connectionstring);
            con.Open();
            string sqlquery = "UPDATE INTO Patient (Name,Address,Age,City,Num_Of_Fam,Status,Month) +" +
                               "VALUES(@param1,@param2,@param3,@param4,@param5,@param6,@param7)";

            SqlCommand sqlCommand = new SqlCommand(sqlquery, con);
            sqlCommand.Parameters.AddWithValue("@param1", patient.Name);
            sqlCommand.Parameters.AddWithValue("@param2", patient.Address);
            sqlCommand.Parameters.AddWithValue("@param4", patient.Age);
            sqlCommand.Parameters.AddWithValue("@param3", patient.City);
            sqlCommand.Parameters.AddWithValue("@param5", patient.Num_Of_Fam);
            sqlCommand.Parameters.AddWithValue("@param6", patient.Status);
            sqlCommand.Parameters.AddWithValue("@param7", patient.Month);

            sqlCommand.ExecuteNonQuery();
        }

        // DELETE api/patient/id
        public void Delete(int id)
        {
            SqlConnection con = new SqlConnection(connectionstring);
            string sqlquery = "Delete From Patient where Id=" + id;
            con.Open();
            SqlCommand sqlCommand = new SqlCommand(sqlquery, con);
            sqlCommand.ExecuteNonQuery();
            con.Close();
        }
    }
}
