using Final_Project.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data;
using System.Data.SqlClient;


namespace Final_Project.Pages
{


    public class jobsModel : PageModel
    {

        private readonly ILogger<jobsModel>
            _logger;
        private readonly DB db;
        public jobsModel(ILogger<jobsModel>
            logger, DB db)
        {
            _logger = logger;
            this.db = db;
        }

        public List<string> Job_ID { get; set; } = new List<string>();
        public List<string> Recieved_Date { get; set; } = new List<string>();
        public List<string> State { get; set; } = new List<string>();
        public List<string> ETA { get; set; } = new List<string>();
        public List<string> End_Date { get; set; } = new List<string>();

        public List<string> P_ID { get; set; } = new List<string>();
        public List<string> S_O_ID { get; set; } = new List<string>();


        [BindProperty]
        public string confirmJob { get; set; }
        [BindProperty]
        public string endJobInput { get; set; }
        public string endJob()
        {
            DateTime currentDate = DateTime.Now;

            // Print the current date and time
           

            // Extract and print the current date only
            DateTime currentDateOnly = currentDate.Date;
            Console.WriteLine(endJobInput);
            string ConString = "Data Source=HOZIEN-DELL-G15\\SQLEXPRESS;Initial Catalog=ERP_SYS;Integrated Security=True;Encrypt=False";

            using (SqlConnection con = new SqlConnection(ConString))
            {
                string querystring = $"update Job set State = 'Done' where Job_ID = '{endJobInput}' and State='In Progress'\nUPDATE Sales_Orders SET State = 'Done' WHERE S_O_ID = (SELECT S_O_ID FROM Job WHERE Job_ID = '{endJobInput}');"
                    + $"update Job set End_Date='{currentDate}'where Job_ID='{endJobInput}'";
                con.Open();

                using (SqlCommand cmd = new SqlCommand(querystring, con))
                {
                    try
                    {
                        int rowsAffected = cmd.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            return "DONE UPDATING";
                        }
                        else
                        {
                            return "No rows were updated.";
                        }
                    }
                    catch (SqlException ex)
                    {
                        _logger.LogError(ex, "Error updating data in the database.");

                        return "Error updating data in the database.";
                    }
                }
            }
        }
        public string UpdateState(string job_ID)
        {
            Console.WriteLine(job_ID);
            string ConString = "Data Source=HOZIEN-DELL-G15\\SQLEXPRESS;Initial Catalog=ERP_SYS;Integrated Security=True;Encrypt=False";

            using (SqlConnection con = new SqlConnection(ConString))
            {
                string querystring = $"UPDATE Job SET State = 'In Progress' WHERE Job_ID = '{confirmJob}'";
                con.Open();

                using (SqlCommand cmd = new SqlCommand(querystring, con))
                {
                    try
                    {
                        int rowsAffected = cmd.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            return "DONE UPDATING";
                        }
                        else
                        {
                            return "No rows were updated.";
                        }
                    }
                    catch (SqlException ex)
                    {
                        _logger.LogError(ex, "Error updating data in the database.");

                        return "Error updating data in the database.";
                    }
                }
            }
        }


        public void OnPost()
        {


        }

        public void OnGet()
        {
            db.getJob(Job_ID,Recieved_Date, State, ETA, End_Date);
        }


    }
}
