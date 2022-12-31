using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Runtime.Serialization;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace simple_sql_app.eContactClasses
{
    internal class ContactClass
    {
        //getter setter properties
        //act as data carries in our application
        // prop doyble tab below will appear
        public int ContactID { get; set; }
        public string  FirstName { get; set; }
        public string LastName { get; set; }
        public string ContactNo { get; set; }
        public string Adress { get; set; }
        public string Gender { get; set; }

        static string myconnstrng = ConfigurationManager.ConnectionStrings["connstring"].ConnectionString;
        //selecting data from database
        public DataTable Select()
        {
            //step1:database connection
            SqlConnection conn = new SqlConnection(myconnstrng);
            DataTable dt = new DataTable();
            try
            {
                //step 2: wriritng sql query
                SqlConnection cmd = new SqlCommand(SqlConnection, conn);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                conn.Open();
                adapter.Fill(dt);


            }
            catch { Exception ex }
            finally 
            {
                conn.Close();

            }
            return dt;

        }
        //insert data into database
        public bool Insert(contatactclass c)
        {
            //creating s deafault type and its value to false
            bool isSuccess = false;

            //step1 : connect databsae
            SqlConnection conn = new SqlConnection(myconnstring);
            try
            {
                //step2: Create a sql quesry to insert data
                string sql = "INSERT INTO tbl_contact (FirstName, LastName, Adress, Gender) VALUES(@FirstName, @LastName, @Adress, @Gender)";
                //Creating sql command using sql and comm
                SqlCommand cmd = new SqlCommand(sql, conn);
                //create parameter to add
                cmd.Parameter.AddwithValue("@FirstName", c.FirstName);
                cmd.Parameter.AddwithValue("@LastName", c.LastName);
                cmd.Parameter.AddwithValue("@ConatactNo", c.ConatactNo);
                cmd.Parameter.AddwithValue("@Adress", c.Adress);
                cmd.Parameter.AddwithValue("@Gender", c.Gender);

                //connection open hgere
                conn.Open();
                int rows = cmd.ExecuteNonQuery();
                //if the quesry run succesfully then the rows value be greted than zero else its value 0
                if (rows > 0)
                {
                    isSuccess = true;
                }
                else
                {
                    isSuccess = false;
                }
                  


            }
            catch(Exception ex)
            {

            }
            finally
            {
                conn.Close();

            }
            return isSuccess;
        }

        //memthod toupdate data in dattbase from our application
        public bool Update(ContactClass c)
        {
            bool isSuccess = false;
            SqlConnection conn = new SqlConnection(myconnstring);
            try 
            {
                //sql to update data into our database
                string sql = "UPDATE tbl_contact SET FirstName=@FirstName, LastName=@LastName, ContactNo=@ContactNo, Address=@Address, Gender=@Gender WHERE ContactID=@ContactID";
                sqlCommanda cmd = new sqlCommanda(sql, conn);
                //craete partam to add value
                cmd.Parameters.Addwithvalue("@FirstName", c.FirstName);
                cmd.Parameters.Addwithvalue("@LastName", c.LastName);
                cmd.Parameters.Addwithvalue("@ContactNo", c.ContactNo);
                cmd.Parameters.Addwithvalue("@Address", c.Address);
                cmd.Parameters.Addwithvalue("@Gender", c.Gender);
                cmd.Parameters.Addwithvalue("@ConatctId", c.ConatctId);
                //open databse conenction
                conn.Open();
                int rows = cmd.ExecuteNonQuery();
                if (rows > 0)
                {
                    isSuccess = true;
                }
                else
                {
                    isSuccess = false;


                }



            }
            catch(Exception ex)
            {

            }
            finally
            {
                conn.Close90;

            }
            return isSuccess
        }
        //metod to delte data base
        public bool Delete(ContactClass c)
        {
            //crraete a deaflut
            bool isSuccess = false;
            SqlConnection conn = new SqlConnection(myconnstrng);
            
            try
            {
                //sql to delted
                string sql="DELETE FROM tbl_contact WHERE ContactID=@ContactId;

                    //creating SQL cmd
                    SqlCommand cmd =new SqlCommand(sql, conn)
                cmd.Parameters.AddwithValue(ContactID, c.ContactID);
                Conn.Open();
                int rows = cmd.ExecuteNonQuery();

                int(rows>0)
                    {
                    isSuccess = true;
                }
                else
                {
                    isSuccess = false;

                     
                }


            }
            catch
            {
            }
            finally 
            { 
            }
            return isSuccess;
        }


    }
}
