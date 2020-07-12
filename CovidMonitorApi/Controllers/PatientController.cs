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
    public class PatientController : ApiController
    {
        string connectionstring = ConfigurationManager.ConnectionStrings["connectionString"].ToString();
        // GET api/patient
        [HttpGet]
        public List<Patient> GetAll()     
        {
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
        [HttpPost]
        public IHttpActionResult Post(Patient patient)
        {
            try 
            { 
                SqlConnection con = new SqlConnection(connectionstring);
                con.Open();
                string sqlquery = "INSERT INTO Patient (Name,Address,Age,City,Num_Of_Families,Status,Month)" +
                                   "VALUES(@param1,@param2,@param3,@param4,@param5,@param6,@param7)";

                SqlCommand sqlCommand = new SqlCommand(sqlquery, con);

                (sqlCommand.Parameters.Add("@param1", SqlDbType.VarChar)).Value = patient.Name.ToString();
                (sqlCommand.Parameters.Add("@param2", SqlDbType.VarChar)).Value = patient.Address.ToString();
                (sqlCommand.Parameters.Add("@param3", SqlDbType.Int)).Value = Convert.ToInt32(patient.Age);
                (sqlCommand.Parameters.Add("@param4", SqlDbType.NChar)).Value = patient.City.ToString();
                (sqlCommand.Parameters.Add("@param5", SqlDbType.Int)).Value = Convert.ToInt32(patient.Num_Of_Fam);
                (sqlCommand.Parameters.Add("@param6", SqlDbType.Int)).Value = Convert.ToInt32(patient.Status);
                (sqlCommand.Parameters.Add("@param7", SqlDbType.NChar)).Value = patient.Month.ToString();

                sqlCommand.ExecuteNonQuery();
                con.Close();
            }
            catch(Exception ex)
            {
                return StatusCode(HttpStatusCode.InternalServerError);
            }       
            return StatusCode(HttpStatusCode.OK);

        }

        // PUT api/patient/id
        public IHttpActionResult Put(int id, Patient patient)
        {
            try
            {
                SqlConnection con = new SqlConnection(connectionstring);
                con.Open();
                string sqlquery = "UPDATE Patient SET " +
                                  "Name = @param1,Address = @param2,Age = @param3,City = @param4," +
                                  "Num_Of_Families = @param5,Status = @param6,Month = @param7 " +
                                  "Where Id = " + id;
                SqlCommand sqlCommand = new SqlCommand(sqlquery, con);
                sqlCommand.Parameters.AddWithValue("@param1", patient.Name);
                sqlCommand.Parameters.AddWithValue("@param2", patient.Address);
                sqlCommand.Parameters.AddWithValue("@param3", patient.Age);
                sqlCommand.Parameters.AddWithValue("@param4", patient.City);
                sqlCommand.Parameters.AddWithValue("@param5", patient.Num_Of_Fam);
                sqlCommand.Parameters.AddWithValue("@param6", patient.Status);
                sqlCommand.Parameters.AddWithValue("@param7", patient.Month);
                sqlCommand.ExecuteNonQuery();
                con.Close();
            }
            catch(Exception ex)
            {
                return StatusCode(HttpStatusCode.InternalServerError);
            }
            return StatusCode(HttpStatusCode.OK);

        }

        // DELETE api/patient/id
        public IHttpActionResult Delete(int id)
        {
            try 
            { 
                SqlConnection con = new SqlConnection(connectionstring);
                string sqlquery = "Delete From Patient where Id=" + id;
                con.Open();
                SqlCommand sqlCommand = new SqlCommand(sqlquery, con);
                sqlCommand.ExecuteNonQuery();
                con.Close();
            }
            catch(Exception ex)
            {
                return StatusCode(HttpStatusCode.InternalServerError);
            }
                return StatusCode(HttpStatusCode.OK);
            }
        }
}
