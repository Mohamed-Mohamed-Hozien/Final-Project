using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;
namespace Final_Project.Pages
{
    public class addAndPropertiesModel : PageModel
    {
        private readonly ILogger<addAndPropertiesModel> _logger;

        public addAndPropertiesModel(ILogger<addAndPropertiesModel> logger)
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

        public int OID { get; set; }

        string ConString = "Data Source=Eng_Ziad;Initial Catalog=ERP_SYS;Integrated Security=True";



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

            currentID = "S_O" + OID.ToString("D3");



        }

        

        public void OnGet()
        {
           


        }
       
        

        public string getNewOrder()
        {
            
            Console.WriteLine("ooooo" + insertedPaymentID + insertedCID + insertedEID);
            getHighstOrder();

            Console.WriteLine(currentID + "getNew is running");
            string queryString = $"INSERT INTO Sales_Orders (S_O_ID, State, Customer_ID,E_ID,Payment_ID) VALUES ('{currentID}','Received','{insertedCID}','{insertedEID}','{insertedPaymentID}')";
            //Console.WriteLine(queryString);

            using (SqlConnection con = new SqlConnection(ConString))
            {
                con.Open();
                using (SqlCommand command = new SqlCommand(queryString, con))
                {





                    try
                    {
                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            Console.WriteLine("DONE");
                            return "Done";

                        }
                        else
                        {
                            Console.WriteLine("Fsil");
                            return "Fail";
                        }
                    }
                    catch (SqlException ex)
                    {
                        Console.WriteLine($"Error: {ex.Message}");
                        return "Error" + ex.Message;
                    }
                }
            }


        }
    }
}
