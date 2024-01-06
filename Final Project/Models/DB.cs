using Microsoft.AspNetCore.Authorization.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;
using System.Data;
using System.Data.SqlClient;


namespace Final_Project.Models
{

    public class DB
    {
        public SqlConnection con { get; set; }
        public DB()
        {
            string conStr = "Data Source=HOZIEN-DELL-G15\\SQLEXPRESS;Initial Catalog=ERP_SYS;Integrated Security=True;Encrypt=False";
            con = new SqlConnection(conStr);

        }
        public string id { get; set; }

        public List<string> Job_ID { get; set; } = new List<string>();
        public List<string> Recieved_Date { get; set; } = new List<string>();
        public List<string> State { get; set; } = new List<string>();
        public List<string> ETA { get; set; } = new List<string>();
        public List<string> End_Date { get; set; } = new List<string>();

        [BindProperty]
        public string confirmJob { get; set; }
        [BindProperty]
        public string endJobInput { get; set; }

        public List<string> Customer_ID { get; set; } = new List<string>();
        public List<string> Email { get; set; } = new List<string>();
        public List<string> Bank_Account { get; set; } = new List<string>();

        public List<string> P_O_ID { get; set; } = new List<string>();
        public List<string> Purchasing_state { get; set; } = new List<string>();
        public List<string> Payment_ID { get; set; } = new List<string>();
        public List<string> E_ID { get; set; } = new List<string>();
        public List<string> Supplies_ID { get; set; } = new List<string>();

        public object getRole(string E_ID, string Password)
        {
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
            finally
            {
                con.Close();
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


        public object addEmployee(string E_ID, int SSN, string E_Mail, string userName, string Password, string phoneNumber, string Role)
        {
            object Reader = null;
            DataTable dt = new DataTable();

            string Query = $"INSERT INTO Employee    (E_ID, SSN, Email, UserName, Password, Phone_Number, Role)\r\n                        values('{E_ID}',{SSN},'{E_Mail}','{userName}','{Password}','{phoneNumber}','{Role}')";
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



        public object updateState(string job_ID)
        {
            object Reader = null;
            DataTable dt = new DataTable();

            string Query = $"update Job set State = 'In Progress' where Job_ID='{job_ID}'";
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

        /*public void getJob(List<string> Job_ID, List<string> Recieved_Date, List<string> State, List<string> ETA, List<string> End_Date)
        {
            DateTime currentDate = DateTime.Now;
            DateTime currentDateOnly = currentDate.Date;
            string ConString = "Data Source=Eng_Ziad;Initial Catalog=ERP_SYS;Integrated Security=True";

            using (SqlConnection con = new SqlConnection(ConString))
            {
                string querystring = $"select Job_ID , RECEIVED_DATE ,End_Date , State ,ETA from Job\n";

                con.Open();

                using (SqlCommand cmd = new SqlCommand(querystring, con))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        try
                        {

                            while (reader.Read())
                            {
                                Job_ID.Add(reader[0].ToString());
                                Recieved_Date.Add(reader[1].ToString());
                                End_Date.Add(reader[2].ToString());
                                State.Add(reader[3].ToString());
                                ETA.Add(reader[4].ToString());


                            }

                        }
                        catch (SqlException ex)
                        {
                            Console.WriteLine(ex.ToString());

                        }
                    }
                }


            }
        }*/

        public void getCustomer(List<string> Customer_ID, List<string> Email, List<string> Bank_Account)
        {
            DateTime currentDate = DateTime.Now;
            DateTime currentDateOnly = currentDate.Date;
            string ConString = "Data Source=HOZIEN-DELL-G15\\SQLEXPRESS;Initial Catalog=ERP_SYS;Integrated Security=True;Encrypt=False";

            using (SqlConnection con = new SqlConnection(ConString))
            {
                string querystring = $"select Customer_ID , Email , Bank_Account from Customer\n";

                con.Open();

                using (SqlCommand cmd = new SqlCommand(querystring, con))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        try
                        {

                            while (reader.Read())
                            {
                                Customer_ID.Add(reader[0].ToString());
                                Email.Add(reader[1].ToString());
                                Bank_Account.Add(reader[2].ToString());
                            }
                        }
                        catch (SqlException ex)
                        {
                            Console.WriteLine(ex.ToString());

                        }
                    }
                }
            }
        }

        public void getPurchasing_Order(List<string> P_O_ID, List<string> Purchasing_state, List<string> Payment_ID, List<string> E_ID, List<string> Supplies_ID)
        {
            DateTime currentDate = DateTime.Now;
            DateTime currentDateOnly = currentDate.Date;
            string ConString = "Data Source=HOZIEN-DELL-G15\\SQLEXPRESS;Initial Catalog=ERP_SYS;Integrated Security=True;Encrypt=False";

            using (SqlConnection con = new SqlConnection(ConString))
            {
                string querystring = $"select * from Purchasing_Order\n";

                con.Open();

                using (SqlCommand cmd = new SqlCommand(querystring, con))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        try
                        {

                            while (reader.Read())
                            {
                                P_O_ID.Add(reader[0].ToString());
                                Purchasing_state.Add(reader[1].ToString());
                                Payment_ID.Add(reader[2].ToString());
                                E_ID.Add(reader[3].ToString());
                                Supplies_ID.Add(reader[4].ToString());
                            }
                        }
                        catch (SqlException ex)
                        {
                            Console.WriteLine(ex.ToString());

                        }
                    }
                }
            }
        }




    }
}
