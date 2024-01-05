using Final_Project.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data;
using System.Data.SqlClient;


namespace Final_Project.Pages
{


    public class jobsModel : PageModel
    {

        private readonly ILogger<jobsModel> _logger;

        public jobsModel(ILogger<jobsModel> logger)
        {
            _logger = logger;
        }
        public DataTable dt { get; set; }

        public List<string> Job_ID { get; set; } = new List<string>();
        public List<string> Recieved_Date { get; set; } = new List<string>();
        public List<string> State { get; set; } = new List<string>();
        public List<string> ETA { get; set; } = new List<string>();





        public string UpdateState(string job_ID)
        {
            Console.WriteLine(job_ID);
            string ConString = "Data Source=DESKTOP-S23QDQL;Initial Catalog=project202;Integrated Security=True;Encrypt=False";

            using (SqlConnection con = new SqlConnection(ConString))
            {
                string querystring = $"UPDATE job SET State = 'In Progress' WHERE Job_ID = '{job_ID}'";
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
            string ConString = "Data Source=DESKTOP-S23QDQL;Initial Catalog=project202;Integrated Security=True;Encrypt=False";

            using (SqlConnection con = new SqlConnection(ConString))
            {
                string querystring = "select Job_ID , RECEIVED_DATE , State ,ETA from job";
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
                                State.Add(reader[2].ToString());
                                ETA.Add(reader[3].ToString());


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
