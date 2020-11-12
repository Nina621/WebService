using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebService.Models;

namespace WebService.Controllers
{
    public class StudentController : ApiController
    {
        // GET: service/Student
        public HttpResponseMessage Get()
        {
            DataTable table = new DataTable();

            string query = @"
            SELECT StudentID,StudentJMBAG,StudentName,StudentSurname,StudentGender,StudentCity,StudentDirection,YearOfCollage
            FROM dbo.StudentDB";

            using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["StudentAppDB"].ConnectionString))
            using (var cmd = new SqlCommand(query, con))
            using (var da = new SqlDataAdapter(cmd))
            {
                cmd.CommandType = CommandType.Text;
                da.Fill(table);
            }
            return Request.CreateResponse(HttpStatusCode.OK, table);
        }



        // POST: service/Student
        public string POST(Student student)
        {
            try
            {
                DataTable table = new DataTable();
                string query = @"

                          INSERT INTO dbo.StudentDB (StudentJMBAG,StudentName,StudentSurname,StudentGender,StudentCity,StudentDirection,YearOfCollage)

                          VALUES

                           ('" + student.StudentJMBAG + @"'
                           ,'" + student.StudentName + @"'
                           ,'" + student.StudentSurname + @"'
                           ,'" + student.StudentGender + @"'
                           ,'" + student.StudentCity + @"'
                           ,'" + student.StudentDirection + @"'
                           ,'" + student.YearOfCollage + @"'
                                
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



        // PUT: service/Student

        public string PUT(Student student)
        {

            try

            {
                DataTable table = new DataTable();

                string query = @"

                      UPDATE dbo.StudentDB SET StudentJMBAG = '" + student.StudentJMBAG + @"'
                                             ,StudentName = '" + student.StudentName + @"'
                                             ,StudentSurname = '" + student.StudentSurname + @"'
                                             ,StudentGender = '" + student.StudentGender + @"'
                                             ,StudentCity = '" + student.StudentCity + @"'
                                             ,StudentDirection = '" + student.StudentDirection + @"'
                                             ,YearOfCollage = '" + student.YearOfCollage + @"'
                     
                                             WHERE StudentID = " + student.StudentID + @"

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



        // DELETE: service/Student

        public string DELETE(int ID)
        {
            try

            {
                DataTable table = new DataTable();

                string query = @"

                      DELETE FROM dbo.StudentDB WHERE StudentID =" + ID;

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
