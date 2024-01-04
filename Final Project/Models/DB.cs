using Microsoft.AspNetCore.Authorization.Infrastructure;
using System.Data;
using System.Data.SqlClient;


namespace Final_Project.Models
{
      
    public class DB
    {
        public SqlConnection con {  get; set; }
        public DB() {
            string conStr = "Data Source=Eng_Ziad;Initial Catalog=Project202;Integrated Security=True";
            con = new SqlConnection(conStr);       
        
        }
        public  string id {  get; set; }
        


        public object getRole(string E_ID, string Password) {
        object Reader = null;
        DataTable dt = new DataTable();
            id = E_ID;

            string Query = $"select E.Role from Employee E where E.E_ID ='{E_ID}' and E.Password ='{Password}'";
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(Query, con);
                Reader = cmd.ExecuteScalar();
            }
            catch (SqlException ex)
            {
                Console.Write(ex);
            }
            finally { con.Close();
            }
            
            return Reader;
        }
        public object getName()
        {
            object Reader = null;
            DataTable dt = new DataTable();

            string Query = $"select E.UserName from Employee E where E.E_ID ='{id}' ";
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(Query, con);
                Reader = cmd.ExecuteScalar();
            }
            catch (SqlException ex)
            {
                Console.Write(ex);
            }
            finally
            {
                con.Close();
            }

            return Reader;
        }

        public DataTable TestingQuery(string Q)
        {
            DataTable dt = new DataTable();

            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(Q, con);
                dt.Load(cmd.ExecuteReader());
                
                
            }
            catch (SqlException ex)
            {
                

            }
            finally
            {
                con.Close();
            }
            return dt;
        }


        public object addEmployee(string E_ID, int SSN,string E_Mail,string userName,string Password,string phoneNumber,string Role)
        {
            object Reader = null;
            DataTable dt = new DataTable();

            string Query = $"INSERT INTO Employee    (E_ID, SSN, Email, UserName, Password, Phone_Number, Role)\r\n                        values('{E_ID}',{SSN},'{E_Mail}','{userName}','{Password}','{phoneNumber}','{Role}')";
            Console.WriteLine("THE QUERY\n"+Query,"\n");
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(Query, con);
                Reader = cmd.ExecuteScalar();
            }
            catch (SqlException ex)
            {
                Console.Write(ex);
            }
            finally
            {
                con.Close();
            }

            return Reader;
        }
        public object updateEmployee(string E_ID, int SSN, string E_Mail, string userName, string Password, string phoneNumber, string Role)
        {
            object Reader = null;
            DataTable dt = new DataTable();

            string Query = $"update Employee set\r\n                    SSN={SSN},\r\n                    Email='{E_Mail}',\r\n                    UserName='{userName}',\r\n                    Password='{Password}',\r\n                    Phone_Number={phoneNumber},\r\n                    Role='{Role}'\r\nwhere E_ID='{E_ID}'";
            Console.WriteLine("THE QUERY\n" + Query, "\n");
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(Query, con);
                Reader = cmd.ExecuteScalar();
            }
            catch (SqlException ex)
            {
                Console.Write(ex);
            }
            finally
            {
                con.Close();
            }

            return Reader;
        }

        public object getJob()
        {
            object Reader = null;
            DataTable dt = new DataTable();

            string Query = "select Job_ID , RECEIVED_DATE , State ,ETA from job";
            Console.WriteLine("THE QUERY\n" + Query, "\n");
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(Query, con);
                Reader = cmd.ExecuteReader();
            }
            catch (SqlException ex)
            {
                Console.Write(ex);
            }
            finally
            {
                con.Close();
            }

            return Reader;
        }




    }
}
