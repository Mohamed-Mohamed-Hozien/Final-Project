using Azure;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel;
using System.Data.SqlClient;
namespace Final_Project.Pages
{
    public class Sales_OrderModel : PageModel
    {
        private readonly ILogger<Sales_OrderModel> _logger;

        public Sales_OrderModel(ILogger<Sales_OrderModel> logger)
        {
            _logger = logger;
        }

        [BindProperty]
        public List<string> C_ID { get; set; } = new List<string>();
        [BindProperty]
        public List<string> E_ID { get; set; } = new List<string>();
        [BindProperty]
        public List<string> state { get; set; } = new List<string>();
        [BindProperty]
        public List<string> O_ID { get; set; } = new List<string>();
        [BindProperty]
        public string insertedPaymentID { get; set; }
        [BindProperty]
        public string insertedCID { get; set; }
        [BindProperty]
        public string insertedPID { get; set; }
        [BindProperty]
        public string insertedEID { get; set; }

        public string currentID { get; set; }

        public string prCurrentID {  get; set; }

        public string currentJobID { get; set; }

        [BindProperty]
        public string confirmedOrderID { get; set; }
        [BindProperty]
       
        public int POID {  get; set; }
        
        public int OID { get; set; }

        public int JID { get; set; }

        [BindProperty]
        public int DeliverOrderID { get; set; }

        string ConString = "Data Source=Eng_Ziad;Initial Catalog=ERP_SYS;Integrated Security=True";

        public void getPreviousID()
            
        {
            getHighstOrder();
            
            POID = int.Parse(currentID.Replace("S_O", ""));

            POID -= 1;
            prCurrentID = "S_O" + POID.ToString("D3");

        }
        
        public string confirmOrder()
        {
            
;            using (SqlConnection con = new SqlConnection(ConString))
            {
                DateTime currentDate = DateTime.Now;

                // Print the current date and time

                TimeSpan currentTimeOnly = currentDate.TimeOfDay;
                string formattedTime = currentTimeOnly.ToString(@"hh\:mm");
                // Extract and print the current date only
                DateTime currentDateOnly = currentDate.Date;
                string querystring = $"update Sales_Orders set State='In Progress' where S_O_ID='{confirmedOrderID}' and State='Received'\n";
                    /*$"update job set State='Received' where job.Order_ID='{confirmedOrderID}'"+
                $"update job set RECEIVED_DATE='{currentDate}' where job.Order_ID='{confirmedOrderID}'";*/


                con.Open();

                using (SqlCommand cmd = new SqlCommand(querystring, con))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        try
                        {

                            while (reader.Read())
                            {
                                


                            }

                        }
                        catch (SqlException ex)
                        {
                            _logger.LogError(ex, "Error reading data from the database.");

                        }
                    }
                }

                


            }
            addJob();
            return "l";

        }


        




        public void getHighstJob()
        {
            using (SqlConnection con = new SqlConnection(ConString))
            {
                string querystring = "SELECT MAX(Job_ID) AS Highest_Job_ID FROM Job;";
                con.Open();

                using (SqlCommand cmd = new SqlCommand(querystring, con))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        try
                        {

                            while (reader.Read())
                            {
                                currentJobID = reader[0].ToString();


                            }

                        }
                        catch (SqlException ex)
                        {
                            _logger.LogError(ex, "Error reading data from the database.");

                        }
                    }
                }


            }
            JID = int.Parse(currentJobID.Replace("J", ""));
            JID += 1;

            currentJobID = "J" + JID.ToString("D3");



        }

       


        public void getHighstOrder()
        {
            using (SqlConnection con = new SqlConnection(ConString))
            {
                string querystring = "SELECT MAX(S_O_ID) AS Highest_Order_ID FROM Sales_Orders;";
                con.Open();

                using (SqlCommand cmd = new SqlCommand(querystring, con))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        try
                        {

                            while (reader.Read())
                            {
                                currentID = reader[0].ToString();


                            }

                        }
                        catch (SqlException ex)
                        {
                            _logger.LogError(ex, "Error reading data from the database.");

                        }
                    }
                }


            }
            OID = int.Parse(currentID.Replace("S_O", ""));
            OID += 1;
            
            currentID="S_O" + OID.ToString("D3");



        }
        
        public void getOrders()
        {
            

            using (SqlConnection con = new SqlConnection(ConString))
            {
                string querystring = "select S_O_ID , State , Customer_ID ,E_ID from Sales_Orders";
                con.Open();

                using (SqlCommand cmd = new SqlCommand(querystring, con))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        try
                        {

                            while (reader.Read())
                            {
                                O_ID.Add(reader[0].ToString());
                                state.Add(reader[1].ToString());
                                C_ID.Add(reader[2].ToString());
                                E_ID.Add(reader[3].ToString());


                            }

                        }
                        catch (SqlException ex)
                        {
                            _logger.LogError(ex, "Error reading data from the database.");

                        }
                    }
                }


            }
        }
        
        public void OnGet()
        {
            getOrders();

            //Console.WriteLine(currentID);//
            
            

        }
        
        
        

        public void OnPost()
        {
            confirmOrder();
            
            
            





        }

        public void addJob()
        {
            getHighstJob();
            DateTime currentDate = DateTime.Now;

            // Print the current date and time

            TimeSpan currentTimeOnly = currentDate.TimeOfDay;
            string formattedTime = currentTimeOnly.ToString(@"hh\:mm");
            // Extract and print the current date only
            DateTime currentDateOnly = currentDate.Date;
            getPreviousID();

            string qu = $"INSERT INTO Job (Job_ID, RECEIVED_DATE, State, End_Date, ETA, Supplies_ID, P_ID, S_O_ID)\r\nVALUES ('{currentJobID}', '{currentDate}', 'Received', '{currentDate}', '{formattedTime}', 'S021', 'PR025', '{prCurrentID}'); UPDATE Sales_Orders SET State = 'In Progress' WHERE S_O_ID = '{prCurrentID}' AND State = 'Received';";
            using (SqlConnection con = new SqlConnection(ConString))
            {
                /*$"update job set State='Received' where job.Order_ID='{confirmedOrderID}'"+
            $"update job set RECEIVED_DATE='{currentDate}' where job.Order_ID='{confirmedOrderID}'";*/


                con.Open();

                using (SqlCommand cmd = new SqlCommand(qu, con))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        try
                        {

                            while (reader.Read())
                            {



                            }

                        }
                        catch (SqlException ex)
                        {
                            _logger.LogError(ex, "Error reading data from the database.");

                        }
                    }
                }




            }
        }
    }

}
