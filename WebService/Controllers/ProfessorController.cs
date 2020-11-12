using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebService.Models;

namespace WebService.Controllers
{
    public class ProfessorController : ApiController
    {
        // GET: service/Professor
        public HttpResponseMessage GET()
        {
            DataTable table = new DataTable();

            string query = @"

                    SELECT ProfessorID,ProfessorName,ProfessorSurname,ProfessorSubject,convert(varchar(10),Date_Time,120) as Date_Time

                    FROM dbo.ProfessorDB";

            using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["StudentAppDB"].ConnectionString))
            using (var cmd = new SqlCommand(query, con))
            using (var da = new SqlDataAdapter(cmd))


            {
                cmd.CommandType = CommandType.Text;
                da.Fill(table);

            }


            return Request.CreateResponse(HttpStatusCode.OK, table);

        }


        // POST: service/Professor

        public string POST(Professor professor)
        {
            try

            {
                
                DataTable table = new DataTable();

                string query = @"

                          INSERT INTO dbo.ProfessorDB (ProfessorName,ProfessorSurname,ProfessorSubject,Date_Time)

                          VALUES

                           ('" + professor.ProfessorName + @"'
                           ,'" + professor.ProfessorSurname + @"'
                           ,'" + professor.ProfessorSubject + @"'
                           ,'" + professor.Date_Time.ToString("yyyy-MM-dd  HH:mm:ss") + @"'
                            
                           )";



                using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["StudentAppDB"].ConnectionString))
                using (var cmd = new SqlCommand(query, con))
                using (var da = new SqlDataAdapter(cmd))


                {

                    cmd.CommandType = CommandType.Text;
                    
                    da.Fill(table);
                }

                return "Record Inserted Successfully!";

            }

            catch (Exception ex)
            {

                return "Error while inserting record!";

            }
        }
        

        // PUT: service/Professor

        public string PUT(Professor professor)
        {
            try

            {

                DataTable table = new DataTable();

                string query = @"

                      UPDATE dbo.ProfessorDB SET ProfessorName = '" + professor.ProfessorName + @"'
                                              ,ProfessorSurname = '" + professor.ProfessorSurname + @"'
                                              ,ProfessorSubject = '" + professor.ProfessorSubject + @"'
                                              ,Date_Time ='" + professor.Date_Time.ToString("yyyy-MM-dd  HH:mm:ss") + @"'
                  
                     
                                              WHERE ProfessorID = " + professor.ProfessorID + @"


                                               ";


                using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["StudentAppDB"].ConnectionString))
                using (var cmd = new SqlCommand(query, con))
                using (var da = new SqlDataAdapter(cmd))

                {

                    cmd.CommandType = CommandType.Text;
                    da.Fill(table);

                }

                return "Record Update Successfully!";

            }

            catch (Exception)


            {

                return "Error while updating record!";

            }
        }

        // DELETE: service/Professor

        public string DELETE(int ID)
        {
            try

            {
                DataTable table = new DataTable();

                string query = @"

                      DELETE FROM dbo.ProfessorDB WHERE ProfessorID =" + ID;

                using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["StudentAppDB"].ConnectionString))
                using (var cmd = new SqlCommand(query, con))
                using (var da = new SqlDataAdapter(cmd))

                {

                    cmd.CommandType = CommandType.Text;
                    da.Fill(table);

                }

                return "Record Delete Successfully!";

            }

            catch (Exception)

            {

                return "Error while deleting record!";
            }
        }

    }


}
